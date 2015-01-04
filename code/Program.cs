using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
/*
*
* Copyright (C) 2011-2014 Wang Shiliang
* All rights reserved
* filename : Program.cs
* description : This is the main entrance of the whole program
* created by Wang Shiliang at 5/31/2011 18:29:20
*
*/
namespace ToeflPractice
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SplashScreen());
        }
    }
}
