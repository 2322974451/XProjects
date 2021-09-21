using System;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001660 RID: 5728
	internal class Process_PtcG2C_BigMeleePointOutLookNtf
	{
		// Token: 0x0600EECE RID: 61134 RVA: 0x0034A4DC File Offset: 0x003486DC
		public static void Process(PtcG2C_BigMeleePointOutLookNtf roPtc)
		{
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_BIGMELEE_FIGHT;
			if (flag)
			{
				XBigMeleeBattleDocument.Doc.SetPoint(roPtc.Data.roleid, roPtc.Data.point);
			}
		}
	}
}
