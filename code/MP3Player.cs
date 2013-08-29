/*
*
* Copyright (C) 2011-2014 Wang Shiliang
* All rights reserved
* filename : MP3Player.cs
* description : This is the MP3Player class for playing the .mp3 file.
* created by Wang Shiliang at 6/1/2011 15:19:50
*
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace ToeflSpeaking  
{  
public class MP3Player  
{  
     /// <summary>  
      /// 文件地址

      /// </summary>  
      public string FilePath = "";  

      /// <summary>  
      /// 播放  
      /// </summary>  
      public void Play()  
      {  
          mciSendString("close all", "", 0, 0);  
          mciSendString("open " + FilePath + " alias media", "",0, 0);  
          mciSendString("play media", "", 0, 0);  
      }  

      /// <summary>  
      /// 暂停  
      /// </summary>  
      public void Pause()  
      {  
          mciSendString("pause media", "", 0, 0);  
      }  

      /// <summary>  
      /// 停止  
      /// </summary>  
      public void Stop()  
      {  
          mciSendString("close media", "", 0, 0);  
      }  

      /// <summary>  
      /// API函数  
      /// </summary>  
      [DllImport("winmm.dll", EntryPoint = "mciSendString", CharSet = CharSet.Auto)]  
      private static extern int mciSendString(  
       string lpstrCommand,  
       string lpstrReturnString,  
       int uReturnLength,  
       int hwndCallback  
      );  
  }  
}