// Decompiled with JetBrains decompiler
// Type: XUtliPoolLib.XFileLog
// Assembly: XUtliPoolLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D0B5E37-6957-4C11-AC8A-5F5BE652A435
// Assembly location: F:\龙之谷\Client\Assets\Lib\XUtliPoolLib.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

namespace XUtliPoolLib
{
    public class XFileLog : MonoBehaviour
    {
        private static Queue<string> CustomLogQueue = new Queue<string>();
        private const int QUEUE_SIZE = 20;
        public static string RoleName = "";
        public static uint RoleLevel = 0;
        public static int RoleProf = 0;
        public static string ServerID = "";
        public static string OpenID = "";
        public static uint SceneID = 0;
        private static Application.LogCallback callBack = (Application.LogCallback)null;
        private string _outpath;
        public bool _logOpen = true;
        private bool _firstWrite = true;
        private string _guiLog = "";
        private bool _showGuiLog = false;
        private GUIStyle fontStyle = (GUIStyle)null;
        public static string debugStr = "0";
        public static bool _OpenCustomBtn = false;
        public static bool _debugTrigger = true;
        private Vector2 scrollPosition;
        private bool _showCustomInfo = false;
        public static bool _logBundleOpen = false;
        public static string _customInfo = "";
        public static int _customInfoHeight = 0;

        private void Start()
        {
            this._outpath = Application.persistentDataPath + string.Format("/{0}{1}{2}_{3}{4}{5}.log", (object)DateTime.Now.Year.ToString().PadLeft(2, '0'), (object)DateTime.Now.Month.ToString().PadLeft(2, '0'), (object)DateTime.Now.Day.ToString().PadLeft(2, '0'), (object)DateTime.Now.Hour.ToString().PadLeft(2, '0'), (object)DateTime.Now.Minute.ToString().PadLeft(2, '0'), (object)DateTime.Now.Second.ToString().PadLeft(2, '0'));
            string path = Application.platform == RuntimePlatform.IPhonePlayer ? "/private" + Application.persistentDataPath : Application.persistentDataPath;
            if (Directory.Exists(path))
            {
                FileInfo[] files = new DirectoryInfo(path).GetFiles();
                if (files != null)
                {
                    for (int index = 0; index < files.Length; ++index)
                    {
                        if (!(files[index].Name.Substring(files[index].Name.LastIndexOf(".") + 1) != "log"))
                        {
                            if (DateTime.Now.Subtract(files[index].CreationTime).TotalDays > 1.0)
                            {
                                try
                                {
                                    files[index].Delete();
                                }
                                catch
                                {
                                    XSingleton<XDebug>.singleton.AddErrorLog("Del Log File Error!!!");
                                }
                            }
                        }
                    }
                }
            }
            XFileLog.callBack = new Application.LogCallback(this.HandleLog);
            Application.logMessageReceived += XFileLog.callBack;
            XSingleton<XDebug>.singleton.AddLog(this._outpath);
        }

        public void HandleLog(string logString, string stackTrace, LogType type)
        {
            if (!this._firstWrite)
                return;
            if (this._logOpen)
                this.WriterLog(logString);
            if (type != LogType.Error && type != LogType.Exception)
                return;
            this._firstWrite = false;
            this.Log((object)logString);
            this.Log((object)stackTrace);
            string logstring = string.Format("{0}\n{1}\n", (object)logString, (object)stackTrace);
            while (XFileLog.CustomLogQueue.Count > 0)
                logstring = string.Format("{0}\n{1}", (object)logstring, (object)XFileLog.CustomLogQueue.Dequeue());
            this.SendBuglyReport(logstring);
            this._guiLog = logstring;
            this._showGuiLog = true;
        }

        private void OnGUI()
        {
            if (XFileLog._logBundleOpen && (UnityEngine.Object)XSingleton<XUpdater.XUpdater>.singleton.ABManager != (UnityEngine.Object)null)
                GUI.TextArea(new Rect(0.0f, 30f, 100f, 30f), XSingleton<XUpdater.XUpdater>.singleton.ABManager.BundleCount.ToString());
            if (this.fontStyle == null)
                this.fontStyle = new GUIStyle();
            if (this._showGuiLog)
            {
                if (GUI.Button(new Rect(0.0f, 0.0f, 100f, 30f), "CrashLog"))
                    this._showGuiLog = !this._showGuiLog;
                if (this._showGuiLog)
                {
                    this.fontStyle.normal.textColor = new Color(1f, 0.0f, 0.0f);
                    this.fontStyle.fontSize = 14;
                    this.fontStyle.normal.background = Texture2D.whiteTexture;
                    GUI.TextArea(new Rect(0.0f, 40f, 1136f, 3200f), this._guiLog, this.fontStyle);
                }
            }
            if (Input.GetKey(KeyCode.F5))
                XFileLog._OpenCustomBtn = !XFileLog._OpenCustomBtn;
            if (XFileLog._OpenCustomBtn && GUI.Button(new Rect(250f, 0.0f, 150f, 50f), "Info"))
                this._showCustomInfo = !this._showCustomInfo;
            if (!this._showCustomInfo)
                return;
            this.fontStyle.normal.textColor = new Color(0.0f, 0.0f, 0.0f);
            this.fontStyle.fontSize = 16;
            this.fontStyle.normal.background = Texture2D.whiteTexture;
            this.scrollPosition = GUI.BeginScrollView(new Rect(0.0f, 30f, 1136f, 640f), this.scrollPosition, new Rect(0.0f, 30f, 1136f, (float)(XFileLog._customInfoHeight * (this.fontStyle.fontSize + 2) + 100)));
            GUI.Label(new Rect(0.0f, 30f, 1136f, (float)(XFileLog._customInfoHeight * (this.fontStyle.fontSize + 2) + 30)), XFileLog._customInfo, this.fontStyle);
            GUI.EndScrollView();
        }

        public void WriterLog(string logString)
        {
            using (StreamWriter streamWriter1 = new StreamWriter(this._outpath, true, Encoding.UTF8))
            {
                StreamWriter streamWriter2 = streamWriter1;
                object[] objArray = new object[7];
                DateTime now = DateTime.Now;
                objArray[0] = (object)now.Year;
                now = DateTime.Now;
                int num = now.Month;
                objArray[1] = (object)num.ToString().PadLeft(2, '0');
                now = DateTime.Now;
                num = now.Day;
                objArray[2] = (object)num.ToString().PadLeft(2, '0');
                now = DateTime.Now;
                num = now.Hour;
                objArray[3] = (object)num.ToString().PadLeft(2, '0');
                now = DateTime.Now;
                num = now.Minute;
                objArray[4] = (object)num.ToString().PadLeft(2, '0');
                now = DateTime.Now;
                num = now.Second;
                objArray[5] = (object)num.ToString().PadLeft(2, '0');
                now = DateTime.Now;
                num = now.Millisecond;
                objArray[6] = (object)num.ToString().PadLeft(3, '0');
                string str = string.Format("[{0}]{1}", (object)string.Format("{0}/{1}/{2} {3}:{4}:{5}.{6}", objArray), (object)logString);
                streamWriter2.WriteLine(str);
                XSingleton<XUpdater.XUpdater>.singleton.XPlatform.SetNoBackupFlag(this._outpath);
            }
        }

        private void Update()
        {
        }

        public void Log(params object[] objs)
        {
            string logString = "";
            for (int index = 0; index < objs.Length; ++index)
                logString = index != 0 ? logString + ", " + objs[index].ToString() : logString + objs[index].ToString();
            this.WriterLog(logString);
        }

        public void SendBuglyReport(string logstring)
        {
            if (Application.platform == RuntimePlatform.WindowsEditor || (uint)Application.platform <= 0U)
                return;
            (XUpdater.XUpdater.XGameRoot.GetComponent("XBuglyMgr") as IXBuglyMgr).ReportCrashToBugly(XFileLog.ServerID, XFileLog.RoleName, XFileLog.RoleLevel, XFileLog.RoleProf, XFileLog.OpenID, XSingleton<XUpdater.XUpdater>.singleton.Version, Time.realtimeSinceStartup.ToString(), "loaded", XFileLog.SceneID.ToString(), logstring);
        }

        public static void AddCustomLog(string customLog)
        {
            XFileLog.CustomLogQueue.Enqueue(customLog);
            while (XFileLog.CustomLogQueue.Count > 20)
                XFileLog.CustomLogQueue.Dequeue();
        }
    }
}
