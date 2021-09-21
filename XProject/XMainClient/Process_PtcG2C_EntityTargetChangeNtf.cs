using System;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200153E RID: 5438
	internal class Process_PtcG2C_EntityTargetChangeNtf
	{
		// Token: 0x0600EA0F RID: 59919 RVA: 0x00343A6C File Offset: 0x00341C6C
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
