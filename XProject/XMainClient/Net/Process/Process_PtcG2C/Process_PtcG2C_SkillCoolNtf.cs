using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcG2C_SkillCoolNtf
	{

		public static void Process(PtcG2C_SkillCoolNtf roPtc)
		{
			XCoolDownAllSkillsArgs @event = XEventPool<XCoolDownAllSkillsArgs>.GetEvent();
			@event.Firer = XSingleton<XGame>.singleton.Doc;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
		}
	}
}
