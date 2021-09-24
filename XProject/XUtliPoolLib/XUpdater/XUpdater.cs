

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
using UnityEngine;
using XUtliPoolLib;

namespace XUpdater
{
    public sealed class XUpdater : XSingleton<XUpdater>
    {
        public static readonly uint Major_Version = 1;
        private static XLaunchMode _launch_mode = XLaunchMode.Live;
        public static GameObject XGameRoot = (GameObject)null;
        public static Assembly Ass = Assembly.GetAssembly(typeof(GameObject));
        public static int Md5Length = 16;
        private int _main_threadId = 0;
        private bool _bEditorMode = false;
        private bool _bFetchVersion = false;
        private bool _bFetchServer = false;
        private StringBuilder _log = new StringBuilder();
        private IEnumerator _downloader = (IEnumerator)null;
        private IEnumerator _download_prepare = (IEnumerator)null;
        private IEnumerator _comparer = (IEnumerator)null;
        private IEnumerator _launcher = (IEnumerator)null;
        private IEnumerator _finish = (IEnumerator)null;
        private byte[] _script = (byte[])null;
        private bool _on_file_download_retry = false;
        private bool _on_file_download_need_retry = false;
        private bool _update_done = false;
        private bool _bundle_fetching = false;
        private bool _asset_loading = false;
        private XVersion _version_getter = (XVersion)null;
        private XBundle _bundle_getter = (XBundle)null;
        private XFileLog _filelog_getter = (XFileLog)null;
        private IFMOD_Listener _fmod_listenter = (IFMOD_Listener)null;
        private ITssSdk _tssSdk = (ITssSdk)null;
        private IApolloManager _apolloManager = (IApolloManager)null;
        private IBroardcast _broadcast = (IBroardcast)null;
        private ILuaEngine _lua_engine = (ILuaEngine)null;
        private IXPandoraMgr _pandoraManager = (IXPandoraMgr)null;
        private IXGameSirControl _SirControl = (IXGameSirControl)null;
        private IXVideo _video = (IXVideo)null;
        private IPlatform _platform = (IPlatform)null;
        private BuildTarget _runtime_platform = BuildTarget.Unknown;
        private string _platform_name = "";
        private string _version = "0.0.0";
        private string _target_version = "0.0.0";
        private bool _need_check_file = false;
        private bool _need_play_cg = true;
        private XFetchVersionNetwork _fetch_version_network = (XFetchVersionNetwork)null;
        private float _fetch_version_time = 0.0f;
        private ulong _update_pakcage_size = 0;
        private XVersionData _server = (XVersionData)null;
        private XVersionData _client = (XVersionData)null;
        private XVersionData _buildin = (XVersionData)null;
        private IResourceHelp _resourcehelp = (IResourceHelp)null;
        private XBundleData _bundle_data = (XBundleData)null;
        private eUPdatePhase _phase = eUPdatePhase.xUP_None;
        private List<XBundleData> _download_bundle = new List<XBundleData>();
        private List<XBundleData> _cacheload_bundle = new List<XBundleData>();
        private List<XMetaResPackage> _meta_bundle = new List<XMetaResPackage>();
        private Dictionary<uint, UnityEngine.Object> _persist_assets = new Dictionary<uint, UnityEngine.Object>();
        private Dictionary<uint, byte[]> _persist_image = new Dictionary<uint, byte[]>();
        private Dictionary<uint, XBundleData> _assets = new Dictionary<uint, XBundleData>();
        private Dictionary<uint, XResPackage> _res_list = new Dictionary<uint, XResPackage>();
        private Dictionary<uint, AssetBundle> _bundles = new Dictionary<uint, AssetBundle>();
        public AssetBundleManager ABManager;
        private bool _is_download_update_pic = false;

        public static XLaunchMode LaunchMode => XUpdater._launch_mode;

        public bool EditorMode => this._bEditorMode;

        public string Version => this._version;

        public string TargetVersion => this._target_version;

        public bool NeedCheckFile => this._need_check_file;

        public BuildTarget RunTimePlatform => this._runtime_platform;

        public string Platform => this._platform_name;

        public IPlatform XPlatform => this._platform;

        public ILuaEngine XLuaEngine => this._lua_engine;

        public IApolloManager XApolloManager => this._apolloManager;

        public IBroardcast XBroadCast => this._broadcast;

        public ITssSdk XTssSdk => this._tssSdk;

        public IXPandoraMgr XPandoraManager => this._pandoraManager;

        public IXGameSirControl GameSirControl => this._SirControl;

        public IResourceHelp XResourceHelp => this._resourcehelp;

        public bool IsDone => this._update_done;

        internal eUPdatePhase Phase
        {
            set => this._phase = value;
        }

        public int ManagedThreadId => this._main_threadId;

        public bool Reboot { get; set; }

        public override bool Init()
        {
            this._main_threadId = Thread.CurrentThread.ManagedThreadId;
            this._bEditorMode = Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.WindowsPlayer;
            this.Reboot = false;
            XUpdater.XGameRoot = GameObject.Find("XGamePoint");
            this.GetLaunchMode();
            switch (Application.platform)
            {
                case RuntimePlatform.IPhonePlayer:
                    this._runtime_platform = BuildTarget.IOS;
                    this._platform_name = this.PatchPrefix() + "IOS/";
                    break;
                case RuntimePlatform.Android:
                    this._runtime_platform = BuildTarget.Android;
                    this._platform_name = this.PatchPrefix() + "Android/";
                    break;
                default:
                    this._runtime_platform = BuildTarget.Standalone;
                    this._platform_name = this.PatchPrefix() ?? "";
                    break;
            }
            this._version_getter = XUpdater.XGameRoot.AddComponent<XVersion>();
            this._bundle_getter = XUpdater.XGameRoot.AddComponent<XBundle>();
            this._filelog_getter = XUpdater.XGameRoot.AddComponent<XFileLog>();
            this._fmod_listenter = GameObject.Find("Main Camera").GetComponent("FMOD_Listener") as IFMOD_Listener;
            this._tssSdk = XUpdater.XGameRoot.GetComponent("TssSDKManager") as ITssSdk;
            this._apolloManager = XUpdater.XGameRoot.GetComponent("ApolloManager") as IApolloManager;
            this._broadcast = XUpdater.XGameRoot.GetComponent("BroadcastManager") as IBroardcast;
            this._platform = XUpdater.XGameRoot.GetComponent("XPlatform") as IPlatform;
            this._video = XUpdater.XGameRoot.GetComponent("XVideoMgr") as IXVideo;
            this._lua_engine = XUpdater.XGameRoot.GetComponent("LuaEngine") as ILuaEngine;
            this._pandoraManager = XUpdater.XGameRoot.GetComponent("XPandoraMgr") as IXPandoraMgr;
            this._SirControl = XUpdater.XGameRoot.GetComponent("XGameSirControl") as IXGameSirControl;
            if (this._SirControl != null)
                this._SirControl.Init();
            this.ABManager = XUpdater.XGameRoot.AddComponent<AssetBundleManager>();
            this.ABManager.Init();
            XSingleton<XDebug>.singleton.Init(this._platform, this._filelog_getter);
            XSingleton<XCaching>.singleton.Init();
            XSingleton<XLoadingUI>.singleton.Init();
            XBinaryReader.Init();
            UnityEngine.Object.DontDestroyOnLoad((UnityEngine.Object)XUpdater.XGameRoot);
            return true;
        }

        public override void Uninit()
        {
            foreach (AssetBundle assetBundle in this._bundles.Values)
                assetBundle.Unload(false);
            this._assets.Clear();
            this._persist_assets.Clear();
            this._bundles.Clear();
            this._res_list.Clear();
            if (this._video != null && this._video.isPlaying)
                this._video.Stop();
            this._phase = eUPdatePhase.xUP_Prepare;
            this._update_done = false;
            if (this._fetch_version_network != null)
                this._fetch_version_network.Close();
            UnityEngine.Object.Destroy((UnityEngine.Object)XUpdater.XGameRoot);
        }

        public void Clear()
        {
            Dictionary<uint, AssetBundle>.Enumerator enumerator = this._bundles.GetEnumerator();
            while (enumerator.MoveNext())
                enumerator.Current.Value.Unload(false);
            this._bundles.Clear();
        }

        public void Update()
        {
            switch (this._phase)
            {
                case eUPdatePhase.xUP_Prepare:
                    if (this.Preparing())
                    {
                        this._phase = eUPdatePhase.xUP_FetchVersion;
                        break;
                    }
                    XSingleton<XLoadingUI>.singleton.SetStatus(XSingleton<XStringTable>.singleton.GetString("XUPDATE_ERROR_FETCHLOCALVERSIONERROR"));
                    this.OnError();
                    break;
                case eUPdatePhase.xUP_FetchVersion:
                    if (!this._bFetchVersion)
                    {
                        if (this._fetch_version_network == null)
                            this._fetch_version_network = new XFetchVersionNetwork();
                        XSingleton<XLoadingUI>.singleton.SetStatus(XSingleton<XStringTable>.singleton.GetString("XUPDATE_INFO_FETCHVERSION"));
                        this._fetch_version_network.Init();
                        if (this._fetch_version_network.Connect(XSingleton<XCaching>.singleton.VersionServer.Substring(0, XSingleton<XCaching>.singleton.VersionServer.LastIndexOf(':')), int.Parse(XSingleton<XCaching>.singleton.VersionServer.Substring(XSingleton<XCaching>.singleton.VersionServer.LastIndexOf(':') + 1))))
                        {
                            this._bFetchVersion = true;
                            this._fetch_version_time = Time.time;
                            break;
                        }
                        XSingleton<XLoadingUI>.singleton.SetStatus(XSingleton<XStringTable>.singleton.GetString("XUPDATE_ERROR_FETCHVERSIONERROR"));
                        XSingleton<XUpdater>.singleton.OnError();
                        this._fetch_version_network.Close();
                        break;
                    }
                    if ((double)Time.time - (double)this._fetch_version_time > 5.0)
                    {
                        XSingleton<XLoadingUI>.singleton.SetStatus(XSingleton<XStringTable>.singleton.GetString("XUPDATE_ERROR_FETCHVERSIONERROR"));
                        XSingleton<XUpdater>.singleton.OnError();
                        this._fetch_version_network.Close();
                        break;
                    }
                    break;
                case eUPdatePhase.xUP_LoadVersion:
                    if (!this._bFetchServer)
                    {
                        this._cacheload_bundle.Clear();
                        this._download_bundle.Clear();
                        this._meta_bundle.Clear();
                        this._version_getter.ServerDownload(new HandleVersionDownload(this.OnVersionDownloaded), new HandleVersionLoaded(this.OnVersionLoaded));
                    }
                    this._bFetchServer = true;
                    break;
                case eUPdatePhase.xUP_CompareVersion:
                    if (this._comparer == null)
                    {
                        this._comparer = this.VersionComparer();
                        break;
                    }
                    if (!this._comparer.MoveNext())
                        this._comparer = (IEnumerator)null;
                    break;
                case eUPdatePhase.xUP_DownLoadBundle:
                    if (this._downloader == null)
                    {
                        this._downloader = this.DownLoadBundles();
                        break;
                    }
                    if (!this._downloader.MoveNext())
                    {
                        this._downloader = (IEnumerator)null;
                        this._phase = eUPdatePhase.xUP_ShowVersion;
                    }
                    break;
                case eUPdatePhase.xUP_ShowVersion:
                    this.ShowVersionInfo(this._server);
                    break;
                case eUPdatePhase.xUP_LaunchGame:
                    if (this._launcher == null)
                    {
                        this._launcher = this.LaunchGame();
                        break;
                    }
                    if (!this._launcher.MoveNext())
                    {
                        this._launcher = (IEnumerator)null;
                        this.OnEnding();
                    }
                    break;
                case eUPdatePhase.xUP_Finish:
                    if (this._finish == null)
                    {
                        this._finish = this.Finish();
                        break;
                    }
                    if (!this._finish.MoveNext())
                    {
                        this._finish = (IEnumerator)null;
                        this._update_done = true;
                        XSingleton<XShell>.singleton.StartGame();
                    }
                    break;
            }
            XSingleton<XLoadingUI>.singleton.OnUpdate();
        }

        public void Begin()
        {
            this._update_done = false;
            this._bFetchVersion = false;
            this._bFetchServer = false;
            if (!XSingleton<XStringTable>.singleton.SyncInit())
            {
                this._log.Remove(0, this._log.Length);
                this._log.Append("Error occurred when loading string table.");
                XSingleton<XLoadingUI>.singleton.SetStatus(this._log.ToString());
                XSingleton<XUpdater>.singleton.OnError();
            }
            else if (!this.CheckMemory())
            {
                this._log.Remove(0, this._log.Length);
                this._log.Append(XSingleton<XStringTable>.singleton.GetString("XUPDATE_INFO_EXCLUDE1GPHONE"));
                XSingleton<XLoadingUI>.singleton.SetStatus(this._log.ToString());
                XSingleton<XUpdater>.singleton.OnError();
            }
            else if (XSingleton<XCaching>.singleton.EnableCache())
            {
                this._phase = eUPdatePhase.xUP_Prepare;
            }
            else
            {
                this._log.Remove(0, this._log.Length);
                this._log.Append(XSingleton<XStringTable>.singleton.GetString("XUPDATE_ERROR_ACCESSDENIED"));
                XSingleton<XLoadingUI>.singleton.SetStatus(this._log.ToString());
                XSingleton<XUpdater>.singleton.OnError();
            }
        }

        private IEnumerator Finish()
        {
            if (this._server != null)
            {
                this._server.Bundles.Clear();
                this._version = this._server.ToString();
            }
            this._server = (XVersionData)null;
            this._client = (XVersionData)null;
            this._buildin = (XVersionData)null;
            if (this._need_play_cg && this._video != null)
            {
                this._video.Play();
                yield return (object)null;
                while (this._video.isPlaying)
                    yield return (object)null;
            }
            UnityEngine.Object.DestroyObject((UnityEngine.Object)this._version_getter);
            UnityEngine.Object.DestroyObject((UnityEngine.Object)this._bundle_getter);
        }

        public void OnError() => this._phase = eUPdatePhase.xUP_Error;

        public void DevStart() => this._phase = eUPdatePhase.xUP_ShowVersion;

        public void OnRetry()
        {
            switch (this._phase)
            {
                case eUPdatePhase.xUP_DownLoadBundle:
                    if (!this._on_file_download_need_retry)
                        break;
                    this._on_file_download_retry = true;
                    break;
                case eUPdatePhase.xUP_Finish:
                    if (!this._video.isPlaying)
                        break;
                    this._video.Stop();
                    break;
                case eUPdatePhase.xUP_Error:
                    if (this._server != null)
                        break;
                    this.Begin();
                    break;
            }
        }

        private void OnEnding()
        {
            XSingleton<XLoadingUI>.singleton.LoadingOK = true;
            this._download_bundle.Clear();
            this._cacheload_bundle.Clear();
            this._meta_bundle.Clear();
            this._phase = eUPdatePhase.xUP_Ending;
        }

        public bool ContainRes(uint hash) => this._res_list.ContainsKey(hash);

        public UnityEngine.Object ResourceLoad(uint hash)
        {
            UnityEngine.Object @object = (UnityEngine.Object)null;
            XResPackage xresPackage = (XResPackage)null;
            if (this._res_list != null && this._res_list.TryGetValue(hash, out xresPackage) && !this._persist_assets.TryGetValue(hash, out @object))
            {
                AssetBundle assetBundle = (AssetBundle)null;
                uint key = XSingleton<XCommon>.singleton.XHash(xresPackage.bundle);
                if (!this._bundles.TryGetValue(key, out assetBundle))
                {
                    byte[] binary = (byte[])null;
                    if (!this._persist_image.TryGetValue(key, out binary))
                    {
                        XBundleData data = (XBundleData)null;
                        if (!this._assets.TryGetValue(key, out data))
                            return (UnityEngine.Object)null;
                        binary = XSingleton<XCaching>.singleton.LoadFile(XSingleton<XCaching>.singleton.GetLocalPath(data));
                    }
                    assetBundle = AssetBundle.LoadFromMemory(binary);
                    this._bundles.Add(key, assetBundle);
                }
                string name = xresPackage.location.Substring(xresPackage.location.LastIndexOf('/') + 1);
                @object = assetBundle.LoadAsset(name, XUpdater.Ass.GetType(xresPackage.type));
            }
            return @object;
        }

        private AsyncVersionProcessRequest OnVersionDownloaded(TextAsset text)
        {
            AsyncVersionProcessRequest avpr = new AsyncVersionProcessRequest();
            XSingleton<XLoadingUI>.singleton.SetStatus(XSingleton<XStringTable>.singleton.GetString("XUPDATE_INFO_FETCHMANIFEST"));
            if ((UnityEngine.Object)text != (UnityEngine.Object)null)
            {
                byte[] contents = text.bytes;
                new Thread((ThreadStart)(() =>
                {
                    avpr.IsCorrect = this.LoadVersion(contents);
                    avpr.IsDone = true;
                })).Start();
            }
            else
            {
                avpr.IsDone = true;
                avpr.IsCorrect = false;
            }
            return avpr;
        }

        private void OnVersionLoaded(bool correct)
        {
            if (correct)
            {
                this._phase = eUPdatePhase.xUP_CompareVersion;
            }
            else
            {
                this._log.Remove(0, this._log.Length);
                this._log.Append(XSingleton<XStringTable>.singleton.GetString("XUPDATE_ERROR_MANIFESTERROR"));
                XSingleton<XLoadingUI>.singleton.SetStatus(this._log.ToString());
                XSingleton<XUpdater>.singleton.OnError();
            }
        }

        private void OnBundleFetched(WWW www, byte[] bytes, XBundleData data, bool newdownload)
        {
            if (newdownload)
            {
                XSingleton<XDebug>.singleton.AddLog("Finished Download ", data.Name);
                this._log.Remove(0, this._log.Length);
                this._log.AppendFormat(XSingleton<XStringTable>.singleton.GetString("XUPDATE_INFO_DOWNLOAD_FILE_COMPLETE"), (object)data.Name);
                XSingleton<XLoadingUI>.singleton.SetStatus(this._log.ToString());
            }
            else
            {
                XSingleton<XDebug>.singleton.AddLog("Finished Extract ", data.Name);
                this._log.Remove(0, this._log.Length);
                this._log.AppendFormat(XSingleton<XStringTable>.singleton.GetString("XUPDATE_INFO_EXTRACTING_COMPLETE"), (object)data.Name);
                XSingleton<XLoadingUI>.singleton.SetStatus(this._log.ToString());
            }
            uint key = XSingleton<XCommon>.singleton.XHash(data.Name);
            bool load = false;
            this._bundle_data = data;
            switch (this._bundle_data.Level)
            {
                case AssetLevel.Memory:
                    load = true;
                    break;
                case AssetLevel.Image:
                    byte[] numArray = new byte[bytes.Length];
                    bytes.CopyTo((Array)numArray, 0);
                    this._persist_image.Add(key, numArray);
                    break;
            }
            this._assets.Add(key, this._bundle_data);
            this._bundle_getter.GetBundle(www, bytes, new HandleLoadBundle(this.OnBundleLoaded), load);
        }

        private void OnBundleLoaded(AssetBundle bundle)
        {
            if ((UnityEngine.Object)bundle != (UnityEngine.Object)null)
                this._bundles.Add(XSingleton<XCommon>.singleton.XHash(this._bundle_data.Name), bundle);
            this._bundle_fetching = false;
        }

        private void OnAssetLoaded(XResPackage package, UnityEngine.Object asset)
        {
            uint key = XSingleton<XCommon>.singleton.XHash(package.location);
            if (asset != (UnityEngine.Object)null)
            {
                if (!this._persist_assets.ContainsKey(key))
                    this._persist_assets.Add(key, asset);
                else
                    this._persist_assets[key] = asset;
            }
            this._asset_loading = false;
        }

        private void UpdateLocalVersion(Stream s)
        {
            this._buildin = this.FetchBuildIn(s);
            this._client = this.FetchBuildOut();
            if (this._buildin != null)
                XSingleton<XDebug>.singleton.AddLog("BuildIn version: ", this._buildin.ToString());
            if (this._client != null)
                XSingleton<XDebug>.singleton.AddLog("BuildOut version: ", this._client.ToString());
            this._need_play_cg = this._client == null;
            if (this._client == null)
            {
                this._client = new XVersionData(this._buildin);
                if (!XSingleton<XCaching>.singleton.CleanCache())
                {
                    this._log.Remove(0, this._log.Length);
                    this._log.Append(XSingleton<XStringTable>.singleton.GetString("XUPDATE_ERROR_DELETEDENIED"));
                    XSingleton<XLoadingUI>.singleton.SetStatus(this._log.ToString());
                    XSingleton<XUpdater>.singleton.OnError();
                }
            }
            else if (this._client.CompareTo(this._buildin) < 0 || (int)this._buildin.Build_Version != (int)this._client.Build_Version)
            {
                this._need_play_cg = true;
                this._client.VersionCopy(this._buildin);
                if (!XSingleton<XCaching>.singleton.CleanCache())
                {
                    this._log.Remove(0, this._log.Length);
                    this._log.Append(XSingleton<XStringTable>.singleton.GetString("XUPDATE_ERROR_DELETEDENIED"));
                    XSingleton<XLoadingUI>.singleton.SetStatus(this._log.ToString());
                    XSingleton<XUpdater>.singleton.OnError();
                }
            }
            XSingleton<XDebug>.singleton.AddLog("Client version: ", this._client.ToString());
        }

        private XVersionData FetchBuildIn(Stream s) => s == null ? (XVersionData)null : XVersionData.Convert2Version(new StreamReader(s).ReadToEnd());

        private XVersionData FetchBuildOut()
        {
            string localVersion = XVersion.GetLocalVersion();
            XSingleton<XDebug>.singleton.AddLog("Local Version Path " + localVersion);
            XVersionData xversionData = (XVersionData)null;
            if (File.Exists(localVersion))
            {
                using (MemoryStream memoryStream = new MemoryStream(this.XCryptography(File.ReadAllBytes(localVersion))))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(XVersionData));
                    try
                    {
                        xversionData = xmlSerializer.Deserialize((Stream)memoryStream) as XVersionData;
                    }
                    catch (Exception ex)
                    {
                        xversionData = (XVersionData)null;
                        XSingleton<XDebug>.singleton.AddLog("Build Out Version Fetching FAILED! " + ex.Message);
                    }
                    finally
                    {
                        memoryStream.Close();
                    }
                }
            }
            else
                XSingleton<XDebug>.singleton.AddLog("Local Version Path " + localVersion + " not exists.");
            return xversionData;
        }

        private bool LoadVersion(byte[] text)
        {
            if (BitConverter.ToString(text, 0, XUpdater.Md5Length) == XSingleton<XCaching>.singleton.CalculateMD5(text, XUpdater.Md5Length, text.Length - XUpdater.Md5Length))
            {
                using (MemoryStream memoryStream = new MemoryStream(text, XUpdater.Md5Length, text.Length - XUpdater.Md5Length))
                {
                    this._server = new XmlSerializer(typeof(XVersionData)).Deserialize((Stream)memoryStream) as XVersionData;
                    if (this._server != null && this._server.Target_Platform == this._runtime_platform)
                    {
                        XSingleton<XDebug>.singleton.AddLog("Server version: ", this._server.ToString());
                        return true;
                    }
                }
            }
            XSingleton<XDebug>.singleton.AddLog("Analysis Server version error!");
            this._server = (XVersionData)null;
            return false;
        }

        private bool CheckMemory() => true;

        private bool Preparing()
        {
            Stream s = (Stream)null;
            XSingleton<XDebug>.singleton.AddLog("Fetch local version...");
            switch (Application.platform)
            {
                case RuntimePlatform.IPhonePlayer:
                    s = XSingleton<XResourceLoaderMgr>.singleton.ReadText("ios-version", ".bytes", false);
                    break;
                case RuntimePlatform.Android:
                    s = XSingleton<XResourceLoaderMgr>.singleton.ReadText("android-version", ".bytes", false);
                    break;
            }
            if (s == null)
                return XUpdater.LaunchMode == XLaunchMode.Dev;
            this.UpdateLocalVersion(s);
            XSingleton<XResourceLoaderMgr>.singleton.ClearStream(s);
            return true;
        }

        private IEnumerator VersionComparer()
        {
            int compare = this._client.CompareTo(this._server);
            this._update_pakcage_size = 0UL;
            if (compare > 0)
            {
                this._server = this._client;
                this._download_prepare = (IEnumerator)null;
                this.DownLoadConfirmed(false);
            }
            else if (compare == 0 || compare < 0 && this._client.CanUpdated(this._server))
            {
                if (this._download_prepare == null)
                    this._download_prepare = this.DownLoadPrepare();
                while (this._download_prepare.MoveNext())
                    yield return (object)null;
                this._download_prepare = (IEnumerator)null;
                this.DownLoadConfirmed((uint)compare > 0U);
            }
            else
            {
                XSingleton<XLoadingUI>.singleton.SetStatus(XSingleton<XStringTable>.singleton.GetString("XUPDATE_ERROR_VERSIONNOTMATCH"));
                this.ShowVersionInfo(this._client, false);
                Texture tex = (Texture)null;
                if (!this._is_download_update_pic)
                {
                    WWW www = new WWW("https://image.lzgjx.qq.com/sharingicon/updateimg.jpg");
                    while (!www.isDone)
                        yield return (object)null;
                    if (string.IsNullOrEmpty(www.error))
                        tex = (Texture)www.texture;
                    www.Dispose();
                    this._is_download_update_pic = true;
                    www = (WWW)null;
                }
                this._phase = eUPdatePhase.xUP_Error;
                XSingleton<XLoadingUI>.singleton.SetDownLoad(new XLoadingUI.OnSureCallBack(this.ToAppStore), tex);
                tex = (Texture)null;
            }
        }

        private void ToAppStore()
        {
            switch (Application.platform)
            {
                case RuntimePlatform.IPhonePlayer:
                    for (int index = 0; index < this._client.Res.Count; ++index)
                    {
                        if (this._client.Res[index].location == "Table/StringTable")
                        {
                            string localPath = XSingleton<XCaching>.singleton.GetLocalPath(this._client.GetSpecificBundle(this._client.Res[index].bundle));
                            try
                            {
                                byte[] binary = File.ReadAllBytes(localPath);
                                if (binary != null)
                                {
                                    AssetBundle assetBundle = AssetBundle.LoadFromMemory(binary);
                                    if ((UnityEngine.Object)assetBundle != (UnityEngine.Object)null)
                                    {
                                        TextAsset ta = assetBundle.LoadAsset("StringTable", typeof(TextAsset)) as TextAsset;
                                        if ((UnityEngine.Object)ta != (UnityEngine.Object)null && !XSingleton<XStringTable>.singleton.ReInit(ta))
                                            XSingleton<XStringTable>.singleton.SyncInit();
                                    }
                                    break;
                                }
                                break;
                            }
                            catch (Exception ex)
                            {
                                XSingleton<XDebug>.singleton.AddErrorLog("ToAppStore: ", ex.Message);
                                break;
                            }
                        }
                    }
                    string str1 = XSingleton<XStringTable>.singleton.GetString("XUPDATE_ERROR_VERSIONNOTMATCH_URL");
                    XSingleton<XDebug>.singleton.AddLog("AppStore Url: ", str1);
                    Application.OpenURL(str1);
                    break;
                case RuntimePlatform.Android:
                    for (int index = 0; index < this._client.Res.Count; ++index)
                    {
                        if (this._client.Res[index].location == "Table/StringTable")
                        {
                            string localPath = XSingleton<XCaching>.singleton.GetLocalPath(this._client.GetSpecificBundle(this._client.Res[index].bundle));
                            try
                            {
                                byte[] binary = File.ReadAllBytes(localPath);
                                if (binary != null)
                                {
                                    AssetBundle assetBundle = AssetBundle.LoadFromMemory(binary);
                                    if ((UnityEngine.Object)assetBundle != (UnityEngine.Object)null)
                                    {
                                        TextAsset ta = assetBundle.LoadAsset("StringTable", typeof(TextAsset)) as TextAsset;
                                        if ((UnityEngine.Object)ta != (UnityEngine.Object)null && !XSingleton<XStringTable>.singleton.ReInit(ta))
                                            XSingleton<XStringTable>.singleton.SyncInit();
                                    }
                                    break;
                                }
                                break;
                            }
                            catch (Exception ex)
                            {
                                XSingleton<XDebug>.singleton.AddErrorLog("ToAndroidAppStore: ", ex.Message);
                                break;
                            }
                        }
                    }
                    string str2 = XSingleton<XStringTable>.singleton.GetString("XUPDATE_ERROR_VERSIONNOTMATCH_ANDROID_URL");
                    XSingleton<XDebug>.singleton.AddLog("AndroidAppStore Url: ", str2);
                    Application.OpenURL(str2);
                    break;
            }
        }

        private void DownLoadConfirmedCallBack() => this._phase = eUPdatePhase.xUP_DownLoadBundle;

        private void DownLoadCancelledCallBack()
        {
            this._phase = eUPdatePhase.xUP_Error;
            XSingleton<XLoadingUI>.singleton.SetStatus("");
            this.ShowVersionInfo(this._client, false);
        }

        private void DownLoadConfirmed(bool updated)
        {
            if (updated)
            {
                if (this._update_pakcage_size < 1048576UL)
                {
                    this.DownLoadConfirmedCallBack();
                }
                else
                {
                    XSingleton<XLoadingUI>.singleton.SetDialog(this._update_pakcage_size, new XLoadingUI.OnSureCallBack(this.DownLoadConfirmedCallBack), new XLoadingUI.OnSureCallBack(this.DownLoadCancelledCallBack));
                    this._phase = eUPdatePhase.xUP_DownLoadConfirm;
                }
            }
            else
                this._phase = eUPdatePhase.xUP_DownLoadBundle;
        }

        private IEnumerator DownLoadPrepare()
        {
            for (int i = 0; i < this._server.Res.Count; ++i)
            {
                if (this._buildin.NeedDownload(this._server.Res[i].bundle))
                {
                    XBundleData bundle = this._server.GetSpecificBundle(this._server.Res[i].bundle);
                    if (bundle == null)
                        XSingleton<XDebug>.singleton.AddLog("Bundle ", this._server.Res[i].bundle, " is missing in sever bundle set.");
                    else if (!this._cacheload_bundle.Contains(bundle) && !this._download_bundle.Contains(bundle))
                    {
                        AsyncCachedRequest acr = XSingleton<XCaching>.singleton.IsBundleCached(bundle, this._server.MD5_Size);
                        while (!acr.IsDone)
                            yield return (object)null;
                        if (!acr.Cached && acr.MaybeCached)
                        {
                            XBundleData clientData = (XBundleData)null;
                            foreach (XBundleData bundle1 in this._client.Bundles)
                            {
                                XBundleData data = bundle1;
                                if (data.Name == bundle.Name)
                                {
                                    clientData = data;
                                    break;
                                }
                                data = (XBundleData)null;
                            }
                            acr.Cached = clientData != null && clientData.MD5 == bundle.MD5;
                            clientData = (XBundleData)null;
                        }
                        XSingleton<XDebug>.singleton.AddLog("Bundle ", bundle.Name, " cached is ", acr.Cached.ToString());
                        if (acr.Cached)
                        {
                            this._cacheload_bundle.Add(bundle);
                        }
                        else
                        {
                            this._download_bundle.Add(bundle);
                            this._update_pakcage_size += (ulong)bundle.Size;
                        }
                        bundle = (XBundleData)null;
                        acr = (AsyncCachedRequest)null;
                    }
                }
            }
            this.MetaPrepare(this._server.AB);
            this.MetaPrepare(this._server.Scene);
            this.MetaPrepare(this._server.FMOD);
        }

        private void MetaPrepare(List<XMetaResPackage> meta)
        {
            bool flag = this._platform != null && !this._platform.IsPublish();
            for (int index = 0; index < meta.Count; ++index)
            {
                if (this._buildin.NeedDownload(meta[index].bundle) && this._client.NeedDownload(meta[index].bundle))
                {
                    if (!this._meta_bundle.Contains(meta[index]))
                        this._meta_bundle.Add(meta[index]);
                    if (flag)
                        XSingleton<XDebug>.singleton.AddLog("Meta ", meta[index].download, " is prepared to downloading...");
                    this._update_pakcage_size += (ulong)meta[index].Size;
                }
            }
        }

        private IEnumerator DownLoadBundles()
        {
            bool log = this._platform != null && !this._platform.IsPublish();
            int total = this._download_bundle.Count + this._cacheload_bundle.Count + this._meta_bundle.Count;
            int processed = 0;
            for (int i = 0; i < this._download_bundle.Count; ++i)
            {
                while (this._bundle_fetching)
                    yield return (object)null;
                if (log)
                    XSingleton<XDebug>.singleton.AddLog("Updating ", this._download_bundle[i].Name, " ... ", processed.ToString(), "/", total.ToString());
                this._bundle_fetching = true;
                ++processed;
                XSingleton<XCaching>.singleton.Download(this._download_bundle[i], new HandleFetchBundle(this.OnBundleFetched), (float)processed / (float)total);
            }
            for (int i = 0; i < this._cacheload_bundle.Count; ++i)
            {
                while (this._bundle_fetching)
                    yield return (object)null;
                if (log)
                    XSingleton<XDebug>.singleton.AddLog("Extracting ", this._cacheload_bundle[i].Name, " ... ", processed.ToString(), "/", total.ToString());
                this._bundle_fetching = true;
                ++processed;
                if (Application.platform == RuntimePlatform.IPhonePlayer)
                {
                    while (!XSingleton<XCaching>.singleton.Extract(this._cacheload_bundle[i], new HandleFetchBundle(this.OnBundleFetched), (float)processed / (float)total))
                        yield return (object)null;
                }
                else
                    XSingleton<XCaching>.singleton.Extract(this._cacheload_bundle[i], new HandleFetchBundle(this.OnBundleFetched), (float)processed / (float)total);
            }
            while (this._bundle_fetching)
                yield return (object)null;
            for (int i = 0; i < this._meta_bundle.Count; ++i)
            {
                ++processed;
                AsyncWriteRequest awr = XSingleton<XCaching>.singleton.Download(this._meta_bundle[i].download, this._meta_bundle[i].Size, (float)processed / (float)total);
                if (log)
                    XSingleton<XDebug>.singleton.AddLog("Download meta ", this._meta_bundle[i].download, " ... ", processed.ToString(), "/", total.ToString());
                while (!awr.IsDone)
                {
                    if (awr.HasError)
                    {
                        if (this._on_file_download_retry)
                        {
                            this._on_file_download_retry = false;
                            this._on_file_download_need_retry = false;
                            --i;
                            --processed;
                            this._log.Length = 0;
                            this._log.Append(XSingleton<XStringTable>.singleton.GetString("XUPDATE_INFO_RETRY"));
                            XSingleton<XLoadingUI>.singleton.SetStatus(this._log.ToString());
                            yield return (object)null;
                            break;
                        }
                        this._on_file_download_need_retry = true;
                        this._log.Length = 0;
                        this._log.AppendFormat(XSingleton<XStringTable>.singleton.GetString("XUPDATE_ERROR_DOWNLOADRESFAILED_AND_RETRY"), (object)awr.Name);
                        XSingleton<XLoadingUI>.singleton.SetStatus(this._log.ToString());
                        yield return (object)null;
                    }
                    else
                        yield return (object)null;
                }
                awr = (AsyncWriteRequest)null;
            }
            for (int i = 0; i < this._server.Res.Count; ++i)
            {
                if (this.ProcessAssets(this._server.Res[i]))
                {
                    if (this._server.Res[i].rtype != ResourceType.Script)
                    {
                        uint hash = XSingleton<XCommon>.singleton.XHash(this._server.Res[i].location);
                        this._res_list.Add(hash, this._server.Res[i]);
                    }
                    this._log.Remove(0, this._log.Length);
                    this._log.AppendFormat(XSingleton<XStringTable>.singleton.GetString("XUPDATE_INFO_PRELOADING"), (object)((float)((double)i / (double)this._server.Res.Count * 100.0)).ToString("F0"));
                    XSingleton<XLoadingUI>.singleton.SetStatus(this._log.ToString());
                    if (i << 30 == 0)
                        yield return (object)null;
                }
            }
            AsyncLogRequest alr = this.LogNewVersion();
            while (!alr.IsDone)
                Thread.Sleep(1);
            this.XPlatform.SetNoBackupFlag(XVersion.GetLocalVersion());
        }

        private AsyncLogRequest LogNewVersion()
        {
            AsyncLogRequest alr = new AsyncLogRequest();
            if (this._server != this._client)
                new Thread((ThreadStart)(() =>
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        XmlSerializer xmlSerializer = new XmlSerializer(typeof(XVersionData));
                        XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                        namespaces.Add(string.Empty, string.Empty);
                        xmlSerializer.Serialize((Stream)memoryStream, (object)this._server, namespaces);
                        File.WriteAllBytes(XVersion.GetLocalVersion(), this.XCryptography(memoryStream.ToArray()));
                    }
                    alr.IsDone = true;
                })).Start();
            else
                alr.IsDone = true;
            return alr;
        }

        private void ShowVersionInfo(XVersionData data, bool launch = true)
        {
            if (data != null)
            {
                this._log.Remove(0, this._log.Length);
                this._log.Append("v").Append(data.ToString());
                XSingleton<XLoadingUI>.singleton.SetVersion(this._log.ToString());
            }
            else
                XSingleton<XLoadingUI>.singleton.SetVersion("Dev 0.0.0");
            if (!launch)
                return;
            this._phase = eUPdatePhase.xUP_LaunchGame;
        }

        private bool ProcessAssets(XResPackage res)
        {
            AssetBundle assetBundle = (AssetBundle)null;
            if (!this._bundles.TryGetValue(XSingleton<XCommon>.singleton.XHash(res.bundle), out assetBundle))
                return false;
            string name = res.location.Substring(res.location.LastIndexOf('/') + 1);
            switch (res.rtype)
            {
                case ResourceType.Assets:
                    this.OnAssetLoaded(res, assetBundle.LoadAsset(name, XUpdater.Ass.GetType(res.type)));
                    break;
                case ResourceType.Script:
                    this._script = (assetBundle.LoadAsset(name, XUpdater.Ass.GetType(res.type)) as TextAsset).bytes;
                    assetBundle.Unload(false);
                    this._bundles.Remove(XSingleton<XCommon>.singleton.XHash(res.bundle));
                    break;
            }
            return true;
        }

        private IEnumerator AsyncProcessAssets(XResPackage package, AssetBundle bundle)
        {
            string name = package.location.Substring(package.location.LastIndexOf('/') + 1);
            this._asset_loading = true;
            this._bundle_getter.GetAsset(bundle, package, new HandleLoadAsset(this.OnAssetLoaded));
            while (this._asset_loading)
                yield return (object)null;
        }

        private IEnumerator LaunchGame()
        {
            XSingleton<XLoadingUI>.singleton.SetStatus(XSingleton<XStringTable>.singleton.GetString("XUPDATE_INFO_LOADING"));
            yield return (object)null;
            this.ABManager.Init();
            this.XPlatform.ReloadFMOD();
            AsyncAssemblyRequest aar = new AsyncAssemblyRequest();
            ResourceRequest rrq = (ResourceRequest)null;
            if (Application.platform == RuntimePlatform.Android)
            {
                string path = Application.persistentDataPath + "/XMainClient.bytes";
                if (File.Exists(path))
                    this._script = File.ReadAllBytes(path);
                if (this._script == null && Application.platform == RuntimePlatform.Android)
                {
                    rrq = Resources.LoadAsync("XMainClient", typeof(TextAsset));
                    yield return (object)rrq;
                    this._script = (rrq.asset as TextAsset).bytes;
                }
                path = (string)null;
            }
            switch (Application.platform)
            {
                case RuntimePlatform.IPhonePlayer:
                    aar.Main = Assembly.Load("XMainClient");
                    break;
                default:
                    aar.Main = this._script == null ? Assembly.Load("XMainClient") : Assembly.Load(this._script);
                    break;
            }
            XSingleton<XShell>.singleton.MakeEntrance(aar.Main);
            if (rrq != null && rrq.asset != (UnityEngine.Object)null)
                Resources.UnloadAsset(rrq.asset);
            this._script = (byte[])null;
            this._log.Remove(0, this._log.Length);
            this._log.Append(XSingleton<XStringTable>.singleton.GetString("XUPDATE_INFO_LAUNCHING"));
            XSingleton<XLoadingUI>.singleton.SetStatus(this._log.ToString());
            yield return (object)null;
            XSingleton<XShell>.singleton.PreLaunch();
            while (!XSingleton<XShell>.singleton.Launched())
            {
                yield return (object)null;
                XSingleton<XShell>.singleton.Launch();
            }
            this.XLuaEngine.InitLua();
        }

        private byte[] XCryptography(byte[] bs)
        {
            for (int index = 0; index < bs.Length; ++index)
                bs[index] = (byte)((uint)bs[index] ^ 154U);
            return bs;
        }

        private string PatchPrefix()
        {
            switch (XUpdater.LaunchMode)
            {
                case XLaunchMode.Live:
                    return "Patch/Live/";
                case XLaunchMode.PreProduct:
                    return "Patch/PreProduct/";
                case XLaunchMode.Dev:
                    return "Patch/Dev/";
                default:
                    return "Patch/Live/";
            }
        }

        private void GetLaunchMode() => XUpdater._launch_mode = XLaunchMode.Dev;

        public void PlayCG(object o = null) => this._video.Play();

        public void SetServerVersion(string data)
        {
            string str = "";
            if (this._buildin != null)
                str = this._buildin.Build_Version.ToString();
            string[] strArray1 = data.Split('|');
            switch (Application.platform)
            {
                case RuntimePlatform.IPhonePlayer:
                    this._target_version = strArray1[0];
                    try
                    {
                        if (strArray1.Length > 3)
                        {
                            string[] strArray2 = strArray1[3].Split(':');
                            for (int index = 0; index < strArray2.Length; ++index)
                            {
                                string[] strArray3 = strArray2[index].Split('.');
                                if (strArray3.Length > 1 && strArray3[1] == str)
                                    this._target_version = strArray2[index];
                            }
                            break;
                        }
                        break;
                    }
                    catch (Exception ex)
                    {
                        XSingleton<XDebug>.singleton.AddErrorLog("GetServer ExData Error!!!   " + ex.Message);
                        break;
                    }
                case RuntimePlatform.Android:
                    this._target_version = strArray1[1];
                    try
                    {
                        if (strArray1.Length > 4)
                        {
                            string[] strArray4 = strArray1[4].Split(':');
                            for (int index = 0; index < strArray4.Length; ++index)
                            {
                                string[] strArray5 = strArray4[index].Split('.');
                                if (strArray5.Length > 1 && strArray5[1] == str)
                                    this._target_version = strArray4[index];
                            }
                            break;
                        }
                        break;
                    }
                    catch (Exception ex)
                    {
                        XSingleton<XDebug>.singleton.AddErrorLog("GetServer ExData Error!!!   " + ex.Message);
                        break;
                    }
            }
            try
            {
                if (strArray1.Length > 2)
                    this._need_check_file = strArray1[2] == "1";
            }
            catch (Exception ex)
            {
                XSingleton<XDebug>.singleton.AddErrorLog("GetServer CheckFile Flag Error!!!   " + ex.Message);
            }
            XSingleton<XDebug>.singleton.AddGreenLog(data);
            this._fetch_version_network.Close();
            this._phase = eUPdatePhase.xUP_LoadVersion;
        }
    }
}
