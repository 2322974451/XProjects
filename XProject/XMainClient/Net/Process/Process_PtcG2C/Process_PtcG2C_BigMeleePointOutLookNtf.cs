using System;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcG2C_BigMeleePointOutLookNtf
	{

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
