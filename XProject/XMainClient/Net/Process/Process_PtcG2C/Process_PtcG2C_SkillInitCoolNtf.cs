using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcG2C_SkillInitCoolNtf
	{

		public static void Process(PtcG2C_SkillInitCoolNtf roPtc)
		{
			XInitCoolDownAllSkillsArgs @event = XEventPool<XInitCoolDownAllSkillsArgs>.GetEvent();
			@event.Firer = XSingleton<XGame>.singleton.Doc;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
		}
	}
}
