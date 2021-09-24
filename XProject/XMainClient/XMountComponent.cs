using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XMountComponent : XComponent
	{

		public override uint ID
		{
			get
			{
				return XMountComponent.uuID;
			}
		}

		public XEntity Copilot
		{
			get
			{
				return this._mount_copilotMainBody;
			}
		}

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

		public void RealMount(Transform mountPoint, Vector3 pos, ref Quaternion basic_rotation, float mountScale)
		{
			bool flag = mountPoint == null || !XEntity.ValideEntity(this._mountMainBody);
			if (!flag)
			{
				XMountComponent._Mount(this._mountMainBody, mountPoint, pos, ref basic_rotation, mountScale);
			}
		}

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

		public void RealMountCopilot(Transform mountPoint, Vector3 pos, ref Quaternion basic_rotation, float mountScale)
		{
			bool flag = mountPoint == null || !XEntity.ValideEntity(this._mount_copilotMainBody);
			if (!flag)
			{
				XMountComponent._Mount(this._mount_copilotMainBody, mountPoint, pos, ref basic_rotation, mountScale);
			}
		}

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

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("MountComponent");

		private XEntity _mountMainBody = null;

		private XEntity _mount_copilotMainBody = null;
	}
}
