using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000FC7 RID: 4039
	internal class XMountComponent : XComponent
	{
		// Token: 0x170036B8 RID: 14008
		// (get) Token: 0x0600D201 RID: 53761 RVA: 0x0030E224 File Offset: 0x0030C424
		public override uint ID
		{
			get
			{
				return XMountComponent.uuID;
			}
		}

		// Token: 0x170036B9 RID: 14009
		// (get) Token: 0x0600D202 RID: 53762 RVA: 0x0030E23C File Offset: 0x0030C43C
		public XEntity Copilot
		{
			get
			{
				return this._mount_copilotMainBody;
			}
		}

		// Token: 0x0600D203 RID: 53763 RVA: 0x0030E254 File Offset: 0x0030C454
		public void PreMount(XEntity entity)
		{
			bool flag = XEntity.ValideEntity(entity);
			if (flag)
			{
				bool flag2 = this._mountMainBody != null;
				if (!flag2)
				{
					this._mountMainBody = entity;
					this._mountMainBody.OnMount(this._entity as XMount, false);
				}
			}
		}

		// Token: 0x0600D204 RID: 53764 RVA: 0x0030E29C File Offset: 0x0030C49C
		public void RealMount(Transform mountPoint, Vector3 pos, ref Quaternion basic_rotation, float mountScale)
		{
			bool flag = mountPoint == null || !XEntity.ValideEntity(this._mountMainBody);
			if (!flag)
			{
				XMountComponent._Mount(this._mountMainBody, mountPoint, pos, ref basic_rotation, mountScale);
			}
		}

		// Token: 0x0600D205 RID: 53765 RVA: 0x0030E2DC File Offset: 0x0030C4DC
		public bool PreMountCopilot(XEntity entity)
		{
			bool flag = XEntity.ValideEntity(entity);
			bool result;
			if (flag)
			{
				bool flag2 = this._mount_copilotMainBody != null;
				if (flag2)
				{
					result = false;
				}
				else
				{
					bool flag3 = entity.Machine != null;
					if (flag3)
					{
						entity.Machine.ForceToDefaultState(false);
					}
					entity.LookTo(this._entity.MoveObj.Forward);
					this._mount_copilotMainBody = entity;
					this._mount_copilotMainBody.OnMount(this._entity as XMount, true);
					result = true;
				}
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600D206 RID: 53766 RVA: 0x0030E360 File Offset: 0x0030C560
		public void RealMountCopilot(Transform mountPoint, Vector3 pos, ref Quaternion basic_rotation, float mountScale)
		{
			bool flag = mountPoint == null || !XEntity.ValideEntity(this._mount_copilotMainBody);
			if (!flag)
			{
				XMountComponent._Mount(this._mount_copilotMainBody, mountPoint, pos, ref basic_rotation, mountScale);
			}
		}

		// Token: 0x0600D207 RID: 53767 RVA: 0x0030E3A0 File Offset: 0x0030C5A0
		public void UnMount(XEntity entity)
		{
			bool flag = this._mountMainBody == entity;
			if (flag)
			{
				bool flag2 = this._mountMainBody == null;
				if (!flag2)
				{
					this.UnMountAll();
				}
			}
			else
			{
				bool flag3 = this._mount_copilotMainBody == entity;
				if (flag3)
				{
					bool flag4 = this._mount_copilotMainBody == null;
					if (!flag4)
					{
						this._UnMount(ref this._mount_copilotMainBody);
					}
				}
			}
		}

		// Token: 0x0600D208 RID: 53768 RVA: 0x0030E400 File Offset: 0x0030C600
		public void UnMountAll()
		{
			bool flag = this._mount_copilotMainBody != null;
			if (flag)
			{
				this._UnMount(ref this._mount_copilotMainBody);
			}
			bool flag2 = this._mountMainBody != null;
			if (flag2)
			{
				this._UnMount(ref this._mountMainBody);
			}
		}

		// Token: 0x0600D209 RID: 53769 RVA: 0x0030E444 File Offset: 0x0030C644
		private static void _Mount(XEntity mainBody, Transform mountPoint, Vector3 pos, ref Quaternion basic_rotation, float mountScale)
		{
			bool flag = mountScale > 0f;
			if (flag)
			{
				mountScale = 1f / mountScale;
			}
			mainBody.EngineObject.SetParentTrans(mountPoint);
			mainBody.EngineObject.SetLocalPRS(pos, true, Quaternion.Inverse(basic_rotation), true, Vector3.one * mountScale, true);
		}

		// Token: 0x0600D20A RID: 53770 RVA: 0x0030E4A0 File Offset: 0x0030C6A0
		private void _UnMount(ref XEntity mountEntity)
		{
			bool flag = !mountEntity.Destroying;
			if (flag)
			{
				Vector3 position = this._entity.EngineObject.Position;
				position.y += 0.5f;
				mountEntity.EngineObject.SetParent(null);
				mountEntity.EngineObject.Position = position;
				mountEntity.EngineObject.Rotation = this._entity.EngineObject.Rotation;
				mountEntity.EngineObject.LocalScale = Vector3.one;
				mountEntity.OnMount(null, false);
			}
			mountEntity = null;
		}

		// Token: 0x04005F46 RID: 24390
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("MountComponent");

		// Token: 0x04005F47 RID: 24391
		private XEntity _mountMainBody = null;

		// Token: 0x04005F48 RID: 24392
		private XEntity _mount_copilotMainBody = null;
	}
}
