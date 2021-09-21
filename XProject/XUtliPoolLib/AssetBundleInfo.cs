// Decompiled with JetBrains decompiler
// Type: XUtliPoolLib.AssetBundleInfo
// Assembly: XUtliPoolLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D0B5E37-6957-4C11-AC8A-5F5BE652A435
// Assembly location: F:\龙之谷\Client\Assets\Lib\XUtliPoolLib.dll

using System;
using System.Collections.Generic;
using UnityEngine;

namespace XUtliPoolLib
{
    public class AssetBundleInfo
    {
        public AssetBundleInfo.OnUnloadedHandler onUnloaded;
        internal AssetBundle bundle;
        public uint bundleName;
        public AssetBundleData data;
        public float minLifeTime = 2f;
        private float _readyTime;
        private bool _isReady;
        private UnityEngine.Object _mainObject;
        private HashSet<AssetBundleInfo> deps = (HashSet<AssetBundleInfo>)null;
        private List<uint> depChildren = (List<uint>)null;
        private List<WeakReference> references = new List<WeakReference>();

        [SerializeField]
        public int refCount { get; private set; }

        public void AddDependency(AssetBundleInfo target)
        {
            if (target == null)
                return;
            if (this.deps == null)
                this.deps = new HashSet<AssetBundleInfo>();
            if (this.deps.Add(target))
            {
                target.Retain();
                if (target.depChildren == null)
                    target.depChildren = new List<uint>();
                target.depChildren.Add(this.bundleName);
            }
        }

        public void ResetLifeTime()
        {
            if (!this._isReady)
                return;
            this._readyTime = Time.time;
        }

        public void Retain() => ++this.refCount;

        public void Release() => --this.refCount;

        public void Retain(UnityEngine.Object owner)
        {
            if (owner == (UnityEngine.Object)null)
                throw new Exception("Please set the user!");
            for (int index = 0; index < this.references.Count; ++index)
            {
                if (owner.Equals(this.references[index].Target))
                    return;
            }
            this.references.Add(new WeakReference((object)owner));
        }

        public void Release(object owner)
        {
            for (int index = 0; index < this.references.Count; ++index)
            {
                if (this.references[index].Target == owner)
                {
                    this.references.RemoveAt(index);
                    break;
                }
            }
        }

        public virtual GameObject Instantiate() => this.Instantiate(true);

        public virtual GameObject Instantiate(bool enable)
        {
            if (!(this.mainObject != (UnityEngine.Object)null) || !(this.mainObject is GameObject))
                return (GameObject)null;
            GameObject mainObject = this.mainObject as GameObject;
            mainObject.SetActive(enable);
            GameObject gameObject = XCommon.Instantiate<GameObject>(mainObject);
            gameObject.name = mainObject.name;
            this.Retain((UnityEngine.Object)gameObject);
            return gameObject;
        }

        public virtual GameObject Instantiate(
          Vector3 position,
          Quaternion rotation,
          bool enable = true)
        {
            if (!(this.mainObject != (UnityEngine.Object)null) || !(this.mainObject is GameObject))
                return (GameObject)null;
            GameObject mainObject = this.mainObject as GameObject;
            mainObject.SetActive(enable);
            GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(mainObject, position, rotation, (Transform)null);
            gameObject.name = mainObject.name;
            this.Retain((UnityEngine.Object)gameObject);
            return gameObject;
        }

        public UnityEngine.Object Require(UnityEngine.Object user)
        {
            this.Retain(user);
            return this.mainObject;
        }

        public UnityEngine.Object Require(Component c, bool autoBindGameObject) => autoBindGameObject && (bool)(UnityEngine.Object)c && (bool)(UnityEngine.Object)c.gameObject ? this.Require((UnityEngine.Object)c.gameObject) : this.Require((UnityEngine.Object)c);

        private int UpdateReference()
        {
            for (int index = 0; index < this.references.Count; ++index)
            {
                if (!(bool)(UnityEngine.Object)this.references[index].Target)
                {
                    this.references.RemoveAt(index);
                    --index;
                }
            }
            return this.references.Count;
        }

        public bool isUnused => this._isReady && (double)Time.time - (double)this._readyTime > (double)this.minLifeTime && this.refCount <= 0 && this.UpdateReference() == 0;

        public virtual void Dispose()
        {
            this.UnloadBundle();
            if (this.deps != null)
            {
                HashSet<AssetBundleInfo>.Enumerator enumerator = this.deps.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    AssetBundleInfo current = enumerator.Current;
                    if (current.depChildren != null)
                        current.depChildren.Remove(this.bundleName);
                    current.Release();
                }
                this.deps.Clear();
            }
            this.references.Clear();
            if (this.onUnloaded != null)
                this.onUnloaded(this);
            if (!(this._mainObject is GameObject) && !(this._mainObject is ScriptableObject) && !(this._mainObject is Material))
                Resources.UnloadAsset(this._mainObject);
            else
                UnityEngine.Object.Destroy(this._mainObject);
            this._mainObject = (UnityEngine.Object)null;
        }

        public bool isReady
        {
            get => this._isReady;
            set => this._isReady = value;
        }

        public AsyncOperation LoadAsync(string name, System.Type t) => this._mainObject == (UnityEngine.Object)null && this._isReady ? (AsyncOperation)this.bundle.LoadAssetAsync(name, t) : (AsyncOperation)null;

        public void AsyncLoadFinish(UnityEngine.Object asset)
        {
            if (!(this._mainObject == (UnityEngine.Object)null) || !this._isReady)
                return;
            this.Release();
            this._mainObject = asset;
            if (this.data.compositeType == AssetBundleExportType.Root && (UnityEngine.Object)XSingleton<XUpdater.XUpdater>.singleton.ABManager != (UnityEngine.Object)null)
                XSingleton<XUpdater.XUpdater>.singleton.ABManager.AddUnloadBundleQueue(this);
        }

        public virtual UnityEngine.Object mainObject
        {
            get
            {
                if (this._mainObject == (UnityEngine.Object)null && this._isReady)
                {
                    this._mainObject = this.bundle.LoadAsset(this.bundle.GetAllAssetNames()[0]);
                    if (this._mainObject != (UnityEngine.Object)null && this.data.compositeType == AssetBundleExportType.Root && (UnityEngine.Object)XSingleton<XUpdater.XUpdater>.singleton.ABManager != (UnityEngine.Object)null)
                        XSingleton<XUpdater.XUpdater>.singleton.ABManager.AddUnloadBundleQueue(this);
                }
                return this._mainObject;
            }
        }

        private T LoadAsset<T>(string name) where T : UnityEngine.Object => this.bundle.LoadAsset(name, typeof(T)) as T;

        public void UnloadBundle()
        {
            if ((UnityEngine.Object)this.bundle != (UnityEngine.Object)null)
            {
                if (AssetBundleManager.enableLog)
                    XSingleton<XDebug>.singleton.AddLog("Unload : " + (object)this.data.compositeType + " >> " + (object)this.bundleName + "(" + this.data.debugName != null ? this.data.debugName : ")");
                this.bundle.Unload(false);
                if ((UnityEngine.Object)XSingleton<XUpdater.XUpdater>.singleton.ABManager != (UnityEngine.Object)null)
                    XSingleton<XUpdater.XUpdater>.singleton.ABManager.DeleteBundleCount();
            }
            this.bundle = (AssetBundle)null;
        }

        public delegate void OnUnloadedHandler(AssetBundleInfo abi);
    }
}
