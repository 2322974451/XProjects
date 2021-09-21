// Decompiled with JetBrains decompiler
// Type: XUpdater.XVersion
// Assembly: XUtliPoolLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D0B5E37-6957-4C11-AC8A-5F5BE652A435
// Assembly location: F:\龙之谷\Client\Assets\Lib\XUtliPoolLib.dll

using System.Collections;
using System.IO;
using System.Threading;
using UnityEngine;
using XUtliPoolLib;

namespace XUpdater
{
    internal sealed class XVersion : MonoBehaviour
    {
        public static readonly string LOCAL_VERSION_FILE = "manifest.asset";
        private WWW _server_Version = (WWW)null;
        private uint _time_out_token = 0;

        public static string VERSION_FILE => string.Format("manifest.{0}.assetbundle", (object)XSingleton<XUpdater>.singleton.TargetVersion.ToString());

        public static string GetLocalVersion() => XSingleton<XCaching>.singleton.UpdatePath + XVersion.LOCAL_VERSION_FILE;

        public void ServerDownload(HandleVersionDownload callback1, HandleVersionLoaded callback2)
        {
            this.StopAllCoroutines();
            string log2 = XSingleton<XCaching>.singleton.HostUrl + XSingleton<XUpdater>.singleton.Platform;
            XSingleton<XLoadingUI>.singleton.SetStatus(XSingleton<XStringTable>.singleton.GetString("XUPDATE_INFO_CONNECTING"));
            XSingleton<XDebug>.singleton.AddLog("connecting to update server: ", log2);
            this._time_out_token = XSingleton<XTimerMgr>.singleton.SetTimer(5f, new XTimerMgr.ElapsedEventHandler(this.OnTimeOut), (object)null);
            this.StartCoroutine(this.DownloadVersion(XSingleton<XCaching>.singleton.MakeToken(log2 + XVersion.VERSION_FILE), callback1, callback2));
        }

        private IEnumerator DownloadVersion(
          string url,
          HandleVersionDownload callback1,
          HandleVersionLoaded callback2)
        {
            this._server_Version = new WWW(url);
            yield return (object)this._server_Version;
            XSingleton<XLoadingUI>.singleton.SetStatus(XSingleton<XStringTable>.singleton.GetString("XUPDATE_INFO_CHECKUPDATING"));
            XSingleton<XTimerMgr>.singleton.KillTimer(this._time_out_token);
            if (this._server_Version != null)
            {
                if (string.IsNullOrEmpty(this._server_Version.error))
                {
                    if (callback1 != null)
                    {
                        AssetBundle ab = this._server_Version.assetBundle;
                        if ((Object)ab == (Object)null)
                        {
                            XSingleton<XDebug>.singleton.AddErrorLog("load server manifest bundle error.");
                            XSingleton<XLoadingUI>.singleton.SetStatus(XSingleton<XStringTable>.singleton.GetString("XUPDATE_ERROR_FETCHMANIFESTERROR"));
                            XSingleton<XUpdater>.singleton.OnError();
                        }
                        else
                        {
                            Object asset = ab.LoadAsset("manifest", typeof(TextAsset));
                            if (asset == (Object)null)
                            {
                                XSingleton<XDebug>.singleton.AddErrorLog("load server manifest bundle error.");
                                XSingleton<XLoadingUI>.singleton.SetStatus(XSingleton<XStringTable>.singleton.GetString("XUPDATE_ERROR_FETCHMANIFESTERROR"));
                                XSingleton<XUpdater>.singleton.OnError();
                            }
                            else
                            {
                                AsyncVersionProcessRequest avpr = callback1(asset as TextAsset);
                                while (!avpr.IsDone)
                                    Thread.Sleep(1);
                                if (callback2 != null)
                                    callback2(avpr.IsCorrect);
                                ab.Unload(false);
                                avpr = (AsyncVersionProcessRequest)null;
                            }
                            asset = (Object)null;
                        }
                        ab = (AssetBundle)null;
                    }
                }
                else if (XUpdater.LaunchMode == XLaunchMode.Dev)
                {
                    XSingleton<XUpdater>.singleton.DevStart();
                }
                else
                {
                    XSingleton<XDebug>.singleton.AddErrorLog(this._server_Version.error);
                    XSingleton<XLoadingUI>.singleton.SetStatus(XSingleton<XStringTable>.singleton.GetString("XUPDATE_ERROR_FETCHMANIFESTERROR"));
                    XSingleton<XUpdater>.singleton.OnError();
                }
                this._server_Version.Dispose();
                this._server_Version = (WWW)null;
            }
            else
            {
                XSingleton<XDebug>.singleton.AddErrorLog("ERROR: _server_Version is NULL!");
                XSingleton<XLoadingUI>.singleton.SetStatus(XSingleton<XStringTable>.singleton.GetString("XUPDATE_ERROR_FETCHMANIFESTERROR"));
                XSingleton<XUpdater>.singleton.OnError();
            }
        }

        private IEnumerator LocalDownload(XVersion.HandleFinishDownload callback)
        {
            string path = Application.persistentDataPath + XVersion.VERSION_FILE;
            if (!File.Exists(path))
            {
                if (callback != null)
                    callback((WWW)null, (string)null);
            }
            else
            {
                string local_location = "file://" + path;
                WWW localVersion = new WWW(local_location);
                yield return (object)localVersion;
                if (callback != null)
                    callback(localVersion, localVersion.error);
                localVersion.Dispose();
                localVersion = (WWW)null;
                local_location = (string)null;
                localVersion = (WWW)null;
            }
        }

        private void OnTimeOut(object o)
        {
            if (XUpdater.LaunchMode == XLaunchMode.Dev)
            {
                XSingleton<XUpdater>.singleton.DevStart();
                if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor)
                    XSingleton<XDebug>.singleton.AddErrorLog("Connect to update server timeout...");
            }
            else
            {
                XSingleton<XLoadingUI>.singleton.SetStatus(XSingleton<XStringTable>.singleton.GetString("XUPDATE_ERROR_CANNOTCONNECTTOSERVER"));
                XSingleton<XUpdater>.singleton.OnError();
            }
            this.StopAllCoroutines();
            this._server_Version.Dispose();
            this._server_Version = (WWW)null;
        }

        private delegate void HandleFinishDownload(WWW www, string error);
    }
}
