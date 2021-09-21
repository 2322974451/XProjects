using System;
using KKSG;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020010B2 RID: 4274
	internal class Process_PtcG2C_PkPrepareNtf
	{
		// Token: 0x0600D784 RID: 55172 RVA: 0x003281E8 File Offset: 0x003263E8
		public static void Process(PtcG2C_PkPrepareNtf roPtc)
		{
			bool flag = roPtc.Data.beginorend == 0U;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddLog("PK Prepare Begin at ", Time.frameCount.ToString(), null, null, null, null, XDebugColor.XDebug_None);
				bool flag2 = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded();
				if (flag2)
				{
					DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.ShowCountDownFrame(true);
				}
				bool flag3 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
				if (flag3)
				{
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.ShowCountDownFrame(true);
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.HideLeftTime();
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.uiBehaviour.m_PromptFrame.gameObject.SetActive(false);
				}
				bool flag4 = XSingleton<XScene>.singleton.SceneType == SceneType.SKYCITY_FIGHTING;
				if (flag4)
				{
					XSkyArenaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XSkyArenaBattleDocument>(XSkyArenaBattleDocument.uuID);
					specificDocument.HideVSInfo();
					specificDocument.HideTime();
					XSingleton<UiUtility>.singleton.SetMiniMapOpponentStatus(false);
				}
				bool flag5 = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_RESWAR_PVP;
				if (flag5)
				{
					XGuildMineBattleDocument specificDocument2 = XDocuments.GetSpecificDocument<XGuildMineBattleDocument>(XGuildMineBattleDocument.uuID);
					specificDocument2.HideVSInfo();
				}
				bool flag6 = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_BIGMELEE_FIGHT;
				if (flag6)
				{
					XBigMeleeBattleDocument specificDocument3 = XDocuments.GetSpecificDocument<XBigMeleeBattleDocument>(XBigMeleeBattleDocument.uuID);
					specificDocument3.HideInfo();
				}
			}
			else
			{
				bool flag7 = 1U == roPtc.Data.beginorend;
				if (flag7)
				{
					XSingleton<XDebug>.singleton.AddLog("PK Prepare End at ", Time.frameCount.ToString(), null, null, null, null, XDebugColor.XDebug_None);
					bool flag8 = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded();
					if (flag8)
					{
						DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.ShowCountDownFrame(false);
					}
					bool flag9 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
					if (flag9)
					{
						DlgBase<BattleMain, BattleMainBehaviour>.singleton.ShowCountDownFrame(false);
					}
					bool flag10 = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_PVP;
					if (flag10)
					{
						bool flag11 = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded();
						if (flag11)
						{
							DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.SetLeftTime((uint)XSingleton<XGlobalConfig>.singleton.GetInt("PVPGameTime"));
						}
						bool flag12 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
						if (flag12)
						{
							DlgBase<BattleMain, BattleMainBehaviour>.singleton.SetLeftTime((uint)XSingleton<XGlobalConfig>.singleton.GetInt("PVPGameTime"), -1);
						}
					}
					bool flag13 = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_PK;
					if (flag13)
					{
						bool flag14 = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded();
						if (flag14)
						{
							DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.SetLeftTime((uint)XSingleton<XGlobalConfig>.singleton.GetInt("PkUpdateTime"));
						}
						bool flag15 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
						if (flag15)
						{
							DlgBase<BattleMain, BattleMainBehaviour>.singleton.SetLeftTime((uint)XSingleton<XGlobalConfig>.singleton.GetInt("PkUpdateTime"), -1);
						}
					}
					bool flag16 = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_INVFIGHT;
					if (flag16)
					{
						bool flag17 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
						if (flag17)
						{
							DlgBase<BattleMain, BattleMainBehaviour>.singleton.SetLeftTime((uint)XSingleton<XGlobalConfig>.singleton.GetInt("InvFightFightTime"), -1);
						}
					}
					bool flag18 = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_HORSE_RACE || XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_WEEKEND4V4_HORSERACING;
					if (flag18)
					{
						XRaceDocument specificDocument4 = XDocuments.GetSpecificDocument<XRaceDocument>(XRaceDocument.uuID);
						bool flag19 = specificDocument4.RaceHandler != null;
						if (flag19)
						{
							specificDocument4.RaceHandler.RefreshTime(0f);
						}
					}
				}
			}
		}
	}
}
