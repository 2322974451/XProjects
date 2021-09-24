using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class WeaponLoadTask : MountLoadTask
	{

		public WeaponLoadTask(EPartType p, MountLoadCallback mountPartLoadCb) : base(p, mountPartLoadCb)
		{
		}

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

		public override void ProcessEnable(bool enable, bool forceDisable, int layer)
		{
			base.ProcessEnable(enable, forceDisable, layer);
			bool flag = this.xgo2 != null;
			if (flag)
			{
				MountLoadTask.ProcessEnable(this.xgo2, enable, forceDisable, layer);
			}
		}

		public override void ProcessRenderQueue(int renderQueue)
		{
			base.ProcessRenderQueue(renderQueue);
			bool flag = this.xgo2 != null;
			if (flag)
			{
				MountLoadTask.ProcessRenderQueue(this.xgo2, renderQueue);
			}
		}

		public override void ProcessRenderComponent(XEntity e)
		{
			base.ProcessRenderComponent(e);
			bool flag = this.xgo2 != null;
			if (flag)
			{
				MountLoadTask.ProcessRenderComponent(this.xgo2, e);
			}
		}

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

		public XGameObject xgo2 = null;

		private static Quaternion _defaultSkinRot = Quaternion.Euler(new Vector3(-90f, 0f, 0f));

		private static CommandCallback secondWeaponLoaded = new CommandCallback(WeaponLoadTask._SecondWeaponLoaded);
	}
}
