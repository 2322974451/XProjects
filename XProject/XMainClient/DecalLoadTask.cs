using System;
using System.Collections.Generic;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class DecalLoadTask : EquipLoadTask
	{

		public DecalLoadTask(EPartType p, PartLoadCallback partLoadCb, PartLoadTask face) : base(p)
		{
			this.loadCb = new LoadCallBack(this.LoadFinish);
			this.faceTask = face;
			this.m_PartLoadCb = partLoadCb;
		}

		public override void Load(XEntity e, int prefessionID, ref FashionPositionInfo newFpi, bool async, HashSet<string> loadedPath)
		{
			bool flag = base.IsSamePart(ref newFpi);
			if (flag)
			{
				bool flag2 = this.m_PartLoadCb != null;
				if (flag2)
				{
					this.m_PartLoadCb(this, false);
				}
			}
			else
			{
				this.Reset(e);
				bool flag3 = base.MakePath(ref newFpi, loadedPath);
				if (flag3)
				{
					if (async)
					{
						this.loadTask = XSingleton<XResourceLoaderMgr>.singleton.GetShareResourceAsync<Texture2D>(this.location, ".tga", this.loadCb, this);
					}
					else
					{
						Texture2D sharedResource = XSingleton<XResourceLoaderMgr>.singleton.GetSharedResource<Texture2D>(this.location, ".tga", true, false);
						this.LoadFinish(sharedResource, this);
					}
				}
				else
				{
					bool flag4 = this.m_PartLoadCb != null;
					if (flag4)
					{
						this.m_PartLoadCb(this, false);
					}
				}
			}
		}

		private void LoadFinish(UnityEngine.Object obj, object cbOjb)
		{
			bool flag = this.processStatus == EProcessStatus.EProcessing;
			if (flag)
			{
				this.processStatus = EProcessStatus.EPreProcess;
				this.decalTex = (obj as Texture2D);
				bool flag2 = this.m_PartLoadCb != null;
				if (flag2)
				{
					this.m_PartLoadCb(this, false);
				}
			}
		}

		public override void Reset(XEntity e)
		{
			base.Reset(e);
			bool flag = this.decalTex != null;
			if (flag)
			{
				XSingleton<XResourceLoaderMgr>.singleton.UnSafeDestroyShareResource(this.location, ".tga", this.decalTex, false);
				this.decalTex = null;
			}
			bool flag2 = this.loadTask != null;
			if (flag2)
			{
				this.loadTask.CancelLoad(this.loadCb);
				this.loadTask = null;
			}
		}

		public void PostLoad(CombineMeshTask combineMeshTask)
		{
			bool flag = this.decalTex != null;
			Texture texture;
			if (flag)
			{
				texture = this.decalTex;
			}
			else
			{
				texture = this.faceTask.GetTexture();
			}
			bool flag2 = texture != null;
			if (flag2)
			{
				bool isOnepart = combineMeshTask.isOnepart;
				if (isOnepart)
				{
					ShaderManager.SetTexture(combineMeshTask.mpb, texture, ShaderManager._ShaderKeyIDFace);
				}
				else
				{
					ShaderManager.SetTexture(combineMeshTask.mpb, texture, ShaderManager._ShaderKeyIDSkin[0]);
				}
			}
			this.processStatus = EProcessStatus.EProcessed;
		}

		public Texture2D decalTex = null;

		protected LoadAsyncTask loadTask = null;

		protected LoadCallBack loadCb = null;

		private PartLoadTask faceTask = null;

		private PartLoadCallback m_PartLoadCb = null;
	}
}
