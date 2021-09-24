using System;
using System.Collections.Generic;
using System.Threading;
using XUtliPoolLib;

namespace XMainClient
{

	internal sealed class XDocuments : XObject
	{

		public XDocuments()
		{
			this._async_data.Clear();
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XJadeDocument.Execute), null, XJadeDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XArenaDocument.Execute), null, XArenaDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XEquipDocument.Execute), new OnLoadedCallback(XEquipDocument.OnTableLoaded), XEquipDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XAchievementDocument.Execute), null, XAchievementDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XActivityDocument.Execute), null, XActivityDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XDailyActivitiesDocument.Execute), null, XDailyActivitiesDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XFashionDocument.Execute), null, XFashionDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XSuperRiskDocument.Execute), null, XSuperRiskDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XEmblemDocument.Execute), null, XEmblemDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XEnhanceDocument.Execute), new OnLoadedCallback(XEnhanceDocument.OnTableLoaded), XEnhanceDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XSystemRewardDocument.Execute), null, XSystemRewardDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XRechargeDocument.Execute), null, XRechargeDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XChatDocument.Execute), null, XChatDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XPurchaseDocument.Execute), null, XPurchaseDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XFPStrengthenDocument.Execute), null, XFPStrengthenDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XGameMallDocument.Execute), null, XGameMallDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XExpeditionDocument.Execute), new OnLoadedCallback(XExpeditionDocument.OnTableLoaded), XExpeditionDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XScreenShotShareDocument.Execute), null, XScreenShotShareDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XFriendsDocument.Execute), null, XFriendsDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XLevelDocument.Execute), null, XLevelDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XGuildSkillDocument.Execute), new OnLoadedCallback(XGuildSkillDocument.OnTableLoaded), XGuildSkillDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XGuildRelaxGameDocument.Execute), null, XGuildRelaxGameDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XGuildJokerDocument.Execute), null, XGuildJokerDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XGuildSignInDocument.Execute), null, XGuildSignInDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XGuildRedPacketDocument.Execute), null, XGuildRedPacketDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XGuildQualifierDocument.Execute), null, XGuildQualifierDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XGuildRankDocument.Execute), null, XGuildRankDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XGuildSalaryDocument.Execute), new OnLoadedCallback(XGuildSalaryDocument.OnTableLoaded), XGuildSalaryDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XGuildTerritoryDocument.Execute), new OnLoadedCallback(XGuildTerritoryDocument.OnLoadcallback), XGuildTerritoryDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XInvitationDocument.Execute), null, XInvitationDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XOnlineRewardDocument.Execute), null, XOnlineRewardDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XLevelRewardDocument.Execute), null, XLevelRewardDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XTeamDocument.Execute), new OnLoadedCallback(XTeamDocument.OnTableLoaded), XTeamDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XTitleDocument.Execute), new OnLoadedCallback(XTitleDocument.OnTableLoaded), XTitleDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XQualifyingDocument.Execute), null, XQualifyingDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XCharacterItemDocument.Execute), new OnLoadedCallback(XCharacterItemDocument.OnTableLoaded), XCharacterItemDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XGuildSmallMonsterDocument.Execute), null, XGuildSmallMonsterDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XPetDocument.Execute), new OnLoadedCallback(XPetDocument.OnTableLoaded), XPetDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(AuctionDocument.Execute), new OnLoadedCallback(AuctionDocument.OnTableLoaded), AuctionDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XCharacterEquipDocument.Execute), new OnLoadedCallback(XCharacterEquipDocument.OnTableLoaded), XCharacterEquipDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XGuildDocument.Execute), new OnLoadedCallback(XGuildDocument.OnTableLoaded), XGuildDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XFightGroupDocument.Execute), new OnLoadedCallback(XFightGroupDocument.OnTableLoaded), XFightGroupDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XFindExpDocument.Execute), null, XFindExpDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XEquipCreateDocument.Execute), new OnLoadedCallback(XEquipCreateDocument.OnTableLoaded), XEquipCreateDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XDesignationDocument.Execute), null, XDesignationDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XDragonRewardDocument.Execute), null, XDragonRewardDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XSpectateSceneDocument.Execute), null, XSpectateSceneDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XLevelSealDocument.Execute), null, XLevelSealDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XQuickReplyDocument.Execute), new OnLoadedCallback(XQuickReplyDocument.OnTableLoaded), XQuickReplyDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XVoiceQADocument.Execute), null, XVoiceQADocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XDragonNestDocument.Execute), null, XDragonNestDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XSevenLoginDocument.Execute), null, XSevenLoginDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XGuildDragonDocument.Execute), null, XGuildDragonDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XSpectateLevelRewardDocument.Execute), null, XSpectateLevelRewardDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XFlowerRankDocument.Execute), null, XFlowerRankDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XWelfareDocument.Execute), new OnLoadedCallback(XWelfareDocument.OnTableLoaded), XWelfareDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XPVPActivityDocument.Execute), null, XPVPActivityDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XFlowerReplyDocument.Execute), null, XFlowerReplyDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XWeekendPartyDocument.Execute), null, XWeekendPartyDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XCarnivalDocument.Execute), null, XCarnivalDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XBossBushDocument.Execute), null, XBossBushDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XWorldBossDocument.Execute), null, XWorldBossDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(FirstPassDocument.Execute), null, FirstPassDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XTempActivityDocument.Execute), null, XTempActivityDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XOperatingActivityDocument.Execute), null, XOperatingActivityDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XThemeActivityDocument.Execute), null, XThemeActivityDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XSpriteSystemDocument.Execute), new OnLoadedCallback(XSpriteSystemDocument.OnTableLoaded), XSpriteSystemDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XCardCollectDocument.Execute), new OnLoadedCallback(XCardCollectDocument.OnTableLoaded), XCardCollectDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XSkyArenaEntranceDocument.Execute), null, XSkyArenaEntranceDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XBigMeleeEntranceDocument.Execute), null, XBigMeleeEntranceDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XBattleFieldEntranceDocument.Execute), null, XBattleFieldEntranceDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XGuildMineMainDocument.Execute), null, XGuildMineMainDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XRaceDocument.Execute), null, XRaceDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XPersonalCareerDocument.Execute), null, XPersonalCareerDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XGuildMineBattleDocument.Execute), null, XGuildMineBattleDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XDragonCrusadeDocument.Execute), new OnLoadedCallback(XDragonCrusadeDocument.OnTableLoaded), XDragonCrusadeDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XSmeltDocument.Execute), null, XSmeltDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(HomePlantDocument.Execute), null, HomePlantDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(HomeMainDocument.Execute), null, HomeMainDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XTaskDocument.Execute), null, XTaskDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XOptionsDocument.Execute), new OnLoadedCallback(XOptionsDocument.OnTableLoaded), XOptionsDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XHomeCookAndPartyDocument.Execute), null, XHomeCookAndPartyDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XHomeFishingDocument.Execute), null, XHomeFishingDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XMainInterfaceDocument.Execute), null, XMainInterfaceDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XGuildResContentionBuffDocument.Execute), null, XGuildResContentionBuffDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(AuctionHouseDocument.Execute), null, AuctionHouseDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XGuildDonateDocument.Execute), null, XGuildDonateDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XGuildDailyTaskDocument.Execute), null, XGuildDailyTaskDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XPushSubscribeDocument.Execute), null, XPushSubscribeDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XMentorshipDocument.Execute), null, XMentorshipDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XEnchantDocument.Execute), new OnLoadedCallback(XEnchantDocument.OnTableLoaded), XEnchantDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XHeroBattleDocument.Execute), null, XHeroBattleDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XNormalShopDocument.Execute), null, XNormalShopDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XWeekNestDocument.Execute), null, XWeekNestDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XCompeteDocument.Execute), null, XCompeteDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XPartnerDocument.Execute), new OnLoadedCallback(XPartnerDocument.OnTableLoaded), XPartnerDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XWeddingDocument.Execute), new OnLoadedCallback(XWeddingDocument.OnTableLoaded), XWeddingDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(PandoraDocument.Execute), null, PandoraDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XJokerKingDocument.Execute), null, XJokerKingDocument.AsynLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XDanceDocument.Execute), new OnLoadedCallback(XDanceDocument.OnTableLoaded), XDanceDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XForgeDocument.Execute), new OnLoadedCallback(XForgeDocument.OnTableLoaded), XForgeDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XFreeTeamVersusLeagueDocument.Execute), null, XFreeTeamVersusLeagueDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XNestDocument.Execute), null, XNestDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XProfessionChangeDocument.Execute), null, XProfessionChangeDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XSkillTreeDocument.Execute), null, XSkillTreeDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XMilitaryRankDocument.Execute), null, XMilitaryRankDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XGuildCollectDocument.Execute), null, XGuildCollectDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XRenameDocument.Execute), null, XRenameDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(ArtifactDocument.Execute), new OnLoadedCallback(ArtifactDocument.OnTableLoaded), ArtifactDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(ArtifactComposeDocument.Execute), null, ArtifactComposeDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XFashionStorageDocument.Execute), null, XFashionStorageDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(ArtifactBagDocument.Execute), null, ArtifactBagDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(ArtifactAtlasDocument.Execute), null, ArtifactAtlasDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XAbyssPartyDocument.Execute), null, XAbyssPartyDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XCustomBattleDocument.Execute), null, XCustomBattleDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XMobaEntranceDocument.Execute), null, XMobaEntranceDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XMobaBattleDocument.Execute), null, XMobaBattleDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XCharacterCommonMenuDocument.Execute), null, XCharacterCommonMenuDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(TaJieHelpDocument.Execute), null, TaJieHelpDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(GroupChatDocument.Execute), new OnLoadedCallback(GroupChatDocument.OnTableLoaded), GroupChatDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XAncientDocument.Execute), null, XAncientDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(ArtifactDeityStoveDocument.Execute), null, ArtifactDeityStoveDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(ArtifactRecastDocument.Execute), null, ArtifactRecastDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(ArtifactFuseDocument.Execute), null, ArtifactFuseDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(ArtifactInscriptionDocument.Execute), null, ArtifactInscriptionDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(WeekEndNestDocument.Execute), null, WeekEndNestDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(EquipUpgradeDocument.Execute), new OnLoadedCallback(EquipUpgradeDocument.OnTableLoaded), EquipUpgradeDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(EquipFusionDocument.Execute), new OnLoadedCallback(EquipFusionDocument.OnTableLoaded), EquipFusionDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XPrerogativeDocument.Execute), new OnLoadedCallback(XPrerogativeDocument.OnTableLoaded), XPrerogativeDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XNPCFavorDocument.Execute), null, XNPCFavorDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XTargetRewardDocument.Execute), new OnLoadedCallback(XTargetRewardDocument.OnTableLoaded), XTargetRewardDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XDragonGuildDocument.Execute), new OnLoadedCallback(XDragonGuildDocument.OnTableLoaded), XDragonGuildDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XYorozuyaDocument.Execute), new OnLoadedCallback(XYorozuyaDocument.OnTableLoaded), XYorozuyaDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XDragonGuildTaskDocument.Execute), null, XDragonGuildTaskDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XBackFlowDocument.Execute), null, XBackFlowDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XTransformDocument.Execute), null, XTransformDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XRiftDocument.Execute), null, XRiftDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XCampDuelDocument.Execute), null, XCampDuelDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(ArtifactRefinedDocument.Execute), null, ArtifactRefinedDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XArtifactCreateDocument.Execute), new OnLoadedCallback(XArtifactCreateDocument.OnTableLoaded), XArtifactCreateDocument.AsyncLoader));
			this._async_data.Add(new XDocuments.AsyncLoadData(new XDocuments.AsyncLoadExecute(XGuildGrowthDocument.Execute), new OnLoadedCallback(XGuildGrowthDocument.OnTableLoaded), XGuildGrowthDocument.AsyncLoader));
		}

		public XBagDocument XBagDoc
		{
			get
			{
				return this._bag_doc;
			}
		}

		public XBattleDocument XBattleDoc
		{
			get
			{
				return this._battle_doc;
			}
		}

		public XSpectateSceneDocument XSpectateSceneDoc
		{
			get
			{
				return this._spectateScene_doc;
			}
		}

		public XSceneDamageRankDocument XSceneDamageRankDoc
		{
			get
			{
				return this._SceneDamageRank_doc;
			}
		}

		public XCombatStatisticsDocument XCombatStatisticsDoc
		{
			get
			{
				return this._CombatStatistics_doc;
			}
		}

		public void CtorLoad()
		{
			ThreadPool.SetMaxThreads(XTableAsyncLoader.AsyncPerTime, XTableAsyncLoader.AsyncPerTime);
			XTableAsyncLoader.currentThreadCount = XTableAsyncLoader.AsyncPerTime;
			XDocuments.AsyncLoadData[] array = new XDocuments.AsyncLoadData[XTableAsyncLoader.AsyncPerTime];
			for (int i = 0; i < XTableAsyncLoader.AsyncPerTime; i++)
			{
				array[i] = this._async_data[i];
				array[i].Execute(array[i].Loaded);
			}
			int j = 0;
			int asyncPerTime = XTableAsyncLoader.AsyncPerTime;
			while (j < this._async_data.Count)
			{
				for (int k = 0; k < XTableAsyncLoader.AsyncPerTime; k++)
				{
					XDocuments.AsyncLoadData asyncLoadData = array[k];
					bool flag = asyncLoadData.TableLoader != null && asyncLoadData.TableLoader.IsDone;
					if (flag)
					{
						j++;
						bool flag2 = asyncPerTime < this._async_data.Count;
						if (flag2)
						{
							asyncLoadData = this._async_data[asyncPerTime++];
							asyncLoadData.Execute(asyncLoadData.Loaded);
						}
						else
						{
							asyncLoadData.TableLoader = null;
						}
						array[k] = asyncLoadData;
					}
				}
				Thread.Sleep(1);
			}
		}

		public override bool Initilize(int flag)
		{
			this._bag_doc = (XSingleton<XComponentMgr>.singleton.CreateComponent(this, XBagDocument.uuID) as XBagDocument);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XMainInterfaceDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XCharacterEquipDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XJadeDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XArenaDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XEquipDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XAchievementDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XCharacterDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XActivityDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XMystShopDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XLoginRewardDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XDailyActivitiesDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XFashionDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XSuperRiskDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XEmblemDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XRankDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XFlowerSendDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XFlowerRankDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XFlowerReplyDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XWeekendPartyDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XPlatformAbilityDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XPKInvitationDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XWelfareDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XCharacterCommonMenuDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XEnhanceDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XOptionsDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XSystemRewardDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XNormalShopDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XSweepDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XTeamDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XGameMallDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XShowGetItemDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, AdditionRemindDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XRechargeDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XPurchaseDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XFPStrengthenDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XExpeditionDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XWorldBossDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XDanceDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XLevelUpStatusDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XShowGetAchivementTipDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XSystemTipDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XSkillTreeDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XOtherPlayerInfoDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XRecycleItemDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XChatDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XSelectCharacterDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XGuildDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XGuildListDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XFriendsDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XLevelDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XGuildHallDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XGuildApproveDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XGuildMemberDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XGuildSignInDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XGuildViewDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XGuildRelaxGameDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XGuildJokerDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XGuildJockerMatchDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XGuildSkillDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XGuildRedPacketDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XGuildArenaDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XGuildInheritDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XGuildQualifierDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XLevelRewardDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XCharacterItemDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XGuildDragonDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XGuildRankDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XGuildSalaryDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XTitleDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XGuildArenaBattleDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XGuildTerritoryDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XInvitationDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XOnlineRewardDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XQualifyingDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XBattleSkillDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XGuildSmallMonsterDocument.uuID);
			this._SceneDamageRank_doc = (XSingleton<XComponentMgr>.singleton.CreateComponent(this, XSceneDamageRankDocument.uuID) as XSceneDamageRankDocument);
			this._battle_doc = (XSingleton<XComponentMgr>.singleton.CreateComponent(this, XBattleDocument.uuID) as XBattleDocument);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XPetDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, AuctionDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XFindExpDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XEquipCreateDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XMailDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XPPTDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XDesignationDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XDragonRewardDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XLevelSealDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XQuickReplyDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XCaptainPVPDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XVoiceQADocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XSpectateDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XSpectateLevelRewardDocument.uuID);
			this._spectateScene_doc = (XSingleton<XComponentMgr>.singleton.CreateComponent(this, XSpectateSceneDocument.uuID) as XSpectateSceneDocument);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XPVPActivityDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XBattleCaptainPVPDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XSkyArenaEntranceDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XSkyArenaBattleDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XBigMeleeEntranceDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XBigMeleeBattleDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XBattleFieldEntranceDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XBattleFieldBattleDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XRaceDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XPersonalCareerDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XDragonNestDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XPushSubscribeDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XTeamInviteDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XGuildMineBattleDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XGuildMineMainDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XGuildMineEntranceDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XBossBushDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XApolloDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, GroupChatDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XAncientDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XRadioDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XSevenLoginDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, FirstPassDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XOperatingActivityDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XThemeActivityDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, BiochemicalHellDogDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, MadDuckSiegeDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XTempActivityDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XRollDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XSpriteSystemDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XCardCollectDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XDragonCrusadeDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XReviveDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XIDIPDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XSmeltDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, HomePlantDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, HomeMainDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XJokerKingDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XCarnivalDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XTaskDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XHomeCookAndPartyDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XActivityInviteDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XHomeFishingDocument.uuID);
			this._CombatStatistics_doc = (XSingleton<XComponentMgr>.singleton.CreateComponent(this, XCombatStatisticsDocument.uuID) as XCombatStatisticsDocument);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, AuctionHouseDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XGuildResContentionBuffDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XScreenShotShareDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XGuildDonateDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XGuildDailyTaskDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XBillBoardDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XMentorshipDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XEnchantDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XHeroBattleDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XHeroBattleSkillDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XWeekNestDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XCompeteDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XPartnerDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XWeddingDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XDragonPartnerDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XNPCFavorDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XDramaDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, PandoraDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XForgeDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XFreeTeamVersusLeagueDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XTeamLeagueBattleDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XNestDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XProfessionChangeDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XAnnouncementDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XRenameDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XHallFameDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XMilitaryRankDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XGuildCollectDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XExchangeItemDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XFashionStorageDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, ArtifactBagDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, ArtifactDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, ArtifactComposeDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, ArtifactAtlasDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XRequestDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XAbyssPartyDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XCustomBattleDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XMobaEntranceDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XMobaBattleDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, TaJieHelpDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, ArtifactDeityStoveDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, ArtifactRecastDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, ArtifactFuseDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, ArtifactInscriptionDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, WeekEndNestDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XGuildWeeklyBountyDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, EquipUpgradeDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, EquipFusionDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XTargetRewardDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XDragonGuildDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XDragonGuildListDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XDragonGuildTaskDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XDragonGuildApproveDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XTransformDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XBackFlowDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XYorozuyaDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XRiftDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XCampDuelDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, ArtifactRefinedDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XArtifactCreateDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XCrossGVGDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XGuildGrowthDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XPrerogativeDocument.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XLuaDocument.uuID);
			return true;
		}

		public static T GetSpecificDocument<T>(uint uuID) where T : XComponent
		{
			return XSingleton<XGame>.singleton.Doc.GetXComponent(uuID) as T;
		}

		public void Refresh()
		{
			base.Uninitilize();
			this.Initilize(0);
		}

		private XBagDocument _bag_doc = null;

		private XBattleDocument _battle_doc = null;

		private XSpectateSceneDocument _spectateScene_doc = null;

		private XSceneDamageRankDocument _SceneDamageRank_doc = null;

		private XCombatStatisticsDocument _CombatStatistics_doc = null;

		private List<XDocuments.AsyncLoadData> _async_data = new List<XDocuments.AsyncLoadData>(64);

		private delegate void AsyncLoadExecute(OnLoadedCallback notcallback = null);

		private struct AsyncLoadData
		{

			public AsyncLoadData(XDocuments.AsyncLoadExecute exe, OnLoadedCallback loadedcallback, XTableAsyncLoader loader)
			{
				this.Execute = exe;
				this.Loaded = loadedcallback;
				this.TableLoader = loader;
			}

			public XDocuments.AsyncLoadExecute Execute;

			public OnLoadedCallback Loaded;

			public XTableAsyncLoader TableLoader;
		}
	}
}
