using System;
using System.Collections.Generic;
using KKSG;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcG2C_SelectRoleNtf
	{

		public static void Process(PtcG2C_SelectRoleNtf roPtc)
		{
			XSingleton<XGame>.singleton.PlayerID = roPtc.Data.roleData.Brief.roleID;
			List<SkillInfo> skills = null;
			List<uint> skillSlot = null;
			uint skillPageIndex = 0U;
			bool flag = roPtc.Data.roleData.skill != null;
			if (flag)
			{
				skills = ((roPtc.Data.roleData.skill.index == 0U) ? roPtc.Data.roleData.skill.Skills : roPtc.Data.roleData.skill.SkillsTwo);
				skillSlot = ((roPtc.Data.roleData.skill.index == 0U) ? roPtc.Data.roleData.skill.SkillSlot : roPtc.Data.roleData.skill.SkillSlotTwo);
				skillPageIndex = roPtc.Data.roleData.skill.index;
			}
			XSingleton<XAttributeMgr>.singleton.InitPlayerAttr(roPtc.Data.roleData.Brief, roPtc.Data.roleData.Attributes, skills, skillSlot, skillPageIndex, roPtc.Data.roleData.system, roPtc.Data.roleData.military);
			XOptionsDocument specificDocument = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
			specificDocument.InitServerConfig(roPtc.Data.roleData.config);
			XSingleton<XItemDrawerMgr>.singleton.Init((uint)roPtc.Data.roleData.Brief.type);
			XSingleton<XGameSysMgr>.singleton.InitWhenSelectRole(roPtc.Data.roleData.Brief.level);
			XSingleton<XGame>.singleton.Doc.XBagDoc.Init(roPtc.Data.roleData.Bag);
			XSingleton<XStageProgress>.singleton.Init(roPtc.Data.roleData.Stages);
			XMainInterfaceDocument specificDocument2 = XDocuments.GetSpecificDocument<XMainInterfaceDocument>(XMainInterfaceDocument.uuID);
			specificDocument2.BackFlow = roPtc.Data.backflow_firstenter;
			XSingleton<XTutorialMgr>.singleton.Reset(roPtc.Data.roleData.Brief.tutorialBitsArray);
			XTaskDocument specificDocument3 = XDocuments.GetSpecificDocument<XTaskDocument>(XTaskDocument.uuID);
			specificDocument3.TaskRecord.InitFromServerData(roPtc.Data.roleData.task_record);
			XGuildDailyTaskDocument specificDocument4 = XDocuments.GetSpecificDocument<XGuildDailyTaskDocument>(XGuildDailyTaskDocument.uuID);
			specificDocument4.InitFromServerData(roPtc.Data.roleData.task_record);
			XTempActivityDocument specificDocument5 = XDocuments.GetSpecificDocument<XTempActivityDocument>(XTempActivityDocument.uuID);
			specificDocument5.InitActivityRecordFromServerData(roPtc.Data.roleData.spActivityRecord);
			WeekEndNestDocument.Doc.OfflineOpenSetTaskId();
			XEmblemDocument specificDocument6 = XDocuments.GetSpecificDocument<XEmblemDocument>(XEmblemDocument.uuID);
			specificDocument6.InitWhenCreateRole(roPtc.Data.roleData.Brief.level);
			XCharacterEquipDocument specificDocument7 = XDocuments.GetSpecificDocument<XCharacterEquipDocument>(XCharacterEquipDocument.uuID);
			specificDocument7.UpdateRedPoints(roPtc.Data.roleData.Brief.level);
			ArtifactBagDocument.Doc.UpdateRedPoints(roPtc.Data.roleData.Brief.level);
			XCharacterItemDocument specificDocument8 = XDocuments.GetSpecificDocument<XCharacterItemDocument>(XCharacterItemDocument.uuID);
			specificDocument8.UpdateRedPoints(roPtc.Data.roleData.Brief.level);
			XAchievementDocument specificDocument9 = XDocuments.GetSpecificDocument<XAchievementDocument>(XAchievementDocument.uuID);
			specificDocument9.InitAchivement((roPtc.Data.roleData.achieve == null) ? null : roPtc.Data.roleData.achieve.oldachievement);
			XPurchaseDocument specificDocument10 = XDocuments.GetSpecificDocument<XPurchaseDocument>(XPurchaseDocument.uuID);
			specificDocument10.InitPurchaseInfo(roPtc.Data.roleData.BuyInfo);
			XFashionDocument specificDocument11 = XDocuments.GetSpecificDocument<XFashionDocument>(XFashionDocument.uuID);
			specificDocument11.Init(roPtc.Data.roleData.fashionrecord.bagfashion, roPtc.Data.roleData.fashionrecord.bodyfashion, roPtc.Data.roleData.fashionrecord.collected);
			XFashionStorageDocument specificDocument12 = XDocuments.GetSpecificDocument<XFashionStorageDocument>(XFashionStorageDocument.uuID);
			specificDocument12.Init(roPtc.Data.roleData.fashionrecord);
			XPrerogativeDocument specificDocument13 = XDocuments.GetSpecificDocument<XPrerogativeDocument>(XPrerogativeDocument.uuID);
			specificDocument13.Initialize(roPtc.Data.roleData.payv2.consume.setid, roPtc.Data.roleData.payv2.consume.activateid);
			XSingleton<XUICacheMgr>.singleton.Init();
			XPetDocument specificDocument14 = XDocuments.GetSpecificDocument<XPetDocument>(XPetDocument.uuID);
			specificDocument14.OnPetAllNotify(roPtc.Data.roleData.petsys);
			XCardCollectDocument specificDocument15 = XDocuments.GetSpecificDocument<XCardCollectDocument>(XCardCollectDocument.uuID);
			specificDocument15.InitCardData(roPtc.Data.roleData.atlas);
			XAbyssPartyDocument specificDocument16 = XDocuments.GetSpecificDocument<XAbyssPartyDocument>(XAbyssPartyDocument.uuID);
			bool flag2 = roPtc.Data.roleData.Stages.absparty != null;
			if (flag2)
			{
				specificDocument16.SetAbyssIndex(roPtc.Data.roleData.Stages.absparty.aby);
			}
			XTitleDocument specificDocument17 = XDocuments.GetSpecificDocument<XTitleDocument>(XTitleDocument.uuID);
			specificDocument17.RefreshTitleLevelUp();
			XPartnerDocument.Doc.ReqPartnerInfo();
			XNPCFavorDocument specificDocument18 = XDocuments.GetSpecificDocument<XNPCFavorDocument>(XNPCFavorDocument.uuID);
			specificDocument18.ReqNPCFavorUnionInfo();
			XSpriteSystemDocument specificDocument19 = XDocuments.GetSpecificDocument<XSpriteSystemDocument>(XSpriteSystemDocument.uuID);
			specificDocument19.SetAllInfo(roPtc.Data.roleData.SpriteRecord);
			XHeroBattleDocument specificDocument20 = XDocuments.GetSpecificDocument<XHeroBattleDocument>(XHeroBattleDocument.uuID);
			specificDocument20.SetHeroBattleInfo(roPtc.Data.roleData.herobattle);
			XQualifyingDocument specificDocument21 = XDocuments.GetSpecificDocument<XQualifyingDocument>(XQualifyingDocument.uuID);
			specificDocument21.SetQulifyingRewardCount(roPtc.Data.roleData.pkrecord);
			bool flag3 = !string.IsNullOrEmpty(XSingleton<XLoginDocument>.singleton.OpenID);
			if (flag3)
			{
				XSingleton<XUpdater.XUpdater>.singleton.XTssSdk.OnLogin((int)XSingleton<XLoginDocument>.singleton.Channel, XSingleton<XLoginDocument>.singleton.OpenID, XSingleton<XClientNetwork>.singleton.ServerID, roPtc.Data.roleData.Brief.roleID.ToString());
			}
			XSingleton<XUpdater.XUpdater>.singleton.XApolloManager.Init((int)XSingleton<XLoginDocument>.singleton.Channel, XSingleton<XLoginDocument>.singleton.OpenID);
			XSingleton<XUpdater.XUpdater>.singleton.XPlatform.SendUserInfo(XSingleton<XClientNetwork>.singleton.ServerID, roPtc.Data.roleData.Brief.roleID);
			XSingleton<XUpdater.XUpdater>.singleton.XBroadCast.SetAccount((int)XSingleton<XLoginDocument>.singleton.Channel, XSingleton<XLoginDocument>.singleton.OpenID, XSingleton<XLoginDocument>.singleton.TokenCache);
			XSingleton<XUpdater.XUpdater>.singleton.XApolloManager.SetRealtimeMode();
			XSingleton<XPandoraSDKDocument>.singleton.PandoraLogin();
			XSmeltDocument.Doc.InitEquipAndEmblemRedDot();
			XSmeltDocument.Doc.ResetSetting();
			ArtifactInscriptionDocument.Doc.ResetSetting();
			ArtifactFuseDocument.Doc.ResetSetting();
			ArtifactRecastDocument.Doc.ResetSetting();
			ArtifactRefinedDocument.Doc.ResetSetting();
			XFileLog.RoleName = roPtc.Data.roleData.Brief.name;
			XPlatformAbilityDocument.Doc.QueryQQVipInfo();
			XRechargeDocument specificDocument22 = XDocuments.GetSpecificDocument<XRechargeDocument>(XRechargeDocument.uuID);
			specificDocument22.GetPayMarketingInfo();
			XRechargeDocument specificDocument23 = XDocuments.GetSpecificDocument<XRechargeDocument>(XRechargeDocument.uuID);
			specificDocument23.PayParameterNtf();
			XMilitaryRankDocument specificDocument24 = XDocuments.GetSpecificDocument<XMilitaryRankDocument>(XMilitaryRankDocument.uuID);
			specificDocument24.SetMyMilitaryRecord(roPtc.Data.roleData.military);
			XFPStrengthenDocument specificDocument25 = XDocuments.GetSpecificDocument<XFPStrengthenDocument>(XFPStrengthenDocument.uuID);
			specificDocument25.RequsetFightNum();
			AdditionRemindDocument specificDocument26 = XDocuments.GetSpecificDocument<AdditionRemindDocument>(AdditionRemindDocument.uuID);
			bool flag4 = roPtc.Data.roleData.misc != null;
			if (flag4)
			{
				specificDocument26.SetFreeflowTime(roPtc.Data.roleData.misc.freeflow_hinttime);
			}
			XSingleton<XReconnection>.singleton.SetPlayerInfo(roPtc.Data.roleData);
		}
	}
}
