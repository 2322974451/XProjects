using System;
using System.Collections.Generic;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008A3 RID: 2211
	internal class XBuffTriggerByQTE : XBuffTrigger
	{
		// Token: 0x0600861E RID: 34334 RVA: 0x0010D9A4 File Offset: 0x0010BBA4
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

		// Token: 0x0600861F RID: 34335 RVA: 0x0010D9FE File Offset: 0x0010BBFE
		public override void OnUpdate()
		{
			base.Trigger();
			base.OnUpdate();
		}

		// Token: 0x06008620 RID: 34336 RVA: 0x0010DA10 File Offset: 0x0010BC10
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

		// Token: 0x040029CD RID: 10701
		private HashSet<int> m_QTEList = new HashSet<int>();

		// Token: 0x040029CE RID: 10702
		private long m_PreToken = 0L;
	}
}
