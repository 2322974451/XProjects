using System;
using System.Collections.Generic;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000FD2 RID: 4050
	internal class DecalLoadTask : EquipLoadTask
	{
		// Token: 0x0600D252 RID: 53842 RVA: 0x003113B8 File Offset: 0x0030F5B8
		public DecalLoadTask(EPartType p, PartLoadCallback partLoadCb, PartLoadTask face) : base(p)
		{
			this.loadCb = new LoadCallBack(this.LoadFinish);
			this.faceTask = face;
			this.m_PartLoadCb = partLoadCb;
		}

		// Token: 0x0600D253 RID: 53843 RVA: 0x00311414 File Offset: 0x0030F614
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

		// Token: 0x0600D254 RID: 53844 RVA: 0x003114DC File Offset: 0x0030F6DC
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

		// Token: 0x0600D255 RID: 53845 RVA: 0x0031152C File Offset: 0x0030F72C
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

		// Token: 0x0600D256 RID: 53846 RVA: 0x003115A0 File Offset: 0x0030F7A0
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

		// Token: 0x04005F86 RID: 24454
		public Texture2D decalTex = null;

		// Token: 0x04005F87 RID: 24455
		protected LoadAsyncTask loadTask = null;

		// Token: 0x04005F88 RID: 24456
		protected LoadCallBack loadCb = null;

		// Token: 0x04005F89 RID: 24457
		private PartLoadTask faceTask = null;

		// Token: 0x04005F8A RID: 24458
		private PartLoadCallback m_PartLoadCb = null;
	}
}
