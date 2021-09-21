// Decompiled with JetBrains decompiler
// Type: XUpdater.XDownloader
// Assembly: XUtliPoolLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D0B5E37-6957-4C11-AC8A-5F5BE652A435
// Assembly location: F:\龙之谷\Client\Assets\Lib\XUtliPoolLib.dll

using System.Collections;
using System.Text;
using UnityEngine;
using XUtliPoolLib;

namespace XUpdater
{
    public sealed class XDownloader : MonoBehaviour
    {
        private StringBuilder _log = new StringBuilder();
        private WWW _downloader = (WWW)null;
        private bool _download = true;
        private uint _token = 0;
        private float _total_percent = 0.0f;
        private string _current_name = (string)null;
        private XTimerMgr.ElapsedEventHandler _progressCb = (XTimerMgr.ElapsedEventHandler)null;

        private void Awake() => this._progressCb = new XTimerMgr.ElapsedEventHandler(this.Progress);

        internal void GetBundle(
          XBundleData bundle,
          string url,
          HandleBundleDownload callback1,
          HandleFetchBundle callback2,
          float percent)
        {
            this._download = url.Contains("?token=");
            this._current_name = bundle.Name;
            this._total_percent = percent;
            this.StartCoroutine(this.Download(bundle, url, callback1, callback2));
        }

        public void GetMeta(
          string url,
          string name,
          XDownloader.HandleBytesDownload callback,
          float percent)
        {
            this._download = true;
            this._current_name = name;
            this._total_percent = percent;
            this.StartCoroutine(this.MetaDownload(url, callback));
        }

        public void GetBytes(string url, XDownloader.HandleBytesDownload callback) => this.StartCoroutine(this.BytesDownload(url, callback));

        private IEnumerator MetaDownload(
          string url,
          XDownloader.HandleBytesDownload callback)
        {
            XSingleton<XTimerMgr>.singleton.KillTimer(this._token);
            this._token = XSingleton<XTimerMgr>.singleton.SetTimer(0.1f, this._progressCb, (object)null);
            this._downloader = new WWW(url);
            yield return (object)this._downloader;
            XSingleton<XTimerMgr>.singleton.KillTimer(this._token);
            this.Progress((object)null);
            XSingleton<XTimerMgr>.singleton.KillTimer(this._token);
            if (callback != null)
                callback(this._downloader, this._downloader.error);
            this._downloader.Dispose();
            this._downloader = (WWW)null;
        }

        private IEnumerator BytesDownload(
          string url,
          XDownloader.HandleBytesDownload callback)
        {
            WWW www = new WWW(url);
            yield return (object)www;
            if (callback != null)
                callback(www, www.error);
            www.Dispose();
            www = (WWW)null;
        }

        private IEnumerator Download(
          XBundleData bundle,
          string url,
          HandleBundleDownload callback1,
          HandleFetchBundle callback2)
        {
            XSingleton<XTimerMgr>.singleton.KillTimer(this._token);
            this._token = XSingleton<XTimerMgr>.singleton.SetTimer(0.1f, this._progressCb, (object)null);
            this._downloader = new WWW(url);
            yield return (object)this._downloader;
            XSingleton<XTimerMgr>.singleton.KillTimer(this._token);
            this.Progress((object)null);
            XSingleton<XTimerMgr>.singleton.KillTimer(this._token);
            bool error = false;
            if (callback1 != null)
            {
                AsyncWriteRequest awr = callback1(this._downloader, bundle, this._downloader.error);
                while (!awr.IsDone)
                {
                    if (awr.HasError)
                    {
                        error = true;
                        break;
                    }
                    yield return (object)null;
                }
                XSingleton<XUpdater>.singleton.XPlatform.SetNoBackupFlag(awr.Location);
                awr = (AsyncWriteRequest)null;
            }
            if (error)
            {
                this._log.Length = 0;
                this._log.AppendFormat(XSingleton<XStringTable>.singleton.GetString("XUPDATE_ERROR_DOWNLOADRESFAILED"), (object)bundle.Name);
                XSingleton<XLoadingUI>.singleton.SetStatus(this._log.ToString());
            }
            else if (callback2 != null)
                callback2(this._downloader, this._downloader.bytes, bundle, this._download);
            this._downloader = (WWW)null;
        }

        private void Progress(object o)
        {
            this._log.Remove(0, this._log.Length);
            int num = Mathf.FloorToInt(this._total_percent * 100f);
            if (this._download)
                this._log.AppendFormat(XSingleton<XStringTable>.singleton.GetString("XUPDATE_INFO_DOWNLOADING"), (object)num);
            else
                this._log.AppendFormat(XSingleton<XStringTable>.singleton.GetString("XUPDATE_INFO_EXTRACTING"), (object)num);
            XSingleton<XLoadingUI>.singleton.SetStatus(this._log.ToString());
            this._token = XSingleton<XTimerMgr>.singleton.SetTimer(0.1f, this._progressCb, o);
        }

        public delegate void HandleBytesDownload(WWW www, string error);
    }
}
