/*
*
* Copyright (C) 2011-2014 Wang Shiliang
* All rights reserved
* filename : Record.cs
* description : This is the class for Recording
* created by Wang Shiliang at 6/1/2011 11:30:50
*
*/
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;
using Microsoft.DirectX.DirectSound;
using Microsoft.DirectX;

namespace ToeflSpeaking
{
    class RecordS
    {
        public const int mNotifyNum = 16;           
        private int mNextCaptureOffset = 0;         
        private int mSampleCount = 0;               
        private int mNotifySize = 0;                
        private int mBufferSize = 0;                
        private string mFileName = string.Empty;    
        private FileStream mWaveFile = null;        
        private BinaryWriter mWriter = null;        
        private Capture mCapDev = null;             
        private CaptureBuffer mRecBuffer = null;    
        private Notify mNotify = null;              
        private WaveFormat mWavFormat;                       
        private Thread mNotifyThread = null;                 
        private AutoResetEvent mNotificationEvent = null;    
        private int flag = 0;


        public RecordS()
        {
            InitCaptureDevice();
            mWavFormat = CreateWaveFormat();
        }

        public void SetFileName(string filename)
        {
            mFileName = filename;
        }

        public string getFileName()
        {
            return mFileName;
        }

        public void RecStart()
        {
            flag = 1;
            CreateSoundFile();
            CreateCaptureBuffer();
            InitNotifications();
            mRecBuffer.Start(true);
        }

        public void RecStop()
        {
            if (null != mNotificationEvent)
                mNotificationEvent.Set();

            flag = 0;
            mRecBuffer.Stop();
            RecordCapturedData();
            mWriter.Seek(4, SeekOrigin.Begin);
            mWriter.Write((int)(mSampleCount + 36));  
            mWriter.Seek(40, SeekOrigin.Begin);
            mWriter.Write(mSampleCount);                
            mWriter.Close();
            mWaveFile.Close();
            mWriter = null;
            mWaveFile = null;
            
        }

        private bool InitCaptureDevice()
        {
            CaptureDevicesCollection devices = new CaptureDevicesCollection();  
            Guid deviceGuid = Guid.Empty;                                       
            if (devices.Count > 0)
            {
                deviceGuid = devices[0].DriverGuid;
            }
            else
            {
                MessageBox.Show("系统中没有音频捕捉设备", "Warning");
                return false;
            }
            try
            {
                mCapDev = new Capture(deviceGuid);
            }
            catch (DirectXException e)
            {
                MessageBox.Show(e.ToString(), "Warning");
                return false;
            }
            return true;
        }

        private WaveFormat CreateWaveFormat()
        {
            WaveFormat format = new WaveFormat();
            format.FormatTag = WaveFormatTag.Pcm;   
            format.SamplesPerSecond = 22050;        
            format.BitsPerSample = 16;              
            format.Channels = 1;                    
            format.BlockAlign = (short)(format.Channels * (format.BitsPerSample / 8));      
            format.AverageBytesPerSecond = format.BlockAlign * format.SamplesPerSecond;
            return format;
        }

        private void CreateCaptureBuffer()
        {
            CaptureBufferDescription bufferdescription = new CaptureBufferDescription();

            if (null != mNotify)
            {
                mNotify.Dispose();
                mNotify = null;
            }

            if (null != mRecBuffer)
            {
                mRecBuffer.Dispose();
                mRecBuffer = null;
            }

            mNotifySize = (1024 > mWavFormat.AverageBytesPerSecond / 8) ? 1024 : (mWavFormat.AverageBytesPerSecond / 8);
            mNotifySize -= mNotifySize % mWavFormat.BlockAlign;
            mBufferSize = mNotifySize * mNotifyNum;
            bufferdescription.BufferBytes = mBufferSize;
            bufferdescription.Format = mWavFormat;           
            mRecBuffer = new CaptureBuffer(bufferdescription, mCapDev);
            mNextCaptureOffset = 0;
        }

        private bool InitNotifications()
        {
            if (null == mRecBuffer)
            {
                MessageBox.Show("未创建录音缓冲区", "Warning");
                return false;             
            }
            
            mNotificationEvent = new AutoResetEvent(false);
            if (null == mNotifyThread)
            {
                mNotifyThread = new Thread(new ThreadStart(WaitThread));
                mNotifyThread.Start();
            }

            BufferPositionNotify[] PositionNotify = new BufferPositionNotify[mNotifyNum];

            for (int i = 0; i < mNotifyNum; i++)
            {
                PositionNotify[i].Offset = (mNotifySize * i) + mNotifySize - 1;
                PositionNotify[i].EventNotifyHandle = mNotificationEvent.Handle;
            }

            mNotify = new Notify(mRecBuffer);
            mNotify.SetNotificationPositions(PositionNotify, mNotifyNum);
            return true;
        }

        private void RecordCapturedData()
        {
            byte[] CaptureData = null;
            int ReadPos;

            int CapturePos;
            int LockSize;

            mRecBuffer.GetCurrentPosition(out CapturePos, out ReadPos);
            LockSize = ReadPos - mNextCaptureOffset;
            if (LockSize < 0)
                LockSize += mBufferSize;

            LockSize -= (LockSize % mNotifySize);

            if (0 == LockSize)
                return;

            CaptureData = (byte[])mRecBuffer.Read(mNextCaptureOffset, typeof(byte), LockFlag.None, LockSize);

            mWriter.Write(CaptureData, 0, CaptureData.Length);

            mSampleCount += CaptureData.Length;

            mNextCaptureOffset += CaptureData.Length;
            mNextCaptureOffset %= mBufferSize; // Circular buffer
        }

        private void WaitThread()
        {
            while (true&&flag==1)
            {
                mNotificationEvent.WaitOne(Timeout.Infinite, true);
                RecordCapturedData();
            }
        }

        private void CreateSoundFile()      
        {
            /**************************************************************************
            Here is where the file will be created. A
            wave file is a RIFF file, which has chunks
            of data that describe what the file contains.
            A wave RIFF file is put together like this:
            The 12 byte RIFF chunk is constructed like this:
            Bytes 0 - 3 : 'R' 'I' 'F' 'F'
            Bytes 4 - 7 : Length of file, minus the first 8 bytes of the RIFF description.
                               (4 bytes for "WAVE" + 24 bytes for format chunk length +
                               8 bytes for data chunk description + actual sample data size.)
            Bytes 8 - 11: 'W' 'A' 'V' 'E'
            The 24 byte FORMAT chunk is constructed like this:
            Bytes 0 - 3 : 'f' 'm' 't' ' '
            Bytes 4 - 7 : The format chunk length. This is always 16.
            Bytes 8 - 9 : File padding. Always 1.
            Bytes 10- 11: Number of channels. Either 1 for mono, or 2 for stereo.
            Bytes 12- 15: Sample rate.
            Bytes 16- 19: Number of bytes per second.
            Bytes 20- 21: Bytes per sample. 1 for 8 bit mono, 2 for 8 bit stereo or
                              16 bit mono, 4 for 16 bit stereo.
            Bytes 22- 23: Number of bits per sample.
            The DATA chunk is constructed like this:
            Bytes 0 - 3 : 'd' 'a' 't' 'a'
            Bytes 4 - 7 : Length of data, in bytes.
            Bytes 8 -...: Actual sample data.
            ***************************************************************************/

            Directory.CreateDirectory(Path.GetDirectoryName(mFileName));
            // Open up the wave file for writing.
            mWaveFile = new FileStream(mFileName, FileMode.Create);
            mWriter = new BinaryWriter(mWaveFile);

            // Set up file with RIFF chunk info.
            char[] ChunkRiff = { 'R', 'I', 'F', 'F' };
            char[] ChunkType = { 'W', 'A', 'V', 'E' };
            char[] ChunkFmt  = { 'f', 'm', 't', ' ' };
            char[] ChunkData = { 'd', 'a', 't', 'a' };

            short shPad = 1;                    // File padding
            int nFormatChunkLength = 0x10;      // Format chunk length.
            int nLength = 0;                    // File length, minus first 8 bytes of RIFF description. This will be filled in later.
            short shBytesPerSample = 0;         // Bytes per sample.

            if (8 == mWavFormat.BitsPerSample && 1 == mWavFormat.Channels)
                shBytesPerSample = 1;
            else if ((8 == mWavFormat.BitsPerSample && 2 == mWavFormat.Channels) || (16 == mWavFormat.BitsPerSample && 1 == mWavFormat.Channels))
                shBytesPerSample = 2;
            else if (16 == mWavFormat.BitsPerSample && 2 == mWavFormat.Channels)
                shBytesPerSample = 4;

            mWriter.Write(ChunkRiff);
            mWriter.Write(nLength);
            mWriter.Write(ChunkType);
            mWriter.Write(ChunkFmt);
            mWriter.Write(nFormatChunkLength);
            mWriter.Write(shPad);
            mWriter.Write(mWavFormat.Channels);
            mWriter.Write(mWavFormat.SamplesPerSecond);
            mWriter.Write(mWavFormat.AverageBytesPerSecond);
            mWriter.Write(shBytesPerSample);
            mWriter.Write(mWavFormat.BitsPerSample);
            
            mWriter.Write(ChunkData);
            mWriter.Write((int)0);   // The sample length will be written in later.
        }
    }
}
