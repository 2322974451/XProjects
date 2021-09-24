using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcG2C_EnterSceneNtf
	{

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
