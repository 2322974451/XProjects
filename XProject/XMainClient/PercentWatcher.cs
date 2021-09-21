using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000DB2 RID: 3506
	internal struct PercentWatcher
	{
		// Token: 0x0600BE22 RID: 48674 RVA: 0x00278D24 File Offset: 0x00276F24
		public static bool IsValidAttr(XAttributeDefine attr)
		{
			return attr == XAttributeDefine.XAttr_MaxMP_Percent || attr == XAttributeDefine.XAttr_MaxHP_Percent || attr == XAttributeDefine.XAttr_MaxSuperArmor_Percent;
		}

		// Token: 0x0600BE23 RID: 48675 RVA: 0x00278D54 File Offset: 0x00276F54
		public PercentWatcher(XAttributes attributes, XAttributeDefine attr, double targetDeltaPercent)
		{
			this.m_bValid = false;
			this.m_TargetDeltaPercent = 0.0;
			this.m_TargetDeltaBasic = 0.0;
			this.m_BasicAttr = XAttributeDefine.XAttr_Invalid;
			this.m_Atributes = null;
			bool flag = !PercentWatcher.IsValidAttr(attr);
			if (!flag)
			{
				this.m_BasicAttr = XAttributeCommon.GetAttrCurAttr(attr);
				bool flag2 = this.m_BasicAttr == XAttributeDefine.XAttr_Invalid;
				if (!flag2)
				{
					this.m_bValid = true;
					this.m_Atributes = attributes;
					double attr2 = this.m_Atributes.GetAttr(attr);
					bool flag3 = attr2 + targetDeltaPercent <= -1.0;
					if (flag3)
					{
						targetDeltaPercent = -1.0 - attr2 + 0.001;
					}
					this.m_TargetDeltaPercent = targetDeltaPercent;
					double num = Math.Max(0.001, 1.0 + attr2);
					double attr3 = this.m_Atributes.GetAttr(this.m_BasicAttr);
					this.m_TargetDeltaBasic = attr3 / num * this.m_TargetDeltaPercent;
					this.m_TargetDeltaBasic = XCombat.CheckChangeHPLimit(this.m_BasicAttr, this.m_TargetDeltaBasic, attributes.Entity, true, true);
					bool flag4 = this.m_TargetDeltaPercent < 0.0;
					if (flag4)
					{
						this._ChangeBasic();
					}
				}
			}
		}

		// Token: 0x0600BE24 RID: 48676 RVA: 0x00278E98 File Offset: 0x00277098
		private void _ChangeBasic()
		{
			XAttrChangeEventArgs @event = XEventPool<XAttrChangeEventArgs>.GetEvent();
			@event.AttrKey = this.m_BasicAttr;
			@event.DeltaValue = this.m_TargetDeltaBasic;
			@event.Firer = this.m_Atributes.Entity;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
		}

		// Token: 0x0600BE25 RID: 48677 RVA: 0x00278EE4 File Offset: 0x002770E4
		public void Check()
		{
			bool flag = !this.m_bValid;
			if (!flag)
			{
				bool flag2 = this.m_TargetDeltaPercent > 0.0;
				if (flag2)
				{
					this._ChangeBasic();
				}
			}
		}

		// Token: 0x17003352 RID: 13138
		// (get) Token: 0x0600BE26 RID: 48678 RVA: 0x00278F20 File Offset: 0x00277120
		public double TargetDeltaValue
		{
			get
			{
				return this.m_TargetDeltaBasic;
			}
		}

		// Token: 0x17003353 RID: 13139
		// (get) Token: 0x0600BE27 RID: 48679 RVA: 0x00278F38 File Offset: 0x00277138
		public XAttributeDefine BasicAttr
		{
			get
			{
				return this.m_BasicAttr;
			}
		}

		// Token: 0x04004D9D RID: 19869
		private bool m_bValid;

		// Token: 0x04004D9E RID: 19870
		private double m_TargetDeltaPercent;

		// Token: 0x04004D9F RID: 19871
		private double m_TargetDeltaBasic;

		// Token: 0x04004DA0 RID: 19872
		private XAttributeDefine m_BasicAttr;

		// Token: 0x04004DA1 RID: 19873
		private XAttributes m_Atributes;
	}
}
