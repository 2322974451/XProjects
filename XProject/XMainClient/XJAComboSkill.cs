using System;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000EE2 RID: 3810
	internal sealed class XJAComboSkill : XArtsSkill
	{
		// Token: 0x17003538 RID: 13624
		// (get) Token: 0x0600C9FC RID: 51708 RVA: 0x002DAD70 File Offset: 0x002D8F70
		public bool DuringJA
		{
			get
			{
				return this._during_ja;
			}
		}

		// Token: 0x17003539 RID: 13625
		// (get) Token: 0x0600C9FD RID: 51709 RVA: 0x002DAD88 File Offset: 0x002D8F88
		public override int SkillType
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x0600C9FE RID: 51710 RVA: 0x002DAD9C File Offset: 0x002D8F9C
		public bool IsInJaPeriod()
		{
			XJAData xjadata = this._data.Ja[0];
			return XSingleton<XCommon>.singleton.IsLess(base.TimeElapsed, xjadata.End * this._time_scale) && XSingleton<XCommon>.singleton.IsGreater(base.TimeElapsed, xjadata.At * this._time_scale);
		}

		// Token: 0x0600C9FF RID: 51711 RVA: 0x002DAE00 File Offset: 0x002D9000
		public void ReFire(uint id, XEntity target, int slot, float speed, uint sequence)
		{
			this._during_ja = false;
			bool flag = id > 0U;
			if (flag)
			{
				XSkillCore skill = this._skillmgr.GetSkill(id);
				bool flag2 = skill != null;
				if (flag2)
				{
					this._firer.Skill.EndSkill(false, true);
					XAttackEventArgs @event = XEventPool<XAttackEventArgs>.GetEvent();
					@event.Identify = id;
					@event.Firer = this._firer;
					@event.Slot = slot;
					@event.Target = target;
					@event.TimeScale = speed;
					@event.SyncSequence = sequence;
					XSingleton<XEventMgr>.singleton.FireEvent(@event);
				}
			}
			else
			{
				XSkillJAPassedEventArgs event2 = XEventPool<XSkillJAPassedEventArgs>.GetEvent();
				event2.Firer = this._firer;
				event2.Slot = this._slot_pos;
				XSingleton<XEventMgr>.singleton.FireEvent(event2);
			}
		}

		// Token: 0x0600CA00 RID: 51712 RVA: 0x002DAEC0 File Offset: 0x002D90C0
		private uint GetNextJAIdentify()
		{
			uint result = 0U;
			bool flag = this.ValidJA();
			if (flag)
			{
				XJAData xjadata = this._data.Ja[0];
				bool isPlayer = this._firer.IsPlayer;
				bool flag2;
				if (isPlayer)
				{
					bool autoPlayOn = (this._firer.Attributes as XPlayerAttributes).AutoPlayOn;
					if (autoPlayOn)
					{
						flag2 = true;
					}
					else
					{
						float lastAttackTime = DlgBase<BattleMain, BattleMainBehaviour>.singleton.SkillHandler.LastAttackTime;
						float a = lastAttackTime - this._sub_fire_time;
						flag2 = (XSingleton<XCommon>.singleton.IsLess(a, xjadata.End * this._time_scale) && XSingleton<XCommon>.singleton.IsGreater(a, xjadata.At * this._time_scale));
					}
				}
				else
				{
					flag2 = true;
				}
				bool flag3 = flag2;
				if (flag3)
				{
					result = XSingleton<XCommon>.singleton.XHash(xjadata.Name);
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.SkillHandler.LastAttackTime = 0f;
				}
				else
				{
					result = XSingleton<XCommon>.singleton.XHash(xjadata.Next_Name);
				}
			}
			return result;
		}

		// Token: 0x0600CA01 RID: 51713 RVA: 0x002DAFCC File Offset: 0x002D91CC
		private void ReFire(object param)
		{
			uint nextJAIdentify = this.GetNextJAIdentify();
			bool flag = nextJAIdentify > 0U;
			if (flag)
			{
				bool syncMode = XSingleton<XGame>.singleton.SyncMode;
				if (!syncMode)
				{
					XSkillCore skill = this._skillmgr.GetSkill(nextJAIdentify);
					bool flag2 = skill != null && skill.CanCast(this._token);
					if (flag2)
					{
						this._firer.Net.ReportSkillAction(null, XSingleton<XCommon>.singleton.XHash(skill.Soul.Name), this._slot_pos);
					}
				}
			}
			else
			{
				this._during_ja = false;
				XSkillJAPassedEventArgs @event = XEventPool<XSkillJAPassedEventArgs>.GetEvent();
				@event.Firer = this._firer;
				@event.Slot = this._slot_pos;
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
			}
		}

		// Token: 0x0600CA02 RID: 51714 RVA: 0x002DB08C File Offset: 0x002D928C
		protected override void Start()
		{
			this._sub_fire_time = Time.time;
			this._during_ja = false;
			bool isPlayer = this._firer.IsPlayer;
			if (isPlayer)
			{
				this.JAAt();
			}
			base.Start();
		}

		// Token: 0x0600CA03 RID: 51715 RVA: 0x002DB0CC File Offset: 0x002D92CC
		protected override void Stop(bool cleanUp)
		{
			base.Stop(cleanUp);
			bool flag = !this._firer.Destroying && this._during_ja;
			if (flag)
			{
				this._during_ja = false;
				XSkillJAPassedEventArgs @event = XEventPool<XSkillJAPassedEventArgs>.GetEvent();
				@event.Firer = this._firer;
				@event.Slot = this._slot_pos;
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
			}
		}

		// Token: 0x0600CA04 RID: 51716 RVA: 0x002DB130 File Offset: 0x002D9330
		private void OnEnter(object o)
		{
			this._during_ja = true;
		}

		// Token: 0x0600CA05 RID: 51717 RVA: 0x002DB13A File Offset: 0x002D933A
		private void OnLeave(object o)
		{
			this._during_ja = false;
		}

		// Token: 0x0600CA06 RID: 51718 RVA: 0x002DB144 File Offset: 0x002D9344
		private void JAAt()
		{
			bool flag = this._ReFire == null;
			if (flag)
			{
				this._ReFire = new XTimerMgr.ElapsedEventHandler(this.ReFire);
			}
			bool flag2 = this._EnterJA == null;
			if (flag2)
			{
				this._EnterJA = new XTimerMgr.ElapsedEventHandler(this.OnEnter);
			}
			bool flag3 = this._LeaveJA == null;
			if (flag3)
			{
				this._LeaveJA = new XTimerMgr.ElapsedEventHandler(this.OnLeave);
			}
			bool flag4 = this._data.Ja.Count == 1;
			if (flag4)
			{
				base.AddedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer(this._data.Ja[0].Point * this._time_scale, this._ReFire, null), true);
				base.AddedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer(this._data.Ja[0].At * this._time_scale, this._EnterJA, null), true);
				base.AddedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer(this._data.Ja[0].End * this._time_scale, this._LeaveJA, null), true);
			}
			else
			{
				this._during_ja = true;
			}
		}

		// Token: 0x0600CA07 RID: 51719 RVA: 0x002DB278 File Offset: 0x002D9478
		private bool ValidJA()
		{
			return true;
		}

		// Token: 0x0400594B RID: 22859
		private float _sub_fire_time = 0f;

		// Token: 0x0400594C RID: 22860
		private bool _during_ja = false;

		// Token: 0x0400594D RID: 22861
		private XTimerMgr.ElapsedEventHandler _ReFire = null;

		// Token: 0x0400594E RID: 22862
		private XTimerMgr.ElapsedEventHandler _EnterJA = null;

		// Token: 0x0400594F RID: 22863
		private XTimerMgr.ElapsedEventHandler _LeaveJA = null;
	}
}
