// Decompiled with JetBrains decompiler
// Type: XUpdater.XCaching
// Assembly: XUtliPoolLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D0B5E37-6957-4C11-AC8A-5F5BE652A435
// Assembly location: F:\龙之谷\Client\Assets\Lib\XUtliPoolLib.dll

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using UnityEngine;
using XUtliPoolLib;

namespace XUpdater
{
    public sealed class XCaching : XSingleton<XCaching>
    {
        private string _version_server = (string)null;
        private string _host_url = (string)null;
        internal static readonly string UPDATE_DIRECTORY = "/update/";
        private string _update_path = (string)null;
        private StringBuilder _log = new StringBuilder();
        private XDownloader _down_loader = (XDownloader)null;
        private MD5CryptoServiceProvider _md5Generator = (MD5CryptoServiceProvider)null;
        private AsyncExtractRequest _aer = (AsyncExtractRequest)null;
        private AsyncWriteRequest _meta_awr = (AsyncWriteRequest)null;

        public string VersionServer => this._version_server;

        public string HostUrl => this._host_url;

        public string UpdatePath => this._update_path;

        public XDownloader Downloader => this._down_loader;

        internal string GetLocalPath(XBundleData data) => string.Format("{0}{1}.assetbundle", (object)this._update_path, (object)data.Name);

        internal string GetLocalUrl(XBundleData data)
        {
            string log2 = string.Format("{0}{1}{2}.assetbundle", XSingleton<XUpdater>.singleton.RunTimePlatform != BuildTarget.Standalone ? (object)"file://" : (object)"file:///", (object)this._update_path, (object)data.Name);
            XSingleton<XDebug>.singleton.AddLog("LocalURL: ", log2);
            return log2;
        }

        public string GetLoginServerAddress(string loginType)
        {
            IPlatform xplatform = XSingleton<XUpdater>.singleton.XPlatform;
            return xplatform.GetHostWithHttpDns(xplatform.GetLoginServer(loginType));
        }

        internal string GetDownloadUrl(XBundleData data) => this.MakeToken(string.Format("{0}{1}/{2}.assetbundle", (object)this.HostUrl, (object)XSingleton<XUpdater>.singleton.Platform, (object)data.Name));

        internal string MakeToken(string url) => string.Format("{0}?token={1}", (object)url, (object)DateTime.Now.Ticks);

        public override bool Init()
        {
            IPlatform xplatform = XSingleton<XUpdater>.singleton.XPlatform;
            this._version_server = xplatform.GetHostWithHttpDns(xplatform.GetVersionServer());
            this._host_url = xplatform.GetHostUrl();
            this._md5Generator = new MD5CryptoServiceProvider();
            this._down_loader = XUpdater.XGameRoot.AddComponent<XDownloader>();
            this._update_path = Application.persistentDataPath + XCaching.UPDATE_DIRECTORY;
            return true;
        }

        internal bool EnableCache()
        {
            if (!Directory.Exists(this._update_path))
            {
                XSingleton<XDebug>.singleton.AddLog("Create new path " + this._update_path);
                try
                {
                    Directory.CreateDirectory(this._update_path);
                    return Directory.Exists(this._update_path);
                }
                catch (Exception ex)
                {
                    XSingleton<XDebug>.singleton.AddErrorLog(string.Format("Error ", (object)ex.Message));
                    return false;
                }
            }
            else
            {
                XSingleton<XDebug>.singleton.AddLog(string.Format("Path {0} exists.", (object)this._update_path));
                return true;
            }
        }

        internal AsyncCachedRequest IsBundleCached(XBundleData bundle, uint size)
        {
            string fullpath = this.GetLocalPath(bundle);
            AsyncCachedRequest req = new AsyncCachedRequest();
            if (bundle.Size < size)
            {
                new Thread((ThreadStart)(() =>
                {
                    if (File.Exists(fullpath))
                    {
                        req.Cached = this.CalculateMD5(this.LoadFile(fullpath)) == bundle.MD5;
                        req.MaybeCached = true;
                    }
                    req.IsDone = true;
                })).Start();
            }
            else
            {
                req.MaybeCached = File.Exists(fullpath);
                req.IsDone = true;
            }
            return req;
        }

        internal bool CleanCache()
        {
            string path = Application.platform == RuntimePlatform.IPhonePlayer ? "/private" + this._update_path : this._update_path;
            try
            {
                if (!Directory.Exists(path))
                    return true;
                new DirectoryInfo(path).Delete(true);
                return !Directory.Exists(path) && this.EnableCache();
            }
            catch (Exception ex)
            {
                XSingleton<XDebug>.singleton.AddErrorLog("CleanCache error: ", ex.Message);
                return false;
            }
        }

        internal byte[] LoadFile(string fullpath) => File.ReadAllBytes(fullpath);

        private AsyncReadRequest LoadFileAsync(string fullpath)
        {
            AsyncReadRequest arr = new AsyncReadRequest();
            new Thread((ThreadStart)(() =>
            {
                arr.bytes = File.ReadAllBytes(fullpath);
                arr.IsDone = true;
            })).Start();
            return arr;
        }

        internal void Download(XBundleData bundle, HandleFetchBundle callback, float percent) => this._down_loader.GetBundle(bundle, this.GetDownloadUrl(bundle), new HandleBundleDownload(this.OnBundleDownload), callback, percent);

        internal AsyncWriteRequest Download(string meta, uint size, float percent)
        {
            this._meta_awr = new AsyncWriteRequest();
            this._meta_awr.Size = size;
            this._meta_awr.Location = meta;
            this._meta_awr.Name = meta.Substring(meta.LastIndexOf('/') + 1);
            this._meta_awr.HasError = false;
            string name = meta.Substring(meta.LastIndexOf("/") + 1);
            meta = this.MakeToken(this.HostUrl + XSingleton<XUpdater>.singleton.Platform + meta);
            this._down_loader.GetMeta(meta, name, new XDownloader.HandleBytesDownload(this.OnMetaDownload), percent);
            return this._meta_awr;
        }

        internal bool Extract(XBundleData bundle, HandleFetchBundle callback, float percent)
        {
            if (Application.platform == RuntimePlatform.IPhonePlayer)
            {
                if (this._aer == null)
                {
                    this._aer = new AsyncExtractRequest();
                    new Thread((ThreadStart)(() =>
                    {
                        this._aer.Data = File.ReadAllBytes(this.GetLocalPath(bundle));
                        this._aer.IsDone = true;
                    })).Start();
                }
                if (!this._aer.IsDone)
                    return false;
                callback((WWW)null, this._aer.Data, bundle, false);
                this._aer.Data = (byte[])null;
                this._aer = (AsyncExtractRequest)null;
                return true;
            }
            this._down_loader.GetBundle(bundle, this.GetLocalUrl(bundle), (HandleBundleDownload)null, callback, percent);
            return true;
        }

        private void OnMetaDownload(WWW www, string error)
        {
            if (string.IsNullOrEmpty(error))
            {
                byte[] bs = www.bytes;
                new Thread((ThreadStart)(() =>
                {
                    try
                    {
                        if (XSingleton<XUpdater>.singleton.NeedCheckFile && Path.GetExtension(this._meta_awr.Location).Contains("ab") && (bs[0] != (byte)85 || bs[1] != (byte)110 || bs[2] != (byte)105 || bs[3] != (byte)116 || bs[4] != (byte)121 || bs[5] != (byte)70 || bs[6] != (byte)83))
                            throw new Exception("Meta head check failed.");
                        string str5 = Path.Combine(this._update_path, "AssetBundles");
                        string fileName = Path.GetFileName(this._meta_awr.Location);
                        if (!Directory.Exists(str5))
                            Directory.CreateDirectory(str5);
                        string str6 = Path.Combine(str5, fileName);
                        File.WriteAllBytes(str6, bs);
                        if (XSingleton<XUpdater>.singleton.NeedCheckFile)
                        {
                            Thread.Sleep(1);
                            if (!this.CheckFileSize(str6, (long)this._meta_awr.Size))
                                throw new Exception("Meta File size " + (object)this._meta_awr.Size + " not match.");
                            XSingleton<XUpdater>.singleton.XPlatform.SetNoBackupFlag(str6);
                            this._meta_awr.IsDone = true;
                        }
                        else
                        {
                            XSingleton<XUpdater>.singleton.XPlatform.SetNoBackupFlag(str6);
                            this._meta_awr.IsDone = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        this.OnDownloadFailed(ex.Message, this._meta_awr);
                    }
                })).Start();
            }
            else
                this.OnDownloadFailed(error, this._meta_awr);
        }

        private void OnDownloadFailed(string error, AsyncWriteRequest awr)
        {
            XSingleton<XDebug>.singleton.AddErrorLog("Download Meta ", awr.Name, " error: ", error);
            awr.HasError = true;
        }

        private AsyncWriteRequest OnBundleDownload(
          WWW www,
          XBundleData bundle,
          string error)
        {
            AsyncWriteRequest req = new AsyncWriteRequest();
            if (string.IsNullOrEmpty(error))
            {
                byte[] bs = www.bytes;
                new Thread((ThreadStart)(() =>
                {
                    req.Location = this.GetLocalPath(bundle);
                    try
                    {
                        File.WriteAllBytes(req.Location, bs);
                        req.IsDone = true;
                    }
                    catch (Exception ex)
                    {
                        this.OnDownloadFailed(ex.Message, req);
                    }
                })).Start();
            }
            else
                this.OnDownloadFailed(error, req);
            return req;
        }

        internal string CalculateMD5(byte[] bundle) => BitConverter.ToString(this._md5Generator.ComputeHash(bundle));

        internal string CalculateMD5(byte[] bundle, int offset, int count) => BitConverter.ToString(this._md5Generator.ComputeHash(bundle, offset, count));

        public bool CheckFileSize(string filePath, long fileSize)
        {
            try
            {
                if (!File.Exists(filePath))
                    return false;
                FileInfo fileInfo = new FileInfo(filePath);
                return fileSize == fileInfo.Length;
            }
            catch (Exception ex)
            {
                XSingleton<XDebug>.singleton.AddErrorLog("XCaching.CheckFileSize: " + ex.Message);
                return false;
            }
        }

        public override void Uninit()
        {
        }
    }
}
