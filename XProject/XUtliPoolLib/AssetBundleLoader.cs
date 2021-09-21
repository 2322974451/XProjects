// Decompiled with JetBrains decompiler
// Type: XUtliPoolLib.AssetBundleLoader
// Assembly: XUtliPoolLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D0B5E37-6957-4C11-AC8A-5F5BE652A435
// Assembly location: F:\龙之谷\Client\Assets\Lib\XUtliPoolLib.dll

using UnityEngine;

namespace XUtliPoolLib
{
    public abstract class AssetBundleLoader
    {
        internal AssetBundleManager.LoadAssetCompleteHandler onComplete;
        public int loadHandlerID;
        public uint bundleName;
        public AssetBundleData bundleData;
        public AssetBundleInfo bundleInfo;
        public AssetBundleManager bundleManager;
        public LoadState state = LoadState.State_None;
        protected AssetBundleLoader[] depLoaders;

        public virtual void Load()
        {
        }

        public virtual void LoadImm()
        {
        }

        public virtual void LoadBundle()
        {
        }

        public virtual void LoadBundleImm()
        {
        }

        public virtual bool isComplete => this.state == LoadState.State_Error || this.state == LoadState.State_Complete;

        protected virtual void Complete()
        {
            if (this.onComplete != null)
            {
                AssetBundleManager.LoadAssetCompleteHandler onComplete = this.onComplete;
                this.onComplete = (AssetBundleManager.LoadAssetCompleteHandler)null;
                onComplete(this.bundleInfo, this.loadHandlerID);
            }
            this.bundleManager.LoadComplete(this);
        }

        protected virtual void Error()
        {
            if (this.onComplete != null)
            {
                AssetBundleManager.LoadAssetCompleteHandler onComplete = this.onComplete;
                this.onComplete = (AssetBundleManager.LoadAssetCompleteHandler)null;
                onComplete(this.bundleInfo, this.loadHandlerID);
            }
            this.bundleManager.LoadError(this);
        }

        protected bool UnloadNotLoadingBundle(AssetBundle bundle)
        {
            if (!((Object)bundle == (Object)null))
                return false;
            int bundleCount = XSingleton<XUpdater.XUpdater>.singleton.ABManager.BundleCount;
            XSingleton<XUpdater.XUpdater>.singleton.ABManager.UnloadNotUsedLoader();
            Resources.UnloadUnusedAssets();
            XSingleton<XDebug>.singleton.AddErrorLog("AssetBundle Count: ", bundleCount.ToString(), " , ", XSingleton<XUpdater.XUpdater>.singleton.ABManager.BundleCount.ToString());
            return true;
        }
    }
}
