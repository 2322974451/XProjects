using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{

	internal sealed class XComponentMgr : XSingleton<XComponentMgr>
	{

		public XComponentMgr()
		{
			int num = 15;
			int num2 = 26;
			XComponentMgr.ComponentCache componentCache = new XComponentMgr.ComponentCache();
			componentCache.SlotIndex = num;
			this._componentCache.Add(XEquipComponent.uuID, componentCache);
			componentCache = new XComponentMgr.ComponentCache();
			componentCache.SlotIndex = num2;
			this._componentCache.Add(XRenderComponent.uuID, componentCache);
			int num3 = XFastEnumIntEqualityComparer<XComponentMgr.XComponentSet>.ToInt(XComponentMgr.XComponentSet.MAX);
			for (int i = 0; i < num3; i++)
			{
				bool flag = i != num && i != num2;
				if (flag)
				{
					Dictionary<uint, int> slots = this._slots;
					XCommon singleton = XSingleton<XCommon>.singleton;
					XComponentMgr.XComponentSet xcomponentSet = (XComponentMgr.XComponentSet)i;
					slots.Add(singleton.XHash(xcomponentSet.ToString()), i);
				}
			}
		}

		public XComponent CreateComponent(XObject hoster, uint uuid)
		{
			XComponent xcomponent = null;
			XComponentMgr.ComponentCache componentCache = null;
			bool flag = this._componentCache.TryGetValue(uuid, out componentCache);
			if (flag)
			{
				bool flag2 = componentCache.componentCache.Count > 0;
				if (flag2)
				{
					xcomponent = componentCache.componentCache.Dequeue();
				}
				else
				{
					xcomponent = this.ComponentFactory((XComponentMgr.XComponentSet)componentCache.SlotIndex);
				}
			}
			else
			{
				int slot = 0;
				bool flag3 = this._slots.TryGetValue(uuid, out slot);
				if (flag3)
				{
					xcomponent = this.ComponentFactory((XComponentMgr.XComponentSet)slot);
				}
			}
			bool flag4 = xcomponent != null;
			if (flag4)
			{
				xcomponent.InitilizeBuffer();
				bool flag5 = hoster != null;
				if (flag5)
				{
					hoster.AttachComponent(xcomponent);
				}
				XComponentMgr.ComponenCreatetCount++;
				this.count++;
				return xcomponent;
			}
			throw new XErrorUnregisteredComponentException("Component with uuid: " + uuid + " not registered.");
		}

		public void RemoveComponent(XComponent c)
		{
			bool flag = !c.ManualUnitBuff;
			if (flag)
			{
				c.UninitilizeBuffer();
				this.count--;
			}
			XComponentMgr.ComponentCache componentCache = null;
			bool flag2 = this._componentCache.TryGetValue(c.ID, out componentCache);
			if (flag2)
			{
				componentCache.componentCache.Enqueue(c);
			}
		}

		public void ClearAll()
		{
			foreach (KeyValuePair<uint, XComponentMgr.ComponentCache> keyValuePair in this._componentCache)
			{
				keyValuePair.Value.componentCache.Clear();
			}
		}

		public void PrintAllComponent()
		{
		}

		private XComponent ComponentFactory(XComponentMgr.XComponentSet slot)
		{
			switch (slot)
			{
			case XComponentMgr.XComponentSet.Player_Attributes:
				return new XPlayerAttributes();
			case XComponentMgr.XComponentSet.Basic_Move:
				return new XMoveComponent();
			case XComponentMgr.XComponentSet.BeHit_Presentation:
				return new XBeHitComponent();
			case XComponentMgr.XComponentSet.Charge_Move:
				return new XChargeComponent();
			case XComponentMgr.XComponentSet.Basic_Fall:
				return new XFallComponent();
			case XComponentMgr.XComponentSet.Freezing_Presentation:
				return new XFreezeComponent();
			case XComponentMgr.XComponentSet.Basic_Idle:
				return new XIdleComponent();
			case XComponentMgr.XComponentSet.Basic_Jump:
				return new XJumpComponent();
			case XComponentMgr.XComponentSet.Basic_Rotation:
				return new XRotationComponent();
			case XComponentMgr.XComponentSet.Audio:
				return new XAudioComponent();
			case XComponentMgr.XComponentSet.Character_Billboard:
				return new XBillboardComponent();
			case XComponentMgr.XComponentSet.Moba_Billboard:
				return new XMobaBillboardComponent();
			case XComponentMgr.XComponentSet.Character_Buff:
				return new XBuffComponent();
			case XComponentMgr.XComponentSet.Death:
				return new XDeathComponent();
			case XComponentMgr.XComponentSet.Character_Equipment:
				return new XEquipComponent();
			case XComponentMgr.XComponentSet.Entity_Gravity:
				return new XGravityComponent();
			case XComponentMgr.XComponentSet.CombatInfoInScene:
				return new XHUDComponent();
			case XComponentMgr.XComponentSet.Presentation:
				return new XPresentComponent();
			case XComponentMgr.XComponentSet.Skill:
				return new XSkillComponent();
			case XComponentMgr.XComponentSet.StateMachine:
				return new XStateMachine();
			case XComponentMgr.XComponentSet.Camera_Basic_Collison:
				return new XCameraCollisonComponent();
			case XComponentMgr.XComponentSet.Camera_Basic_Shake:
				return new XCameraShakeComponent();
			case XComponentMgr.XComponentSet.Action_Generator:
				return new XActionGeneratorComponent();
			case XComponentMgr.XComponentSet.Renderer:
				return new XRenderComponent();
			case XComponentMgr.XComponentSet.Net_Component:
				return new XNetComponent();
			case XComponentMgr.XComponentSet.Role_Attributes:
				return new XRoleAttributes();
			case XComponentMgr.XComponentSet.Camera_Common_Action:
				return new XCameraActionComponent();
			case XComponentMgr.XComponentSet.ShowUp:
				return new XShowUpComponent();
			case XComponentMgr.XComponentSet.Npc_Attributes:
				return new XNpcAttributes();
			case XComponentMgr.XComponentSet.Camera_Solo_Effect:
				return new XCameraSoloComponent();
			case XComponentMgr.XComponentSet.Camera_Wall_Component:
				return new XCameraWallComponent();
			case XComponentMgr.XComponentSet.Camera_Motion:
				return new XCameraMotionComponent();
			case XComponentMgr.XComponentSet.Navgation_Component:
				return new XNavigationComponent();
			case XComponentMgr.XComponentSet.Camera_CloseUp_Component:
				return new XCameraCloseUpComponent();
			case XComponentMgr.XComponentSet.Camera_IntellectiveFollow_Component:
				return new XCameraIntellectiveFollow();
			case XComponentMgr.XComponentSet.Fly:
				return new XFlyComponent();
			case XComponentMgr.XComponentSet.Shadow:
				return new XShadowComponent();
			case XComponentMgr.XComponentSet.Others_Attributes:
				return new XOthersAttributes();
			case XComponentMgr.XComponentSet.Endure:
				return new XEndureComponent();
			case XComponentMgr.XComponentSet.FindExpDocument:
				return new XFindExpDocument();
			case XComponentMgr.XComponentSet.EquipCreateDocument:
				return new XEquipCreateDocument();
			case XComponentMgr.XComponentSet.ArenaDocument:
				return new XArenaDocument();
			case XComponentMgr.XComponentSet.AchievementDocument:
				return new XAchievementDocument();
			case XComponentMgr.XComponentSet.JadeDocument:
				return new XJadeDocument();
			case XComponentMgr.XComponentSet.CharacterDocument:
				return new XCharacterDocument();
			case XComponentMgr.XComponentSet.ActivityDocument:
				return new XActivityDocument();
			case XComponentMgr.XComponentSet.MystShopDocument:
				return new XMystShopDocument();
			case XComponentMgr.XComponentSet.LoginRewardDocument:
				return new XLoginRewardDocument();
			case XComponentMgr.XComponentSet.MainInterfaceDocument:
				return new XMainInterfaceDocument();
			case XComponentMgr.XComponentSet.DailyActivitiesDocument:
				return new XDailyActivitiesDocument();
			case XComponentMgr.XComponentSet.FashionDocument:
				return new XFashionDocument();
			case XComponentMgr.XComponentSet.SuperRiskDocument:
				return new XSuperRiskDocument();
			case XComponentMgr.XComponentSet.EmblemDocument:
				return new XEmblemDocument();
			case XComponentMgr.XComponentSet.RankDocument:
				return new XRankDocument();
			case XComponentMgr.XComponentSet.FlowerSendDocument:
				return new XFlowerSendDocument();
			case XComponentMgr.XComponentSet.FlowerRankDocument:
				return new XFlowerRankDocument();
			case XComponentMgr.XComponentSet.FlowerReplyDocument:
				return new XFlowerReplyDocument();
			case XComponentMgr.XComponentSet.WeekendPartyDocument:
				return new XWeekendPartyDocument();
			case XComponentMgr.XComponentSet.PlatformAbilityDocument:
				return new XPlatformAbilityDocument();
			case XComponentMgr.XComponentSet.PKInvitationDocument:
				return new XPKInvitationDocument();
			case XComponentMgr.XComponentSet.WelfareDocument:
				return new XWelfareDocument();
			case XComponentMgr.XComponentSet.CharacterCommonMenuDocument:
				return new XCharacterCommonMenuDocument();
			case XComponentMgr.XComponentSet.EnhanceDocument:
				return new XEnhanceDocument();
			case XComponentMgr.XComponentSet.OptionsDocument:
				return new XOptionsDocument();
			case XComponentMgr.XComponentSet.SystemRewardDocument:
				return new XSystemRewardDocument();
			case XComponentMgr.XComponentSet.XBagDocument:
				return new XBagDocument();
			case XComponentMgr.XComponentSet.CharacterEquipDocument:
				return new XCharacterEquipDocument();
			case XComponentMgr.XComponentSet.XEquipDocument:
				return new XEquipDocument();
			case XComponentMgr.XComponentSet.NormalShopDocument:
				return new XNormalShopDocument();
			case XComponentMgr.XComponentSet.SweepDocument:
				return new XSweepDocument();
			case XComponentMgr.XComponentSet.TeamDocument:
				return new XTeamDocument();
			case XComponentMgr.XComponentSet.ShowGetItemDocument:
				return new XShowGetItemDocument();
			case XComponentMgr.XComponentSet.AdditionRemindDocument:
				return new AdditionRemindDocument();
			case XComponentMgr.XComponentSet.ExpeditionDocument:
				return new XExpeditionDocument();
			case XComponentMgr.XComponentSet.WorldBossDocument:
				return new XWorldBossDocument();
			case XComponentMgr.XComponentSet.DanceDocument:
				return new XDanceDocument();
			case XComponentMgr.XComponentSet.XRechargeDocument:
				return new XRechargeDocument();
			case XComponentMgr.XComponentSet.XPurchaseDocument:
				return new XPurchaseDocument();
			case XComponentMgr.XComponentSet.XFPStrengthenDocument:
				return new XFPStrengthenDocument();
			case XComponentMgr.XComponentSet.LevelUpStatusDocument:
				return new XLevelUpStatusDocument();
			case XComponentMgr.XComponentSet.ShowGetAchivementTipDocument:
				return new XShowGetAchivementTipDocument();
			case XComponentMgr.XComponentSet.SystemTipDocument:
				return new XSystemTipDocument();
			case XComponentMgr.XComponentSet.SkillTreeDocument:
				return new XSkillTreeDocument();
			case XComponentMgr.XComponentSet.XOtherPlayerInfoDocument:
				return new XOtherPlayerInfoDocument();
			case XComponentMgr.XComponentSet.RecycleItemDocument:
				return new XRecycleItemDocument();
			case XComponentMgr.XComponentSet.XChatDocument:
				return new XChatDocument();
			case XComponentMgr.XComponentSet.SelectCharacterDocument:
				return new XSelectCharacterDocument();
			case XComponentMgr.XComponentSet.GuildDocument:
				return new XGuildDocument();
			case XComponentMgr.XComponentSet.GuildListDocument:
				return new XGuildListDocument();
			case XComponentMgr.XComponentSet.XFriendsDocument:
				return new XFriendsDocument();
			case XComponentMgr.XComponentSet.XLevelDocument:
				return new XLevelDocument();
			case XComponentMgr.XComponentSet.XGuildArenaBattleDocument:
				return new XGuildArenaBattleDocument();
			case XComponentMgr.XComponentSet.GuildHallDocument:
				return new XGuildHallDocument();
			case XComponentMgr.XComponentSet.GuildApproveDocument:
				return new XGuildApproveDocument();
			case XComponentMgr.XComponentSet.GuildMemberDocument:
				return new XGuildMemberDocument();
			case XComponentMgr.XComponentSet.GuildSignInDocument:
				return new XGuildSignInDocument();
			case XComponentMgr.XComponentSet.GuildViewDocument:
				return new XGuildViewDocument();
			case XComponentMgr.XComponentSet.GuildRelaxGameDocument:
				return new XGuildRelaxGameDocument();
			case XComponentMgr.XComponentSet.GuildJokerDocument:
				return new XGuildJokerDocument();
			case XComponentMgr.XComponentSet.GuildSkillDocument:
				return new XGuildSkillDocument();
			case XComponentMgr.XComponentSet.GuildRedPacketDocument:
				return new XGuildRedPacketDocument();
			case XComponentMgr.XComponentSet.XGuildQualifierDocument:
				return new XGuildQualifierDocument();
			case XComponentMgr.XComponentSet.XGuildJokerMatchDocument:
				return new XGuildJockerMatchDocument();
			case XComponentMgr.XComponentSet.XGuildArenaDocument:
				return new XGuildArenaDocument();
			case XComponentMgr.XComponentSet.XGuildRankDocument:
				return new XGuildRankDocument();
			case XComponentMgr.XComponentSet.XGuildSalaryDocument:
				return new XGuildSalaryDocument();
			case XComponentMgr.XComponentSet.XGuildInheritDocument:
				return new XGuildInheritDocument();
			case XComponentMgr.XComponentSet.XGuildTerritoryDocument:
				return new XGuildTerritoryDocument();
			case XComponentMgr.XComponentSet.LevelRewardDocument:
				return new XLevelRewardDocument();
			case XComponentMgr.XComponentSet.CharacterItemDocument:
				return new XCharacterItemDocument();
			case XComponentMgr.XComponentSet.GuildDragonDocument:
				return new XGuildDragonDocument();
			case XComponentMgr.XComponentSet.NextDayRewardDocument:
				return new XNextDayRewardDocument();
			case XComponentMgr.XComponentSet.InvitationDocument:
				return new XInvitationDocument();
			case XComponentMgr.XComponentSet.OnlineRewardDocument:
				return new XOnlineRewardDocument();
			case XComponentMgr.XComponentSet.FootFx:
				return new XFootFxComponent();
			case XComponentMgr.XComponentSet.XLocateTarget:
				return new XLocateTargetComponent();
			case XComponentMgr.XComponentSet.QualifyingDocument:
				return new XQualifyingDocument();
			case XComponentMgr.XComponentSet.BattleSkillDocument:
				return new XBattleSkillDocument();
			case XComponentMgr.XComponentSet.GuildSmallMonsterDocument:
				return new XGuildSmallMonsterDocument();
			case XComponentMgr.XComponentSet.XTitleDocument:
				return new XTitleDocument();
			case XComponentMgr.XComponentSet.XQuickTimeEventComponent:
				return new XQuickTimeEventComponent();
			case XComponentMgr.XComponentSet.SceneDamageRankDocument:
				return new XSceneDamageRankDocument();
			case XComponentMgr.XComponentSet.XSuperArmorComponent:
				return new XSuperArmorComponent();
			case XComponentMgr.XComponentSet.WoozyComponent:
				return new XWoozyComponent();
			case XComponentMgr.XComponentSet.BattleDocument:
				return new XBattleDocument();
			case XComponentMgr.XComponentSet.XAIComponent:
				return new XAIComponent();
			case XComponentMgr.XComponentSet.XInheritComponent:
				return new XInheritComponent();
			case XComponentMgr.XComponentSet.FishingComponent:
				return new XFishingComponent();
			case XComponentMgr.XComponentSet.Camera_Vertical_Adjustment:
				return new XCameraVAdjustComponent();
			case XComponentMgr.XComponentSet.FightGroupDocument:
				return new XFightGroupDocument();
			case XComponentMgr.XComponentSet.PetDocument:
				return new XPetDocument();
			case XComponentMgr.XComponentSet.AuctionDocument:
				return new AuctionDocument();
			case XComponentMgr.XComponentSet.MailDocument:
				return new XMailDocument();
			case XComponentMgr.XComponentSet.XGameMallDocument:
				return new XGameMallDocument();
			case XComponentMgr.XComponentSet.PPTDocument:
				return new XPPTDocument();
			case XComponentMgr.XComponentSet.MountComponent:
				return new XMountComponent();
			case XComponentMgr.XComponentSet.DesignationDocument:
				return new XDesignationDocument();
			case XComponentMgr.XComponentSet.DragonRewardDocument:
				return new XDragonRewardDocument();
			case XComponentMgr.XComponentSet.LevelSealDocument:
				return new XLevelSealDocument();
			case XComponentMgr.XComponentSet.Bubble:
				return new XBubbleComponent();
			case XComponentMgr.XComponentSet.XTerritoryComponent:
				return new XTerritoryComponent();
			case XComponentMgr.XComponentSet.QuickReplyDocument:
				return new XQuickReplyDocument();
			case XComponentMgr.XComponentSet.CaptainPVPDocument:
				return new XCaptainPVPDocument();
			case XComponentMgr.XComponentSet.VoiceQADocument:
				return new XVoiceQADocument();
			case XComponentMgr.XComponentSet.BattleCaptainPVPDocument:
				return new XBattleCaptainPVPDocument();
			case XComponentMgr.XComponentSet.XSkyArenaEntranceDocument:
				return new XSkyArenaEntranceDocument();
			case XComponentMgr.XComponentSet.XSkyArenaBattleDocument:
				return new XSkyArenaBattleDocument();
			case XComponentMgr.XComponentSet.XBigMeleeEntranceDocument:
				return new XBigMeleeEntranceDocument();
			case XComponentMgr.XComponentSet.XBigMeleeBattleDocument:
				return new XBigMeleeBattleDocument();
			case XComponentMgr.XComponentSet.XBattleFieldEntranceDocument:
				return new XBattleFieldEntranceDocument();
			case XComponentMgr.XComponentSet.XBattleFieldBattleDocument:
				return new XBattleFieldBattleDocument();
			case XComponentMgr.XComponentSet.XRaceDocument:
				return new XRaceDocument();
			case XComponentMgr.XComponentSet.XPersonalCareerDocument:
				return new XPersonalCareerDocument();
			case XComponentMgr.XComponentSet.DragonNestDocument:
				return new XDragonNestDocument();
			case XComponentMgr.XComponentSet.PushSubscribeDocument:
				return new XPushSubscribeDocument();
			case XComponentMgr.XComponentSet.PVPActivityDocument:
				return new XPVPActivityDocument();
			case XComponentMgr.XComponentSet.TeamInviteDocument:
				return new XTeamInviteDocument();
			case XComponentMgr.XComponentSet.XBossBushDocument:
				return new XBossBushDocument();
			case XComponentMgr.XComponentSet.SpectateDocument:
				return new XSpectateDocument();
			case XComponentMgr.XComponentSet.SpectateSceneDocument:
				return new XSpectateSceneDocument();
			case XComponentMgr.XComponentSet.SpectateLevelRewardDocument:
				return new XSpectateLevelRewardDocument();
			case XComponentMgr.XComponentSet.XApolloDocument:
				return new XApolloDocument();
			case XComponentMgr.XComponentSet.GroupChatDocument:
				return new GroupChatDocument();
			case XComponentMgr.XComponentSet.XBigPrizeDocument:
				return new XAncientDocument();
			case XComponentMgr.XComponentSet.XRadioDocument:
				return new XRadioDocument();
			case XComponentMgr.XComponentSet.XLuaDocument:
				return new XLuaDocument();
			case XComponentMgr.XComponentSet.XSevenLoginDocument:
				return new XSevenLoginDocument();
			case XComponentMgr.XComponentSet.FirstPassDocument:
				return new FirstPassDocument();
			case XComponentMgr.XComponentSet.XOperatingActivityDocument:
				return new XOperatingActivityDocument();
			case XComponentMgr.XComponentSet.XThemeActivityDocument:
				return new XThemeActivityDocument();
			case XComponentMgr.XComponentSet.BiochemicalHellDogDocument:
				return new BiochemicalHellDogDocument();
			case XComponentMgr.XComponentSet.MadDuckSiegeDocument:
				return new MadDuckSiegeDocument();
			case XComponentMgr.XComponentSet.RollDocument:
				return new XRollDocument();
			case XComponentMgr.XComponentSet.SpriteSystemDocument:
				return new XSpriteSystemDocument();
			case XComponentMgr.XComponentSet.XCardCollectDocument:
				return new XCardCollectDocument();
			case XComponentMgr.XComponentSet.XDragonCrusadeDocument:
				return new XDragonCrusadeDocument();
			case XComponentMgr.XComponentSet.XGuildMineBattleDocument:
				return new XGuildMineBattleDocument();
			case XComponentMgr.XComponentSet.XGuildMineMainDocument:
				return new XGuildMineMainDocument();
			case XComponentMgr.XComponentSet.XGuildMineEntranceDocument:
				return new XGuildMineEntranceDocument();
			case XComponentMgr.XComponentSet.XManipulation:
				return new XManipulationComponent();
			case XComponentMgr.XComponentSet.ReviveDocument:
				return new XReviveDocument();
			case XComponentMgr.XComponentSet.IDIPDocument:
				return new XIDIPDocument();
			case XComponentMgr.XComponentSet.XSmeltDocument:
				return new XSmeltDocument();
			case XComponentMgr.XComponentSet.HomePlantDocument:
				return new HomePlantDocument();
			case XComponentMgr.XComponentSet.HomeMainDocument:
				return new HomeMainDocument();
			case XComponentMgr.XComponentSet.TaskDocument:
				return new XTaskDocument();
			case XComponentMgr.XComponentSet.XCarnivalDocument:
				return new XCarnivalDocument();
			case XComponentMgr.XComponentSet.TempActivityDocument:
				return new XTempActivityDocument();
			case XComponentMgr.XComponentSet.HomeCookAndPartyDocument:
				return new XHomeCookAndPartyDocument();
			case XComponentMgr.XComponentSet.ActivityInviteDocument:
				return new XActivityInviteDocument();
			case XComponentMgr.XComponentSet.HomeFishingDocument:
				return new XHomeFishingDocument();
			case XComponentMgr.XComponentSet.CombatStatisticsDocument:
				return new XCombatStatisticsDocument();
			case XComponentMgr.XComponentSet.AuctionHouseDocument:
				return new AuctionHouseDocument();
			case XComponentMgr.XComponentSet.GuildResContentionBuffDocument:
				return new XGuildResContentionBuffDocument();
			case XComponentMgr.XComponentSet.XScreenShotShareDocument:
				return new XScreenShotShareDocument();
			case XComponentMgr.XComponentSet.GuildDonateDocument:
				return new XGuildDonateDocument();
			case XComponentMgr.XComponentSet.GuildDailyTaskDocument:
				return new XGuildDailyTaskDocument();
			case XComponentMgr.XComponentSet.BillboardDocument:
				return new XBillBoardDocument();
			case XComponentMgr.XComponentSet.CharacterShowChatComponent:
				return new XCharacterShowChatComponent();
			case XComponentMgr.XComponentSet.MentorshipDocument:
				return new XMentorshipDocument();
			case XComponentMgr.XComponentSet.EnchantDocument:
				return new XEnchantDocument();
			case XComponentMgr.XComponentSet.HeroBattleDocument:
				return new XHeroBattleDocument();
			case XComponentMgr.XComponentSet.HeroBattleSkillDocument:
				return new XHeroBattleSkillDocument();
			case XComponentMgr.XComponentSet.XWeekNestDocument:
				return new XWeekNestDocument();
			case XComponentMgr.XComponentSet.XCompeteDocument:
				return new XCompeteDocument();
			case XComponentMgr.XComponentSet.XPartnerDocument:
				return new XPartnerDocument();
			case XComponentMgr.XComponentSet.WeddingDocument:
				return new XWeddingDocument();
			case XComponentMgr.XComponentSet.DragonPartnerDocument:
				return new XDragonPartnerDocument();
			case XComponentMgr.XComponentSet.NPCFavorDocument:
				return new XNPCFavorDocument();
			case XComponentMgr.XComponentSet.DramaDocument:
				return new XDramaDocument();
			case XComponentMgr.XComponentSet.XJokerKingDocument:
				return new XJokerKingDocument();
			case XComponentMgr.XComponentSet.PandoraDocument:
				return new PandoraDocument();
			case XComponentMgr.XComponentSet.XForgeDocument:
				return new XForgeDocument();
			case XComponentMgr.XComponentSet.FreeTeamVersusLeagueDocument:
				return new XFreeTeamVersusLeagueDocument();
			case XComponentMgr.XComponentSet.TeamLeagueBattleDocument:
				return new XTeamLeagueBattleDocument();
			case XComponentMgr.XComponentSet.NestDocument:
				return new XNestDocument();
			case XComponentMgr.XComponentSet.ProfessionChangeDocument:
				return new XProfessionChangeDocument();
			case XComponentMgr.XComponentSet.AnnouncementDocument:
				return new XAnnouncementDocument();
			case XComponentMgr.XComponentSet.HallFameDocument:
				return new XHallFameDocument();
			case XComponentMgr.XComponentSet.MilitaryRankDocument:
				return new XMilitaryRankDocument();
			case XComponentMgr.XComponentSet.GuildCollectDocument:
				return new XGuildCollectDocument();
			case XComponentMgr.XComponentSet.ExchangeItemDocument:
				return new XExchangeItemDocument();
			case XComponentMgr.XComponentSet.RenameDocument:
				return new XRenameDocument();
			case XComponentMgr.XComponentSet.FashionStorageDocument:
				return new XFashionStorageDocument();
			case XComponentMgr.XComponentSet.ArtifactDocument:
				return new ArtifactDocument();
			case XComponentMgr.XComponentSet.ArtifactComposeDocument:
				return new ArtifactComposeDocument();
			case XComponentMgr.XComponentSet.ArtifactBagDocument:
				return new ArtifactBagDocument();
			case XComponentMgr.XComponentSet.ArtifactAtlasDocument:
				return new ArtifactAtlasDocument();
			case XComponentMgr.XComponentSet.RequestDocument:
				return new XRequestDocument();
			case XComponentMgr.XComponentSet.AbyssPartyDocument:
				return new XAbyssPartyDocument();
			case XComponentMgr.XComponentSet.CustomBattleDocument:
				return new XCustomBattleDocument();
			case XComponentMgr.XComponentSet.MobaEntranceDocument:
				return new XMobaEntranceDocument();
			case XComponentMgr.XComponentSet.MobaBattleDocument:
				return new XMobaBattleDocument();
			case XComponentMgr.XComponentSet.TaJieHelpDocument:
				return new TaJieHelpDocument();
			case XComponentMgr.XComponentSet.ArtifactDeityStoveDocument:
				return new ArtifactDeityStoveDocument();
			case XComponentMgr.XComponentSet.ArtifactRecastDocument:
				return new ArtifactRecastDocument();
			case XComponentMgr.XComponentSet.ArtifactFuseDocument:
				return new ArtifactFuseDocument();
			case XComponentMgr.XComponentSet.ArtifactInscriptionDocument:
				return new ArtifactInscriptionDocument();
			case XComponentMgr.XComponentSet.WeekEndNestDocument:
				return new WeekEndNestDocument();
			case XComponentMgr.XComponentSet.XGuildWeeklyBountyDocument:
				return new XGuildWeeklyBountyDocument();
			case XComponentMgr.XComponentSet.EquipUpgradeDocument:
				return new EquipUpgradeDocument();
			case XComponentMgr.XComponentSet.EquipFusionDocument:
				return new EquipFusionDocument();
			case XComponentMgr.XComponentSet.PrerogativeDocument:
				return new XPrerogativeDocument();
			case XComponentMgr.XComponentSet.TargetRewardDocument:
				return new XTargetRewardDocument();
			case XComponentMgr.XComponentSet.XDragonGuildDocument:
				return new XDragonGuildDocument();
			case XComponentMgr.XComponentSet.XDragonGuildListDocument:
				return new XDragonGuildListDocument();
			case XComponentMgr.XComponentSet.XDragonGuildTaskDocument:
				return new XDragonGuildTaskDocument();
			case XComponentMgr.XComponentSet.XDragonGuildApproveDocument:
				return new XDragonGuildApproveDocument();
			case XComponentMgr.XComponentSet.XTransformDocument:
				return new XTransformDocument();
			case XComponentMgr.XComponentSet.XBackFlowDocument:
				return new XBackFlowDocument();
			case XComponentMgr.XComponentSet.XYorozuyaDocument:
				return new XYorozuyaDocument();
			case XComponentMgr.XComponentSet.MysterioursDocument:
				return new XRiftDocument();
			case XComponentMgr.XComponentSet.XCampDuelDocument:
				return new XCampDuelDocument();
			case XComponentMgr.XComponentSet.ArtifactRefinedDocument:
				return new ArtifactRefinedDocument();
			case XComponentMgr.XComponentSet.XArtifactCreateDocument:
				return new XArtifactCreateDocument();
			case XComponentMgr.XComponentSet.CrossGVGDocument:
				return new XCrossGVGDocument();
			case XComponentMgr.XComponentSet.XGuildGrowthDocument:
				return new XGuildGrowthDocument();
			}
			throw new XErrorUnregisteredComponentException("Component at slot " + slot + " not registered.");
		}

		private Dictionary<uint, int> _slots = new Dictionary<uint, int>();

		private Dictionary<uint, XComponentMgr.ComponentCache> _componentCache = new Dictionary<uint, XComponentMgr.ComponentCache>();

		public static int ComponenCreatetCount = 0;

		private int count = 0;

		public class ComponentCache
		{

			public int SlotIndex = -1;

			public Queue<XComponent> componentCache = new Queue<XComponent>();
		}

		private enum XComponentSet
		{

			AI_Auto_Fight,

			Player_Attributes,

			Basic_Move,

			BeHit_Presentation,

			Charge_Move,

			Basic_Fall,

			Freezing_Presentation,

			Basic_Idle,

			Basic_Jump,

			Basic_Rotation,

			Audio,

			Character_Billboard,

			Moba_Billboard,

			Character_Buff,

			Death,

			Character_Equipment,

			Entity_Gravity,

			CombatInfoInScene,

			Presentation,

			Skill,

			StateMachine,

			Role_StateMachine,

			AI_StateMachine,

			Camera_Basic_Collison,

			Camera_Basic_Shake,

			Action_Generator,

			Renderer,

			Net_Component,

			Role_Attributes,

			Camera_Common_Action,

			ShowUp,

			Npc_Attributes,

			Camera_Solo_Effect,

			Camera_Wall_Component,

			Camera_Motion,

			Navgation_Component,

			Camera_CloseUp_Component,

			Camera_IntellectiveFollow_Component,

			Fly,

			Shadow,

			Assist_AI,

			Others_Attributes,

			Endure,

			TShow,

			CampMainDocument,

			CampMissionDocument,

			FindExpDocument,

			EquipCreateDocument,

			ArenaDocument,

			AchievementDocument,

			JadeDocument,

			CharacterDocument,

			ActivityDocument,

			MystShopDocument,

			LoginRewardDocument,

			MainInterfaceDocument,

			DailyActivitiesDocument,

			FashionDocument,

			SuperRiskDocument,

			EmblemDocument,

			RankDocument,

			FlowerSendDocument,

			FlowerRankDocument,

			FlowerReplyDocument,

			WeekendPartyDocument,

			PlatformAbilityDocument,

			PKInvitationDocument,

			WelfareDocument,

			CharacterCommonMenuDocument,

			EnhanceDocument,

			OptionsDocument,

			SystemRewardDocument,

			XBagDocument,

			CharacterEquipDocument,

			XEquipDocument,

			NormalShopDocument,

			SweepDocument,

			TeamDocument,

			ShowGetItemDocument,

			AdditionRemindDocument,

			ExpeditionDocument,

			WorldBossDocument,

			DanceDocument,

			XRechargeDocument,

			XPurchaseDocument,

			XFPStrengthenDocument,

			LevelUpStatusDocument,

			ShowGetAchivementTipDocument,

			SystemTipDocument,

			ReinforceDocument,

			SkillTreeDocument,

			XOtherPlayerInfoDocument,

			LotteryDocument,

			RecycleItemDocument,

			XChatDocument,

			SelectCharacterDocument,

			GuildDocument,

			GuildListDocument,

			XFriendsDocument,

			XLevelDocument,

			XGuildArenaBattleDocument,

			GuildHallDocument,

			GuildApproveDocument,

			GuildMemberDocument,

			GuildSignInDocument,

			GuildViewDocument,

			GuildRelaxGameDocument,

			GuildJokerDocument,

			GuildSkillDocument,

			GuildRedPacketDocument,

			XGuildQualifierDocument,

			XGuildJokerMatchDocument,

			XGuildArenaDocument,

			XGuildRankDocument,

			XGuildSalaryDocument,

			XGuildInheritDocument,

			XGuildTerritoryDocument,

			LevelRewardDocument,

			CharacterItemDocument,

			GuildDragonDocument,

			NextDayRewardDocument,

			InvitationDocument,

			OnlineRewardDocument,

			FootFx,

			XRoleAutoFightAIComponent,

			XLocateTarget,

			SmeltingDocument,

			QualifyingDocument,

			XAIArenaFightComponent,

			BattleSkillDocument,

			GuildSmallMonsterDocument,

			XTitleDocument,

			XQuickTimeEventComponent,

			SceneDamageRankDocument,

			XSuperArmorComponent,

			WoozyComponent,

			BattleDocument,

			XAIComponent,

			XInheritComponent,

			GayValleyDocument,

			GayValleyFashionDocument,

			GayValleyFishingDocument,

			FishingComponent,

			Camera_Vertical_Adjustment,

			TShowDocument,

			FightGroupDocument,

			PetDocument,

			XAuctionDocument,

			AuctionDocument,

			MailDocument,

			XGameMallDocument,

			PPTDocument,

			MountComponent,

			DesignationDocument,

			DragonRewardDocument,

			LevelSealDocument,

			Bubble,

			XTerritoryComponent,

			QuickReplyDocument,

			CaptainPVPDocument,

			VoiceQADocument,

			BattleCaptainPVPDocument,

			XSkyArenaEntranceDocument,

			XSkyArenaBattleDocument,

			XBigMeleeEntranceDocument,

			XBigMeleeBattleDocument,

			XBattleFieldEntranceDocument,

			XBattleFieldBattleDocument,

			XRaceDocument,

			XPersonalCareerDocument,

			DragonNestDocument,

			PushSubscribeDocument,

			MulActivityDocument,

			PVPActivityDocument,

			TeamInviteDocument,

			XBossBushDocument,

			SpectateDocument,

			SpectateSceneDocument,

			SpectateLevelRewardDocument,

			XApolloDocument,

			GroupChatDocument,

			XBigPrizeDocument,

			XRadioDocument,

			XLuaDocument,

			XSevenLoginDocument,

			FirstPassDocument,

			XOperatingActivityDocument,

			XThemeActivityDocument,

			BiochemicalHellDogDocument,

			MadDuckSiegeDocument,

			RollDocument,

			SpriteSystemDocument,

			XCardCollectDocument,

			XDragonCrusadeDocument,

			XGuildMineBattleDocument,

			XGuildMineMainDocument,

			XGuildMineEntranceDocument,

			XManipulation,

			ReviveDocument,

			IDIPDocument,

			XSmeltDocument,

			HomePlantDocument,

			HomeMainDocument,

			TaskDocument,

			XCarnivalDocument,

			TempActivityDocument,

			HomeCookAndPartyDocument,

			ActivityInviteDocument,

			HomeFishingDocument,

			CombatStatisticsDocument,

			AuctionHouseDocument,

			GuildResContentionBuffDocument,

			XScreenShotShareDocument,

			GuildDonateDocument,

			GuildDailyTaskDocument,

			BillboardDocument,

			CharacterShowChatComponent,

			MentorshipDocument,

			EnchantDocument,

			HeroBattleDocument,

			HeroBattleSkillDocument,

			XWeekNestDocument,

			XCompeteDocument,

			XPartnerDocument,

			WeddingDocument,

			DragonPartnerDocument,

			NPCFavorDocument,

			DramaDocument,

			XJokerKingDocument,

			PandoraDocument,

			XForgeDocument,

			FreeTeamVersusLeagueDocument,

			TeamLeagueBattleDocument,

			NestDocument,

			ProfessionChangeDocument,

			AnnouncementDocument,

			HallFameDocument,

			MilitaryRankDocument,

			GuildCollectDocument,

			ExchangeItemDocument,

			RenameDocument,

			FashionStorageDocument,

			ArtifactDocument,

			ArtifactComposeDocument,

			ArtifactBagDocument,

			ArtifactAtlasDocument,

			RequestDocument,

			AbyssPartyDocument,

			CustomBattleDocument,

			MobaEntranceDocument,

			MobaBattleDocument,

			TaJieHelpDocument,

			ArtifactDeityStoveDocument,

			ArtifactRecastDocument,

			ArtifactFuseDocument,

			ArtifactInscriptionDocument,

			WeekEndNestDocument,

			XGuildWeeklyBountyDocument,

			EquipUpgradeDocument,

			EquipFusionDocument,

			PrerogativeDocument,

			TargetRewardDocument,

			XDragonGuildDocument,

			XDragonGuildListDocument,

			XDragonGuildTaskDocument,

			XDragonGuildApproveDocument,

			XTransformDocument,

			XBackFlowDocument,

			XYorozuyaDocument,

			MysterioursDocument,

			XCampDuelDocument,

			ArtifactRefinedDocument,

			XArtifactCreateDocument,

			CrossGVGDocument,

			XGuildGrowthDocument,

			MAX
		}
	}
}
