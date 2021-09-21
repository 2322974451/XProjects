using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000FC8 RID: 4040
	internal sealed class XComponentMgr : XSingleton<XComponentMgr>
	{
		// Token: 0x0600D20D RID: 53773 RVA: 0x0030E564 File Offset: 0x0030C764
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

		// Token: 0x0600D20E RID: 53774 RVA: 0x0030E63C File Offset: 0x0030C83C
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

		// Token: 0x0600D20F RID: 53775 RVA: 0x0030E71C File Offset: 0x0030C91C
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

		// Token: 0x0600D210 RID: 53776 RVA: 0x0030E778 File Offset: 0x0030C978
		public void ClearAll()
		{
			foreach (KeyValuePair<uint, XComponentMgr.ComponentCache> keyValuePair in this._componentCache)
			{
				keyValuePair.Value.componentCache.Clear();
			}
		}

		// Token: 0x0600D211 RID: 53777 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public void PrintAllComponent()
		{
		}

		// Token: 0x0600D212 RID: 53778 RVA: 0x0030E7BC File Offset: 0x0030C9BC
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

		// Token: 0x04005F49 RID: 24393
		private Dictionary<uint, int> _slots = new Dictionary<uint, int>();

		// Token: 0x04005F4A RID: 24394
		private Dictionary<uint, XComponentMgr.ComponentCache> _componentCache = new Dictionary<uint, XComponentMgr.ComponentCache>();

		// Token: 0x04005F4B RID: 24395
		public static int ComponenCreatetCount = 0;

		// Token: 0x04005F4C RID: 24396
		private int count = 0;

		// Token: 0x020019F6 RID: 6646
		public class ComponentCache
		{
			// Token: 0x040080BC RID: 32956
			public int SlotIndex = -1;

			// Token: 0x040080BD RID: 32957
			public Queue<XComponent> componentCache = new Queue<XComponent>();
		}

		// Token: 0x020019F7 RID: 6647
		private enum XComponentSet
		{
			// Token: 0x040080BF RID: 32959
			AI_Auto_Fight,
			// Token: 0x040080C0 RID: 32960
			Player_Attributes,
			// Token: 0x040080C1 RID: 32961
			Basic_Move,
			// Token: 0x040080C2 RID: 32962
			BeHit_Presentation,
			// Token: 0x040080C3 RID: 32963
			Charge_Move,
			// Token: 0x040080C4 RID: 32964
			Basic_Fall,
			// Token: 0x040080C5 RID: 32965
			Freezing_Presentation,
			// Token: 0x040080C6 RID: 32966
			Basic_Idle,
			// Token: 0x040080C7 RID: 32967
			Basic_Jump,
			// Token: 0x040080C8 RID: 32968
			Basic_Rotation,
			// Token: 0x040080C9 RID: 32969
			Audio,
			// Token: 0x040080CA RID: 32970
			Character_Billboard,
			// Token: 0x040080CB RID: 32971
			Moba_Billboard,
			// Token: 0x040080CC RID: 32972
			Character_Buff,
			// Token: 0x040080CD RID: 32973
			Death,
			// Token: 0x040080CE RID: 32974
			Character_Equipment,
			// Token: 0x040080CF RID: 32975
			Entity_Gravity,
			// Token: 0x040080D0 RID: 32976
			CombatInfoInScene,
			// Token: 0x040080D1 RID: 32977
			Presentation,
			// Token: 0x040080D2 RID: 32978
			Skill,
			// Token: 0x040080D3 RID: 32979
			StateMachine,
			// Token: 0x040080D4 RID: 32980
			Role_StateMachine,
			// Token: 0x040080D5 RID: 32981
			AI_StateMachine,
			// Token: 0x040080D6 RID: 32982
			Camera_Basic_Collison,
			// Token: 0x040080D7 RID: 32983
			Camera_Basic_Shake,
			// Token: 0x040080D8 RID: 32984
			Action_Generator,
			// Token: 0x040080D9 RID: 32985
			Renderer,
			// Token: 0x040080DA RID: 32986
			Net_Component,
			// Token: 0x040080DB RID: 32987
			Role_Attributes,
			// Token: 0x040080DC RID: 32988
			Camera_Common_Action,
			// Token: 0x040080DD RID: 32989
			ShowUp,
			// Token: 0x040080DE RID: 32990
			Npc_Attributes,
			// Token: 0x040080DF RID: 32991
			Camera_Solo_Effect,
			// Token: 0x040080E0 RID: 32992
			Camera_Wall_Component,
			// Token: 0x040080E1 RID: 32993
			Camera_Motion,
			// Token: 0x040080E2 RID: 32994
			Navgation_Component,
			// Token: 0x040080E3 RID: 32995
			Camera_CloseUp_Component,
			// Token: 0x040080E4 RID: 32996
			Camera_IntellectiveFollow_Component,
			// Token: 0x040080E5 RID: 32997
			Fly,
			// Token: 0x040080E6 RID: 32998
			Shadow,
			// Token: 0x040080E7 RID: 32999
			Assist_AI,
			// Token: 0x040080E8 RID: 33000
			Others_Attributes,
			// Token: 0x040080E9 RID: 33001
			Endure,
			// Token: 0x040080EA RID: 33002
			TShow,
			// Token: 0x040080EB RID: 33003
			CampMainDocument,
			// Token: 0x040080EC RID: 33004
			CampMissionDocument,
			// Token: 0x040080ED RID: 33005
			FindExpDocument,
			// Token: 0x040080EE RID: 33006
			EquipCreateDocument,
			// Token: 0x040080EF RID: 33007
			ArenaDocument,
			// Token: 0x040080F0 RID: 33008
			AchievementDocument,
			// Token: 0x040080F1 RID: 33009
			JadeDocument,
			// Token: 0x040080F2 RID: 33010
			CharacterDocument,
			// Token: 0x040080F3 RID: 33011
			ActivityDocument,
			// Token: 0x040080F4 RID: 33012
			MystShopDocument,
			// Token: 0x040080F5 RID: 33013
			LoginRewardDocument,
			// Token: 0x040080F6 RID: 33014
			MainInterfaceDocument,
			// Token: 0x040080F7 RID: 33015
			DailyActivitiesDocument,
			// Token: 0x040080F8 RID: 33016
			FashionDocument,
			// Token: 0x040080F9 RID: 33017
			SuperRiskDocument,
			// Token: 0x040080FA RID: 33018
			EmblemDocument,
			// Token: 0x040080FB RID: 33019
			RankDocument,
			// Token: 0x040080FC RID: 33020
			FlowerSendDocument,
			// Token: 0x040080FD RID: 33021
			FlowerRankDocument,
			// Token: 0x040080FE RID: 33022
			FlowerReplyDocument,
			// Token: 0x040080FF RID: 33023
			WeekendPartyDocument,
			// Token: 0x04008100 RID: 33024
			PlatformAbilityDocument,
			// Token: 0x04008101 RID: 33025
			PKInvitationDocument,
			// Token: 0x04008102 RID: 33026
			WelfareDocument,
			// Token: 0x04008103 RID: 33027
			CharacterCommonMenuDocument,
			// Token: 0x04008104 RID: 33028
			EnhanceDocument,
			// Token: 0x04008105 RID: 33029
			OptionsDocument,
			// Token: 0x04008106 RID: 33030
			SystemRewardDocument,
			// Token: 0x04008107 RID: 33031
			XBagDocument,
			// Token: 0x04008108 RID: 33032
			CharacterEquipDocument,
			// Token: 0x04008109 RID: 33033
			XEquipDocument,
			// Token: 0x0400810A RID: 33034
			NormalShopDocument,
			// Token: 0x0400810B RID: 33035
			SweepDocument,
			// Token: 0x0400810C RID: 33036
			TeamDocument,
			// Token: 0x0400810D RID: 33037
			ShowGetItemDocument,
			// Token: 0x0400810E RID: 33038
			AdditionRemindDocument,
			// Token: 0x0400810F RID: 33039
			ExpeditionDocument,
			// Token: 0x04008110 RID: 33040
			WorldBossDocument,
			// Token: 0x04008111 RID: 33041
			DanceDocument,
			// Token: 0x04008112 RID: 33042
			XRechargeDocument,
			// Token: 0x04008113 RID: 33043
			XPurchaseDocument,
			// Token: 0x04008114 RID: 33044
			XFPStrengthenDocument,
			// Token: 0x04008115 RID: 33045
			LevelUpStatusDocument,
			// Token: 0x04008116 RID: 33046
			ShowGetAchivementTipDocument,
			// Token: 0x04008117 RID: 33047
			SystemTipDocument,
			// Token: 0x04008118 RID: 33048
			ReinforceDocument,
			// Token: 0x04008119 RID: 33049
			SkillTreeDocument,
			// Token: 0x0400811A RID: 33050
			XOtherPlayerInfoDocument,
			// Token: 0x0400811B RID: 33051
			LotteryDocument,
			// Token: 0x0400811C RID: 33052
			RecycleItemDocument,
			// Token: 0x0400811D RID: 33053
			XChatDocument,
			// Token: 0x0400811E RID: 33054
			SelectCharacterDocument,
			// Token: 0x0400811F RID: 33055
			GuildDocument,
			// Token: 0x04008120 RID: 33056
			GuildListDocument,
			// Token: 0x04008121 RID: 33057
			XFriendsDocument,
			// Token: 0x04008122 RID: 33058
			XLevelDocument,
			// Token: 0x04008123 RID: 33059
			XGuildArenaBattleDocument,
			// Token: 0x04008124 RID: 33060
			GuildHallDocument,
			// Token: 0x04008125 RID: 33061
			GuildApproveDocument,
			// Token: 0x04008126 RID: 33062
			GuildMemberDocument,
			// Token: 0x04008127 RID: 33063
			GuildSignInDocument,
			// Token: 0x04008128 RID: 33064
			GuildViewDocument,
			// Token: 0x04008129 RID: 33065
			GuildRelaxGameDocument,
			// Token: 0x0400812A RID: 33066
			GuildJokerDocument,
			// Token: 0x0400812B RID: 33067
			GuildSkillDocument,
			// Token: 0x0400812C RID: 33068
			GuildRedPacketDocument,
			// Token: 0x0400812D RID: 33069
			XGuildQualifierDocument,
			// Token: 0x0400812E RID: 33070
			XGuildJokerMatchDocument,
			// Token: 0x0400812F RID: 33071
			XGuildArenaDocument,
			// Token: 0x04008130 RID: 33072
			XGuildRankDocument,
			// Token: 0x04008131 RID: 33073
			XGuildSalaryDocument,
			// Token: 0x04008132 RID: 33074
			XGuildInheritDocument,
			// Token: 0x04008133 RID: 33075
			XGuildTerritoryDocument,
			// Token: 0x04008134 RID: 33076
			LevelRewardDocument,
			// Token: 0x04008135 RID: 33077
			CharacterItemDocument,
			// Token: 0x04008136 RID: 33078
			GuildDragonDocument,
			// Token: 0x04008137 RID: 33079
			NextDayRewardDocument,
			// Token: 0x04008138 RID: 33080
			InvitationDocument,
			// Token: 0x04008139 RID: 33081
			OnlineRewardDocument,
			// Token: 0x0400813A RID: 33082
			FootFx,
			// Token: 0x0400813B RID: 33083
			XRoleAutoFightAIComponent,
			// Token: 0x0400813C RID: 33084
			XLocateTarget,
			// Token: 0x0400813D RID: 33085
			SmeltingDocument,
			// Token: 0x0400813E RID: 33086
			QualifyingDocument,
			// Token: 0x0400813F RID: 33087
			XAIArenaFightComponent,
			// Token: 0x04008140 RID: 33088
			BattleSkillDocument,
			// Token: 0x04008141 RID: 33089
			GuildSmallMonsterDocument,
			// Token: 0x04008142 RID: 33090
			XTitleDocument,
			// Token: 0x04008143 RID: 33091
			XQuickTimeEventComponent,
			// Token: 0x04008144 RID: 33092
			SceneDamageRankDocument,
			// Token: 0x04008145 RID: 33093
			XSuperArmorComponent,
			// Token: 0x04008146 RID: 33094
			WoozyComponent,
			// Token: 0x04008147 RID: 33095
			BattleDocument,
			// Token: 0x04008148 RID: 33096
			XAIComponent,
			// Token: 0x04008149 RID: 33097
			XInheritComponent,
			// Token: 0x0400814A RID: 33098
			GayValleyDocument,
			// Token: 0x0400814B RID: 33099
			GayValleyFashionDocument,
			// Token: 0x0400814C RID: 33100
			GayValleyFishingDocument,
			// Token: 0x0400814D RID: 33101
			FishingComponent,
			// Token: 0x0400814E RID: 33102
			Camera_Vertical_Adjustment,
			// Token: 0x0400814F RID: 33103
			TShowDocument,
			// Token: 0x04008150 RID: 33104
			FightGroupDocument,
			// Token: 0x04008151 RID: 33105
			PetDocument,
			// Token: 0x04008152 RID: 33106
			XAuctionDocument,
			// Token: 0x04008153 RID: 33107
			AuctionDocument,
			// Token: 0x04008154 RID: 33108
			MailDocument,
			// Token: 0x04008155 RID: 33109
			XGameMallDocument,
			// Token: 0x04008156 RID: 33110
			PPTDocument,
			// Token: 0x04008157 RID: 33111
			MountComponent,
			// Token: 0x04008158 RID: 33112
			DesignationDocument,
			// Token: 0x04008159 RID: 33113
			DragonRewardDocument,
			// Token: 0x0400815A RID: 33114
			LevelSealDocument,
			// Token: 0x0400815B RID: 33115
			Bubble,
			// Token: 0x0400815C RID: 33116
			XTerritoryComponent,
			// Token: 0x0400815D RID: 33117
			QuickReplyDocument,
			// Token: 0x0400815E RID: 33118
			CaptainPVPDocument,
			// Token: 0x0400815F RID: 33119
			VoiceQADocument,
			// Token: 0x04008160 RID: 33120
			BattleCaptainPVPDocument,
			// Token: 0x04008161 RID: 33121
			XSkyArenaEntranceDocument,
			// Token: 0x04008162 RID: 33122
			XSkyArenaBattleDocument,
			// Token: 0x04008163 RID: 33123
			XBigMeleeEntranceDocument,
			// Token: 0x04008164 RID: 33124
			XBigMeleeBattleDocument,
			// Token: 0x04008165 RID: 33125
			XBattleFieldEntranceDocument,
			// Token: 0x04008166 RID: 33126
			XBattleFieldBattleDocument,
			// Token: 0x04008167 RID: 33127
			XRaceDocument,
			// Token: 0x04008168 RID: 33128
			XPersonalCareerDocument,
			// Token: 0x04008169 RID: 33129
			DragonNestDocument,
			// Token: 0x0400816A RID: 33130
			PushSubscribeDocument,
			// Token: 0x0400816B RID: 33131
			MulActivityDocument,
			// Token: 0x0400816C RID: 33132
			PVPActivityDocument,
			// Token: 0x0400816D RID: 33133
			TeamInviteDocument,
			// Token: 0x0400816E RID: 33134
			XBossBushDocument,
			// Token: 0x0400816F RID: 33135
			SpectateDocument,
			// Token: 0x04008170 RID: 33136
			SpectateSceneDocument,
			// Token: 0x04008171 RID: 33137
			SpectateLevelRewardDocument,
			// Token: 0x04008172 RID: 33138
			XApolloDocument,
			// Token: 0x04008173 RID: 33139
			GroupChatDocument,
			// Token: 0x04008174 RID: 33140
			XBigPrizeDocument,
			// Token: 0x04008175 RID: 33141
			XRadioDocument,
			// Token: 0x04008176 RID: 33142
			XLuaDocument,
			// Token: 0x04008177 RID: 33143
			XSevenLoginDocument,
			// Token: 0x04008178 RID: 33144
			FirstPassDocument,
			// Token: 0x04008179 RID: 33145
			XOperatingActivityDocument,
			// Token: 0x0400817A RID: 33146
			XThemeActivityDocument,
			// Token: 0x0400817B RID: 33147
			BiochemicalHellDogDocument,
			// Token: 0x0400817C RID: 33148
			MadDuckSiegeDocument,
			// Token: 0x0400817D RID: 33149
			RollDocument,
			// Token: 0x0400817E RID: 33150
			SpriteSystemDocument,
			// Token: 0x0400817F RID: 33151
			XCardCollectDocument,
			// Token: 0x04008180 RID: 33152
			XDragonCrusadeDocument,
			// Token: 0x04008181 RID: 33153
			XGuildMineBattleDocument,
			// Token: 0x04008182 RID: 33154
			XGuildMineMainDocument,
			// Token: 0x04008183 RID: 33155
			XGuildMineEntranceDocument,
			// Token: 0x04008184 RID: 33156
			XManipulation,
			// Token: 0x04008185 RID: 33157
			ReviveDocument,
			// Token: 0x04008186 RID: 33158
			IDIPDocument,
			// Token: 0x04008187 RID: 33159
			XSmeltDocument,
			// Token: 0x04008188 RID: 33160
			HomePlantDocument,
			// Token: 0x04008189 RID: 33161
			HomeMainDocument,
			// Token: 0x0400818A RID: 33162
			TaskDocument,
			// Token: 0x0400818B RID: 33163
			XCarnivalDocument,
			// Token: 0x0400818C RID: 33164
			TempActivityDocument,
			// Token: 0x0400818D RID: 33165
			HomeCookAndPartyDocument,
			// Token: 0x0400818E RID: 33166
			ActivityInviteDocument,
			// Token: 0x0400818F RID: 33167
			HomeFishingDocument,
			// Token: 0x04008190 RID: 33168
			CombatStatisticsDocument,
			// Token: 0x04008191 RID: 33169
			AuctionHouseDocument,
			// Token: 0x04008192 RID: 33170
			GuildResContentionBuffDocument,
			// Token: 0x04008193 RID: 33171
			XScreenShotShareDocument,
			// Token: 0x04008194 RID: 33172
			GuildDonateDocument,
			// Token: 0x04008195 RID: 33173
			GuildDailyTaskDocument,
			// Token: 0x04008196 RID: 33174
			BillboardDocument,
			// Token: 0x04008197 RID: 33175
			CharacterShowChatComponent,
			// Token: 0x04008198 RID: 33176
			MentorshipDocument,
			// Token: 0x04008199 RID: 33177
			EnchantDocument,
			// Token: 0x0400819A RID: 33178
			HeroBattleDocument,
			// Token: 0x0400819B RID: 33179
			HeroBattleSkillDocument,
			// Token: 0x0400819C RID: 33180
			XWeekNestDocument,
			// Token: 0x0400819D RID: 33181
			XCompeteDocument,
			// Token: 0x0400819E RID: 33182
			XPartnerDocument,
			// Token: 0x0400819F RID: 33183
			WeddingDocument,
			// Token: 0x040081A0 RID: 33184
			DragonPartnerDocument,
			// Token: 0x040081A1 RID: 33185
			NPCFavorDocument,
			// Token: 0x040081A2 RID: 33186
			DramaDocument,
			// Token: 0x040081A3 RID: 33187
			XJokerKingDocument,
			// Token: 0x040081A4 RID: 33188
			PandoraDocument,
			// Token: 0x040081A5 RID: 33189
			XForgeDocument,
			// Token: 0x040081A6 RID: 33190
			FreeTeamVersusLeagueDocument,
			// Token: 0x040081A7 RID: 33191
			TeamLeagueBattleDocument,
			// Token: 0x040081A8 RID: 33192
			NestDocument,
			// Token: 0x040081A9 RID: 33193
			ProfessionChangeDocument,
			// Token: 0x040081AA RID: 33194
			AnnouncementDocument,
			// Token: 0x040081AB RID: 33195
			HallFameDocument,
			// Token: 0x040081AC RID: 33196
			MilitaryRankDocument,
			// Token: 0x040081AD RID: 33197
			GuildCollectDocument,
			// Token: 0x040081AE RID: 33198
			ExchangeItemDocument,
			// Token: 0x040081AF RID: 33199
			RenameDocument,
			// Token: 0x040081B0 RID: 33200
			FashionStorageDocument,
			// Token: 0x040081B1 RID: 33201
			ArtifactDocument,
			// Token: 0x040081B2 RID: 33202
			ArtifactComposeDocument,
			// Token: 0x040081B3 RID: 33203
			ArtifactBagDocument,
			// Token: 0x040081B4 RID: 33204
			ArtifactAtlasDocument,
			// Token: 0x040081B5 RID: 33205
			RequestDocument,
			// Token: 0x040081B6 RID: 33206
			AbyssPartyDocument,
			// Token: 0x040081B7 RID: 33207
			CustomBattleDocument,
			// Token: 0x040081B8 RID: 33208
			MobaEntranceDocument,
			// Token: 0x040081B9 RID: 33209
			MobaBattleDocument,
			// Token: 0x040081BA RID: 33210
			TaJieHelpDocument,
			// Token: 0x040081BB RID: 33211
			ArtifactDeityStoveDocument,
			// Token: 0x040081BC RID: 33212
			ArtifactRecastDocument,
			// Token: 0x040081BD RID: 33213
			ArtifactFuseDocument,
			// Token: 0x040081BE RID: 33214
			ArtifactInscriptionDocument,
			// Token: 0x040081BF RID: 33215
			WeekEndNestDocument,
			// Token: 0x040081C0 RID: 33216
			XGuildWeeklyBountyDocument,
			// Token: 0x040081C1 RID: 33217
			EquipUpgradeDocument,
			// Token: 0x040081C2 RID: 33218
			EquipFusionDocument,
			// Token: 0x040081C3 RID: 33219
			PrerogativeDocument,
			// Token: 0x040081C4 RID: 33220
			TargetRewardDocument,
			// Token: 0x040081C5 RID: 33221
			XDragonGuildDocument,
			// Token: 0x040081C6 RID: 33222
			XDragonGuildListDocument,
			// Token: 0x040081C7 RID: 33223
			XDragonGuildTaskDocument,
			// Token: 0x040081C8 RID: 33224
			XDragonGuildApproveDocument,
			// Token: 0x040081C9 RID: 33225
			XTransformDocument,
			// Token: 0x040081CA RID: 33226
			XBackFlowDocument,
			// Token: 0x040081CB RID: 33227
			XYorozuyaDocument,
			// Token: 0x040081CC RID: 33228
			MysterioursDocument,
			// Token: 0x040081CD RID: 33229
			XCampDuelDocument,
			// Token: 0x040081CE RID: 33230
			ArtifactRefinedDocument,
			// Token: 0x040081CF RID: 33231
			XArtifactCreateDocument,
			// Token: 0x040081D0 RID: 33232
			CrossGVGDocument,
			// Token: 0x040081D1 RID: 33233
			XGuildGrowthDocument,
			// Token: 0x040081D2 RID: 33234
			MAX
		}
	}
}
