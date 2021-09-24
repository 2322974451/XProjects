using System;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XSuperArmorComponent : XComponent
	{

		public override uint ID
		{
			get
			{
				return XSuperArmorComponent.uuID;
			}
		}

		public override void Attached()
		{
			this.SetRecoveryTimeLimit(this._entity.Attributes.SuperArmorRecoveryTimeLimit);
		}

		public void SetRecoveryTimeLimit(double second)
		{
			this._recoveryTimeLimit = (float)second;
		}

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

		protected override void EventSubscribe()
		{
			base.RegisterEvent(XEventDefine.XEvent_WoozyOn, new XComponent.XEventHandler(this.OnWoozyEvent));
			base.RegisterEvent(XEventDefine.XEvent_WoozyOff, new XComponent.XEventHandler(this.OnWoozyOffEvent));
		}

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

		protected bool OnWoozyEvent(XEventArgs e)
		{
			this._woozyOn = true;
			return true;
		}

		public override void OnDetachFromHost()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this._timeToken);
			base.OnDetachFromHost();
		}

		private bool _woozyOn = false;

		private float _recoveryTimeLimit = 0f;

		private uint _timeToken = 0U;

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XSuperArmorComponent");

		private static readonly int BossType = 1;

		private static readonly int EliteType = 6;
	}
}
