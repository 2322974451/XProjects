using System;
using System.Collections.Generic;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000FD0 RID: 4048
	internal class MountLoadTask : EquipLoadTask
	{
		// Token: 0x0600D23B RID: 53819 RVA: 0x00310B94 File Offset: 0x0030ED94
		public MountLoadTask(EPartType p, MountLoadCallback mountPartLoadCb) : base(p)
		{
			this.m_MountPartLoadCb = mountPartLoadCb;
		}

		// Token: 0x170036C5 RID: 14021
		// (get) Token: 0x0600D23C RID: 53820 RVA: 0x00310BB4 File Offset: 0x0030EDB4
		public bool IsSkin
		{
			get
			{
				return this.xgo != null && this.xgo.HasSkin;
			}
		}

		// Token: 0x0600D23D RID: 53821 RVA: 0x00310BDC File Offset: 0x0030EDDC
		public override void Load(XEntity e, int prefessionID, ref FashionPositionInfo newFpi, bool async, HashSet<string> loadedPath)
		{
			bool flag = base.IsSamePart(ref newFpi);
			if (flag)
			{
				bool flag2 = this.m_MountPartLoadCb != null;
				if (flag2)
				{
					this.m_MountPartLoadCb(this);
				}
			}
			else
			{
				this.Reset(e);
				bool flag3 = base.MakePath(ref newFpi, loadedPath);
				if (flag3)
				{
					this.xgo = XGameObject.CreateXGameObject(this.location, async, true);
					this.xgo.CallCommand(MountLoadTask.mountLoadFinish, this, -1, false);
				}
				else
				{
					bool flag4 = string.IsNullOrEmpty(this.location);
					if (flag4)
					{
						this.processStatus = EProcessStatus.EProcessing;
						MountLoadTask.LoadFinish(null, this, -1);
					}
				}
			}
		}

		// Token: 0x0600D23E RID: 53822 RVA: 0x00310C7B File Offset: 0x0030EE7B
		public override void Reset(XEntity e)
		{
			base.Reset(e);
			this.xgo = null;
		}

		// Token: 0x0600D23F RID: 53823 RVA: 0x00310C90 File Offset: 0x0030EE90
		private static void LoadFinish(XGameObject gameObject, object o, int commandID)
		{
			MountLoadTask mountLoadTask = o as MountLoadTask;
			bool flag = mountLoadTask != null;
			if (flag)
			{
				bool flag2 = mountLoadTask.processStatus == EProcessStatus.EProcessing;
				if (flag2)
				{
					mountLoadTask.processStatus = EProcessStatus.EPreProcess;
					bool flag3 = mountLoadTask.m_MountPartLoadCb != null;
					if (flag3)
					{
						mountLoadTask.m_MountPartLoadCb(mountLoadTask);
					}
				}
			}
		}

		// Token: 0x0600D240 RID: 53824 RVA: 0x00310CE4 File Offset: 0x0030EEE4
		public static void ProcessRender(XGameObject xgo, XEntity e, int layer, bool enable, int renderQueue, bool forceDisable)
		{
			bool flag = xgo != null;
			if (flag)
			{
				xgo.GetRender(XCommon.tmpRender);
				for (int i = 0; i < XCommon.tmpRender.Count; i++)
				{
					Renderer renderer = XCommon.tmpRender[i];
					bool flag2 = renderer.gameObject.CompareTag("BindedRes") || renderer.gameObject.CompareTag("Mount_BindedRes");
					bool flag3 = forceDisable && flag2 && layer != XQualitySetting.UILayer;
					if (flag3)
					{
						renderer.enabled = false;
					}
					else
					{
						renderer.enabled = enable;
						Material sharedMaterial = renderer.sharedMaterial;
						bool flag4 = sharedMaterial != null;
						if (flag4)
						{
							bool flag5 = sharedMaterial.shader.renderQueue < 3000;
							if (!flag5)
							{
								bool flag6 = renderQueue > 1000;
								if (flag6)
								{
									renderer.material.renderQueue = renderQueue;
								}
							}
							bool flag7 = layer >= 0;
							if (flag7)
							{
								renderer.gameObject.layer = layer;
								bool flag8 = layer != XQualitySetting.UILayer;
								if (flag8)
								{
									XRenderComponent.AddEquipObj(e, xgo.Get(), renderer);
								}
							}
						}
					}
				}
				XCommon.tmpRender.Clear();
			}
		}

		// Token: 0x0600D241 RID: 53825 RVA: 0x00310E2C File Offset: 0x0030F02C
		public virtual void ProcessRender(XEntity e, int layer, bool enable, int renderQueue, bool forceDisable)
		{
			MountLoadTask.ProcessRender(this.xgo, e, layer, enable, renderQueue, forceDisable);
		}

		// Token: 0x0600D242 RID: 53826 RVA: 0x00310E44 File Offset: 0x0030F044
		public static void ProcessEnable(XGameObject xgo, bool enable, bool forceDisable, int layer)
		{
			bool flag = xgo != null;
			if (flag)
			{
				xgo.GetRender(XCommon.tmpRender);
				for (int i = 0; i < XCommon.tmpRender.Count; i++)
				{
					Renderer renderer = XCommon.tmpRender[i];
					bool flag2 = forceDisable && renderer.gameObject.CompareTag("BindedRes") && layer != XQualitySetting.UILayer;
					if (flag2)
					{
						renderer.enabled = false;
					}
					else
					{
						renderer.enabled = enable;
					}
				}
				XCommon.tmpRender.Clear();
			}
		}

		// Token: 0x0600D243 RID: 53827 RVA: 0x00310ED8 File Offset: 0x0030F0D8
		public static void ProcessRenderQueue(XGameObject xgo, int renderQueue)
		{
			bool flag = renderQueue > 1000 && xgo != null;
			if (flag)
			{
				xgo.GetRender(XCommon.tmpRender);
				for (int i = 0; i < XCommon.tmpRender.Count; i++)
				{
					Renderer renderer = XCommon.tmpRender[i];
					Material sharedMaterial = renderer.sharedMaterial;
					bool flag2 = sharedMaterial != null && sharedMaterial.shader.renderQueue > 3000;
					if (flag2)
					{
						renderer.material.renderQueue = renderQueue;
					}
				}
				XCommon.tmpRender.Clear();
			}
		}

		// Token: 0x0600D244 RID: 53828 RVA: 0x00310F78 File Offset: 0x0030F178
		public static void ProcessRenderComponent(XGameObject xgo, XEntity e)
		{
			bool flag = xgo != null;
			if (flag)
			{
				xgo.GetRender(XCommon.tmpRender);
				for (int i = 0; i < XCommon.tmpRender.Count; i++)
				{
					Renderer render = XCommon.tmpRender[i];
					XRenderComponent.AddEquipObj(e, xgo.Get(), render);
				}
				XCommon.tmpRender.Clear();
			}
		}

		// Token: 0x0600D245 RID: 53829 RVA: 0x00310FDC File Offset: 0x0030F1DC
		public virtual void ProcessEnable(bool enable, bool forceDisable, int layer)
		{
			MountLoadTask.ProcessEnable(this.xgo, enable, forceDisable, layer);
		}

		// Token: 0x0600D246 RID: 53830 RVA: 0x00310FEE File Offset: 0x0030F1EE
		public virtual void ProcessRenderQueue(int renderQueue)
		{
			MountLoadTask.ProcessRenderQueue(this.xgo, renderQueue);
		}

		// Token: 0x0600D247 RID: 53831 RVA: 0x00310FFE File Offset: 0x0030F1FE
		public virtual void ProcessRenderComponent(XEntity e)
		{
			MountLoadTask.ProcessRenderComponent(this.xgo, e);
		}

		// Token: 0x0600D248 RID: 53832 RVA: 0x00311010 File Offset: 0x0030F210
		public XAffiliate PostProcess(XEntity e, XAffiliate aff, Transform attachPoint)
		{
			bool flag = attachPoint == null;
			XAffiliate result;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("not attachPoint part:{0}", new object[]
				{
					this.part
				});
				result = null;
			}
			else
			{
				bool flag2 = aff == null;
				if (flag2)
				{
					aff = XSingleton<XEntityMgr>.singleton.CreateAffiliate(this.fpi.presentID, this.xgo, e);
				}
				else
				{
					aff.Replace(this.fpi.presentID, this.xgo);
				}
				attachPoint.localScale = Vector3.one;
				Vector3 localScale = this.xgo.LocalScale;
				this.xgo.SetParentTrans(attachPoint);
				this.xgo.SetLocalPRS(Vector3.zero, true, Quaternion.identity, true, localScale, true);
				result = aff;
			}
			return result;
		}

		// Token: 0x04005F80 RID: 24448
		public XGameObject xgo = null;

		// Token: 0x04005F81 RID: 24449
		private MountLoadCallback m_MountPartLoadCb = null;

		// Token: 0x04005F82 RID: 24450
		private static CommandCallback mountLoadFinish = new CommandCallback(MountLoadTask.LoadFinish);
	}
}
