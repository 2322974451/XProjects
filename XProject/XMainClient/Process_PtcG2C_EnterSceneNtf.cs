using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000FFA RID: 4090
	internal class Process_PtcG2C_EnterSceneNtf
	{
		// Token: 0x0600D48F RID: 54415 RVA: 0x0032191C File Offset: 0x0031FB1C
		public static void Process(PtcG2C_EnterSceneNtf roPtc)
		{
			XSingleton<XClientNetwork>.singleton.XLoginStep = XLoginStep.Playing;
			XHeroBattleDocument.LoadSkillHandler = roPtc.Data.canMorph;
			bool sceneReady = XSingleton<XScene>.singleton.SceneReady;
			if (sceneReady)
			{
				XSingleton<XScene>.singleton.SceneEnterTo(roPtc.Data, true);
			}
			else
			{
				XSingleton<XScene>.singleton.StoreSceneConfig(roPtc.Data);
			}
		}
	}
}
