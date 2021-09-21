using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000B1C RID: 2844
	internal class TowerInfo
	{
		// Token: 0x0600A73C RID: 42812 RVA: 0x001D8B34 File Offset: 0x001D6D34
		public TowerInfo()
		{
			this.Init();
		}

		// Token: 0x0600A73D RID: 42813 RVA: 0x001D8B48 File Offset: 0x001D6D48
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

		// Token: 0x0600A73E RID: 42814 RVA: 0x001D8B94 File Offset: 0x001D6D94
		public void Destroy()
		{
			this._DestroyFx();
		}

		// Token: 0x0600A73F RID: 42815 RVA: 0x001D8BA0 File Offset: 0x001D6DA0
		private void _DestroyFx()
		{
			bool flag = this.Fx != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this.Fx, true);
				this.Fx = null;
			}
		}

		// Token: 0x0600A740 RID: 42816 RVA: 0x001D8BD6 File Offset: 0x001D6DD6
		private void _SetDistanceType(float sqrDis)
		{
			this.bInRange = (sqrDis <= this.WarningSqrRadius);
		}

		// Token: 0x0600A741 RID: 42817 RVA: 0x001D8BEC File Offset: 0x001D6DEC
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

		// Token: 0x0600A742 RID: 42818 RVA: 0x001D8C30 File Offset: 0x001D6E30
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

		// Token: 0x0600A743 RID: 42819 RVA: 0x001D8D38 File Offset: 0x001D6F38
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

		// Token: 0x0600A744 RID: 42820 RVA: 0x001D8D84 File Offset: 0x001D6F84
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

		// Token: 0x04003DB7 RID: 15799
		public ulong UID;

		// Token: 0x04003DB8 RID: 15800
		public float WarningSqrRadius;

		// Token: 0x04003DB9 RID: 15801
		public ulong TargetUID;

		// Token: 0x04003DBA RID: 15802
		public XFx Fx;

		// Token: 0x04003DBB RID: 15803
		public XEntity Entity;

		// Token: 0x04003DBC RID: 15804
		public XTargetState TargetState;

		// Token: 0x04003DBD RID: 15805
		public XFxType FxType;

		// Token: 0x04003DBE RID: 15806
		public bool bInRange;
	}
}
