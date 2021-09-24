using System;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcG2C_EntityTargetChangeNtf
	{

		public static void Process(PtcG2C_EntityTargetChangeNtf roPtc)
		{
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_MOBA;
			if (flag)
			{
				XMobaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XMobaBattleDocument>(XMobaBattleDocument.uuID);
				specificDocument.OnEntityTargetChange(roPtc.Data);
			}
		}
	}
}
