using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000FB9 RID: 4025
	internal class XActionSender : XSingleton<XActionSender>
	{
		// Token: 0x0600D131 RID: 53553 RVA: 0x00306478 File Offset: 0x00304678
		public void SendMoveAction(XEntity entity, float face, float speed, bool inertia)
		{
			bool flag = !entity.IsPlayer || XSingleton<XInput>.singleton.Freezed;
			if (!flag)
			{
				bool flag2 = face < 0f;
				if (flag2)
				{
					face += 360f;
				}
				uint num = (uint)Mathf.Floor(face + 0.5f);
				uint num2 = (uint)Mathf.Floor(speed * 10f + 0.5f);
				num |= num2 << 16;
				if (inertia)
				{
					num |= 2147483648U;
				}
				this._dir_movePtc.Data.PosXZ = (int)Mathf.Floor(entity.MoveObj.Position.z * 100f + 0.5f);
				this._dir_movePtc.Data.PosXZ |= (int)Mathf.Floor(entity.MoveObj.Position.x * 100f + 0.5f) << 16;
				this._dir_movePtc.Data.Common = (int)num;
				long num3 = this._stub + 1L;
				this._stub = num3;
				this._dir_tick = num3;
			}
		}

		// Token: 0x0600D132 RID: 53554 RVA: 0x00306594 File Offset: 0x00304794
		public void SendMoveAction(XEntity entity, Vector3 des, float speed, bool inertia, bool force2server = false)
		{
			bool flag = !entity.IsPlayer || (!force2server && XSingleton<XInput>.singleton.Freezed);
			if (!flag)
			{
				Vector3 dir = XSingleton<XCommon>.singleton.Horizontal(des - entity.MoveObj.Position);
				dir.y = 0f;
				float num = (dir.sqrMagnitude > 0f) ? XSingleton<XCommon>.singleton.AngleToFloat(dir) : XSingleton<XCommon>.singleton.AngleToFloat(entity.MoveObj.Forward);
				bool flag2 = num < 0f;
				if (flag2)
				{
					num += 360f;
				}
				uint num2 = (uint)Mathf.Floor(num + 0.5f);
				uint num3 = (uint)Mathf.Floor(speed * 10f + 0.5f);
				num2 |= num3 << 16;
				if (inertia)
				{
					num2 |= 2147483648U;
				}
				this._des_movePtc.Data.PosXZ = (int)Mathf.Floor(entity.MoveObj.Position.z * 100f + 0.5f);
				this._des_movePtc.Data.PosXZ |= (int)Mathf.Floor(entity.MoveObj.Position.x * 100f + 0.5f) << 16;
				this._des_movePtc.Data.DesXZ = (int)Mathf.Floor(des.z * 100f + 0.5f);
				this._des_movePtc.Data.DesXZ |= (int)Mathf.Floor(des.x * 100f + 0.5f) << 16;
				this._des_movePtc.Data.Common = (int)num2;
				long num4 = this._stub + 1L;
				this._stub = num4;
				this._des_tick = num4;
			}
		}

		// Token: 0x0600D133 RID: 53555 RVA: 0x0030676C File Offset: 0x0030496C
		public void Empty()
		{
			this._des_tick = 0L;
			this._dir_tick = 0L;
		}

		// Token: 0x0600D134 RID: 53556 RVA: 0x00306780 File Offset: 0x00304980
		public void Flush(bool immediately = false)
		{
			bool flag = immediately || this.SyncPass();
			if (flag)
			{
				bool flag2 = this._des_tick != 0L && this._dir_tick != 0L;
				if (flag2)
				{
					bool flag3 = this._des_tick < this._dir_tick;
					if (flag3)
					{
						XSingleton<XClientNetwork>.singleton.Send(this._des_movePtc);
						XSingleton<XClientNetwork>.singleton.Send(this._dir_movePtc);
					}
					else
					{
						XSingleton<XClientNetwork>.singleton.Send(this._dir_movePtc);
						XSingleton<XClientNetwork>.singleton.Send(this._des_movePtc);
					}
				}
				else
				{
					bool flag4 = this._des_tick != 0L;
					if (flag4)
					{
						XSingleton<XClientNetwork>.singleton.Send(this._des_movePtc);
					}
					bool flag5 = this._dir_tick != 0L;
					if (flag5)
					{
						XSingleton<XClientNetwork>.singleton.Send(this._dir_movePtc);
					}
				}
				this.Empty();
			}
		}

		// Token: 0x0600D135 RID: 53557 RVA: 0x00306868 File Offset: 0x00304A68
		public void SendSkillAction(XEntity entity, XEntity target, uint id, int slot)
		{
			bool flag = !entity.IsPlayer;
			if (!flag)
			{
				XSkillCore skill = entity.SkillMgr.GetSkill(id);
				this.ResetSkillPtc();
				this.skillPtc.Data.SkillID = id;
				this.skillPtc.Data.Target = (XEntity.ValideEntity(target) ? target.ID : 0UL);
				bool flag2 = slot != -1;
				if (flag2)
				{
					this.skillPtc.Data.Slot = slot;
				}
				bool feeding = XSingleton<XVirtualTab>.singleton.Feeding;
				if (feeding)
				{
					this.skillPtc.Data.ManualFace = (int)(XSingleton<XCommon>.singleton.AngleToFloat(XSingleton<XVirtualTab>.singleton.Direction) * 10f);
				}
				XSingleton<XClientNetwork>.singleton.Send(this.skillPtc);
			}
		}

		// Token: 0x0600D136 RID: 53558 RVA: 0x0030693C File Offset: 0x00304B3C
		public void SendSkillAction(XEntity entity, XEntity target, int slot)
		{
			bool flag = !entity.IsPlayer;
			if (!flag)
			{
				this.ResetSkillPtc();
				this.skillPtc.Data.Target = (XEntity.ValideEntity(target) ? target.ID : 0UL);
				this.skillPtc.Data.Slot = slot;
				bool feeding = XSingleton<XVirtualTab>.singleton.Feeding;
				if (feeding)
				{
					this.skillPtc.Data.ManualFace = (int)(XSingleton<XCommon>.singleton.AngleToFloat(XSingleton<XVirtualTab>.singleton.Direction) * 10f);
				}
				XSingleton<XClientNetwork>.singleton.Send(this.skillPtc);
			}
		}

		// Token: 0x0600D137 RID: 53559 RVA: 0x003069E4 File Offset: 0x00304BE4
		private bool SyncPass()
		{
			return XSingleton<XScene>.singleton.IsViewGridScene ? (Time.frameCount % (Application.targetFrameRate / 10) == 0) : ((Time.frameCount & 1) == 0);
		}

		// Token: 0x0600D138 RID: 53560 RVA: 0x00306A20 File Offset: 0x00304C20
		private void ResetSkillPtc()
		{
			this.skillPtc.Data.SkillIDSpecified = false;
			this.skillPtc.Data.SlotSpecified = false;
			this.skillPtc.Data.TargetSpecified = false;
			this.skillPtc.Data.ManualFaceSpecified = false;
		}

		// Token: 0x04005EAB RID: 24235
		private PtcC2G_MoveOperationReq _dir_movePtc = new PtcC2G_MoveOperationReq();

		// Token: 0x04005EAC RID: 24236
		private PtcC2G_MoveOperationReq _des_movePtc = new PtcC2G_MoveOperationReq();

		// Token: 0x04005EAD RID: 24237
		private PtcC2G_CastSkill skillPtc = new PtcC2G_CastSkill();

		// Token: 0x04005EAE RID: 24238
		private long _dir_tick = 0L;

		// Token: 0x04005EAF RID: 24239
		private long _des_tick = 0L;

		// Token: 0x04005EB0 RID: 24240
		private long _stub = 0L;
	}
}
