

using System.Collections.Generic;
using UnityEngine;

namespace XUtliPoolLib
{
    public class LoadAsyncTask
    {
        public EAsyncLoadState loadState = EAsyncLoadState.EFree;
        public System.Type loadType = (System.Type)null;
        public uint hash = 0;
        public string location = "";
        public string ext = "";
        public bool isSharedRes = true;
        public UnityEngine.Object asset = (UnityEngine.Object)null;
        public List<LoadInfo> loadCbList = new List<LoadInfo>();
        private AssetBundleInfo assetBundleInfo = (AssetBundleInfo)null;
        public object cbObj = (object)null;

        public void Clear()
        {
            this.loadState = EAsyncLoadState.EFree;
            this.location = "";
            this.hash = 0U;
            this.asset = (UnityEngine.Object)null;
            this.loadCbList.Clear();
            this.loadType = (System.Type)null;
            this.assetBundleInfo = (AssetBundleInfo)null;
            this.cbObj = (object)null;
        }

        public bool Update()
        {
            switch (this.loadState)
            {
                case EAsyncLoadState.EFree:
                    return false;
                case EAsyncLoadState.EPreLoading:
                    if ((UnityEngine.Object)XSingleton<XUpdater.XUpdater>.singleton.ABManager != (UnityEngine.Object)null)
                        this.assetBundleInfo = XSingleton<XUpdater.XUpdater>.singleton.ABManager.LoadImm(this.hash, this.location, this.ext);
                    if (this.assetBundleInfo == null)
                    {
                        this.asset = Resources.Load(this.location, this.loadType);
                        ++XResourceLoaderMgr.resourceLoadCount;
                    }
                    else
                    {
                        string str = "";
                        int num = this.location.LastIndexOf("/");
                        str = num <= 0 || num + 1 >= this.location.Length ? this.location : this.location.Substring(num + 1);
                        this.asset = this.assetBundleInfo.mainObject;
                        ++XResourceLoaderMgr.abLoadCount;
                    }
                    this.loadState = EAsyncLoadState.ELoading;
                    return false;
                case EAsyncLoadState.ELoading:
                    this.LoadComplete();
                    this.loadState = EAsyncLoadState.EFree;
                    return true;
                case EAsyncLoadState.EInstance:
                    if (this.asset != (UnityEngine.Object)null)
                    {
                        int index = 0;
                        for (int count = this.loadCbList.Count; index < count; ++index)
                        {
                            LoadInfo loadCb = this.loadCbList[index];
                            if (loadCb.loadCb != null)
                            {
                                GameObject gameObject = XCommon.Instantiate<UnityEngine.Object>(this.asset) as GameObject;
                                ++XResourceLoaderMgr.instanceCount;
                                XSingleton<XResourceLoaderMgr>.singleton.AssetsRefRetain(this.hash);
                                XSingleton<XResourceLoaderMgr>.singleton.LogReverseID((UnityEngine.Object)gameObject, this.hash);
                                loadCb.loadCb((UnityEngine.Object)gameObject, this.cbObj);
                            }
                        }
                        this.loadCbList.Clear();
                    }
                    return true;
                default:
                    return false;
            }
        }

        public void CancelLoad(LoadCallBack cb)
        {
            for (int index = this.loadCbList.Count - 1; index >= 0; --index)
            {
                if (this.loadCbList[index].loadCb == cb)
                    this.loadCbList.RemoveAt(index);
            }
        }

        private void ReturnNull()
        {
            int index = 0;
            for (int count = this.loadCbList.Count; index < count; ++index)
            {
                LoadInfo loadCb = this.loadCbList[index];
                if (loadCb.loadCb != null)
                    loadCb.loadCb((UnityEngine.Object)null, this.cbObj);
            }
            this.loadCbList.Clear();
        }

        private void LoadComplete()
        {
            if (this.asset == (UnityEngine.Object)null)
            {
                XResourceLoaderMgr.LoadErrorLog(this.location);
                this.ReturnNull();
            }
            else if (XSingleton<XResourceLoaderMgr>.singleton.useNewMgr)
            {
                XResourceLoaderMgr.UniteObjectInfo uoi1;
                XSingleton<XResourceLoaderMgr>.singleton.GetUOIAsync(this.location, this.hash, (UnityEngine.Object)null, this.assetBundleInfo, this.isSharedRes, out uoi1);
                if (uoi1 == null)
                    return;
                int index = 0;
                for (int count = this.loadCbList.Count; index < count; ++index)
                {
                    LoadInfo loadCb = this.loadCbList[index];
                    if (loadCb.loadCb != null)
                    {
                        UnityEngine.Object uoi2 = XSingleton<XResourceLoaderMgr>.singleton.GetUOI(uoi1, this.isSharedRes, loadCb.usePool);
                        loadCb.loadCb(uoi2, this.cbObj);
                    }
                }
                this.loadCbList.Clear();
            }
            else
            {
                XSingleton<XResourceLoaderMgr>.singleton.AddAssetInPool(this.asset, this.hash, this.assetBundleInfo);
                int index = 0;
                for (int count = this.loadCbList.Count; index < count; ++index)
                {
                    LoadInfo loadCb = this.loadCbList[index];
                    if (loadCb.loadCb != null)
                    {
                        if (this.isSharedRes)
                        {
                            this.GetSharedResourceCb(loadCb.loadCb, this.assetBundleInfo);
                        }
                        else
                        {
                            UnityEngine.Object o = (UnityEngine.Object)null;
                            if (loadCb.usePool && XSingleton<XResourceLoaderMgr>.singleton.GetInObjectPool(ref o, this.hash))
                                loadCb.loadCb(o, this.cbObj);
                            else
                                this.CreateFromPrefabCb(loadCb.loadCb, this.assetBundleInfo);
                        }
                    }
                }
                this.loadCbList.Clear();
            }
        }

        private void GetSharedResourceCb(LoadCallBack loadCb, AssetBundleInfo info = null)
        {
            UnityEngine.Object assetInPool = XSingleton<XResourceLoaderMgr>.singleton.GetAssetInPool(this.hash);
            XSingleton<XResourceLoaderMgr>.singleton.AssetsRefRetain(this.hash);
            loadCb(assetInPool, this.cbObj);
        }

        private void CreateFromPrefabCb(LoadCallBack loadCb, AssetBundleInfo info = null)
        {
            GameObject gameObject = XCommon.Instantiate<UnityEngine.Object>(XSingleton<XResourceLoaderMgr>.singleton.GetAssetInPool(this.hash)) as GameObject;
            XSingleton<XResourceLoaderMgr>.singleton.AssetsRefRetain(this.hash);
            XSingleton<XResourceLoaderMgr>.singleton.LogReverseID((UnityEngine.Object)gameObject, this.hash);
            loadCb((UnityEngine.Object)gameObject, this.cbObj);
        }
    }
}
