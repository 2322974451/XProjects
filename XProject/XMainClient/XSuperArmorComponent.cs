using System;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000FC6 RID: 4038
	internal class XSuperArmorComponent : XComponent
	{
		// Token: 0x170036B7 RID: 14007
		// (get) Token: 0x0600D1F3 RID: 53747 RVA: 0x0030DB48 File Offset: 0x0030BD48
		public override uint ID
		{
			get
			{
				return XSuperArmorComponent.uuID;
			}
		}

		// Token: 0x0600D1F4 RID: 53748 RVA: 0x0030DB5F File Offset: 0x0030BD5F
		public override void Attached()
		{
			this.SetRecoveryTimeLimit(this._entity.Attributes.SuperArmorRecoveryTimeLimit);
		}

		// Token: 0x0600D1F5 RID: 53749 RVA: 0x0030DB79 File Offset: 0x0030BD79
		public void SetRecoveryTimeLimit(double second)
		{
			this._recoveryTimeLimit = (float)second;
		}

		// Token: 0x0600D1F6 RID: 53750 RVA: 0x0030DB84 File Offset: 0x0030BD84
		public override void Update(float fDeltaT)
		{
			bool syncMode = XSingleton<XGame>.singleton.SyncMode;
			if (!syncMode)
			{
				bool isSuperArmorBroken = this._entity.Attributes.IsSuperArmorBroken;
				if (isSuperArmorBroken)
				{
					this.RecoverySuperArmor(fDeltaT);
				}
				else
				{
					this.CheckSuperArmorBroken();
				}
			}
		}

		// Token: 0x0600D1F7 RID: 53751 RVA: 0x0030DBCC File Offset: 0x0030BDCC
		private void OnTimer(object o)
		{
			XAttrChangeEventArgs @event = XEventPool<XAttrChangeEventArgs>.GetEvent();
			@event.AttrKey = XAttributeDefine.XAttr_CurrentSuperArmor_Basic;
			@event.DeltaValue = this._entity.Attributes.GetAttr(XAttributeDefine.XAttr_MaxSuperArmor_Basic) - this._entity.Attributes.GetAttr(XAttributeDefine.XAttr_CurrentSuperArmor_Basic) + 1.0;
			@event.Firer = this._entity;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
			this._entity.Attributes.IsSuperArmorBroken = false;
			this._woozyOn = false;
			XArmorRecoverArgs event2 = XEventPool<XArmorRecoverArgs>.GetEvent();
			event2.Firer = this._entity;
			XSingleton<XEventMgr>.singleton.FireEvent(event2);
			XArmorRecoverArgs event3 = XEventPool<XArmorRecoverArgs>.GetEvent();
			event3.Firer = XSingleton<XGame>.singleton.Doc;
			event3.Self = this._entity;
			XSingleton<XEventMgr>.singleton.FireEvent(event3);
		}

		// Token: 0x0600D1F8 RID: 53752 RVA: 0x0030DCA0 File Offset: 0x0030BEA0
		private void CheckSuperArmorBroken()
		{
			bool flag = this._entity.Attributes.GetAttr(XAttributeDefine.XAttr_CurrentSuperArmor_Basic) <= 0.0 && this._entity.Attributes.GetAttr(XAttributeDefine.XAttr_CurrentHP_Basic) > 0.0;
			if (flag)
			{
				this._woozyOn = false;
				this._entity.Attributes.IsSuperArmorBroken = true;
				XArmorBrokenArgs @event = XEventPool<XArmorBrokenArgs>.GetEvent();
				@event.Firer = this._entity;
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
				XArmorBrokenArgs event2 = XEventPool<XArmorBrokenArgs>.GetEvent();
				event2.Firer = XSingleton<XGame>.singleton.Doc;
				event2.Self = this._entity;
				XSingleton<XEventMgr>.singleton.FireEvent(event2);
				bool flag2 = !XSingleton<XGame>.singleton.SyncMode;
				if (flag2)
				{
					bool flag3 = this._recoveryTimeLimit > 0f;
					if (flag3)
					{
						this._timeToken = XSingleton<XTimerMgr>.singleton.SetTimer(this._recoveryTimeLimit, new XTimerMgr.ElapsedEventHandler(this.OnTimer), null);
					}
					XEntityStatistics.RowData byID = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID(this._entity.TypeID);
					bool flag4 = byID != null;
					if (flag4)
					{
						bool flag5 = byID.SuperArmorBrokenBuff[0] != 0 && byID.SuperArmorBrokenBuff[1] != 0;
						if (flag5)
						{
							XBuffAddEventArgs event3 = XEventPool<XBuffAddEventArgs>.GetEvent();
							event3.xBuffDesc.BuffID = byID.SuperArmorBrokenBuff[0];
							event3.xBuffDesc.BuffLevel = byID.SuperArmorBrokenBuff[1];
							event3.Firer = this._entity;
							event3.xBuffDesc.CasterID = this._entity.ID;
							XSingleton<XEventMgr>.singleton.FireEvent(event3);
						}
					}
				}
			}
		}

		// Token: 0x0600D1F9 RID: 53753 RVA: 0x0030DE6C File Offset: 0x0030C06C
		private double GetRateByState()
		{
			XQTEState qtespecificPhase = this._entity.GetQTESpecificPhase();
			bool flag = qtespecificPhase > XQTEState.QTE_None;
			if (flag)
			{
				int num = XSingleton<XEntityMgr>.singleton.SuperArmorCoffTable.Table.Length;
				int i = 0;
				while (i < num)
				{
					SuperArmorRecoveryCoffTable.RowData rowData = XSingleton<XEntityMgr>.singleton.SuperArmorCoffTable.Table[i];
					bool flag2 = rowData.Value == XFastEnumIntEqualityComparer<XQTEState>.ToInt(qtespecificPhase);
					if (flag2)
					{
						bool flag3 = this._entity.IsBoss && rowData.monster_type == XSuperArmorComponent.BossType;
						if (flag3)
						{
							return rowData.SupRecoveryChange;
						}
						bool flag4 = this._entity.IsElite && rowData.monster_type == XSuperArmorComponent.EliteType;
						if (flag4)
						{
							return rowData.SupRecoveryChange;
						}
						return rowData.SupRecoveryChange;
					}
					else
					{
						i++;
					}
				}
			}
			return 1.0;
		}

		// Token: 0x0600D1FA RID: 53754 RVA: 0x0030DF64 File Offset: 0x0030C164
		private void RecoverySuperArmor(float fDeltaT)
		{
			bool woozyOn = this._woozyOn;
			if (woozyOn)
			{
				bool flag = !XSingleton<XGame>.singleton.SyncMode;
				if (flag)
				{
					double attr = this._entity.Attributes.GetAttr(XAttributeDefine.XAttr_SuperArmorRecovery_Total);
					double rateByState = this.GetRateByState();
					XAttrChangeEventArgs @event = XEventPool<XAttrChangeEventArgs>.GetEvent();
					@event.AttrKey = XAttributeDefine.XAttr_CurrentSuperArmor_Basic;
					@event.DeltaValue = attr * rateByState * (double)fDeltaT;
					@event.Firer = this._entity;
					XSingleton<XEventMgr>.singleton.FireEvent(@event);
				}
				bool flag2 = this._entity.Attributes.GetAttr(XAttributeDefine.XAttr_CurrentSuperArmor_Basic) == this._entity.Attributes.GetAttr(XAttributeDefine.XAttr_MaxSuperArmor_Basic) && this._entity.Attributes.GetAttr(XAttributeDefine.XAttr_CurrentHP_Basic) > 0.0;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddLog("Stop Broken State", null, null, null, null, null, XDebugColor.XDebug_None);
					this._entity.Attributes.IsSuperArmorBroken = false;
					this._woozyOn = false;
					XArmorRecoverArgs event2 = XEventPool<XArmorRecoverArgs>.GetEvent();
					event2.Firer = this._entity;
					XSingleton<XEventMgr>.singleton.FireEvent(event2);
					XArmorRecoverArgs event3 = XEventPool<XArmorRecoverArgs>.GetEvent();
					event3.Firer = XSingleton<XGame>.singleton.Doc;
					event3.Self = this._entity;
					XSingleton<XEventMgr>.singleton.FireEvent(event3);
					XSingleton<XTimerMgr>.singleton.KillTimer(this._timeToken);
				}
			}
		}

		// Token: 0x0600D1FB RID: 53755 RVA: 0x0030E0D0 File Offset: 0x0030C2D0
		protected override void EventSubscribe()
		{
			base.RegisterEvent(XEventDefine.XEvent_WoozyOn, new XComponent.XEventHandler(this.OnWoozyEvent));
			base.RegisterEvent(XEventDefine.XEvent_WoozyOff, new XComponent.XEventHandler(this.OnWoozyOffEvent));
		}

		// Token: 0x0600D1FC RID: 53756 RVA: 0x0030E104 File Offset: 0x0030C304
		protected bool OnWoozyOffEvent(XEventArgs e)
		{
			bool flag = !XSingleton<XGame>.singleton.SyncMode;
			if (flag)
			{
				XEntityStatistics.RowData byID = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID(this._entity.TypeID);
				bool flag2 = byID != null && byID.SuperArmorBrokenBuff[0] != 0 && byID.SuperArmorBrokenBuff[1] != 0;
				if (flag2)
				{
					XBuffRemoveEventArgs @event = XEventPool<XBuffRemoveEventArgs>.GetEvent();
					@event.xBuffID = byID.SuperArmorBrokenBuff[0];
					@event.Firer = this._entity;
					XSingleton<XEventMgr>.singleton.FireEvent(@event);
				}
			}
			this._woozyOn = false;
			return true;
		}

		// Token: 0x0600D1FD RID: 53757 RVA: 0x0030E1A8 File Offset: 0x0030C3A8
		protected bool OnWoozyEvent(XEventArgs e)
		{
			this._woozyOn = true;
			return true;
		}

		// Token: 0x0600D1FE RID: 53758 RVA: 0x0030E1C2 File Offset: 0x0030C3C2
		public override void OnDetachFromHost()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this._timeToken);
			base.OnDetachFromHost();
		}

		// Token: 0x04005F40 RID: 24384
		private bool _woozyOn = false;

		// Token: 0x04005F41 RID: 24385
		private float _recoveryTimeLimit = 0f;

		// Token: 0x04005F42 RID: 24386
		private uint _timeToken = 0U;

		// Token: 0x04005F43 RID: 24387
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XSuperArmorComponent");

		// Token: 0x04005F44 RID: 24388
		private static readonly int BossType = 1;

		// Token: 0x04005F45 RID: 24389
		private static readonly int EliteType = 6;
	}
}
