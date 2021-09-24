

using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace XUtliPoolLib
{
    public class AssetBundleManager : MonoBehaviour
    {
        public static Version version = new Version(0, 1, 0);
        public static AssetBundleManager Instance;
        public static string NAME = nameof(AssetBundleManager);
        public static bool enableLog = false;
        private const int MAX_REQUEST = 100;
        private int _requestRemain = 100;
        private Queue<AssetBundleLoader> _requestQueue = new Queue<AssetBundleLoader>();
        private List<AssetBundleLoader> _currentLoadQueue = new List<AssetBundleLoader>();
        private HashSet<AssetBundleLoader> _nonCompleteLoaderSet = new HashSet<AssetBundleLoader>();
        private HashSet<AssetBundleLoader> _thisTimeLoaderSet = new HashSet<AssetBundleLoader>();
        private Dictionary<uint, AssetBundleInfo> _loadedAssetBundle = new Dictionary<uint, AssetBundleInfo>();
        private Dictionary<uint, AssetBundleLoader> _loaderCache = new Dictionary<uint, AssetBundleLoader>();
        private bool _isCurrentLoading;
        private Queue<AssetBundleInfo> _requestUnloadBundleQueue = new Queue<AssetBundleInfo>();
        private AssetBundleLoadProgress _progress = new AssetBundleLoadProgress();
        public AssetBundleManager.LoadProgressHandler onProgress;
        public AssetBundlePathResolver pathResolver;
        private AssetBundleDataReader _depInfoReader;
        private int _bundleCount = 0;
        private uint _defaultHash = 0;

        public int BundleCount => this._bundleCount;

        public AssetBundleManager()
        {
            AssetBundleManager.Instance = this;
            this.pathResolver = new AssetBundlePathResolver();
            this._defaultHash = XSingleton<XCommon>.singleton.XHashLowerRelpaceDot(0U, "Assets.Resources.");
        }

        public AssetBundleDataReader depInfoReader => this._depInfoReader;

        protected void Awake() => this.InvokeRepeating("CheckUnusedBundle", 0.0f, 5f);

        public void Init()
        {
            this.RemoveAll();
            this.LoadDepInfo();
        }

        public void Init(byte[] data, Action callback)
        {
            if (data.Length > 4)
            {
                XBinaryReader reader = XBinaryReader.Get();
                reader.InitByte(data);
                if (reader.ReadChar() == 'A' && reader.ReadChar() == 'B' && reader.ReadChar() == 'D')
                {
                    this._depInfoReader = reader.ReadChar() != 'T' ? (AssetBundleDataReader)new AssetBundleDataBinaryReader() : new AssetBundleDataReader();
                    this._depInfoReader.Read(reader);
                }
                XBinaryReader.Return(reader);
            }
            if (callback == null)
                return;
            callback();
        }

        private void LoadDepInfo()
        {
            string path = string.Format("{0}/{1}", (object)this.pathResolver.BundleCacheDir, (object)this.pathResolver.DependFileName);
            if (File.Exists(path))
            {
                this.Init(File.ReadAllBytes(path), (Action)null);
            }
            else
            {
                TextAsset textAsset = Resources.Load<TextAsset>("dep");
                if ((UnityEngine.Object)textAsset != (UnityEngine.Object)null)
                {
                    this.Init(textAsset.bytes, (Action)null);
                    Resources.UnloadAsset((UnityEngine.Object)textAsset);
                }
                else
                    XSingleton<XDebug>.singleton.AddErrorLog("depFile not exist!");
            }
        }

        private void OnDestroy() => this.RemoveAll();

        public AssetBundleLoader Load(
          uint hash,
          string path,
          string suffix,
          string prefix = null,
          AssetBundleManager.LoadAssetCompleteHandler handler = null,
          int handlerID = -1)
        {
            if (this.depInfoReader == null)
                return (AssetBundleLoader)null;
            AssetBundleLoader loader = this.CreateLoader(hash, path, suffix, prefix);
            if (loader == null)
                return (AssetBundleLoader)null;
            loader.loadHandlerID = handlerID;
            this._thisTimeLoaderSet.Add(loader);
            if (loader.isComplete)
            {
                if (handler != null)
                    handler(loader.bundleInfo, handlerID);
            }
            else
            {
                if (handler != null)
                    loader.onComplete += handler;
                this._isCurrentLoading = true;
                if (loader.state < LoadState.State_LoadingAsync)
                    this._nonCompleteLoaderSet.Add(loader);
                this.StartLoad();
            }
            return loader;
        }

        public AssetBundleInfo LoadImm(
          uint hash,
          string path,
          string suffix,
          string prefix = null)
        {
            if (this.depInfoReader == null)
                return (AssetBundleInfo)null;
            AssetBundleLoader loader = this.CreateLoader(hash, path, suffix, prefix);
            if (loader == null)
                return (AssetBundleInfo)null;
            this._thisTimeLoaderSet.Add(loader);
            if (loader.isComplete)
                return loader.bundleInfo;
            this._isCurrentLoading = true;
            if (loader.state < LoadState.State_Loading)
                this._nonCompleteLoaderSet.Add(loader);
            this.StartLoadImm();
            return loader.bundleInfo;
        }

        public bool CheckInDep(uint hash) => this.depInfoReader != null && this._depInfoReader.GetAssetBundleInfo(hash) != null;

        internal AssetBundleLoader CreateLoader(
          uint abFileName,
          string location = null,
          string suffix = null,
          string prefix = null)
        {
            AssetBundleLoader loader;
            if (this._loaderCache.ContainsKey(abFileName))
            {
                loader = this._loaderCache[abFileName];
            }
            else
            {
                AssetBundleData assetBundleData = this._depInfoReader.GetAssetBundleInfo(abFileName);
                if (assetBundleData == null)
                {
                    uint num = prefix == null ? this._defaultHash : XSingleton<XCommon>.singleton.XHashLowerRelpaceDot(0U, prefix);
                    if (location != null)
                        num = XSingleton<XCommon>.singleton.XHashLowerRelpaceDot(num, location);
                    if (suffix != null)
                        num = XSingleton<XCommon>.singleton.XHashLowerRelpaceDot(num, suffix);
                    assetBundleData = this._depInfoReader.GetAssetBundleInfoByShortName(num);
                }
                if (assetBundleData == null)
                    return (AssetBundleLoader)null;
                loader = this.CreateLoader();
                loader.bundleManager = this;
                loader.bundleData = assetBundleData;
                loader.bundleName = assetBundleData.fullName;
                this._loaderCache[abFileName] = loader;
            }
            return loader;
        }

        protected virtual AssetBundleLoader CreateLoader()
        {
            switch (Application.platform)
            {
                case RuntimePlatform.IPhonePlayer:
                    return (AssetBundleLoader)new IOSAssetBundleLoader();
                case RuntimePlatform.Android:
                    return (AssetBundleLoader)new AndroidAssetBundleLoader();
                default:
                    return (AssetBundleLoader)new MobileAssetBundleLoader();
            }
        }

        private void StartLoad()
        {
            if (this._nonCompleteLoaderSet.Count <= 0)
                return;
            List<AssetBundleLoader> toRelease = ListPool<AssetBundleLoader>.Get();
            toRelease.AddRange((IEnumerable<AssetBundleLoader>)this._nonCompleteLoaderSet);
            this._nonCompleteLoaderSet.Clear();
            List<AssetBundleLoader>.Enumerator enumerator = toRelease.GetEnumerator();
            while (enumerator.MoveNext())
                this._currentLoadQueue.Add(enumerator.Current);
            this._progress = new AssetBundleLoadProgress();
            this._progress.total = this._currentLoadQueue.Count;
            enumerator = toRelease.GetEnumerator();
            while (enumerator.MoveNext())
                enumerator.Current.Load();
            ListPool<AssetBundleLoader>.Release(toRelease);
        }

        private void StartLoadImm()
        {
            if (this._nonCompleteLoaderSet.Count <= 0)
                return;
            if (this._nonCompleteLoaderSet.Count == 1)
            {
                HashSet<AssetBundleLoader>.Enumerator enumerator = this._nonCompleteLoaderSet.GetEnumerator();
                enumerator.MoveNext();
                this._currentLoadQueue.Add(enumerator.Current);
                this._nonCompleteLoaderSet.Clear();
                this._progress.percent = 0.0f;
                this._progress.complete = 0;
                this._progress.loader = (AssetBundleLoader)null;
                this._progress.total = this._currentLoadQueue.Count;
                enumerator.Current.LoadImm();
            }
            else
            {
                List<AssetBundleLoader> toRelease = ListPool<AssetBundleLoader>.Get();
                toRelease.AddRange((IEnumerable<AssetBundleLoader>)this._nonCompleteLoaderSet);
                this._nonCompleteLoaderSet.Clear();
                List<AssetBundleLoader>.Enumerator enumerator = toRelease.GetEnumerator();
                while (enumerator.MoveNext())
                    this._currentLoadQueue.Add(enumerator.Current);
                this._progress.percent = 0.0f;
                this._progress.complete = 0;
                this._progress.loader = (AssetBundleLoader)null;
                this._progress.total = this._currentLoadQueue.Count;
                enumerator = toRelease.GetEnumerator();
                while (enumerator.MoveNext())
                    enumerator.Current.LoadImm();
                ListPool<AssetBundleLoader>.Release(toRelease);
            }
        }

        public void RemoveAll()
        {
            this._currentLoadQueue.Clear();
            this._requestQueue.Clear();
            Dictionary<uint, AssetBundleInfo>.Enumerator enumerator = this._loadedAssetBundle.GetEnumerator();
            while (enumerator.MoveNext())
                enumerator.Current.Value.Dispose();
            this._loadedAssetBundle.Clear();
            this._loaderCache.Clear();
            this._requestUnloadBundleQueue.Clear();
        }

        public AssetBundleInfo GetBundleInfo(uint key)
        {
            Dictionary<uint, AssetBundleInfo>.Enumerator enumerator = this._loadedAssetBundle.GetEnumerator();
            while (enumerator.MoveNext())
            {
                AssetBundleInfo assetBundleInfo = enumerator.Current.Value;
                if ((int)assetBundleInfo.bundleName == (int)key)
                    return assetBundleInfo;
            }
            return (AssetBundleInfo)null;
        }

        internal void RequestLoadBundle(AssetBundleLoader loader)
        {
            if (this._requestRemain < 0)
                this._requestRemain = 0;
            if (this._requestRemain == 0)
                this._requestQueue.Enqueue(loader);
            else
                this.LoadBundle(loader);
        }

        internal void RequestLoadBundleImm(AssetBundleLoader loader)
        {
            if (this._requestRemain < 0)
                this._requestRemain = 0;
            if (this._requestRemain == 0)
                this._requestQueue.Enqueue(loader);
            else
                this.LoadBundleImm(loader);
        }

        private void CheckRequestList()
        {
            while (this._requestRemain > 0 && this._requestQueue.Count > 0)
                this.LoadBundle(this._requestQueue.Dequeue());
        }

        private void LoadBundle(AssetBundleLoader loader)
        {
            if (loader.isComplete)
                return;
            loader.LoadBundle();
            --this._requestRemain;
        }

        private void LoadBundleImm(AssetBundleLoader loader)
        {
            if (loader.isComplete)
                return;
            loader.LoadBundleImm();
            --this._requestRemain;
        }

        internal void LoadError(AssetBundleLoader loader) => this.LoadComplete(loader);

        internal void LoadComplete(AssetBundleLoader loader)
        {
            ++this._requestRemain;
            this._currentLoadQueue.Remove(loader);
            if (this.onProgress != null)
            {
                this._progress.loader = loader;
                this._progress.complete = this._progress.total - this._currentLoadQueue.Count;
                this.onProgress(this._progress);
            }
            if (this._currentLoadQueue.Count == 0 && this._nonCompleteLoaderSet.Count == 0)
            {
                this._isCurrentLoading = false;
                HashSet<AssetBundleLoader>.Enumerator enumerator = this._thisTimeLoaderSet.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    AssetBundleLoader current = enumerator.Current;
                    if (current.bundleInfo != null)
                        current.bundleInfo.ResetLifeTime();
                }
                this._thisTimeLoaderSet.Clear();
            }
            else
                this.CheckRequestList();
        }

        internal AssetBundleInfo CreateBundleInfo(
          AssetBundleLoader loader,
          AssetBundleInfo abi = null,
          AssetBundle assetBundle = null)
        {
            if (abi == null)
                abi = new AssetBundleInfo();
            abi.bundleName = loader.bundleName;
            abi.bundle = assetBundle;
            abi.data = loader.bundleData;
            this._loadedAssetBundle[abi.bundleName] = abi;
            ++this._bundleCount;
            return abi;
        }

        public void DeleteBundleCount() => --this._bundleCount;

        internal void RemoveBundleInfo(AssetBundleInfo abi)
        {
            abi.Dispose();
            this._loadedAssetBundle.Remove(abi.bundleName);
        }

        public bool isCurrentLoading => this._isCurrentLoading;

        private void CheckUnusedBundle() => this.UnloadUnusedBundle();

        public void UnloadUnusedBundle(bool force = false)
        {
            bool flag1 = ((this._isCurrentLoading ? 0 : (!XSingleton<XResourceLoaderMgr>.singleton.isCurrentLoading ? 1 : 0)) | (force ? 1 : 0)) != 0;
            if (!flag1)
                return;
            List<uint> toRelease = ListPool<uint>.Get();
            toRelease.AddRange((IEnumerable<uint>)this._loadedAssetBundle.Keys);
            int num1 = force ? 100000 : 20;
            int num2 = 0;
            bool flag2;
            do
            {
                flag2 = false;
                for (int index = 0; index < toRelease.Count & flag1 && num2 < num1; ++index)
                {
                    AssetBundleInfo abi = this._loadedAssetBundle[toRelease[index]];
                    if (abi.isUnused)
                    {
                        flag2 = true;
                        ++num2;
                        this.RemoveBundleInfo(abi);
                        toRelease.RemoveAt(index);
                        --index;
                    }
                }
            }
            while (flag2 & flag1 && num2 < num1);
            ListPool<uint>.Release(toRelease);
            while (this._requestUnloadBundleQueue.Count > 0 & flag1 && num2 < num1)
            {
                AssetBundleInfo assetBundleInfo = this._requestUnloadBundleQueue.Dequeue();
                if (assetBundleInfo != null)
                {
                    assetBundleInfo.UnloadBundle();
                    ++num2;
                }
            }
        }

        public void UnloadNotUsedLoader()
        {
            List<uint> uintList = ListPool<uint>.Get();
            uintList.AddRange((IEnumerable<uint>)this._loadedAssetBundle.Keys);
            List<AssetBundleLoader> toRelease = ListPool<AssetBundleLoader>.Get();
            toRelease.AddRange((IEnumerable<AssetBundleLoader>)this._nonCompleteLoaderSet);
            toRelease.AddRange((IEnumerable<AssetBundleLoader>)this._currentLoadQueue);
            List<AssetBundleLoader>.Enumerator enumerator = toRelease.GetEnumerator();
            while (enumerator.MoveNext())
                this.RemoveLoadingLoader(enumerator.Current.bundleName, uintList);
            for (int index = 0; index < uintList.Count; index = index - 1 + 1)
            {
                this.RemoveBundleInfo(this._loadedAssetBundle[uintList[index]]);
                uintList.RemoveAt(index);
            }
            ListPool<uint>.Release(uintList);
            ListPool<AssetBundleLoader>.Release(toRelease);
        }

        private void RemoveLoadingLoader(uint hash, List<uint> list)
        {
            AssetBundleData assetBundleInfo = this._depInfoReader.GetAssetBundleInfo(hash);
            list.Remove(assetBundleInfo.fullName);
            if (assetBundleInfo.dependencies == null)
                return;
            for (int index = 0; index < assetBundleInfo.dependencies.Length; ++index)
                this.RemoveLoadingLoader(assetBundleInfo.dependencies[index], list);
        }

        public void AddUnloadBundleQueue(AssetBundleInfo info)
        {
            this._requestUnloadBundleQueue.Enqueue(info);
            if (this._requestUnloadBundleQueue.Count <= 3)
                return;
            this.UnloadUnusedBundle();
        }

        public void RemoveBundle(uint key)
        {
            AssetBundleInfo bundleInfo = this.GetBundleInfo(key);
            if (bundleInfo == null)
                return;
            this.RemoveBundleInfo(bundleInfo);
        }

        public delegate void LoadAssetCompleteHandler(AssetBundleInfo info, int handlerID);

        public delegate void LoaderCompleteHandler(AssetBundleLoader info);

        public delegate void LoadProgressHandler(AssetBundleLoadProgress progress);
    }
}
