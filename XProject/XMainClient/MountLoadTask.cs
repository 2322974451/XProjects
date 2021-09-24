using System;
using System.Collections.Generic;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class MountLoadTask : EquipLoadTask
	{

		public MountLoadTask(EPartType p, MountLoadCallback mountPartLoadCb) : base(p)
		{
			this.m_MountPartLoadCb = mountPartLoadCb;
		}

		public bool IsSkin
		{
			get
			{
				return this.xgo != null && this.xgo.HasSkin;
			}
		}

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

		public override void Reset(XEntity e)
		{
			base.Reset(e);
			this.xgo = null;
		}

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

		public virtual void ProcessRender(XEntity e, int layer, bool enable, int renderQueue, bool forceDisable)
		{
			MountLoadTask.ProcessRender(this.xgo, e, layer, enable, renderQueue, forceDisable);
		}

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

		public virtual void ProcessEnable(bool enable, bool forceDisable, int layer)
		{
			MountLoadTask.ProcessEnable(this.xgo, enable, forceDisable, layer);
		}

		public virtual void ProcessRenderQueue(int renderQueue)
		{
			MountLoadTask.ProcessRenderQueue(this.xgo, renderQueue);
		}

		public virtual void ProcessRenderComponent(XEntity e)
		{
			MountLoadTask.ProcessRenderComponent(this.xgo, e);
		}

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

		public XGameObject xgo = null;

		private MountLoadCallback m_MountPartLoadCb = null;

		private static CommandCallback mountLoadFinish = new CommandCallback(MountLoadTask.LoadFinish);
	}
}
