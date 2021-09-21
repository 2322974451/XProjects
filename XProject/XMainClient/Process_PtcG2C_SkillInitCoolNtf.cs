using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001465 RID: 5221
	internal class Process_PtcG2C_SkillInitCoolNtf
	{
		// Token: 0x0600E69B RID: 59035 RVA: 0x0033EC70 File Offset: 0x0033CE70
		public static void Process(PtcG2C_SkillInitCoolNtf roPtc)
		{
			XInitCoolDownAllSkillsArgs @event = XEventPool<XInitCoolDownAllSkillsArgs>.GetEvent();
			@event.Firer = XSingleton<XGame>.singleton.Doc;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
		}
	}
}
