/*
*
* Copyright (C) 2011-2014 Wang Shiliang
* All rights reserved
* filename : SqlConnect.cs
* description : This file is for connecting to the sql database
* created by Shiliang Wang at 6/1/2011 21:19:50
*
*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace ToeflSpeaking
{
    class SQLiteDatabase
    {
        private String dbConnection;

        public SQLiteDatabase(String inputFile)
        {
            dbConnection = String.Format("data source={0}; Version=3;", inputFile);
        }

        public DataSet GetDataSet(string sql)
        {
            DataSet ds = new DataSet();
            try
            {
                SQLiteDataAdapter da = new SQLiteDataAdapter(sql, dbConnection);
                da.Fill(ds);
            }
            catch (SQLiteException e)
            {
                throw new Exception(e.Message);
            }
            return ds;
        }

        //read the data from the database,return the array of string
        public String[] getReaderString(String sql, String[] type, int number)
        {
            SQLiteConnection cnn = new SQLiteConnection(dbConnection);
            cnn.Open();
            SQLiteCommand mycommand = new SQLiteCommand(sql, cnn);
            SQLiteDataReader reader = mycommand.ExecuteReader();
            reader.Read();
            String[] stringArray = new String[10];
            for (int i = 0; i != number; ++i)
            {
                if (type[i].Equals("int"))
                {
                    stringArray[i] = reader.GetInt32(i).ToString();
                }
                else if (type[i].Equals("string"))
                {
                    stringArray[i] = reader.GetValue(i).ToString();
                }
            }
            reader.Close();
            return stringArray;
        }

        public int ExecuteNonQuery(string sql)
        {
            SQLiteConnection cnn = new SQLiteConnection(dbConnection);
            cnn.Open();
            SQLiteCommand mycommand = new SQLiteCommand(cnn);
            mycommand.CommandText = sql;
            int rowsUpdated = mycommand.ExecuteNonQuery();
            cnn.Close();
            return rowsUpdated;
        }  

        public string ExecuteScalar(string sql)
        {
            SQLiteConnection cnn = new SQLiteConnection(dbConnection);
            cnn.Open();
            SQLiteCommand mycommand = new SQLiteCommand(cnn);
            mycommand.CommandText = sql;
            object value = mycommand.ExecuteScalar();
            cnn.Close();
            if (value != null)
            {
                return value.ToString();
            }
            return "";
        }
    }
}
