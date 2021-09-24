

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

namespace XUtliPoolLib
{
    public sealed class XResourceLoaderMgr : XSingleton<XResourceLoaderMgr>
    {
        public static uint Preload = 1;
        public static uint SharedResource = 2;
        public static uint DontDestroyAsset = 4;
        public static uint Degeneration = 8;
        public static readonly Vector3 Far_Far_Away = new Vector3(0.0f, -1000f, 0.0f);
        public bool useNewMgr = false;
        public bool dontDestroy = false;
        private Dictionary<uint, AssetBundleInfo> _bundle_pool = new Dictionary<uint, AssetBundleInfo>();
        private Dictionary<uint, int> _asset_ref_count = new Dictionary<uint, int>();
        private Dictionary<uint, Queue<UnityEngine.Object>> _object_pool = new Dictionary<uint, Queue<UnityEngine.Object>>();
        private Dictionary<uint, UnityEngine.Object> _asset_pool = new Dictionary<uint, UnityEngine.Object>();
        private Dictionary<uint, UnityEngine.Object> _script_pool = new Dictionary<uint, UnityEngine.Object>();
        private Dictionary<int, uint> _reverse_map = new Dictionary<int, uint>();
        private Dictionary<uint, XResourceLoaderMgr.UniteObjectInfo> m_assetPool = new Dictionary<uint, XResourceLoaderMgr.UniteObjectInfo>();
        private Dictionary<int, XResourceLoaderMgr.UniteObjectInfo> m_instanceIDAssetMap = new Dictionary<int, XResourceLoaderMgr.UniteObjectInfo>();
        private Queue<XResourceLoaderMgr.UniteObjectInfo> m_objInfoPool = new Queue<XResourceLoaderMgr.UniteObjectInfo>();
        private XResourceLoaderMgr.UniteObjectInfo m_degenerationQueue = (XResourceLoaderMgr.UniteObjectInfo)null;
        private XResourceLoaderMgr.UniteObjectInfo m_currentDegeneration = (XResourceLoaderMgr.UniteObjectInfo)null;
        private List<FloatCurve> m_curveData = (List<FloatCurve>)null;
        public static bool UseCurveTable = false;
        private BeforeUnityUnLoadResource m_BeforeUnityUnLoadResourceCb = (BeforeUnityUnLoadResource)null;
        private XmlSerializer[] xmlSerializerCache = new XmlSerializer[2];
        private MemoryStream shareMemoryStream = new MemoryStream(8192);
        private List<LoadAsyncTask> _async_task_list = new List<LoadAsyncTask>();
        private List<IDelayLoad> delayUpdateList = new List<IDelayLoad>();
        public static double delayTime = 0.5;
        private double currentDelayTime = -1.0;
        public bool DelayLoad = false;
        public bool isCurrentLoading = false;
        public float maxLoadThresholdTime = 0.1f;
        public static int resourceLoadCount = 0;
        public static int abLoadCount = 0;
        public static int instanceCount = 0;
        private uint _prefixHash = 0;

        public XResourceLoaderMgr()
        {
            this.xmlSerializerCache[0] = new XmlSerializer(typeof(XSkillData));
            this.xmlSerializerCache[1] = new XmlSerializer(typeof(XCutSceneData));
            this._prefixHash = XSingleton<XCommon>.singleton.XHashLowerRelpaceDot(this._prefixHash, "Assets.Resources.");
        }

        public void LoadServerCurve(string location)
        {
            TextAsset sharedResource = this.GetSharedResource<TextAsset>(location, ".bytes");
            if ((UnityEngine.Object)sharedResource == (UnityEngine.Object)null || sharedResource.bytes == null)
                XResourceLoaderMgr.LoadErrorLog(location);
            XBinaryReader reader = XBinaryReader.Get();
            reader.Init(sharedResource);
            int capacity = reader.ReadInt32();
            XSingleton<XDebug>.singleton.AddLog("loadServerCurve" + (object)capacity);
            this.m_curveData = new List<FloatCurve>(capacity);
            for (int index1 = 0; index1 < capacity; ++index1)
            {
                FloatCurve floatCurve = new FloatCurve();
                floatCurve.namehash = reader.ReadUInt32();
                floatCurve.maxValue = reader.ReadInt16();
                floatCurve.landValue = reader.ReadInt16();
                int length = reader.ReadInt32();
                if (length > 0)
                {
                    floatCurve.value = new short[length];
                    for (int index2 = 0; index2 < length; ++index2)
                        floatCurve.value[index2] = reader.ReadInt16();
                }
                this.m_curveData.Add(floatCurve);
            }
            XBinaryReader.Return(reader);
            this.UnSafeDestroyShareResource(location, ".bytes", (UnityEngine.Object)sharedResource);
        }

        public void ReleasePool()
        {
            if (this.useNewMgr)
            {
                foreach (KeyValuePair<uint, XResourceLoaderMgr.UniteObjectInfo> keyValuePair in this.m_assetPool)
                {
                    XResourceLoaderMgr.UniteObjectInfo uniteObjectInfo = keyValuePair.Value;
                    if (uniteObjectInfo.asset != (UnityEngine.Object)null)
                    {
                        if (!uniteObjectInfo.IsDontDestroyAsset && !uniteObjectInfo.IsDegeneration)
                        {
                            keyValuePair.Value.ClearPool();
                            if (uniteObjectInfo.HasPreload && uniteObjectInfo.refCount == 0)
                            {
                                uniteObjectInfo.IsDegeneration = true;
                                uniteObjectInfo.degenerationTime = 2f;
                                if (this.m_degenerationQueue == null)
                                {
                                    this.m_degenerationQueue = uniteObjectInfo;
                                    this.m_currentDegeneration = uniteObjectInfo;
                                }
                                else if (this.m_currentDegeneration != null)
                                {
                                    this.m_currentDegeneration.next = uniteObjectInfo;
                                    this.m_currentDegeneration = uniteObjectInfo;
                                }
                                if (uniteObjectInfo.asset != (UnityEngine.Object)null)
                                    this.m_instanceIDAssetMap.Remove(uniteObjectInfo.asset.GetInstanceID());
                            }
                            else
                                XSingleton<XDebug>.singleton.AddWarningLog2("Asset Not Release:{0} Ref:{1}", (object)uniteObjectInfo.loc, (object)uniteObjectInfo.refCount);
                        }
                    }
                    else
                        XSingleton<XDebug>.singleton.AddWarningLog2("Asset null:{0} Ref:{1}", (object)uniteObjectInfo.loc, (object)uniteObjectInfo.refCount);
                }
                this.DelayDestroy(0.0f, true);
            }
            else
            {
                foreach (KeyValuePair<uint, Queue<UnityEngine.Object>> keyValuePair in this._object_pool)
                {
                    while (keyValuePair.Value.Count > 0)
                        this.UnSafeDestroy(keyValuePair.Value.Dequeue(), false, true);
                }
                this._object_pool.Clear();
                this._asset_pool.Clear();
                this._script_pool.Clear();
                List<uint> uintList = new List<uint>((IEnumerable<uint>)this._asset_ref_count.Keys);
                for (int index = 0; index < uintList.Count; ++index)
                    this._asset_ref_count[uintList[index]] = 0;
                foreach (KeyValuePair<uint, AssetBundleInfo> keyValuePair in this._bundle_pool)
                    keyValuePair.Value.Release();
                this._bundle_pool.Clear();
            }
            XSingleton<XDebug>.singleton.AddWarningLog2("ResourceLoad:{0} ABLoad:{1} Instance:{2}", (object)XResourceLoaderMgr.resourceLoadCount, (object)XResourceLoaderMgr.abLoadCount, (object)XResourceLoaderMgr.instanceCount);
            XResourceLoaderMgr.resourceLoadCount = 0;
            XResourceLoaderMgr.abLoadCount = 0;
            XResourceLoaderMgr.instanceCount = 0;
            this.isCurrentLoading = false;
            for (int index = 0; index < this._async_task_list.Count; ++index)
                this._async_task_list[index].Clear();
            this._async_task_list.Clear();
            this.shareMemoryStream.Close();
            this.shareMemoryStream = new MemoryStream(8192);
            XSingleton<XEngineCommandMgr>.singleton.Clear();
            this.delayUpdateList.Clear();
        }

        public void DebugPrint()
        {
            foreach (KeyValuePair<uint, XResourceLoaderMgr.UniteObjectInfo> keyValuePair in this.m_assetPool)
            {
                XResourceLoaderMgr.UniteObjectInfo uniteObjectInfo = keyValuePair.Value;
                if (uniteObjectInfo.asset != (UnityEngine.Object)null)
                {
                    if (!uniteObjectInfo.IsDontDestroyAsset)
                        XSingleton<XDebug>.singleton.AddWarningLog2("Asset Not Release:{0} Ref:{1}", (object)uniteObjectInfo.loc, (object)uniteObjectInfo.refCount);
                }
                else
                    XSingleton<XDebug>.singleton.AddWarningLog2("Asset null:{0} Ref:{1}", (object)uniteObjectInfo.loc, (object)uniteObjectInfo.refCount);
            }
        }

        public void SetUnloadCallback(BeforeUnityUnLoadResource cb) => this.m_BeforeUnityUnLoadResourceCb = cb;

        public void CallUnloadCallback()
        {
            if (this.m_BeforeUnityUnLoadResourceCb == null)
                return;
            this.m_BeforeUnityUnLoadResourceCb();
        }

        private uint Hash(string location, string ext) => XSingleton<XCommon>.singleton.XHashLowerRelpaceDot(XSingleton<XCommon>.singleton.XHashLowerRelpaceDot(this._prefixHash, location), ext);

        public Stream ReadText(string location, string suffix, bool error = true)
        {
            TextAsset sharedResource = this.GetSharedResource<TextAsset>(location, suffix, error);
            if ((UnityEngine.Object)sharedResource == (UnityEngine.Object)null)
            {
                if (!error)
                    return (Stream)null;
                XResourceLoaderMgr.LoadErrorLog(location);
            }
            try
            {
                this.shareMemoryStream.SetLength(0L);
                this.shareMemoryStream.Write(sharedResource.bytes, 0, sharedResource.bytes.Length);
                this.shareMemoryStream.Seek(0L, SeekOrigin.Begin);
                return (Stream)this.shareMemoryStream;
            }
            catch (Exception ex)
            {
                XSingleton<XDebug>.singleton.AddErrorLog(ex.Message, location);
                return (Stream)this.shareMemoryStream;
            }
            finally
            {
                this.UnSafeDestroyShareResource(location, suffix, (UnityEngine.Object)sharedResource);
            }
        }

        public void ClearStream(Stream s)
        {
            if (s == null)
                return;
            if (s == this.shareMemoryStream)
                this.shareMemoryStream.SetLength(0L);
            else
                s.Close();
        }

        public XBinaryReader ReadBinary(
          string location,
          string suffix,
          bool readShareResource,
          bool error = true)
        {
            TextAsset sharedResource = this.GetSharedResource<TextAsset>(location, suffix, error);
            if ((UnityEngine.Object)sharedResource == (UnityEngine.Object)null)
            {
                if (!error)
                    return (XBinaryReader)null;
                XResourceLoaderMgr.LoadErrorLog(location);
            }
            try
            {
                XBinaryReader xbinaryReader = XBinaryReader.Get();
                xbinaryReader.Init(sharedResource);
                this.UnSafeDestroyShareResource(location, suffix, (UnityEngine.Object)sharedResource);
                return xbinaryReader;
            }
            catch (Exception ex)
            {
                XSingleton<XDebug>.singleton.AddErrorLog(ex.Message, location);
                return (XBinaryReader)null;
            }
        }

        public void ClearBinary(XBinaryReader reader, bool readShareResource)
        {
            if (reader == null)
                return;
            XBinaryReader.Return(reader, readShareResource);
        }

        public bool ReadText(string location, string suffix, XBinaryReader stream, bool error = true)
        {
            bool flag = true;
            TextAsset sharedResource = this.GetSharedResource<TextAsset>(location, suffix, error);
            if ((UnityEngine.Object)sharedResource == (UnityEngine.Object)null)
            {
                if (error)
                    XResourceLoaderMgr.LoadErrorLog(location);
                return false;
            }
            stream.Init(sharedResource);
            this.UnSafeDestroyShareResource(location, suffix, (UnityEngine.Object)sharedResource);
            return flag;
        }

        public TextAsset ReadLuaBytes(string filename_without_ext)
        {
            TextAsset sharedResource = this.GetSharedResource<TextAsset>("lua/Hotfix/" + filename_without_ext, ".txt", false);
            return (UnityEngine.Object)sharedResource == (UnityEngine.Object)null ? (TextAsset)null : sharedResource;
        }

        public void ReleaseLuaBytes(string filename_without_ext, TextAsset data) => this.UnSafeDestroyShareResource("lua/Hotfix/" + filename_without_ext, ".txt", (UnityEngine.Object)data);

        public bool ReadFile(string location, CVSReader reader)
        {
            TextAsset sharedResource = this.GetSharedResource<TextAsset>(location, ".bytes");
            if ((UnityEngine.Object)sharedResource == (UnityEngine.Object)null || sharedResource.bytes == null)
                XResourceLoaderMgr.LoadErrorLog(location);
            bool flag = true;
            XBinaryReader reader1 = XBinaryReader.Get();
            reader1.Init(sharedResource);
            try
            {
                flag = reader.ReadFile(reader1);
                if (!flag)
                    XSingleton<XDebug>.singleton.AddErrorLog("in File: ", location, reader.error);
            }
            catch (Exception ex)
            {
                XSingleton<XDebug>.singleton.AddErrorLog(ex.Message, " in File: ", location, reader.error);
                flag = false;
            }
            finally
            {
                XBinaryReader.Return(reader1);
            }
            this.UnSafeDestroyShareResource(location, ".bytes", (UnityEngine.Object)sharedResource);
            return flag;
        }

        public bool ReadFile(TextAsset data, CVSReader reader)
        {
            if ((UnityEngine.Object)data == (UnityEngine.Object)null || reader == null)
                return false;
            XBinaryReader reader1 = XBinaryReader.Get();
            reader1.Init(data);
            bool flag = true;
            try
            {
                flag = reader.ReadFile(reader1);
                return flag;
            }
            catch (Exception ex)
            {
                XSingleton<XDebug>.singleton.AddErrorLog("ReadFile: ", ex.Message);
                flag = false;
            }
            finally
            {
                XBinaryReader.Return(reader1);
            }
            return flag;
        }

        public void CreateInAdvance(string location, int num, ECreateHideType hideType)
        {
            if (location == null || location.Length == 0)
                return;
            uint num1 = this.Hash(location, ".prefab");
            int num2 = 0;
            if (this.useNewMgr)
            {
                XResourceLoaderMgr.UniteObjectInfo uniteObjectInfo = (XResourceLoaderMgr.UniteObjectInfo)null;
                if (this.m_assetPool.TryGetValue(num1, out uniteObjectInfo))
                {
                    if (uniteObjectInfo.objPool != null)
                        num2 = uniteObjectInfo.objPool.Count;
                }
                else
                {
                    uniteObjectInfo = this.GetObjectInfo();
                    uniteObjectInfo.Init(location, ".prefab", num1, false, typeof(GameObject), true);
                    this.m_assetPool.Add(num1, uniteObjectInfo);
                }
                if (uniteObjectInfo.objPool == null)
                    uniteObjectInfo.objPool = QueuePool<UnityEngine.Object>.Get();
                for (int index = 0; index < num - num2; ++index)
                {
                    if (uniteObjectInfo.asset != (UnityEngine.Object)null)
                    {
                        GameObject go = XCommon.Instantiate<UnityEngine.Object>(uniteObjectInfo.asset) as GameObject;
                        if ((UnityEngine.Object)go != (UnityEngine.Object)null)
                        {
                            uniteObjectInfo.objPool.Enqueue((UnityEngine.Object)go);
                            switch (hideType)
                            {
                                case ECreateHideType.DisableObject:
                                    go.SetActive(false);
                                    break;
                                case ECreateHideType.DisableAnim:
                                    Animator componentInChildren = go.GetComponentInChildren<Animator>();
                                    if ((UnityEngine.Object)componentInChildren != (UnityEngine.Object)null)
                                    {
                                        componentInChildren.enabled = false;
                                        break;
                                    }
                                    break;
                                case ECreateHideType.DisableParticleRenderer:
                                    XSingleton<XCommon>.singleton.EnableParticleRenderer(go, false);
                                    break;
                            }
                        }
                    }
                }
            }
            else
            {
                if (this._object_pool.ContainsKey(num1))
                    num2 = this._object_pool[num1].Count;
                for (int index = 0; index < num - num2; ++index)
                {
                    UnityEngine.Object fromPrefab = this.CreateFromPrefab(location, false);
                    this.AddToObjectPool(num1, fromPrefab);
                    GameObject go = fromPrefab as GameObject;
                    if ((UnityEngine.Object)go != (UnityEngine.Object)null)
                    {
                        switch (hideType)
                        {
                            case ECreateHideType.DisableObject:
                                go.SetActive(false);
                                break;
                            case ECreateHideType.DisableAnim:
                                Animator componentInChildren = go.GetComponentInChildren<Animator>();
                                if ((UnityEngine.Object)componentInChildren != (UnityEngine.Object)null)
                                {
                                    componentInChildren.enabled = false;
                                    break;
                                }
                                break;
                            case ECreateHideType.DisableParticleRenderer:
                                XSingleton<XCommon>.singleton.EnableParticleRenderer(go, false);
                                break;
                        }
                    }
                }
            }
        }

        public XResourceLoaderMgr.UniteObjectInfo GetUOI(
          uint hash,
          out UnityEngine.Object obj,
          bool useObjPool)
        {
            XResourceLoaderMgr.UniteObjectInfo uniteObjectInfo = (XResourceLoaderMgr.UniteObjectInfo)null;
            obj = (UnityEngine.Object)null;
            if (!this.m_assetPool.TryGetValue(hash, out uniteObjectInfo))
                return (XResourceLoaderMgr.UniteObjectInfo)null;
            obj = uniteObjectInfo.Get(useObjPool);
            return uniteObjectInfo;
        }

        public bool GetUOIAsync(
          string location,
          uint hash,
          UnityEngine.Object asset,
          AssetBundleInfo info,
          bool isSharedResource,
          out XResourceLoaderMgr.UniteObjectInfo uoi)
        {
            uoi = (XResourceLoaderMgr.UniteObjectInfo)null;
            if (this.m_assetPool.TryGetValue(hash, out uoi))
            {
                XSingleton<XDebug>.singleton.AddWarningLog2("LoadAsync asset:{0},already loaded.", (object)location);
                if (asset != uoi.asset)
                    XSingleton<XDebug>.singleton.AddErrorLog("not same asset at same path.");
                return false;
            }
            uoi = this.GetObjectInfo();
            bool flag = uoi.InitAsync(location, hash, asset, info, isSharedResource, true);
            if (isSharedResource && uoi.asset != (UnityEngine.Object)null)
            {
                int instanceId = uoi.asset.GetInstanceID();
                if (this.m_instanceIDAssetMap.ContainsKey(instanceId))
                    XSingleton<XDebug>.singleton.AddErrorLog2("same key already exists in the dictionary:{0}", (object)uoi.asset.name);
                else
                    this.m_instanceIDAssetMap[instanceId] = uoi;
            }
            this.m_assetPool.Add(hash, uoi);
            return flag;
        }

        public UnityEngine.Object GetUOI(
          XResourceLoaderMgr.UniteObjectInfo uoi,
          bool isSharedResource,
          bool useObjPool)
        {
            UnityEngine.Object @object = uoi.Get(useObjPool);
            if (!isSharedResource)
            {
                int instanceId = @object.GetInstanceID();
                if (this.m_instanceIDAssetMap.ContainsKey(instanceId))
                    XSingleton<XDebug>.singleton.AddErrorLog2("same key already exists in the dictionary:{0}", (object)@object.name);
                else
                    this.m_instanceIDAssetMap.Add(instanceId, uoi);
            }
            return @object;
        }

        private void ReturnObject(
          XResourceLoaderMgr.UniteObjectInfo uoi,
          UnityEngine.Object obj,
          int instanceID,
          bool usePool)
        {
            if (uoi != null)
            {
                if (uoi.Return(obj, usePool))
                {
                    if (this.m_degenerationQueue == null)
                    {
                        this.m_degenerationQueue = uoi;
                        this.m_currentDegeneration = uoi;
                    }
                    else if (this.m_currentDegeneration != null)
                    {
                        this.m_currentDegeneration.next = uoi;
                        this.m_currentDegeneration = uoi;
                    }
                    else
                        this.ReturnObject(uoi);
                    this.m_instanceIDAssetMap.Remove(instanceID);
                }
                else
                {
                    if (uoi.IsSharedResource)
                        return;
                    this.m_instanceIDAssetMap.Remove(instanceID);
                }
            }
            else if (XResourceLoaderMgr.UniteObjectInfo.CanDestroy(obj))
                UnityEngine.Object.Destroy(obj);
            else
                Resources.UnloadAsset(obj);
        }

        private void ReturnObject(XResourceLoaderMgr.UniteObjectInfo uoi)
        {
            if (!uoi.IsDegeneration)
                return;
            this.m_assetPool.Remove(uoi.hashID);
            uoi.Clear();
            this.m_objInfoPool.Enqueue(uoi);
        }

        private XResourceLoaderMgr.UniteObjectInfo GetObjectInfo() => this.m_objInfoPool.Count > 0 ? this.m_objInfoPool.Dequeue() : new XResourceLoaderMgr.UniteObjectInfo();

        private void PushLoadTask(uint hash, out LoadAsyncTask task)
        {
            this.isCurrentLoading = true;
            LoadAsyncTask loadAsyncTask = (LoadAsyncTask)null;
            int count = this._async_task_list.Count;
            int index1;
            for (index1 = 0; index1 < count; ++index1)
            {
                LoadAsyncTask asyncTask = this._async_task_list[index1];
                if (asyncTask.loadState == EAsyncLoadState.EFree)
                    loadAsyncTask = asyncTask;
                else if ((int)asyncTask.hash == (int)hash)
                {
                    task = asyncTask;
                    return;
                }
            }
            if (loadAsyncTask == null)
            {
                for (int index2 = index1 + 1; index2 < count; ++index2)
                {
                    LoadAsyncTask asyncTask = this._async_task_list[index2];
                    if (asyncTask.loadState == EAsyncLoadState.EFree)
                    {
                        loadAsyncTask = asyncTask;
                        break;
                    }
                }
            }
            if (loadAsyncTask == null)
            {
                loadAsyncTask = new LoadAsyncTask();
                this._async_task_list.Add(loadAsyncTask);
            }
            task = loadAsyncTask;
            task.Clear();
            task.loadState = EAsyncLoadState.EPreLoading;
        }

        private LoadAsyncTask CreateAsyncTask(
          string location,
          string suffix,
          uint hash,
          LoadCallBack Cb,
          object cbOjb,
          bool sharedRes,
          bool usePool,
          System.Type t)
        {
            LoadAsyncTask task;
            this.PushLoadTask(hash, out task);
            LoadInfo loadInfo;
            loadInfo.loadCb = Cb;
            loadInfo.usePool = usePool;
            task.loadType = t;
            task.hash = hash;
            task.location = location;
            task.ext = suffix;
            task.isSharedRes = sharedRes;
            task.cbObj = cbOjb;
            task.loadCbList.Add(loadInfo);
            return task;
        }

        public GameObject CreateFromPrefab(
          string location,
          Vector3 position,
          Quaternion quaternion,
          bool usePool = true,
          bool dontDestroy = false)
        {
            GameObject fromPrefab = this.CreateFromPrefab(location, usePool, dontDestroy) as GameObject;
            fromPrefab.transform.position = position;
            fromPrefab.transform.rotation = quaternion;
            return fromPrefab;
        }

        public UnityEngine.Object CreateFromPrefab(
          string location,
          bool usePool = true,
          bool dontDestroy = false)
        {
            return (UnityEngine.Object)this.CreateFromAsset<GameObject>(location, ".prefab", usePool, dontDestroy);
        }

        public T CreateFromAsset<T>(string location, string suffix, bool usePool = true, bool dontDestroy = false) where T : UnityEngine.Object
        {
            uint num = this.Hash(location, suffix);
            if (this.useNewMgr)
            {
                UnityEngine.Object @object = (UnityEngine.Object)null;
                XResourceLoaderMgr.UniteObjectInfo uniteObjectInfo = this.GetUOI(num, out @object, usePool);
                if (uniteObjectInfo == null)
                {
                    uniteObjectInfo = this.GetObjectInfo();
                    if (uniteObjectInfo.Init(location, suffix, num, false, typeof(T), true))
                        @object = uniteObjectInfo.Get(usePool);
                    this.m_assetPool.Add(num, uniteObjectInfo);
                }
                uniteObjectInfo.IsDontDestroyAsset = dontDestroy;
                if (@object != (UnityEngine.Object)null)
                    this.m_instanceIDAssetMap.Add(@object.GetInstanceID(), uniteObjectInfo);
                return @object as T;
            }
            float time = Time.time;
            UnityEngine.Object o1 = (UnityEngine.Object)null;
            UnityEngine.Object o2;
            if (usePool && this.GetInObjectPool(ref o1, num))
            {
                o2 = o1;
            }
            else
            {
                o1 = this.GetAssetInPool(num);
                if (o1 == (UnityEngine.Object)null)
                {
                    AssetBundleInfo info = (AssetBundleInfo)null;
                    if ((UnityEngine.Object)XSingleton<XUpdater.XUpdater>.singleton.ABManager != (UnityEngine.Object)null)
                        info = XSingleton<XUpdater.XUpdater>.singleton.ABManager.LoadImm(num, location, suffix);
                    o1 = info == null ? this.CreateFromAssets<T>(location, num) : this.CreateFromAssetBundle<T>(location, num, info);
                }
                o2 = o1 != (UnityEngine.Object)null ? XCommon.Instantiate<UnityEngine.Object>(o1) : (UnityEngine.Object)null;
                if (o2 != (UnityEngine.Object)null)
                {
                    this.AssetsRefRetain(num);
                    this.LogReverseID(o2, num);
                }
                if (XSingleton<XDebug>.singleton.EnableRecord())
                    XSingleton<XDebug>.singleton.AddPoint(num, location, Time.time - time, 0, XDebug.RecordChannel.EResourceLoad);
            }
            return o2 as T;
        }

        public LoadAsyncTask CreateFromPrefabAsync(
          string location,
          LoadCallBack Cb,
          object cbOjb,
          bool usePool = true)
        {
            uint num = this.Hash(location, ".prefab");
            if (this.useNewMgr)
            {
                UnityEngine.Object @object = (UnityEngine.Object)null;
                if (this.GetUOI(num, out @object, usePool) == null)
                    return this.CreateAsyncTask(location, ".prefab", num, Cb, cbOjb, false, usePool, typeof(GameObject));
                Cb(@object, cbOjb);
                return (LoadAsyncTask)null;
            }
            UnityEngine.Object o = (UnityEngine.Object)null;
            if (usePool && this.GetInObjectPool(ref o, num))
            {
                Cb(o, cbOjb);
                return (LoadAsyncTask)null;
            }
            if (!this._asset_pool.TryGetValue(num, out o))
                return this.CreateAsyncTask(location, ".prefab", num, Cb, cbOjb, false, usePool, typeof(GameObject));
            LoadAsyncTask asyncTask = this.CreateAsyncTask(location, ".prefab", num, Cb, cbOjb, false, usePool, typeof(GameObject));
            asyncTask.asset = o;
            asyncTask.loadState = EAsyncLoadState.EInstance;
            return asyncTask;
        }

        public T GetSharedResource<T>(string location, string suffix, bool canNotNull = true, bool preload = false) where T : UnityEngine.Object
        {
            uint num = this.Hash(location, suffix);
            if (this.useNewMgr)
            {
                UnityEngine.Object @object = (UnityEngine.Object)null;
                if (this.GetUOI(num, out @object, false) == null)
                {
                    XResourceLoaderMgr.UniteObjectInfo objectInfo = this.GetObjectInfo();
                    objectInfo.IsDontDestroyAsset = this.dontDestroy;
                    if (objectInfo.Init(location, suffix, num, true, typeof(T), canNotNull))
                        @object = objectInfo.Get(preload);
                    else if (!canNotNull)
                    {
                        this.m_objInfoPool.Enqueue(objectInfo);
                        return default(T);
                    }
                    this.m_assetPool.Add(num, objectInfo);
                    if (@object != (UnityEngine.Object)null)
                        this.m_instanceIDAssetMap.Add(@object.GetInstanceID(), objectInfo);
                }
                return @object as T;
            }
            float time = Time.time;
            UnityEngine.Object object1 = this.GetAssetInPool(num);
            if (object1 == (UnityEngine.Object)null)
            {
                AssetBundleInfo info = (AssetBundleInfo)null;
                if ((UnityEngine.Object)XSingleton<XUpdater.XUpdater>.singleton.ABManager != (UnityEngine.Object)null)
                    info = XSingleton<XUpdater.XUpdater>.singleton.ABManager.LoadImm(num, location, suffix);
                object1 = info == null ? this.CreateFromAssets<T>(location, num, canNotNull) : this.CreateFromAssetBundle<T>(location, num, info, canNotNull);
            }
            if (object1 != (UnityEngine.Object)null)
                this.AssetsRefRetain(num);
            if (XSingleton<XDebug>.singleton.EnableRecord())
                XSingleton<XDebug>.singleton.AddPoint(num, location, Time.time - time, 1, XDebug.RecordChannel.EResourceLoad);
            return object1 as T;
        }

        public LoadAsyncTask GetShareResourceAsync<T>(
          string location,
          string suffix,
          LoadCallBack Cb,
          object cbOjb)
          where T : UnityEngine.Object
        {
            uint num = this.Hash(location, suffix);
            if (this.useNewMgr)
            {
                UnityEngine.Object @object = (UnityEngine.Object)null;
                if (this.GetUOI(num, out @object, false) == null)
                    return this.CreateAsyncTask(location, suffix, num, Cb, (object)null, true, false, typeof(T));
                Cb(@object, cbOjb);
                return (LoadAsyncTask)null;
            }
            UnityEngine.Object object1 = (UnityEngine.Object)null;
            if (!this._asset_pool.TryGetValue(num, out object1))
                return this.CreateAsyncTask(location, suffix, num, Cb, cbOjb, true, false, typeof(T));
            Cb(object1, cbOjb);
            this.AssetsRefRetain(num);
            return (LoadAsyncTask)null;
        }

        public XAnimationClip GetXAnimation(string location, bool showLog = true, bool preload = false)
        {
            uint num = this.Hash(location, ".anim");
            if (this.useNewMgr)
            {
                UnityEngine.Object @object = (UnityEngine.Object)null;
                if (this.GetUOI(num, out @object, false) == null)
                {
                    XResourceLoaderMgr.UniteObjectInfo objectInfo = this.GetObjectInfo();
                    if (objectInfo.InitAnim(location, ".anim", num))
                        @object = objectInfo.Get(false, preload);
                    this.m_assetPool.Add(num, objectInfo);
                    if (@object != (UnityEngine.Object)null)
                        this.m_instanceIDAssetMap.Add(@object.GetInstanceID(), objectInfo);
                }
                return @object as XAnimationClip;
            }
            UnityEngine.Object object1 = this.GetAssetInPool(num);
            if (object1 == (UnityEngine.Object)null)
            {
                AssetBundleInfo info = (AssetBundleInfo)null;
                if ((UnityEngine.Object)XSingleton<XUpdater.XUpdater>.singleton.ABManager != (UnityEngine.Object)null)
                    info = XSingleton<XUpdater.XUpdater>.singleton.ABManager.LoadImm(num, location, ".anim");
                object1 = info == null ? this.CreateFromAssets<XAnimationClip>(location, num, showLog) : this.CreateFromAssetBundle<XAnimationClip>(location, num, info, showLog);
            }
            if (object1 != (UnityEngine.Object)null)
                this.AssetsRefRetain(num);
            return object1 as XAnimationClip;
        }

        public static void SafeGetAnimationClip(string location, ref XAnimationClip clip)
        {
            if ((UnityEngine.Object)clip != (UnityEngine.Object)null)
            {
                XSingleton<XResourceLoaderMgr>.singleton.UnSafeDestroyShareResource(location, ".anim", (UnityEngine.Object)clip);
                clip = (XAnimationClip)null;
            }
            clip = XSingleton<XResourceLoaderMgr>.singleton.GetXAnimation(location);
        }

        public static void SafeDestroy(ref UnityEngine.Object obj, bool returnPool = true)
        {
            XSingleton<XResourceLoaderMgr>.singleton.UnSafeDestroy(obj, returnPool);
            obj = (UnityEngine.Object)null;
        }

        public static void SafeDestroy(ref GameObject obj, bool returnPool = true)
        {
            XSingleton<XResourceLoaderMgr>.singleton.UnSafeDestroy((UnityEngine.Object)obj, returnPool);
            obj = (GameObject)null;
        }

        public static void SafeDestroyShareResource(
          string location,
          ref GameObject obj,
          bool triggerRelease = false)
        {
            XSingleton<XResourceLoaderMgr>.singleton.UnSafeDestroyShareResource(location, ".prefab", (UnityEngine.Object)obj, triggerRelease);
            obj = (GameObject)null;
        }

        public static void SafeDestroyShareResource(string location, ref Material obj)
        {
            XSingleton<XResourceLoaderMgr>.singleton.UnSafeDestroyShareResource(location, ".mat", (UnityEngine.Object)obj);
            obj = (Material)null;
        }

        public static void SafeDestroyShareResource(string location, ref XAnimationClip obj)
        {
            if (!((UnityEngine.Object)obj != (UnityEngine.Object)null))
                return;
            XSingleton<XResourceLoaderMgr>.singleton.UnSafeDestroyShareResource(location, ".anim", (UnityEngine.Object)obj.clip);
            obj = (XAnimationClip)null;
        }

        private void InnerDestroy(UnityEngine.Object obj, int instanceID, bool sharedRes)
        {
            XResourceLoaderMgr.UniteObjectInfo uoi = (XResourceLoaderMgr.UniteObjectInfo)null;
            if (this.m_instanceIDAssetMap.TryGetValue(instanceID, out uoi))
                this.ReturnObject(uoi, obj, instanceID, false);
            else if (sharedRes)
            {
                if (!XResourceLoaderMgr.UniteObjectInfo.CanDestroy(obj))
                    Resources.UnloadAsset(obj);
            }
            else if (XResourceLoaderMgr.UniteObjectInfo.CanDestroy(obj))
                UnityEngine.Object.Destroy(obj);
        }

        public void UnSafeDestroy(UnityEngine.Object o, bool returnPool = true, bool destroyImm = false)
        {
            if (o == (UnityEngine.Object)null)
                return;
            int instanceId = o.GetInstanceID();
            if (this.useNewMgr)
            {
                this.InnerDestroy(o, instanceId, false);
            }
            else
            {
                uint num = 0;
                if (returnPool && this._reverse_map.TryGetValue(instanceId, out num))
                {
                    this.AddToObjectPool(num, o);
                }
                else
                {
                    if (this._reverse_map.TryGetValue(instanceId, out num))
                    {
                        this.AssetsRefRelease(num);
                        this._reverse_map.Remove(instanceId);
                    }
                    if (destroyImm)
                        UnityEngine.Object.DestroyImmediate(o);
                    else
                        UnityEngine.Object.Destroy(o);
                }
            }
        }

        public void UnSafeDestroyShareResource(
          string location,
          string suffix,
          UnityEngine.Object o,
          bool triggerRelease = false)
        {
            if (o == (UnityEngine.Object)null)
                return;
            if (this.useNewMgr)
            {
                int instanceId = o.GetInstanceID();
                this.InnerDestroy(o, instanceId, true);
            }
            else if (!string.IsNullOrEmpty(location))
            {
                uint num = this.Hash(location, suffix);
                if (this._asset_ref_count.ContainsKey(num))
                {
                    if (this.AssetsRefRelease(num) & triggerRelease && !XResourceLoaderMgr.UniteObjectInfo.CanDestroy(o))
                        Resources.UnloadAsset(o);
                }
                else if (!XResourceLoaderMgr.UniteObjectInfo.CanDestroy(o) && (!((UnityEngine.Object)XSingleton<XUpdater.XUpdater>.singleton.ABManager != (UnityEngine.Object)null) || !XSingleton<XUpdater.XUpdater>.singleton.ABManager.CheckInDep(num)))
                    Resources.UnloadAsset(o);
            }
        }

        private void DelayDestroy(float deltaTime, bool force)
        {
            XResourceLoaderMgr.UniteObjectInfo uoi = this.m_degenerationQueue;
            this.m_degenerationQueue = (XResourceLoaderMgr.UniteObjectInfo)null;
            XResourceLoaderMgr.UniteObjectInfo uniteObjectInfo = (XResourceLoaderMgr.UniteObjectInfo)null;
            XResourceLoaderMgr.UniteObjectInfo next;
            for (; uoi != null; uoi = next)
            {
                next = uoi.next;
                uoi.degenerationTime += deltaTime;
                if (force || !uoi.IsDegeneration || (double)uoi.degenerationTime > 2.0)
                {
                    if (uniteObjectInfo != null)
                        uniteObjectInfo.next = uoi.next;
                    this.ReturnObject(uoi);
                }
                else
                {
                    uniteObjectInfo = uoi;
                    if (this.m_degenerationQueue == null)
                        this.m_degenerationQueue = uoi;
                }
            }
            this.m_currentDegeneration = this.m_degenerationQueue;
            while (this.m_currentDegeneration != null && this.m_currentDegeneration.next != null)
                this.m_currentDegeneration = this.m_currentDegeneration.next;
        }

        public void LoadABScene(string path)
        {
            if (XSingleton<XUpdater.XUpdater>.singleton.ABManager.LoadImm(XSingleton<XCommon>.singleton.XHashLowerRelpaceDot(XSingleton<XCommon>.singleton.XHashLowerRelpaceDot(XSingleton<XCommon>.singleton.XHashLowerRelpaceDot(0U, "Assets.XScene.Scenelib."), path), ".unity"), path, ".unity", "Assets.XScene.Scenelib.") == null)
                return;
            XSingleton<XDebug>.singleton.AddLog("Load AB Scene Finish!");
        }

        public IXCurve GetCurve(string location)
        {
            if (!XResourceLoaderMgr.UseCurveTable)
                return this.GetSharedResource<GameObject>(location, ".prefab").GetComponent("XCurve") as IXCurve;
            uint hash = XSingleton<XCommon>.singleton.XHash(location);
            IXCurve xcurve = (IXCurve)this.GetServerCurve(hash);
            if (xcurve == null)
            {
                XSingleton<XDebug>.singleton.AddLog2("curve not found:{0}|Hash:{1}", (object)location, (object)hash);
                xcurve = this.GetSharedResource<GameObject>(location, ".prefab").GetComponent("XCurve") as IXCurve;
            }
            return xcurve;
        }

        private FloatCurve _GetFloatCurve(uint hash)
        {
            int num1 = 0;
            int num2 = this.m_curveData.Count - 1;
            while (num1 <= num2)
            {
                int index = (num1 + num2) / 2;
                if (hash > this.m_curveData[index].namehash)
                {
                    num1 = index + 1;
                }
                else
                {
                    if (hash >= this.m_curveData[index].namehash)
                        return this.m_curveData[index];
                    num2 = index - 1;
                }
            }
            return (FloatCurve)null;
        }

        public FloatCurve GetServerCurve(uint hash) => this._GetFloatCurve(hash);

        public T GetData<T>(string pathwithname, string suffix)
        {
            uint key = XSingleton<XCommon>.singleton.XHash(pathwithname);
            UnityEngine.Object @object = (UnityEngine.Object)null;
            if (!this._script_pool.TryGetValue(key, out @object))
            {
                TextAsset sharedResource = this.GetSharedResource<TextAsset>(pathwithname, suffix);
                if ((UnityEngine.Object)sharedResource == (UnityEngine.Object)null)
                    XSingleton<XDebug>.singleton.AddErrorLog("Deserialize file ", pathwithname, " Error!");
                XmlSerializer xmlSerializer = this.xmlSerializerCache[typeof(T) == typeof(XCutSceneData) ? 1 : 0];
                this.shareMemoryStream.Seek(0L, SeekOrigin.Begin);
                this.shareMemoryStream.SetLength(0L);
                this.shareMemoryStream.Write(sharedResource.bytes, 0, sharedResource.bytes.Length);
                this.shareMemoryStream.Seek(0L, SeekOrigin.Begin);
                object obj = xmlSerializer.Deserialize((Stream)this.shareMemoryStream);
                XDataWrapper instance = ScriptableObject.CreateInstance<XDataWrapper>();
                instance.Data = obj;
                this.UnSafeDestroyShareResource(pathwithname, suffix, (UnityEngine.Object)sharedResource);
                @object = (UnityEngine.Object)instance;
                if ((UnityEngine.Object)null != @object)
                    this._script_pool.Add(key, @object);
            }
            return (T)(@object as XDataWrapper).Data;
        }

        public UnityEngine.Object AddAssetInPool(UnityEngine.Object asset, uint hash, AssetBundleInfo info = null)
        {
            if (asset == (UnityEngine.Object)null)
                return (UnityEngine.Object)null;
            UnityEngine.Object @object = (UnityEngine.Object)null;
            this._asset_pool.TryGetValue(hash, out @object);
            if (@object == (UnityEngine.Object)null)
            {
                @object = asset;
                this._asset_pool[hash] = @object;
                if (info != null && !this._bundle_pool.ContainsKey(hash))
                {
                    info.Retain();
                    this._bundle_pool.Add(hash, info);
                }
            }
            return @object;
        }

        public UnityEngine.Object GetAssetInPool(uint hash)
        {
            UnityEngine.Object @object = (UnityEngine.Object)null;
            this._asset_pool.TryGetValue(hash, out @object);
            return @object;
        }

        public bool GetInObjectPool(ref UnityEngine.Object o, uint id)
        {
            Queue<UnityEngine.Object> objectQueue = (Queue<UnityEngine.Object>)null;
            if (!this._object_pool.TryGetValue(id, out objectQueue) || objectQueue.Count <= 0)
                return false;
            UnityEngine.Object @object = objectQueue.Dequeue();
            while (@object == (UnityEngine.Object)null && objectQueue.Count > 0)
                @object = objectQueue.Dequeue();
            if (@object == (UnityEngine.Object)null)
                return false;
            o = @object;
            return true;
        }

        private UnityEngine.Object CreateFromAssets<T>(
          string location,
          uint hash,
          bool showError = true)
        {
            UnityEngine.Object asset;
            if (typeof(T) == typeof(XAnimationClip))
            {
                XAnimationClip xanimationClip = XAnimationPool.Get();
                xanimationClip.clip = Resources.Load(location, typeof(AnimationClip)) as AnimationClip;
                if ((UnityEngine.Object)xanimationClip.clip == (UnityEngine.Object)null)
                {
                    if (showError)
                        XResourceLoaderMgr.LoadErrorLog(location);
                    return (UnityEngine.Object)null;
                }
                xanimationClip.length = xanimationClip.clip.length;
                asset = (UnityEngine.Object)xanimationClip;
            }
            else
                asset = Resources.Load(location, typeof(T));
            ++XResourceLoaderMgr.resourceLoadCount;
            UnityEngine.Object @object = this.AddAssetInPool(asset, hash);
            if (!(@object == (UnityEngine.Object)null))
                return @object;
            if (showError)
                XResourceLoaderMgr.LoadErrorLog(location);
            return (UnityEngine.Object)null;
        }

        private UnityEngine.Object CreateFromAssetBundle<T>(
          string location,
          uint hash,
          AssetBundleInfo info,
          bool showError = true)
        {
            UnityEngine.Object asset;
            if (typeof(T) == typeof(XAnimationClip))
            {
                XAnimationClip xanimationClip = XAnimationPool.Get();
                xanimationClip.clip = info.mainObject as AnimationClip;
                if ((UnityEngine.Object)xanimationClip.clip == (UnityEngine.Object)null)
                {
                    if (showError)
                        XResourceLoaderMgr.LoadErrorLog(location);
                    return (UnityEngine.Object)null;
                }
                xanimationClip.length = xanimationClip.clip.length;
                asset = (UnityEngine.Object)xanimationClip;
            }
            else
                asset = info.mainObject;
            ++XResourceLoaderMgr.abLoadCount;
            UnityEngine.Object @object = this.AddAssetInPool(asset, hash, info);
            if (!(@object == (UnityEngine.Object)null))
                return @object;
            if (showError)
                XResourceLoaderMgr.LoadErrorLog(location);
            return (UnityEngine.Object)null;
        }

        private void AddToObjectPool(uint id, UnityEngine.Object obj)
        {
            Queue<UnityEngine.Object> objectQueue = (Queue<UnityEngine.Object>)null;
            if (!this._object_pool.TryGetValue(id, out objectQueue))
            {
                objectQueue = new Queue<UnityEngine.Object>();
                this._object_pool.Add(id, objectQueue);
            }
            GameObject gameObject = obj as GameObject;
            if ((UnityEngine.Object)gameObject != (UnityEngine.Object)null)
            {
                Transform transform = gameObject.transform;
                transform.position = XResourceLoaderMgr.Far_Far_Away;
                transform.rotation = Quaternion.identity;
                transform.parent = (Transform)null;
            }
            objectQueue.Enqueue(obj);
        }

        public void AssetsRefRetain(uint hash)
        {
            int num1 = 0;
            this._asset_ref_count.TryGetValue(hash, out num1);
            int num2 = num1 + 1;
            this._asset_ref_count[hash] = num2;
        }

        public bool AssetsRefRelease(uint hash)
        {
            int num1 = 0;
            if (this._asset_ref_count.TryGetValue(hash, out num1))
            {
                int num2 = num1 - 1;
                if (num2 < 0)
                    num2 = 0;
                if (num2 == 0)
                {
                    this._asset_pool.Remove(hash);
                    this._asset_ref_count.Remove(hash);
                    AssetBundleInfo assetBundleInfo = (AssetBundleInfo)null;
                    if (!this._bundle_pool.TryGetValue(hash, out assetBundleInfo))
                        return true;
                    assetBundleInfo.Release();
                    this._bundle_pool.Remove(hash);
                    return false;
                }
                this._asset_ref_count[hash] = num2;
            }
            return false;
        }

        public void LogReverseID(UnityEngine.Object o, uint id)
        {
            if (!(o != (UnityEngine.Object)null))
                return;
            int instanceId = o.GetInstanceID();
            if (!this._reverse_map.ContainsKey(instanceId))
                this._reverse_map.Add(instanceId, id);
        }

        public static void LoadErrorLog(string prefab) => XSingleton<XDebug>.singleton.AddErrorLog("Load resource: ", prefab, " error!");

        public void Update(float deltaTime)
        {
            bool flag1 = false;
            bool flag2 = true;
            float time = Time.time;
            for (int index = 0; index < this._async_task_list.Count; ++index)
            {
                LoadAsyncTask asyncTask = this._async_task_list[index];
                if (flag2)
                {
                    if (asyncTask.Update())
                        asyncTask.Clear();
                    if ((double)(Time.time - time) >= (double)this.maxLoadThresholdTime)
                        flag2 = false;
                }
                flag1 |= asyncTask.loadState == EAsyncLoadState.ELoading;
            }
            if (!flag1)
                this.isCurrentLoading = false;
            this.DelayDestroy(deltaTime, false);
            this.UpdateDelayProcess(deltaTime);
        }

        public void AddDelayProcess(IDelayLoad loader)
        {
            int index = 0;
            for (int count = this.delayUpdateList.Count; index < count; ++index)
            {
                if (this.delayUpdateList[index] == loader)
                    return;
            }
            if (this.currentDelayTime < 0.0)
                this.currentDelayTime = XResourceLoaderMgr.delayTime;
            this.delayUpdateList.Add(loader);
        }

        public void RemoveDelayProcess(IDelayLoad loader) => this.delayUpdateList.Remove(loader);

        public void UpdateDelayProcess(float deltaTime)
        {
            if (this.delayUpdateList.Count <= 0)
                return;
            this.currentDelayTime -= XResourceLoaderMgr.delayTime;
            if (this.currentDelayTime <= 0.0 && this.delayUpdateList[0].DelayUpdate() == EDelayProcessType.EFinish)
            {
                this.delayUpdateList.RemoveAt(0);
                if (this.delayUpdateList.Count > 0)
                    this.currentDelayTime = XResourceLoaderMgr.delayTime;
            }
        }

        public class UniteObjectInfo
        {
            public uint hashID = 0;
            public UnityEngine.Object asset = (UnityEngine.Object)null;
            public int refCount = 0;
            public AssetBundleInfo assetBundleInfo = (AssetBundleInfo)null;
            public Queue<UnityEngine.Object> objPool = (Queue<UnityEngine.Object>)null;
            public string loc = "";
            private uint m_flag = 0;
            public XResourceLoaderMgr.UniteObjectInfo next = (XResourceLoaderMgr.UniteObjectInfo)null;
            public float degenerationTime = 0.0f;

            public bool HasPreload
            {
                get => (this.m_flag & XResourceLoaderMgr.Preload) > 0U;
                set
                {
                    if (value)
                        this.m_flag |= XResourceLoaderMgr.Preload;
                    else
                        this.m_flag &= ~XResourceLoaderMgr.Preload;
                }
            }

            public bool IsSharedResource
            {
                get => (this.m_flag & XResourceLoaderMgr.SharedResource) > 0U;
                set
                {
                    if (value)
                        this.m_flag |= XResourceLoaderMgr.SharedResource;
                    else
                        this.m_flag &= ~XResourceLoaderMgr.SharedResource;
                }
            }

            public bool IsDontDestroyAsset
            {
                get => (this.m_flag & XResourceLoaderMgr.DontDestroyAsset) > 0U;
                set
                {
                    if (value)
                        this.m_flag |= XResourceLoaderMgr.DontDestroyAsset;
                    else
                        this.m_flag &= ~XResourceLoaderMgr.DontDestroyAsset;
                }
            }

            public bool IsDegeneration
            {
                get => (this.m_flag & XResourceLoaderMgr.Degeneration) > 0U;
                set
                {
                    if (value)
                        this.m_flag |= XResourceLoaderMgr.Degeneration;
                    else
                        this.m_flag &= ~XResourceLoaderMgr.Degeneration;
                }
            }

            private void InitAB(string location, string suffix)
            {
                if (!((UnityEngine.Object)XSingleton<XUpdater.XUpdater>.singleton.ABManager != (UnityEngine.Object)null))
                    return;
                this.assetBundleInfo = XSingleton<XUpdater.XUpdater>.singleton.ABManager.LoadImm(this.hashID, location, suffix);
            }

            public bool Init(
              string location,
              string suffix,
              uint hash,
              bool isSharedResource,
              System.Type t,
              bool canNotNull)
            {
                this.loc = location;
                this.IsSharedResource = isSharedResource;
                this.hashID = hash;
                this.InitAB(location, suffix);
                this.asset = this.assetBundleInfo == null ? Resources.Load(location, t) : this.assetBundleInfo.mainObject;
                if (this.asset == (UnityEngine.Object)null & canNotNull)
                {
                    XResourceLoaderMgr.LoadErrorLog(location);
                    return false;
                }
                return canNotNull;
            }

            public bool InitAnim(string location, string suffix, uint hash)
            {
                this.loc = location;
                this.IsSharedResource = true;
                this.hashID = hash;
                this.InitAB(location, suffix);
                float num = 0.0f;
                AnimationClip animationClip;
                if (this.assetBundleInfo != null)
                {
                    animationClip = this.assetBundleInfo.mainObject as AnimationClip;
                    if ((UnityEngine.Object)animationClip != (UnityEngine.Object)null)
                        num = animationClip.length;
                }
                else
                {
                    animationClip = Resources.Load<AnimationClip>(location);
                    if ((UnityEngine.Object)animationClip != (UnityEngine.Object)null)
                        num = animationClip.length;
                }
                if ((UnityEngine.Object)animationClip == (UnityEngine.Object)null)
                {
                    XResourceLoaderMgr.LoadErrorLog(location);
                    return false;
                }
                XAnimationClip xanimationClip = XAnimationPool.Get();
                xanimationClip.clip = animationClip;
                xanimationClip.length = num;
                this.asset = (UnityEngine.Object)xanimationClip;
                return true;
            }

            public bool InitAsync(
              string location,
              uint hash,
              UnityEngine.Object asyncAsset,
              AssetBundleInfo info,
              bool isSharedResource,
              bool showLog)
            {
                this.loc = location;
                this.IsSharedResource = isSharedResource;
                this.hashID = hash;
                this.assetBundleInfo = info;
                this.asset = this.assetBundleInfo == null ? asyncAsset : this.assetBundleInfo.mainObject;
                if (this.asset is AnimationClip)
                {
                    float num = 0.0f;
                    AnimationClip animationClip;
                    if (this.assetBundleInfo != null)
                    {
                        animationClip = this.assetBundleInfo.mainObject as AnimationClip;
                        if ((UnityEngine.Object)animationClip != (UnityEngine.Object)null)
                            num = animationClip.length;
                    }
                    else
                    {
                        animationClip = asyncAsset as AnimationClip;
                        if ((UnityEngine.Object)animationClip != (UnityEngine.Object)null)
                            num = animationClip.length;
                    }
                    if ((UnityEngine.Object)animationClip != (UnityEngine.Object)null)
                    {
                        XAnimationClip xanimationClip = XAnimationPool.Get();
                        xanimationClip.clip = animationClip;
                        xanimationClip.length = num;
                        this.asset = (UnityEngine.Object)xanimationClip;
                    }
                }
                if (!(this.asset == (UnityEngine.Object)null & showLog))
                    return true;
                XResourceLoaderMgr.LoadErrorLog(location);
                return false;
            }

            public UnityEngine.Object Get(bool useObjPool, bool preload = false)
            {
                UnityEngine.Object @object = (UnityEngine.Object)null;
                this.IsDegeneration = false;
                if (preload)
                    this.HasPreload = true;
                if (this.IsSharedResource)
                    @object = this.asset;
                else if (useObjPool && this.objPool != null && this.objPool.Count > 0)
                    @object = this.objPool.Dequeue();
                else if (this.asset != (UnityEngine.Object)null)
                    @object = XCommon.Instantiate<UnityEngine.Object>(this.asset);
                else
                    XSingleton<XDebug>.singleton.AddErrorLog("null asset when instantiate asset");
                if (@object != (UnityEngine.Object)null)
                {
                    ++this.refCount;
                    if (this.assetBundleInfo != null && this.refCount == 1)
                        this.assetBundleInfo.Retain();
                }
                return @object;
            }

            public bool Return(UnityEngine.Object obj, bool useObjPool)
            {
                --this.refCount;
                if (this.asset != (UnityEngine.Object)null && this.refCount <= 0)
                {
                    if (!this.IsSharedResource)
                    {
                        if (this.objPool == null)
                            this.objPool = QueuePool<UnityEngine.Object>.Get();
                        this.objPool.Enqueue(obj);
                    }
                    this.IsDegeneration = true;
                    this.degenerationTime = 0.0f;
                    return true;
                }
                if (!this.IsSharedResource && obj != (UnityEngine.Object)null)
                {
                    if (useObjPool)
                    {
                        if (obj is GameObject)
                        {
                            GameObject gameObject = obj as GameObject;
                            gameObject.transform.position = XResourceLoaderMgr.Far_Far_Away;
                            gameObject.transform.rotation = Quaternion.identity;
                            gameObject.transform.parent = (Transform)null;
                        }
                        if (this.objPool == null)
                            this.objPool = QueuePool<UnityEngine.Object>.Get();
                        this.objPool.Enqueue(obj);
                    }
                    else if (XResourceLoaderMgr.UniteObjectInfo.CanDestroy(obj))
                        UnityEngine.Object.Destroy(obj);
                }
                return false;
            }

            public void Clear()
            {
                if (this.objPool != null)
                {
                    while (this.objPool.Count > 0)
                        UnityEngine.Object.Destroy(this.objPool.Dequeue());
                    QueuePool<UnityEngine.Object>.Release(this.objPool);
                    this.objPool = (Queue<UnityEngine.Object>)null;
                }
                if (this.assetBundleInfo != null)
                    this.assetBundleInfo.Release();
                else if (!XResourceLoaderMgr.UniteObjectInfo.CanDestroy(this.asset))
                    Resources.UnloadAsset(this.asset);
                else if (this.asset is XAnimationClip)
                {
                    XAnimationClip asset = this.asset as XAnimationClip;
                    if ((UnityEngine.Object)asset.clip != (UnityEngine.Object)null)
                        Resources.UnloadAsset((UnityEngine.Object)asset.clip);
                    XAnimationPool.Release(asset);
                }
                this.loc = "";
                this.hashID = 0U;
                this.asset = (UnityEngine.Object)null;
                this.refCount = 0;
                this.next = (XResourceLoaderMgr.UniteObjectInfo)null;
                this.degenerationTime = 0.0f;
                this.IsDegeneration = false;
                this.assetBundleInfo = (AssetBundleInfo)null;
            }

            public void ClearPool()
            {
                if (this.objPool == null)
                    return;
                while (this.objPool.Count > 0)
                    UnityEngine.Object.Destroy(this.objPool.Dequeue());
                QueuePool<UnityEngine.Object>.Release(this.objPool);
                this.objPool = (Queue<UnityEngine.Object>)null;
            }

            public static bool CanDestroy(UnityEngine.Object obj)
            {
                int num;
                switch (obj)
                {
                    case GameObject _:
                    case ScriptableObject _:
                        num = 1;
                        break;
                    default:
                        num = obj is Material ? 1 : 0;
                        break;
                }
                return num != 0;
            }
        }
    }
}
