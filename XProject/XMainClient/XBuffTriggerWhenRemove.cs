using System;

namespace XMainClient
{
	// Token: 0x020008A4 RID: 2212
	internal class XBuffTriggerWhenRemove : XBuffTrigger
	{
		// Token: 0x06008621 RID: 34337 RVA: 0x0010DAC5 File Offset: 0x0010BCC5
		public XBuffTriggerWhenRemove(XBuff buff) : base(buff)
		{
		}

		// Token: 0x06008622 RID: 34338 RVA: 0x0010DAD0 File Offset: 0x0010BCD0
		public override void OnRemove(XEntity entity, bool IsReplaced)
		{
			bool flag = !IsReplaced;
			if (flag)
			{
				base.Trigger();
			}
			base.OnRemove(entity, IsReplaced);
		}
	}
}
