using System;

namespace XMainClient
{

	internal class XBuffTriggerWhenRemove : XBuffTrigger
	{

		public XBuffTriggerWhenRemove(XBuff buff) : base(buff)
		{
		}

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
