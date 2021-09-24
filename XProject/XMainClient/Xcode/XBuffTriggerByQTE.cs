using System;
using System.Collections.Generic;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XBuffTriggerByQTE : XBuffTrigger
	{

		public XBuffTriggerByQTE(XBuff buff) : base(buff)
		{
			int num = 0;
			for (;;)
			{
				int num2 = base._GetTriggerParamInt(buff.BuffInfo, num);
				bool flag = num2 == 0;
				if (flag)
				{
					break;
				}
				this.m_QTEList.Add(num2);
				num++;
			}
		}

		public override void OnUpdate()
		{
			base.Trigger();
			base.OnUpdate();
		}

		public override bool CheckTriggerCondition()
		{
			bool flag = base.Entity.Machine == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = this.m_PreToken == base.Entity.Machine.ActionToken;
				if (flag2)
				{
					result = false;
				}
				else
				{
					this.m_PreToken = base.Entity.Machine.ActionToken;
					bool flag3 = base.Entity.Machine.Current != XStateDefine.XState_BeHit && base.Entity.Machine.Current != XStateDefine.XState_Freeze;
					if (flag3)
					{
						result = false;
					}
					else
					{
						XQTEState qtespecificPhase = base.Entity.GetQTESpecificPhase();
						result = this.m_QTEList.Contains(XFastEnumIntEqualityComparer<XQTEState>.ToInt(qtespecificPhase));
					}
				}
			}
			return result;
		}

		private HashSet<int> m_QTEList = new HashSet<int>();

		private long m_PreToken = 0L;
	}
}
