// Decompiled with JetBrains decompiler
// Type: XMainClient.PartLoadTask
// Assembly: XMainClient, Version=1.0.6733.32538, Culture=neutral, PublicKeyToken=null
// MVID: 71510397-FE89-4B5C-BC50-B6D560866D97
// Assembly location: F:\龙之谷\Client\Assets\Lib\XMainClient.dll

using KKSG;
using System.Collections.Generic;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
    internal class PartLoadTask : EquipLoadTask
    {
        private string replaceMeshLocation = (string)null;
        private string replaceTexLocation = (string)null;
        public byte partType = 0;
        public Mesh mesh = (Mesh)null;
        private Texture2D tex = (Texture2D)null;
        private Texture2D aplhaTex = (Texture2D)null;
        private byte loadState = 0;
        private static PartLoadTask.MeshPart fakeMeshPart = new PartLoadTask.MeshPart();
        private static PartLoadTask.TexPart fakeTexPart = new PartLoadTask.TexPart();
        private static PartLoadTask.AlphaTexPart fakeAlphaTexPart = new PartLoadTask.AlphaTexPart();
        private LoadAsyncTask meshLoadTask = (LoadAsyncTask)null;
        private LoadAsyncTask texLoadTask = (LoadAsyncTask)null;
        private LoadAsyncTask alphaLoadTask = (LoadAsyncTask)null;
        private LoadCallBack loadCb = (LoadCallBack)null;
        private PartLoadCallback m_PartLoadCb = (PartLoadCallback)null;

        public PartLoadTask(EPartType p, PartLoadCallback partLoadCb)
          : base(p)
        {
            this.loadCb = new LoadCallBack(this.LoadFinish);
            this.m_PartLoadCb = partLoadCb;
        }

        public override void Load(
          XEntity e,
          int prefessionID,
          ref FashionPositionInfo newFpi,
          bool async,
          HashSet<string> loadedPath)
        {
            if (this.IsSamePart(ref newFpi))
            {
                if (this.m_PartLoadCb == null)
                    return;
                this.m_PartLoadCb((EquipLoadTask)this, false);
            }
            else
            {
                this.Reset(e);
                if (this.MakePath(ref newFpi, loadedPath))
                {
                    this.replaceMeshLocation = (string)null;
                    this.replaceTexLocation = (string)null;
                    if (XEquipDocument._MeshPartList.GetMeshInfo(this.location, prefessionID, (int)this.part, newFpi.fashionDir, out this.partType, ref this.replaceMeshLocation, ref this.replaceTexLocation))
                    {
                        if (async)
                        {
                            this.meshLoadTask = this.replaceMeshLocation == null ? XSingleton<XResourceLoaderMgr>.singleton.GetShareResourceAsync<Mesh>(this.location, ".asset", this.loadCb, (object)PartLoadTask.fakeMeshPart) : XSingleton<XResourceLoaderMgr>.singleton.GetShareResourceAsync<Mesh>(this.replaceMeshLocation, ".asset", this.loadCb, (object)PartLoadTask.fakeMeshPart);
                            if (this.replaceTexLocation != null)
                            {
                                this.texLoadTask = XSingleton<XResourceLoaderMgr>.singleton.GetShareResourceAsync<Texture2D>(this.replaceTexLocation, ".tga", this.loadCb, (object)PartLoadTask.fakeTexPart);
                                if ((int)this.partType == (int)XMeshPartList.CutoutPart)
                                    this.alphaLoadTask = XSingleton<XResourceLoaderMgr>.singleton.GetShareResourceAsync<Texture2D>(this.replaceTexLocation + "_A", ".png", this.loadCb, (object)PartLoadTask.fakeAlphaTexPart);
                            }
                            else
                            {
                                this.texLoadTask = XSingleton<XResourceLoaderMgr>.singleton.GetShareResourceAsync<Texture2D>(this.location, ".tga", this.loadCb, (object)PartLoadTask.fakeTexPart);
                                if ((int)this.partType == (int)XMeshPartList.CutoutPart)
                                    this.alphaLoadTask = XSingleton<XResourceLoaderMgr>.singleton.GetShareResourceAsync<Texture2D>(this.location + "_A", ".png", this.loadCb, (object)PartLoadTask.fakeAlphaTexPart);
                            }
                        }
                        else
                        {
                            this.LoadFinish(this.replaceMeshLocation == null ? (Object)XSingleton<XResourceLoaderMgr>.singleton.GetSharedResource<Mesh>(this.location, ".asset") : (Object)XSingleton<XResourceLoaderMgr>.singleton.GetSharedResource<Mesh>(this.replaceMeshLocation, ".asset"), (object)PartLoadTask.fakeMeshPart);
                            if (this.replaceTexLocation != null)
                            {
                                this.LoadFinish((Object)XSingleton<XResourceLoaderMgr>.singleton.GetSharedResource<Texture2D>(this.replaceTexLocation, ".tga"), (object)PartLoadTask.fakeTexPart);
                                if ((int)this.partType == (int)XMeshPartList.CutoutPart)
                                    this.LoadFinish((Object)XSingleton<XResourceLoaderMgr>.singleton.GetSharedResource<Texture2D>(this.replaceTexLocation + "_A", ".png"), (object)PartLoadTask.fakeAlphaTexPart);
                            }
                            else
                            {
                                this.LoadFinish((Object)XSingleton<XResourceLoaderMgr>.singleton.GetSharedResource<Texture2D>(this.location, ".tga"), (object)PartLoadTask.fakeTexPart);
                                if ((int)this.partType == (int)XMeshPartList.CutoutPart)
                                    this.LoadFinish((Object)XSingleton<XResourceLoaderMgr>.singleton.GetSharedResource<Texture2D>(this.location + "_A", ".png"), (object)PartLoadTask.fakeAlphaTexPart);
                            }
                        }
                    }
                    else
                    {
                        this.processStatus = EProcessStatus.EPreProcess;
                        if (this.m_PartLoadCb != null)
                            this.m_PartLoadCb((EquipLoadTask)this, true);
                    }
                }
                else if (this.m_PartLoadCb != null)
                    this.m_PartLoadCb((EquipLoadTask)this, true);
            }
        }

        private void LoadFinish(Object obj, object cbOjb)
        {
            if (this.processStatus != EProcessStatus.EProcessing)
                return;
            switch (cbOjb)
            {
                case PartLoadTask.MeshPart _:
                    this.mesh = obj as Mesh;
                    this.loadState |= (byte)1;
                    this.meshLoadTask = (LoadAsyncTask)null;
                    break;
                case PartLoadTask.TexPart _:
                    this.tex = obj as Texture2D;
                    this.texLoadTask = (LoadAsyncTask)null;
                    this.loadState |= (byte)2;
                    break;
                case PartLoadTask.AlphaTexPart _:
                    this.aplhaTex = obj as Texture2D;
                    this.alphaLoadTask = (LoadAsyncTask)null;
                    this.loadState |= (byte)4;
                    break;
                default:
                    XSingleton<XDebug>.singleton.AddErrorLog("assert error equip type");
                    break;
            }
            if ((int)XMeshPartList.ConvertType(this.partType) == (int)this.loadState)
            {
                this.processStatus = EProcessStatus.EPreProcess;
                if (this.m_PartLoadCb != null)
                    this.m_PartLoadCb((EquipLoadTask)this, true);
            }
        }

        public override void Reset(XEntity e)
        {
            if ((Object)this.mesh != (Object)null)
            {
                if (!string.IsNullOrEmpty(this.replaceMeshLocation))
                    XSingleton<XResourceLoaderMgr>.singleton.UnSafeDestroyShareResource(this.replaceMeshLocation, ".asset", (Object)this.mesh, XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_HALL);
                else
                    XSingleton<XResourceLoaderMgr>.singleton.UnSafeDestroyShareResource(this.location, ".asset", (Object)this.mesh, XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_HALL);
                this.mesh = (Mesh)null;
            }
            this.replaceMeshLocation = (string)null;
            if ((Object)this.tex != (Object)null)
            {
                if (!string.IsNullOrEmpty(this.replaceTexLocation))
                    XSingleton<XResourceLoaderMgr>.singleton.UnSafeDestroyShareResource(this.replaceTexLocation, ".tga", (Object)this.tex, XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_HALL);
                else
                    XSingleton<XResourceLoaderMgr>.singleton.UnSafeDestroyShareResource(this.location, ".tga", (Object)this.tex, XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_HALL);
                this.tex = (Texture2D)null;
            }
            if ((Object)this.aplhaTex != (Object)null)
            {
                XSingleton<XResourceLoaderMgr>.singleton.UnSafeDestroyShareResource(this.location + "_A", ".png", (Object)this.aplhaTex, XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_HALL);
                this.aplhaTex = (Texture2D)null;
            }
            this.replaceTexLocation = (string)null;
            this.loadState = (byte)0;
            if (this.meshLoadTask != null)
            {
                this.meshLoadTask.CancelLoad(this.loadCb);
                this.meshLoadTask = (LoadAsyncTask)null;
            }
            if (this.texLoadTask != null)
            {
                this.texLoadTask.CancelLoad(this.loadCb);
                this.texLoadTask = (LoadAsyncTask)null;
            }
            if (this.alphaLoadTask != null)
            {
                this.alphaLoadTask.CancelLoad(this.loadCb);
                this.alphaLoadTask = (LoadAsyncTask)null;
            }
            base.Reset(e);
        }

        public bool HasMesh() => (Object)this.mesh != (Object)null;

        public Texture2D GetTexture() => this.tex;

        public Texture2D GetAlpha() => this.aplhaTex;

        private class MeshPart
        {
        }

        private class TexPart
        {
        }

        private class AlphaTexPart
        {
        }
    }
}
