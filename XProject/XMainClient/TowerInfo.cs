using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class TowerInfo
	{

		public TowerInfo()
		{
			this.Init();
		}

		public void Init()
		{
			this.UID = 0UL;
			this.WarningSqrRadius = 0f;
			this.TargetUID = 0UL;
			this.Fx = null;
			this.Entity = null;
			this.TargetState = XTargetState.TS_NONE;
			this.FxType = XFxType.FT_NONE;
			this.bInRange = false;
		}

		public void Destroy()
		{
			this._DestroyFx();
		}

		private void _DestroyFx()
		{
			bool flag = this.Fx != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this.Fx, true);
				this.Fx = null;
			}
		}

		private void _SetDistanceType(float sqrDis)
		{
			this.bInRange = (sqrDis <= this.WarningSqrRadius);
		}

		private void _SetTargetType(ulong playerUID)
		{
			bool flag = this.TargetUID == 0UL;
			if (flag)
			{
				this.TargetState = XTargetState.TS_NONE;
			}
			else
			{
				bool flag2 = this.TargetUID == playerUID;
				if (flag2)
				{
					this.TargetState = XTargetState.TS_ME;
				}
				else
				{
					this.TargetState = XTargetState.TS_OTHER;
				}
			}
		}

		private void _SetFx(XFxType newFxType, Vector3 pos)
		{
			bool flag = newFxType == this.FxType;
			if (!flag)
			{
				this.FxType = newFxType;
				this._DestroyFx();
				bool flag2 = this.FxType == XFxType.FT_NONE;
				if (!flag2)
				{
					bool flag3 = XEntity.FilterFx(pos, XFxMgr.FilterFxDis1);
					if (!flag3)
					{
						switch (this.FxType)
						{
						case XFxType.FT_WARNING:
							this.Fx = XSingleton<XFxMgr>.singleton.CreateFx(XSingleton<XGlobalConfig>.singleton.GetValue("MobaTowerFxWarning"), null, true);
							break;
						case XFxType.FT_OTHER:
							this.Fx = XSingleton<XFxMgr>.singleton.CreateFx(XSingleton<XGlobalConfig>.singleton.GetValue("MobaTowerFxOther"), null, true);
							break;
						case XFxType.FT_ME:
							this.Fx = XSingleton<XFxMgr>.singleton.CreateFx(XSingleton<XGlobalConfig>.singleton.GetValue("MobaTowerFxMe"), null, true);
							break;
						}
						bool flag4 = this.Fx != null;
						if (flag4)
						{
							this.Fx.Play(pos, Quaternion.identity, Vector3.one, 1f);
						}
					}
				}
			}
		}

		private XFxType _GetFxType()
		{
			bool flag = !this.bInRange;
			XFxType result;
			if (flag)
			{
				result = XFxType.FT_NONE;
			}
			else
			{
				switch (this.TargetState)
				{
				case XTargetState.TS_NONE:
					result = XFxType.FT_WARNING;
					break;
				case XTargetState.TS_ME:
					result = XFxType.FT_ME;
					break;
				case XTargetState.TS_OTHER:
					result = XFxType.FT_OTHER;
					break;
				default:
					result = XFxType.FT_NONE;
					break;
				}
			}
			return result;
		}

		public void Update()
		{
			bool flag = XSingleton<XEntityMgr>.singleton.Player == null;
			if (!flag)
			{
				bool flag2 = !XEntity.ValideEntity(this.Entity);
				if (!flag2)
				{
					Vector3 position = this.Entity.MoveObj.Position;
					Vector3 position2 = XSingleton<XEntityMgr>.singleton.Player.MoveObj.Position;
					float sqrMagnitude = (position - position2).sqrMagnitude;
					this._SetDistanceType(sqrMagnitude);
					this._SetTargetType(XSingleton<XEntityMgr>.singleton.Player.ID);
					XFxType newFxType = this._GetFxType();
					this._SetFx(newFxType, position);
				}
			}
		}

		public ulong UID;

		public float WarningSqrRadius;

		public ulong TargetUID;

		public XFx Fx;

		public XEntity Entity;

		public XTargetState TargetState;

		public XFxType FxType;

		public bool bInRange;
	}
}
