using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000FD1 RID: 4049
	internal class WeaponLoadTask : MountLoadTask
	{
		// Token: 0x0600D24A RID: 53834 RVA: 0x003110F0 File Offset: 0x0030F2F0
		public WeaponLoadTask(EPartType p, MountLoadCallback mountPartLoadCb) : base(p, mountPartLoadCb)
		{
		}

		// Token: 0x0600D24B RID: 53835 RVA: 0x00311104 File Offset: 0x0030F304
		public override void Reset(XEntity e)
		{
			this.processStatus = EProcessStatus.ENotProcess;
			this.location = "";
			bool flag = this.xgo != null;
			if (flag)
			{
				XRenderComponent.RemoveObj(e, this.xgo.Get());
				XGameObject.DestroyXGameObject(this.xgo);
			}
			this.xgo = null;
			bool flag2 = this.xgo2 != null;
			if (flag2)
			{
				XRenderComponent.RemoveObj(e, this.xgo2.Get());
				XGameObject.DestroyXGameObject(this.xgo2);
			}
			this.xgo2 = null;
		}

		// Token: 0x0600D24C RID: 53836 RVA: 0x0031118C File Offset: 0x0030F38C
		public override void ProcessEnable(bool enable, bool forceDisable, int layer)
		{
			base.ProcessEnable(enable, forceDisable, layer);
			bool flag = this.xgo2 != null;
			if (flag)
			{
				MountLoadTask.ProcessEnable(this.xgo2, enable, forceDisable, layer);
			}
		}

		// Token: 0x0600D24D RID: 53837 RVA: 0x003111C4 File Offset: 0x0030F3C4
		public override void ProcessRenderQueue(int renderQueue)
		{
			base.ProcessRenderQueue(renderQueue);
			bool flag = this.xgo2 != null;
			if (flag)
			{
				MountLoadTask.ProcessRenderQueue(this.xgo2, renderQueue);
			}
		}

		// Token: 0x0600D24E RID: 53838 RVA: 0x003111F8 File Offset: 0x0030F3F8
		public override void ProcessRenderComponent(XEntity e)
		{
			base.ProcessRenderComponent(e);
			bool flag = this.xgo2 != null;
			if (flag)
			{
				MountLoadTask.ProcessRenderComponent(this.xgo2, e);
			}
		}

		// Token: 0x0600D24F RID: 53839 RVA: 0x0031122C File Offset: 0x0030F42C
		private static void _SecondWeaponLoaded(XGameObject gameObject, object o, int commandID)
		{
			XEntity xentity = o as XEntity;
			int layer = xentity.DefaultLayer;
			bool enable = true;
			bool flag = xentity.Equipment != null;
			if (flag)
			{
				bool isUIAvatar = xentity.Equipment.IsUIAvatar;
				if (isUIAvatar)
				{
					layer = XQualitySetting.UILayer;
				}
				enable = xentity.Equipment.IsRenderEnable;
			}
			MountLoadTask.ProcessRender(gameObject, xentity, layer, enable, -1, false);
		}

		// Token: 0x0600D250 RID: 53840 RVA: 0x00311288 File Offset: 0x0030F488
		public void PostProcess(Transform attachPoint0, Transform attachPoint1, XEntity e)
		{
			this.xgo.SetParentTrans(attachPoint0);
			bool isSkin = base.IsSkin;
			if (isSkin)
			{
				this.xgo.SetLocalPRS(Vector3.zero, true, WeaponLoadTask._defaultSkinRot, true, Vector3.one, true);
			}
			else
			{
				this.xgo.SetLocalPRS(Vector3.zero, true, Quaternion.identity, true, Vector3.one, true);
			}
			bool flag = attachPoint1 != null;
			if (flag)
			{
				bool flag2 = this.xgo2 == null;
				if (flag2)
				{
					this.xgo2 = XGameObject.CloneXGameObject(this.xgo, true);
					this.xgo2.CallCommand(WeaponLoadTask.secondWeaponLoaded, e, -1, false);
				}
				this.xgo2.SetParentTrans(attachPoint1);
				bool isSkin2 = base.IsSkin;
				if (isSkin2)
				{
					this.xgo2.SetLocalPRS(Vector3.zero, true, WeaponLoadTask._defaultSkinRot, true, Vector3.one, true);
				}
				else
				{
					this.xgo2.SetLocalPRS(Vector3.zero, true, Quaternion.identity, true, Vector3.one, true);
				}
			}
		}

		// Token: 0x04005F83 RID: 24451
		public XGameObject xgo2 = null;

		// Token: 0x04005F84 RID: 24452
		private static Quaternion _defaultSkinRot = Quaternion.Euler(new Vector3(-90f, 0f, 0f));

		// Token: 0x04005F85 RID: 24453
		private static CommandCallback secondWeaponLoaded = new CommandCallback(WeaponLoadTask._SecondWeaponLoaded);
	}
}
