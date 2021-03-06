using System;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcG2C_PvpBattleKill
	{

		public static void Process(PtcG2C_PvpBattleKill roPtc)
		{
			SceneType sceneType = XSingleton<XSceneMgr>.singleton.GetSceneType(XSingleton<XScene>.singleton.SceneID);
			SceneType sceneType2 = sceneType;
			if (sceneType2 <= SceneType.SCENE_HEROBATTLE)
			{
				if (sceneType2 == SceneType.SCENE_GPR)
				{
					XGuildArenaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaBattleDocument>(XGuildArenaBattleDocument.uuID);
					specificDocument.ReceiveBattleSkill(roPtc.Data);
					return;
				}
				if (sceneType2 == SceneType.SCENE_HEROBATTLE)
				{
					XHeroBattleDocument specificDocument2 = XDocuments.GetSpecificDocument<XHeroBattleDocument>(XHeroBattleDocument.uuID);
					specificDocument2.ReceiveBattleSkill(roPtc.Data);
					return;
				}
			}
			else
			{
				if (sceneType2 == SceneType.SCENE_CASTLE_FIGHT)
				{
					XGuildTerritoryDocument specificDocument3 = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
					specificDocument3.ReceiveBattleSkill(roPtc.Data);
					return;
				}
				if (sceneType2 == SceneType.SCENE_BIGMELEE_FIGHT)
				{
					XBigMeleeBattleDocument specificDocument4 = XDocuments.GetSpecificDocument<XBigMeleeBattleDocument>(XBigMeleeBattleDocument.uuID);
					specificDocument4.ReceiveBattleKillInfo(roPtc.Data);
					return;
				}
				if (sceneType2 == SceneType.SCENE_BATTLEFIELD_FIGHT)
				{
					XBattleFieldBattleDocument.Doc.ReceiveBattleKillInfo(roPtc.Data);
					return;
				}
			}
			XBattleCaptainPVPDocument specificDocument5 = XDocuments.GetSpecificDocument<XBattleCaptainPVPDocument>(XBattleCaptainPVPDocument.uuID);
			specificDocument5.SetBattleKill(roPtc);
		}
	}
}
