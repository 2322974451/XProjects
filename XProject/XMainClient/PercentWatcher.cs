using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal struct PercentWatcher
	{

		public static bool IsValidAttr(XAttributeDefine attr)
		{
			return attr == XAttributeDefine.XAttr_MaxMP_Percent || attr == XAttributeDefine.XAttr_MaxHP_Percent || attr == XAttributeDefine.XAttr_MaxSuperArmor_Percent;
		}

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

		private void _ChangeBasic()
		{
			XAttrChangeEventArgs @event = XEventPool<XAttrChangeEventArgs>.GetEvent();
			@event.AttrKey = this.m_BasicAttr;
			@event.DeltaValue = this.m_TargetDeltaBasic;
			@event.Firer = this.m_Atributes.Entity;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
		}

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

		public double TargetDeltaValue
		{
			get
			{
				return this.m_TargetDeltaBasic;
			}
		}

		public XAttributeDefine BasicAttr
		{
			get
			{
				return this.m_BasicAttr;
			}
		}

		private bool m_bValid;

		private double m_TargetDeltaPercent;

		private double m_TargetDeltaBasic;

		private XAttributeDefine m_BasicAttr;

		private XAttributes m_Atributes;
	}
}
