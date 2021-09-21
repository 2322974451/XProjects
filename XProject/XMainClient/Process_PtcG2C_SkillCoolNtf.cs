using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001330 RID: 4912
	internal class Process_PtcG2C_SkillCoolNtf
	{
		// Token: 0x0600E1AE RID: 57774 RVA: 0x00337EDC File Offset: 0x003360DC
		public static void Process(PtcG2C_SkillCoolNtf roPtc)
		{
			XCoolDownAllSkillsArgs @event = XEventPool<XCoolDownAllSkillsArgs>.GetEvent();
			@event.Firer = XSingleton<XGame>.singleton.Doc;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
		}
	}
}
