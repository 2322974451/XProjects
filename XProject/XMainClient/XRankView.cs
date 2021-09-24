using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XMainClient.Utility;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XRankView : DlgBase<XRankView, XRankBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/RankDlg";
			}
		}

		public override int layer
		{
			get
			{
				return 1;
			}
		}

		public override int group
		{
			get
			{
				return 1;
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		public XRankView()
		{
			this.RankUIType.Clear();
			this.RankUIType.Add(XRankType.PPTRank, 0U);
			this.RankUIType.Add(XRankType.LevelRank, 0U);
			this.RankUIType.Add(XRankType.GuildRank, 1U);
			this.RankUIType.Add(XRankType.DragonGuildRank, 7U);
			this.RankUIType.Add(XRankType.FashionRank, 0U);
			this.RankUIType.Add(XRankType.TeamTowerRank, 2U);
			this.RankUIType.Add(XRankType.GuildBossRank, 3U);
			this.RankUIType.Add(XRankType.WorldBossDamageRank, 9U);
			this.RankUIType.Add(XRankType.PetRank, 4U);
			this.RankUIType.Add(XRankType.SpriteRank, 0U);
			this.RankUIType.Add(XRankType.QualifyingRank, 5U);
			this.RankUIType.Add(XRankType.BigMeleeRank, 6U);
			this.RankUIType.Add(XRankType.SkyArenaRank, 8U);
			this.RankUIType.Add(XRankType.CampDuelRankLeft, 10U);
			this.RankUIType.Add(XRankType.CampDuelRankRight, 10U);
			this.RankUIType.Add(XRankType.RiftRank, 11U);
			this.RankItemHandlers.Clear();
			this.RankItemHandlers.Add(XRankType.PPTRank, new XRankView.SetRankItemHandler(this._SetBaseRankItem));
			this.RankItemHandlers.Add(XRankType.LevelRank, new XRankView.SetRankItemHandler(this._SetBaseRankItem));
			this.RankItemHandlers.Add(XRankType.GuildRank, new XRankView.SetRankItemHandler(this._SetGuildRankItem));
			this.RankItemHandlers.Add(XRankType.DragonGuildRank, new XRankView.SetRankItemHandler(this._SetDragonGuildRankItem));
			this.RankItemHandlers.Add(XRankType.FashionRank, new XRankView.SetRankItemHandler(this._SetBaseRankItem));
			this.RankItemHandlers.Add(XRankType.TeamTowerRank, new XRankView.SetRankItemHandler(this._SetTowerRankItem));
			this.RankItemHandlers.Add(XRankType.GuildBossRank, new XRankView.SetRankItemHandler(this._SetGuildBossRankItem));
			this.RankItemHandlers.Add(XRankType.WorldBossDamageRank, new XRankView.SetRankItemHandler(this._SetWorldBossRankItem));
			this.RankItemHandlers.Add(XRankType.PetRank, new XRankView.SetRankItemHandler(this._SetPetRankItem));
			this.RankItemHandlers.Add(XRankType.SpriteRank, new XRankView.SetRankItemHandler(this._SetBaseRankItem));
			this.RankItemHandlers.Add(XRankType.QualifyingRank, new XRankView.SetRankItemHandler(this._SetQualifyingRankItem));
			this.RankItemHandlers.Add(XRankType.LastWeek_PKRank, new XRankView.SetRankItemHandler(this._SetQualifyingRankItem));
			this.RankItemHandlers.Add(XRankType.BigMeleeRank, new XRankView.SetRankItemHandler(this._SetBigMeleeRankItem));
			this.RankItemHandlers.Add(XRankType.SkyArenaRank, new XRankView.SetRankItemHandler(this._SetSkyArenaRankItem));
			this.RankItemHandlers.Add(XRankType.CampDuelRankLeft, new XRankView.SetRankItemHandler(this._SetCampDuelRankLeftItem));
			this.RankItemHandlers.Add(XRankType.CampDuelRankRight, new XRankView.SetRankItemHandler(this._SetCampDuelRankRightItem));
			this.RankItemHandlers.Add(XRankType.RiftRank, new XRankView.SetRankItemHandler(this._SetRiftRankItem));
		}

		protected override void Init()
		{
			XSingleton<XGameSysMgr>.singleton.RegisterSubSysRedPointMgr(XSysDefine.XSys_Rank, this.redpointMgr);
			this._doc = XDocuments.GetSpecificDocument<XRankDocument>(XRankDocument.uuID);
			this._doc.View = this;
			this.m_PreUIType = 9999999U;
			for (int i = 0; i < this.m_RankTypeList.Length; i++)
			{
				uint num;
				XRankView.SetRankItemHandler setHandler;
				bool flag = !this._GetUIAndHandler(this.m_RankTypeList[i], out num, out setHandler);
				if (!flag)
				{
					this._SetMyRankFrame(base.uiBehaviour.m_MyRankFrame[(int)num], null, 0U, setHandler);
				}
			}
			DlgHandlerBase.EnsureCreate<XFlowerRankHandler>(ref this._FlowerRankHandler, base.uiBehaviour.m_FlowerRankRoot, false, this);
		}

		public override void RegisterEvent()
		{
			base.uiBehaviour.m_close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			base.uiBehaviour.m_PopularSprite.RegisterSpritePressEventHandler(new SpritePressEventHandler(this.OnPopularTipsShow));
			for (int i = 0; i < base.uiBehaviour.m_ListPanel.Length; i++)
			{
				base.uiBehaviour.m_ListPanel[i].RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this._OnWrapContentItemUpdated));
			}
			base.uiBehaviour.m_CharacterDummyFrame.RegisterSpriteDragEventHandler(new SpriteDragEventHandler(this._OnCharacterDrag));
			base.uiBehaviour.m_PetDummyFrame.RegisterSpriteDragEventHandler(new SpriteDragEventHandler(this._OnPetDrag));
			base.uiBehaviour.m_DragonGuildHelp.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnDragonGuildHelpBtnClick));
		}

		private bool _OnDragonGuildHelpBtnClick(IXUIButton button)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_Rank_DragonGuild);
			return true;
		}

		private bool _OnCharacterDrag(Vector2 delta)
		{
			bool flag = this._PlayerDummy != null && !this._PlayerDummy.Deprecated;
			if (flag)
			{
				XSingleton<X3DAvatarMgr>.singleton.RotateDummy(this._PlayerDummy, -delta.x / 2f);
			}
			return true;
		}

		private bool _OnPetDrag(Vector2 delta)
		{
			bool flag = this._PetDummy != null && !this._PetDummy.Deprecated;
			if (flag)
			{
				XSingleton<X3DAvatarMgr>.singleton.RotateDummy(this._PetDummy, -delta.x / 2f);
			}
			return true;
		}

		private bool OnPopularTipsShow(IXUISprite sprite, bool isPressed)
		{
			if (isPressed)
			{
				bool flag = !base.uiBehaviour.m_PopularLabel.IsVisible();
				if (flag)
				{
					base.uiBehaviour.m_PopularLabel.SetVisible(true);
				}
				base.uiBehaviour.m_PopularLabel.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("GUILD_RANK_TIPS")));
			}
			else
			{
				bool flag2 = base.uiBehaviour.m_PopularLabel.IsVisible();
				if (flag2)
				{
					base.uiBehaviour.m_PopularLabel.SetVisible(false);
				}
			}
			return false;
		}

		protected override void OnShow()
		{
			base.OnShow();
			base.Alloc3DAvatarPool("XRankView");
		}

		protected override void OnHide()
		{
			base.OnHide();
			bool flag = this.m_uiBehaviour.m_PlayerSnapshot != null;
			if (flag)
			{
				this.m_uiBehaviour.m_PlayerSnapshot.RefreshRenderQueue = null;
			}
			bool flag2 = this.m_uiBehaviour.m_PetSnapshot != null;
			if (flag2)
			{
				this.m_uiBehaviour.m_PetSnapshot.RefreshRenderQueue = null;
			}
			bool flag3 = this.m_uiBehaviour.m_SpriteSnapshot != null;
			if (flag3)
			{
				this.m_uiBehaviour.m_SpriteSnapshot.RefreshRenderQueue = null;
			}
			bool flag4 = this._FlowerRankHandler != null;
			if (flag4)
			{
				this._FlowerRankHandler.ClearPreTabTextures();
			}
			base.Return3DAvatarPool();
			this._PlayerDummy = null;
			this._PetDummy = null;
			this._SpriteDummy = null;
			this.redpointMgr.SetupRedPoints(null);
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
			base.Alloc3DAvatarPool("XRankView");
			XSingleton<X3DAvatarMgr>.singleton.EnableCommonDummy(this._PlayerDummy, this.m_uiBehaviour.m_PlayerSnapshot, true);
			XSingleton<X3DAvatarMgr>.singleton.EnableCommonDummy(this._PetDummy, this.m_uiBehaviour.m_PetSnapshot, true);
			XSingleton<X3DAvatarMgr>.singleton.EnableCommonDummy(this._SpriteDummy, this.m_uiBehaviour.m_SpriteSnapshot, true);
		}

		protected override void OnUnload()
		{
			bool flag = this.m_uiBehaviour.m_PlayerSnapshot != null;
			if (flag)
			{
				this.m_uiBehaviour.m_PlayerSnapshot.RefreshRenderQueue = null;
			}
			bool flag2 = this.m_uiBehaviour.m_PetSnapshot != null;
			if (flag2)
			{
				this.m_uiBehaviour.m_PetSnapshot.RefreshRenderQueue = null;
			}
			bool flag3 = this.m_uiBehaviour.m_SpriteSnapshot != null;
			if (flag3)
			{
				this.m_uiBehaviour.m_SpriteSnapshot.RefreshRenderQueue = null;
			}
			base.Return3DAvatarPool();
			this._PlayerDummy = null;
			this._PetDummy = null;
			this._SpriteDummy = null;
			base.OnUnload();
			this._doc.View = null;
			DlgHandlerBase.EnsureUnload<XFlowerRankHandler>(ref this._FlowerRankHandler);
			DlgHandlerBase.EnsureUnload<XCampDuelRankRewardHandler>(ref this._RankRewardHandler);
		}

		public bool OnCloseClicked(IXUIButton sp)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private bool _GetUIAndHandler(XRankType rankType, out uint uiType, out XRankView.SetRankItemHandler handler)
		{
			uiType = 0U;
			handler = null;
			bool flag = !this.RankUIType.TryGetValue(rankType, out uiType);
			bool result;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("There's no type called ", rankType.ToString(), null, null, null, null);
				result = false;
			}
			else
			{
				bool flag2 = !this.RankItemHandlers.TryGetValue(rankType, out handler);
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("There's no handler for type ", rankType.ToString(), null, null, null, null);
					result = false;
				}
				else
				{
					result = true;
				}
			}
			return result;
		}

		public void ShowRank(XSysDefine sys)
		{
			bool flag = !base.IsVisible();
			if (flag)
			{
				this.SetVisibleWithAnimation(true, null);
			}
			XSubSysRedPointMgr xsubSysRedPointMgr = this.redpointMgr;
			IXUIObject[] btns = base.uiBehaviour.m_tabcontrol.SetupTabs(sys, new XUITabControl.UITabControlCallback(this.OnTabSelectionChanged), false, 1f);
			xsubSysRedPointMgr.SetupRedPoints(btns);
		}

		public void ShowFlowerRank(XSysDefine sys)
		{
			bool flag = !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_FlowerRank);
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("SYSTEM_NOT_OPEN"), "fece00");
			}
			else
			{
				bool flag2 = !base.IsVisible();
				if (flag2)
				{
					this.SetVisibleWithAnimation(true, null);
				}
				XSubSysRedPointMgr xsubSysRedPointMgr = this.redpointMgr;
				IXUIObject[] btns = base.uiBehaviour.m_tabcontrol.SetupTabs(XSysDefine.XSys_FlowerRank, new XUITabControl.UITabControlCallback(this.OnTabSelectionChanged), false, 1f);
				xsubSysRedPointMgr.SetupRedPoints(btns);
				base.uiBehaviour.m_OriginalRank.SetActive(false);
				this._FlowerRankHandler.DefaultTab = sys;
				bool flag3 = !this._FlowerRankHandler.IsVisible();
				if (flag3)
				{
					this._FlowerRankHandler.SetVisible(true);
				}
				else
				{
					this._FlowerRankHandler.ShowRank();
				}
			}
		}

		public void OnTabSelectionChanged(ulong id)
		{
			XSingleton<X3DAvatarMgr>.singleton.ClearDummy(this.m_dummPool);
			this._PlayerDummy = null;
			this._PetDummy = null;
			this._SpriteDummy = null;
			XSysDefine xsysDefine = (XSysDefine)id;
			base.uiBehaviour.m_OriginalRank.SetActive(xsysDefine != XSysDefine.XSys_FlowerRank);
			this._FlowerRankHandler.SetVisible(xsysDefine == XSysDefine.XSys_FlowerRank);
			bool flag = this.emptyUA == null;
			if (flag)
			{
				this.emptyUA = new UnitAppearance();
			}
			XSysDefine xsysDefine2 = xsysDefine;
			if (xsysDefine2 != XSysDefine.XSys_FlowerRank)
			{
				XRankType type;
				switch (xsysDefine2)
				{
				case XSysDefine.XSys_Rank_Rift:
					this._FillCharacterInfoFrame(this.emptyUA);
					this._doc.ReqMysteriourRanklist();
					return;
				case XSysDefine.XSys_Rank_WorldBoss:
					type = XRankType.WorldBossDamageRank;
					this._FillCharacterInfoFrame(this.emptyUA);
					goto IL_24F;
				case XSysDefine.XSys_Rank_PPT:
					type = XRankType.PPTRank;
					this._FillCharacterInfoFrame(this.emptyUA);
					goto IL_24F;
				case XSysDefine.XSys_Rank_Level:
					type = XRankType.LevelRank;
					this._FillCharacterInfoFrame(this.emptyUA);
					goto IL_24F;
				case XSysDefine.XSys_Rank_Guild:
					this._doc.ReqGuildRankList();
					return;
				case XSysDefine.XSys_Rank_Fashion:
					type = XRankType.FashionRank;
					this._FillCharacterInfoFrame(this.emptyUA);
					goto IL_24F;
				case XSysDefine.XSys_Rank_TeamTower:
					type = XRankType.TeamTowerRank;
					goto IL_24F;
				case XSysDefine.XSys_Rank_GuildBoss:
					this._doc.ReqGuildBossRankList();
					return;
				case XSysDefine.XSys_Rank_Pet:
					type = XRankType.PetRank;
					this._FillPetInfoFrame(0U);
					goto IL_24F;
				case XSysDefine.XSys_Rank_Sprite:
					type = XRankType.SpriteRank;
					this._FillCharacterInfoFrame(this.emptyUA);
					goto IL_24F;
				case XSysDefine.XSys_Rank_Qualifying:
					this._FillCharacterInfoFrame(this.emptyUA);
					this._doc.ReqQualifyingRankList();
					return;
				case XSysDefine.XSys_Rank_BigMelee:
					XBigMeleeEntranceDocument.Doc.ReqRankData(0);
					return;
				case XSysDefine.XSys_Rank_DragonGuild:
					this._doc.ReqDragonGuildRankList();
					return;
				case XSysDefine.XSys_Rank_SkyArena:
					type = XRankType.SkyArenaRank;
					this._FillCharacterInfoFrame(this.emptyUA);
					goto IL_24F;
				case XSysDefine.XSys_Rank_CampDuel:
					this._doc.ReqRankList(XRankType.CampDuelRankLeft);
					this._doc.ReqRankList(XRankType.CampDuelRankRight);
					return;
				}
				XSingleton<XDebug>.singleton.AddErrorLog("Invalid system id: ", xsysDefine.ToString(), null, null, null, null);
				return;
				IL_24F:
				this._doc.ReqRankList(type);
			}
		}

		private void _SetFramesActive(uint uiType)
		{
			bool flag = !base.uiBehaviour.m_OriginalRank.activeSelf;
			if (!flag)
			{
				for (uint num = 0U; num < XRankBehaviour.RANK_UI_TYPE_COUNT; num += 1U)
				{
					this.m_uiBehaviour.m_ListPanel[(int)num].gameObject.SetActive(num == uiType);
					this.m_uiBehaviour.m_MyRankFrame[(int)num].SetActive(num == uiType);
					this.m_uiBehaviour.m_TitleFrame[(int)num].SetActive(num == uiType);
				}
			}
		}

		public void RefreshContent()
		{
			bool flag = !base.uiBehaviour.m_OriginalRank.activeSelf;
			if (!flag)
			{
				XRankType currentSelectRankList = this._doc.currentSelectRankList;
				uint num;
				XRankView.SetRankItemHandler setRankItemHandler;
				bool flag2 = !this._GetUIAndHandler(currentSelectRankList, out num, out setRankItemHandler);
				if (!flag2)
				{
					IXUIWrapContent ixuiwrapContent = base.uiBehaviour.m_ListPanel[(int)num];
					ixuiwrapContent.RefreshAllVisibleContents();
				}
			}
		}

		public void RefreshRankWindow()
		{
			bool flag = !base.uiBehaviour.m_OriginalRank.activeSelf;
			if (!flag)
			{
				XRankType currentSelectRankList = this._doc.currentSelectRankList;
				uint num;
				XRankView.SetRankItemHandler setHandler;
				bool flag2 = !this._GetUIAndHandler(currentSelectRankList, out num, out setHandler);
				if (!flag2)
				{
					GameObject gameObject = this.m_uiBehaviour.m_ListPanel[(int)num].gameObject;
					GameObject go = this.m_uiBehaviour.m_MyRankFrame[(int)num];
					IXUIWrapContent ixuiwrapContent = base.uiBehaviour.m_ListPanel[(int)num];
					XBaseRankList rankList = this._doc.GetRankList(currentSelectRankList);
					bool flag3 = rankList == null;
					if (flag3)
					{
						XSingleton<XDebug>.singleton.AddErrorLog("Fail to get rank list whose type is ", currentSelectRankList.ToString(), null, null, null, null);
					}
					else
					{
						this._SetFramesActive(num);
						bool flag4 = this.m_PreUIType != num;
						if (flag4)
						{
							ixuiwrapContent.InitContent();
							this.m_PreUIType = num;
						}
						int num2 = rankList.rankList.Count;
						bool flag5 = currentSelectRankList == XRankType.CampDuelRankLeft || currentSelectRankList == XRankType.CampDuelRankRight;
						if (flag5)
						{
							num2 = Math.Max(num2, this._doc.GetRankList(XRankType.CampDuelRankLeft).rankList.Count);
							num2 = Math.Max(num2, this._doc.GetRankList(XRankType.CampDuelRankRight).rankList.Count);
						}
						ixuiwrapContent.SetContentCount(num2, true);
						this._SetMyRankFrame(go, rankList.GetLatestMyRankInfo(), rankList.upperBound, setHandler);
						this._SetTitle(base.uiBehaviour.m_TitleFrame[(int)num]);
						this.m_uiBehaviour.m_PetInfoFrame.SetActive(currentSelectRankList == XRankType.PetRank);
						XRankType xrankType = currentSelectRankList;
						if (xrankType <= XRankType.FashionRank)
						{
							if (xrankType > XRankType.LevelRank)
							{
								switch (xrankType)
								{
								case XRankType.WorldBossDamageRank:
									this.m_uiBehaviour.m_CharacterInfoFrame.SetActive(true);
									this.m_uiBehaviour.m_EmptyRankLabelGroup.SetGroup(1);
									this.m_uiBehaviour.m_EmptyRankLabel.SetText(XStringDefineProxy.GetString("BIG_BOSS_EMPTY_RANK"));
									this.m_uiBehaviour.m_EmptyRankLabel.gameObject.SetActive(rankList.rankList.Count == 0);
									goto IL_474;
								case XRankType.GuildBossRank:
								{
									this.m_uiBehaviour.m_CharacterInfoFrame.SetActive(false);
									bool flag6 = rankList.rankList.Count == 0;
									if (flag6)
									{
										this.m_uiBehaviour.m_EmptyRankLabel.SetText(XStringDefineProxy.GetString("GUILD_BOSS_EMPTY_RANK_BOSS"));
										this.m_uiBehaviour.m_EmptyRankLabelGroup.SetGroup(0);
										this.m_uiBehaviour.m_EmptyRankLabel.gameObject.SetActive(true);
									}
									else
									{
										this.m_uiBehaviour.m_EmptyRankLabel.gameObject.SetActive(false);
									}
									goto IL_474;
								}
								case XRankType.GuildBossRoleRank:
									goto IL_449;
								case XRankType.FashionRank:
									break;
								default:
									goto IL_449;
								}
							}
						}
						else
						{
							switch (xrankType)
							{
							case XRankType.PetRank:
								this.m_uiBehaviour.m_PetInfoFrame.SetActive(true);
								this.m_uiBehaviour.m_CharacterInfoFrame.SetActive(false);
								this.m_uiBehaviour.m_EmptyRankLabel.gameObject.SetActive(false);
								goto IL_474;
							case XRankType.BigMeleeRank:
							{
								this.m_uiBehaviour.m_CharacterInfoFrame.SetActive(false);
								bool flag7 = rankList.rankList.Count == 0;
								if (flag7)
								{
									this.m_uiBehaviour.m_EmptyRankLabel.SetText(XStringDefineProxy.GetString("BIG_BOSS_EMPTY_RANK"));
									this.m_uiBehaviour.m_EmptyRankLabelGroup.SetGroup(0);
									this.m_uiBehaviour.m_EmptyRankLabel.gameObject.SetActive(true);
								}
								else
								{
									this.m_uiBehaviour.m_EmptyRankLabel.gameObject.SetActive(false);
								}
								goto IL_474;
							}
							case XRankType.SkyArenaRank:
								this.m_uiBehaviour.m_CharacterInfoFrame.SetActive(true);
								this.m_uiBehaviour.m_EmptyRankLabel.SetText(XStringDefineProxy.GetString("BIG_BOSS_EMPTY_RANK"));
								this.m_uiBehaviour.m_EmptyRankLabelGroup.SetGroup(1);
								this.m_uiBehaviour.m_EmptyRankLabel.gameObject.SetActive(true);
								goto IL_474;
							case XRankType.ChickenDinnerRank:
							case XRankType.CampDuelRankLeft:
							case XRankType.CampDuelRankRight:
							case XRankType.LeagueTeamRank:
								goto IL_449;
							case XRankType.SpriteRank:
							case XRankType.QualifyingRank:
							case XRankType.LastWeek_PKRank:
								break;
							default:
								if (xrankType != XRankType.RiftRank)
								{
									goto IL_449;
								}
								break;
							}
						}
						this.m_uiBehaviour.m_CharacterInfoFrame.SetActive(true);
						this.m_uiBehaviour.m_EmptyRankLabel.gameObject.SetActive(false);
						goto IL_474;
						IL_449:
						this.m_uiBehaviour.m_CharacterInfoFrame.SetActive(false);
						this.m_uiBehaviour.m_EmptyRankLabel.gameObject.SetActive(false);
						IL_474:
						XRankType xrankType2 = currentSelectRankList;
						if (xrankType2 - XRankType.CampDuelRankLeft > 1)
						{
							Vector3 group = base.uiBehaviour.m_ListPositionGroup.GetGroup(0);
							base.uiBehaviour.m_ListIXUIPanel.SetCenter(group.x, group.y);
							group = base.uiBehaviour.m_ListPositionGroup.GetGroup(1);
							base.uiBehaviour.m_ListIXUIPanel.SetSize(group.x, group.y);
						}
						else
						{
							Vector3 group = base.uiBehaviour.m_ListPositionGroup.GetGroup(2);
							base.uiBehaviour.m_ListIXUIPanel.SetCenter(group.x, group.y);
							group = base.uiBehaviour.m_ListPositionGroup.GetGroup(3);
							base.uiBehaviour.m_ListIXUIPanel.SetSize(group.x, group.y);
						}
						base.uiBehaviour.m_ListScrollView.ResetPosition();
						bool flag8 = rankList.rankList.Count > 0;
						if (flag8)
						{
							this._doc.SelectItem(0U);
						}
					}
				}
			}
		}

		private void _OnWrapContentItemUpdated(Transform t, int index)
		{
			bool flag = !base.uiBehaviour.m_OriginalRank.activeSelf;
			if (!flag)
			{
				XRankType currentSelectRankList = this._doc.currentSelectRankList;
				XBaseRankList rankList = this._doc.GetRankList(currentSelectRankList);
				bool flag2 = rankList == null;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("Fail to get rank list whose type is ", currentSelectRankList.ToString(), null, null, null, null);
				}
				else
				{
					bool flag3 = index >= rankList.rankList.Count;
					if (flag3)
					{
						bool flag4 = this._doc.currentSelectRankList != XRankType.CampDuelRankLeft && this._doc.currentSelectRankList != XRankType.CampDuelRankRight;
						if (flag4)
						{
							XSingleton<XDebug>.singleton.AddErrorLog("index >= rankDataList.rankList.Count: idx ", index.ToString(), " count ", rankList.rankList.Count.ToString(), null, null);
						}
					}
					else
					{
						XRankView.SetRankItemHandler setRankItemHandler;
						bool flag5 = !this.RankItemHandlers.TryGetValue(currentSelectRankList, out setRankItemHandler);
						if (flag5)
						{
							XSingleton<XDebug>.singleton.AddErrorLog("There's no handler for type ", currentSelectRankList.ToString(), null, null, null, null);
						}
						else
						{
							bool flag6 = currentSelectRankList == XRankType.CampDuelRankLeft;
							if (flag6)
							{
								t = t.Find("Left");
							}
							else
							{
								bool flag7 = currentSelectRankList == XRankType.CampDuelRankRight;
								if (flag7)
								{
									t = t.Find("Right");
								}
							}
							IXUISprite ixuisprite = t.GetComponent("XUISprite") as IXUISprite;
							IXUILabelSymbol ixuilabelSymbol = t.Find("Name").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
							bool flag8 = ixuilabelSymbol != null;
							if (flag8)
							{
								ixuilabelSymbol.ID = (ulong)((long)index);
							}
							IXUILabel ixuilabel = t.Find("Name").GetComponent("XUILabel") as IXUILabel;
							bool flag9 = ixuilabel != null;
							if (flag9)
							{
								ixuilabel.ID = (ulong)((long)index);
							}
							bool flag10 = ixuisprite != null;
							if (flag10)
							{
								ixuisprite.ID = (ulong)((long)index);
								ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnRankItemClickedSp));
							}
							setRankItemHandler(t.gameObject, rankList.rankList[index], index);
							this._ToggleSelection(t.gameObject, (ulong)this._doc.currentSelectIndex == (ulong)((long)index));
						}
					}
				}
			}
		}

		private void _FillCharacterInfoFrame(UnitAppearance data)
		{
			bool flag = !base.uiBehaviour.m_OriginalRank.activeSelf;
			if (!flag)
			{
				this.m_uiBehaviour.m_CharName.SetText(data.unitName);
				this.m_uiBehaviour.m_CharProfession.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfIcon((int)data.unitType));
				bool flag2 = data.uID > 0UL;
				if (flag2)
				{
					this._PlayerDummy = XSingleton<X3DAvatarMgr>.singleton.CreateCommonRoleDummy(this.m_dummPool, data, this.m_uiBehaviour.m_PlayerSnapshot, this._PlayerDummy);
					bool flag3 = data.sprites.Count > 0;
					if (flag3)
					{
						XSpriteSystemDocument specificDocument = XDocuments.GetSpecificDocument<XSpriteSystemDocument>(XSpriteSystemDocument.uuID);
						SpriteTable.RowData bySpriteID = specificDocument._SpriteTable.GetBySpriteID(data.sprites[0].SpriteID);
						bool flag4 = bySpriteID != null;
						if (flag4)
						{
							this._SpriteDummy = XSingleton<X3DAvatarMgr>.singleton.CreateCommonEntityDummy(this.m_dummPool, bySpriteID.SpriteModelID, this.m_uiBehaviour.m_SpriteSnapshot, this._SpriteDummy, 1f);
						}
						else
						{
							bool flag5 = this._SpriteDummy != null;
							if (flag5)
							{
								XSingleton<X3DAvatarMgr>.singleton.DestroyDummy(this.m_dummPool, this._SpriteDummy);
								this._SpriteDummy = null;
							}
						}
					}
					else
					{
						bool flag6 = this._SpriteDummy != null;
						if (flag6)
						{
							XSingleton<X3DAvatarMgr>.singleton.DestroyDummy(this.m_dummPool, this._SpriteDummy);
							this._SpriteDummy = null;
						}
					}
				}
			}
		}

		private void _FillPetInfoFrame(uint petID)
		{
			bool flag = !base.uiBehaviour.m_OriginalRank.activeSelf;
			if (!flag)
			{
				uint presentID = XPetDocument.GetPresentID(petID);
				bool flag2 = presentID > 0U;
				if (flag2)
				{
					this._PetDummy = XSingleton<X3DAvatarMgr>.singleton.CreateCommonEntityDummy(this.m_dummPool, presentID, this.m_uiBehaviour.m_PetSnapshot, this._PetDummy, 1f);
					DlgBase<XPetMainView, XPetMainBehaviour>.singleton.PetActionChange(XPetActionFile.IDLE, petID, this._PetDummy, false);
				}
				else
				{
					XSingleton<X3DAvatarMgr>.singleton.DestroyDummy(this.m_dummPool, this._PetDummy);
					this._PetDummy = null;
				}
			}
		}

		public void UpdateGuildInfo(XBaseRankInfo info)
		{
			bool flag = !base.uiBehaviour.m_OriginalRank.activeSelf;
			if (!flag)
			{
				base.uiBehaviour.m_GuildName.SetText(info.guildname);
				bool flag2 = info.guildname == "" || info.guildname == null;
				if (flag2)
				{
					base.uiBehaviour.m_GuildIcon.SetSprite("");
				}
				else
				{
					base.uiBehaviour.m_GuildIcon.SetSprite(XGuildDocument.GetPortraitName((int)info.guildicon));
				}
			}
		}

		public void UpdatePetInfo(uint petID)
		{
			this._FillPetInfoFrame(petID);
		}

		public void UpdateCharacterInfo(GetUnitAppearanceRes oRes)
		{
			this._FillCharacterInfoFrame(oRes.UnitAppearance);
		}

		private void _ToggleSelection(GameObject go, bool bSelect)
		{
			Transform transform = go.transform.Find("Select");
			bool flag = transform == null;
			if (!flag)
			{
				GameObject gameObject = transform.gameObject;
				gameObject.SetActive(bSelect);
			}
		}

		private void _SetBaseRankItem(GameObject go, XBaseRankInfo info, int index)
		{
			IXUILabelSymbol ixuilabelSymbol = go.transform.FindChild("Name").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
			IXUILabel ixuilabel = go.transform.FindChild("Value").GetComponent("XUILabel") as IXUILabel;
			GameObject gameObject = go.transform.FindChild("QQ").gameObject;
			GameObject gameObject2 = go.transform.FindChild("Wechat").gameObject;
			bool flag = XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Platform_StartPrivilege);
			bool flag2 = !flag;
			if (flag2)
			{
				gameObject.SetActive(false);
				gameObject2.SetActive(false);
			}
			bool flag3 = info == null;
			if (flag3)
			{
				ixuilabelSymbol.InputText = string.Empty;
				ixuilabel.SetText(string.Empty);
				this._SetRank(go, XRankDocument.INVALID_RANK);
				bool flag4 = flag;
				if (flag4)
				{
					gameObject.SetActive(XSingleton<XLoginDocument>.singleton.GetLaunchTypeServerInfo() == StartUpType.StartUp_QQ && XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_QQ);
					gameObject2.SetActive(XSingleton<XLoginDocument>.singleton.GetLaunchTypeServerInfo() == StartUpType.StartUp_WX && XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_WeChat);
				}
				XSingleton<XDebug>.singleton.AddLog("[_SetBaseRankItem] info == null", null, null, null, null, null, XDebugColor.XDebug_None);
			}
			else
			{
				ixuilabelSymbol.InputText = info.formatname;
				ixuilabel.SetText(info.value.ToString());
				this._SetRank(go, info.rank);
				ixuilabelSymbol.RegisterSymbolClickHandler(new LabelSymbolClickEventHandler(this._OnRankItemClicked));
				bool flag5 = flag;
				if (flag5)
				{
					bool flag6 = info.rank == XRankDocument.INVALID_RANK;
					if (flag6)
					{
						gameObject.SetActive(XSingleton<XLoginDocument>.singleton.GetLaunchTypeServerInfo() == StartUpType.StartUp_QQ && XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_QQ);
						gameObject2.SetActive(XSingleton<XLoginDocument>.singleton.GetLaunchTypeServerInfo() == StartUpType.StartUp_WX && XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_WeChat);
					}
					else
					{
						gameObject.SetActive(info.startType == StartUpType.StartUp_QQ);
						gameObject2.SetActive(info.startType == StartUpType.StartUp_WX);
					}
				}
			}
		}

		private void _SetWorldBossRankItem(GameObject go, XBaseRankInfo info, int index)
		{
			IXUILabel ixuilabel = go.transform.FindChild("Name").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel2 = go.transform.FindChild("Profession").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel3 = go.transform.FindChild("Damage").GetComponent("XUILabel") as IXUILabel;
			bool flag = info == null || info.rank == XRankDocument.INVALID_RANK;
			if (flag)
			{
				ixuilabel.SetText(string.Empty);
				ixuilabel2.SetText(string.Empty);
				ixuilabel3.SetText(string.Empty);
				this._SetRank(go, XRankDocument.INVALID_RANK);
				ixuilabel.RegisterLabelClickEventHandler(null);
			}
			else
			{
				XWorldBossDamageRankInfo xworldBossDamageRankInfo = info as XWorldBossDamageRankInfo;
				bool flag2 = xworldBossDamageRankInfo != null;
				if (flag2)
				{
					ixuilabel.SetText(xworldBossDamageRankInfo.formatname);
					ixuilabel2.SetText(XSingleton<XProfessionSkillMgr>.singleton.GetProfName((int)xworldBossDamageRankInfo.profession));
					ixuilabel3.SetText(XSingleton<UiUtility>.singleton.NumberFormatBillion((ulong)xworldBossDamageRankInfo.damage));
				}
				this._SetRank(go, info.rank);
				ixuilabel.RegisterLabelClickEventHandler(new LabelClickEventHandler(this._OnRankItemClicked));
			}
		}

		private void _SetPetRankItem(GameObject go, XBaseRankInfo info, int index)
		{
			IXUILabel ixuilabel = go.transform.FindChild("Name").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel2 = go.transform.FindChild("PetName").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel3 = go.transform.FindChild("PetPPT").GetComponent("XUILabel") as IXUILabel;
			bool flag = info == null || info.rank == XRankDocument.INVALID_RANK;
			if (flag)
			{
				ixuilabel.SetText(string.Empty);
				ixuilabel2.SetText(string.Empty);
				ixuilabel3.SetText(string.Empty);
				this._SetRank(go, XRankDocument.INVALID_RANK);
				ixuilabel.RegisterLabelClickEventHandler(null);
			}
			else
			{
				XPetRankInfo xpetRankInfo = info as XPetRankInfo;
				ixuilabel.SetText(xpetRankInfo.formatname);
				PetInfoTable.RowData petInfo = XPetDocument.GetPetInfo(xpetRankInfo.petID);
				bool flag2 = petInfo != null;
				if (flag2)
				{
					ixuilabel2.SetText(XBaseRankInfo.GetUnderLineName(petInfo.name));
				}
				else
				{
					XSingleton<XDebug>.singleton.AddErrorLog("PetID " + xpetRankInfo.petID + " No Find", null, null, null, null, null);
				}
				ixuilabel3.SetText(xpetRankInfo.value.ToString());
				this._SetRank(go, info.rank);
				ixuilabel.RegisterLabelClickEventHandler(new LabelClickEventHandler(this._OnRankItemClicked));
				ixuilabel2.ID = (ulong)((long)index);
				ixuilabel2.RegisterLabelClickEventHandler(new LabelClickEventHandler(this._OnPetRankItemClicked));
			}
		}

		private void _SetBigMeleeRankItem(GameObject go, XBaseRankInfo info, int index)
		{
			IXUILabel ixuilabel = go.transform.FindChild("Name").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel2 = go.transform.FindChild("Server").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel3 = go.transform.FindChild("Kill").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel4 = go.transform.FindChild("Point").GetComponent("XUILabel") as IXUILabel;
			bool flag = info == null || info.rank == XRankDocument.INVALID_RANK;
			if (flag)
			{
				ixuilabel.SetText(string.Empty);
				ixuilabel2.SetText(string.Empty);
				ixuilabel3.SetText(string.Empty);
				ixuilabel4.SetText(string.Empty);
				this._SetRank(go, XRankDocument.INVALID_RANK);
			}
			else
			{
				XBigMeleeRankInfo xbigMeleeRankInfo = info as XBigMeleeRankInfo;
				ixuilabel.SetText(xbigMeleeRankInfo.name);
				ixuilabel2.SetText(xbigMeleeRankInfo.serverName);
				ixuilabel3.SetText(xbigMeleeRankInfo.kill.ToString());
				ixuilabel4.SetText(xbigMeleeRankInfo.value.ToString());
				this._SetRank(go, info.rank);
			}
		}

		private void _SetCampDuelRankLeftItem(GameObject go, XBaseRankInfo info, int index)
		{
			IXUILabel ixuilabel = go.transform.FindChild("Name").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel2 = go.transform.FindChild("Num").GetComponent("XUILabel") as IXUILabel;
			bool flag = info == null || info.rank == XRankDocument.INVALID_RANK;
			if (flag)
			{
				bool flag2 = XCampDuelDocument.Doc.campID != 2;
				if (flag2)
				{
					ixuilabel.SetText(string.Empty);
					ixuilabel2.SetText(string.Empty);
					this._SetRank(go, XRankDocument.INVALID_RANK);
				}
			}
			else
			{
				XCampDuelRankInfo xcampDuelRankInfo = info as XCampDuelRankInfo;
				ixuilabel.SetText(xcampDuelRankInfo.name);
				ixuilabel2.SetText(xcampDuelRankInfo.value.ToString());
				this._SetRank(go, info.rank);
			}
			XBaseRankList rankList = this._doc.GetRankList(XRankType.CampDuelRankRight);
			bool flag3 = rankList.rankList.Count <= index;
			if (flag3)
			{
				this._SetCampDuelRankClear(go.transform.parent.FindChild("Right"));
			}
		}

		private void _SetCampDuelRankRightItem(GameObject go, XBaseRankInfo info, int index)
		{
			IXUILabel ixuilabel = go.transform.FindChild("Name").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel2 = go.transform.FindChild("Num").GetComponent("XUILabel") as IXUILabel;
			bool flag = info == null || info.rank == XRankDocument.INVALID_RANK;
			if (flag)
			{
				bool flag2 = XCampDuelDocument.Doc.campID != 1;
				if (flag2)
				{
					ixuilabel.SetText(string.Empty);
					ixuilabel2.SetText(string.Empty);
					this._SetRank(go, XRankDocument.INVALID_RANK);
				}
			}
			else
			{
				XCampDuelRankInfo xcampDuelRankInfo = info as XCampDuelRankInfo;
				ixuilabel.SetText(xcampDuelRankInfo.name);
				ixuilabel2.SetText(xcampDuelRankInfo.value.ToString());
				this._SetRank(go, info.rank);
			}
			XBaseRankList rankList = this._doc.GetRankList(XRankType.CampDuelRankLeft);
			bool flag3 = rankList.rankList.Count <= index;
			if (flag3)
			{
				this._SetCampDuelRankClear(go.transform.parent.FindChild("Left"));
			}
		}

		private void _SetCampDuelRankClear(Transform t)
		{
			bool flag = t == null;
			if (!flag)
			{
				IXUILabel ixuilabel = t.FindChild("Name").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel2 = t.FindChild("Num").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(string.Empty);
				ixuilabel2.SetText(string.Empty);
				this._SetRank(t.gameObject, XRankDocument.INVALID_RANK);
			}
		}

		private void _SetSkyArenaRankItem(GameObject go, XBaseRankInfo info, int index)
		{
			IXUILabel ixuilabel = go.transform.FindChild("Name").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel2 = go.transform.FindChild("Kill").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel3 = go.transform.FindChild("Floor").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel4 = go.transform.FindChild("Profession").GetComponent("XUILabel") as IXUILabel;
			bool flag = info == null || info.rank == XRankDocument.INVALID_RANK;
			if (flag)
			{
				ixuilabel.SetText(string.Empty);
				ixuilabel2.SetText(string.Empty);
				ixuilabel3.SetText(string.Empty);
				ixuilabel4.SetText(string.Empty);
				this._SetRank(go, XRankDocument.INVALID_RANK);
			}
			else
			{
				XSkyArenaRankInfo xskyArenaRankInfo = info as XSkyArenaRankInfo;
				ixuilabel.SetText(xskyArenaRankInfo.name);
				ixuilabel2.SetText(xskyArenaRankInfo.kill.ToString());
				ixuilabel3.SetText(xskyArenaRankInfo.floor.ToString());
				ixuilabel4.SetText(XSingleton<XProfessionSkillMgr>.singleton.GetProfName((int)xskyArenaRankInfo.profession));
				this._SetRank(go, info.rank);
			}
		}

		private void _SetGuildBossRankItem(GameObject go, XBaseRankInfo info, int index)
		{
			IXUILabelSymbol ixuilabelSymbol = go.transform.FindChild("Name").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
			IXUILabel ixuilabel = go.transform.FindChild("Value0").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel2 = go.transform.FindChild("Value1").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel3 = go.transform.FindChild("Value2").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel4 = go.transform.FindChild("Value3").GetComponent("XUILabel") as IXUILabel;
			bool flag = info == null || info.rank == XRankDocument.INVALID_RANK;
			if (flag)
			{
				ixuilabelSymbol.InputText = string.Empty;
				ixuilabel.SetText(string.Empty);
				ixuilabel2.SetText(string.Empty);
				ixuilabel3.SetText(string.Empty);
				ixuilabel4.SetText(string.Empty);
				this._SetRank(go, XRankDocument.INVALID_RANK);
				ixuilabelSymbol.RegisterSymbolClickHandler(null);
			}
			else
			{
				XGuildBossRankInfo xguildBossRankInfo = info as XGuildBossRankInfo;
				ixuilabelSymbol.ID = (ulong)((long)(index << 1 | 0));
				GuildBossConfigTable.RowData byBossID = XGuildDragonDocument._GuildBossConfigReader.GetByBossID(xguildBossRankInfo.guildBossIndex);
				XEntityStatistics.RowData byID = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID(byBossID.EnemyID);
				float num = byID.MaxHP * byBossID.LifePercent;
				float num2 = Mathf.Clamp01(xguildBossRankInfo.damage / num);
				string text = (num2 * 100f).ToString("f2") + "%";
				bool flag2 = num2 == 0f;
				if (flag2)
				{
					text = "0%";
				}
				bool flag3 = num2 == 1f;
				if (flag3)
				{
					text = "100%";
				}
				ixuilabelSymbol.InputText = xguildBossRankInfo.guildBossName;
				ixuilabel.SetText(text);
				ixuilabel2.SetText(xguildBossRankInfo.m_Time);
				ixuilabel3.SetText(xguildBossRankInfo.guildName);
				ixuilabel4.SetText(xguildBossRankInfo.strongDPSName);
				this._SetRank(go, info.rank);
				ixuilabelSymbol.RegisterSymbolClickHandler(new LabelSymbolClickEventHandler(this._OnGuildBossClicked));
			}
		}

		private void _SetTowerRankItem(GameObject go, XBaseRankInfo info, int index)
		{
			IXUILabelSymbol ixuilabelSymbol = go.transform.FindChild("Name").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
			IXUILabelSymbol ixuilabelSymbol2 = go.transform.FindChild("Name0").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
			IXUILabelSymbol ixuilabelSymbol3 = go.transform.FindChild("Name1").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
			IXUILabel ixuilabel = go.transform.FindChild("Value0").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel2 = go.transform.FindChild("Value1").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel3 = go.transform.FindChild("Value2").GetComponent("XUILabel") as IXUILabel;
			GameObject gameObject = go.transform.FindChild("QQ").gameObject;
			GameObject gameObject2 = go.transform.FindChild("Wechat").gameObject;
			bool flag = XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Platform_StartPrivilege);
			bool flag2 = !flag;
			if (flag2)
			{
				gameObject.SetActive(false);
				gameObject2.SetActive(false);
			}
			bool flag3 = info == null || info.rank == XRankDocument.INVALID_RANK;
			if (flag3)
			{
				ixuilabelSymbol.InputText = string.Empty;
				ixuilabelSymbol2.InputText = string.Empty;
				ixuilabelSymbol3.InputText = string.Empty;
				ixuilabel.SetText(string.Empty);
				ixuilabel2.SetText(string.Empty);
				ixuilabel3.SetText(string.Empty);
				this._SetRank(go, XRankDocument.INVALID_RANK);
				ixuilabelSymbol.RegisterSymbolClickHandler(null);
				ixuilabelSymbol2.RegisterSymbolClickHandler(null);
				ixuilabelSymbol3.RegisterSymbolClickHandler(null);
				bool flag4 = flag;
				if (flag4)
				{
					gameObject.SetActive(XSingleton<XLoginDocument>.singleton.GetLaunchTypeServerInfo() == StartUpType.StartUp_QQ && XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_QQ);
					gameObject2.SetActive(XSingleton<XLoginDocument>.singleton.GetLaunchTypeServerInfo() == StartUpType.StartUp_WX && XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_WeChat);
				}
			}
			else
			{
				XTeamTowerRankInfo xteamTowerRankInfo = info as XTeamTowerRankInfo;
				ixuilabelSymbol.SetVisible(xteamTowerRankInfo.memberCount == 1U);
				ixuilabelSymbol2.SetVisible(xteamTowerRankInfo.memberCount != 1U);
				ixuilabelSymbol3.SetVisible(xteamTowerRankInfo.memberCount != 1U);
				ixuilabelSymbol.InputText = xteamTowerRankInfo.formatname;
				ixuilabelSymbol2.InputText = xteamTowerRankInfo.formatname;
				ixuilabelSymbol3.InputText = xteamTowerRankInfo.formatname1;
				ixuilabelSymbol.ID = (ulong)((long)(index << 1 | 0));
				ixuilabelSymbol2.ID = (ulong)((long)(index << 1 | 0));
				ixuilabelSymbol3.ID = (ulong)((long)(index << 1 | 1));
				ixuilabel.SetText(XStringDefineProxy.GetString("TEAMTOWER_DIFF" + xteamTowerRankInfo.diff));
				ixuilabel2.SetText(xteamTowerRankInfo.levelCount.ToString());
				ixuilabel3.SetText(xteamTowerRankInfo.GetValue());
				this._SetRank(go, info.rank);
				ixuilabelSymbol.RegisterSymbolClickHandler(new LabelSymbolClickEventHandler(this._OnTwoNameClicked));
				ixuilabelSymbol2.RegisterSymbolClickHandler(new LabelSymbolClickEventHandler(this._OnTwoNameClicked));
				ixuilabelSymbol3.RegisterSymbolClickHandler(new LabelSymbolClickEventHandler(this._OnTwoNameClicked));
				bool flag5 = flag;
				if (flag5)
				{
					gameObject.SetActive(info.startType == StartUpType.StartUp_QQ);
					gameObject2.SetActive(info.startType == StartUpType.StartUp_WX);
				}
			}
		}

		private void _SetQualifyingRankItem(GameObject go, XBaseRankInfo info, int index)
		{
			IXUILabel ixuilabel = go.transform.FindChild("Name").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel2 = go.transform.FindChild("Value1").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel3 = go.transform.FindChild("Value2").GetComponent("XUILabel") as IXUILabel;
			bool flag = info == null || info.rank == XRankDocument.INVALID_RANK;
			if (flag)
			{
				ixuilabel.SetText(string.Empty);
				ixuilabel2.SetText(string.Empty);
				ixuilabel3.SetText(string.Empty);
				this._SetRank(go, XRankDocument.INVALID_RANK);
				ixuilabel.RegisterLabelClickEventHandler(null);
			}
			else
			{
				XQualifyingRankInfo xqualifyingRankInfo = info as XQualifyingRankInfo;
				ixuilabel.SetText(xqualifyingRankInfo.formatname);
				ixuilabel.ID = (ulong)((long)index);
				ixuilabel2.SetText(xqualifyingRankInfo.rankScore.ToString());
				ixuilabel3.SetText(XSingleton<XProfessionSkillMgr>.singleton.GetProfName((int)xqualifyingRankInfo.profession));
				this._SetRank(go, info.rank);
				ixuilabel.RegisterLabelClickEventHandler(new LabelClickEventHandler(this._OnRankItemClicked));
			}
		}

		private void _SetDragonGuildRankItem(GameObject go, XBaseRankInfo info, int index)
		{
			IXUILabelSymbol ixuilabelSymbol = go.transform.FindChild("Name").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
			IXUILabelSymbol ixuilabelSymbol2 = go.transform.FindChild("LeaderName").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
			IXUILabel ixuilabel = go.transform.FindChild("Times").GetComponent("XUILabel") as IXUILabel;
			XDragonGuildRankInfo xdragonGuildRankInfo = info as XDragonGuildRankInfo;
			bool flag = xdragonGuildRankInfo == null;
			if (flag)
			{
				ixuilabelSymbol.InputText = string.Empty;
				ixuilabelSymbol2.InputText = string.Empty;
				ixuilabel.SetText(string.Empty);
				this._SetRank(go, XRankDocument.INVALID_RANK);
			}
			else
			{
				ixuilabelSymbol.InputText = xdragonGuildRankInfo.name;
				ixuilabel.SetText(xdragonGuildRankInfo.value.ToString());
				ixuilabelSymbol2.InputText = xdragonGuildRankInfo.passSceneName;
				this._SetRank(go, info.rank);
			}
		}

		private void _SetGuildRankItem(GameObject go, XBaseRankInfo info, int index)
		{
			IXUILabelSymbol ixuilabelSymbol = go.transform.FindChild("Name").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
			IXUILabel ixuilabel = go.transform.FindChild("Popularity").GetComponent("XUILabel") as IXUILabel;
			IXUILabelSymbol ixuilabelSymbol2 = go.transform.FindChild("LeaderName").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
			IXUILabel ixuilabel2 = go.transform.FindChild("Level").GetComponent("XUILabel") as IXUILabel;
			XGuildRankInfo xguildRankInfo = info as XGuildRankInfo;
			bool flag = xguildRankInfo == null;
			if (flag)
			{
				ixuilabelSymbol.InputText = string.Empty;
				ixuilabel.SetText(string.Empty);
				ixuilabelSymbol2.InputText = string.Empty;
				ixuilabel2.SetText(string.Empty);
				this._SetRank(go, XRankDocument.INVALID_RANK);
			}
			else
			{
				ixuilabelSymbol.InputText = xguildRankInfo.formatname;
				ixuilabel.SetText(xguildRankInfo.presitge.ToString());
				ixuilabel2.SetText(xguildRankInfo.value.ToString());
				ixuilabelSymbol2.InputText = xguildRankInfo.formatname2;
				ixuilabelSymbol.RegisterSymbolClickHandler(new LabelSymbolClickEventHandler(this._OnClickGuild));
				this._SetRank(go, info.rank);
			}
		}

		private void _SetRiftRankItem(GameObject go, XBaseRankInfo info, int index)
		{
			XRiftRankInfo xriftRankInfo = info as XRiftRankInfo;
			IXUILabelSymbol ixuilabelSymbol = go.transform.FindChild("Name").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
			IXUILabel ixuilabel = go.transform.FindChild("time").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel2 = go.transform.FindChild("floor").GetComponent("XUILabel") as IXUILabel;
			bool flag = info == null;
			if (flag)
			{
				ixuilabelSymbol.InputText = string.Empty;
				this._SetRank(go, XRankDocument.INVALID_RANK);
				XSingleton<XDebug>.singleton.AddLog("[_SetBaseRankItem] info == null", null, null, null, null, null, XDebugColor.XDebug_None);
			}
			else
			{
				ixuilabelSymbol.InputText = xriftRankInfo.name;
				ixuilabel.SetText(this._FormatTime(xriftRankInfo.passtime));
				ixuilabel2.SetText(xriftRankInfo.floor.ToString());
				this._SetRank(go, info.rank);
				ixuilabelSymbol.RegisterSymbolClickHandler(new LabelSymbolClickEventHandler(this._OnRankItemClicked));
			}
		}

		private string _FormatTime(uint time)
		{
			uint num = time % 60U;
			return (time / 60U).ToString("d2") + ":" + num.ToString("d2");
		}

		private void _SetRank(GameObject go, uint rankIndex)
		{
			IXUILabel ixuilabel = go.transform.FindChild("Rank").GetComponent("XUILabel") as IXUILabel;
			IXUISprite ixuisprite = go.transform.FindChild("RankImage").GetComponent("XUISprite") as IXUISprite;
			bool flag = rankIndex == XRankDocument.INVALID_RANK;
			if (flag)
			{
				ixuilabel.SetVisible(false);
				ixuisprite.SetVisible(false);
			}
			else
			{
				bool flag2 = rankIndex < 3U;
				if (flag2)
				{
					ixuisprite.SetSprite("N" + (rankIndex + 1U));
					ixuisprite.SetVisible(true);
					ixuilabel.SetVisible(false);
				}
				else
				{
					ixuisprite.SetVisible(false);
					ixuilabel.SetText("No." + (rankIndex + 1U));
					ixuilabel.SetVisible(true);
				}
			}
		}

		private void _SetMyRankFrame(GameObject go, XBaseRankInfo info, uint maxRank, XRankView.SetRankItemHandler setHandler)
		{
			GameObject gameObject = go.transform.FindChild("Tpl").gameObject;
			GameObject gameObject2 = go.transform.FindChild("OutOfRange").gameObject;
			bool flag = this._doc.currentSelectRankList == XRankType.CampDuelRankLeft;
			if (flag)
			{
				IXUIButton ixuibutton = go.transform.Find("Reward").GetComponent("XUIButton") as IXUIButton;
				ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCampDuelReward));
				bool flag2 = XCampDuelDocument.Doc.campID == 2;
				if (flag2)
				{
					return;
				}
			}
			bool flag3 = this._doc.currentSelectRankList == XRankType.CampDuelRankRight;
			if (flag3)
			{
				bool flag4 = XCampDuelDocument.Doc.campID == 1;
				if (flag4)
				{
					return;
				}
			}
			bool flag5 = info == null;
			if (flag5)
			{
				go.SetActive(false);
			}
			else
			{
				go.SetActive(true);
				setHandler(gameObject, info, 0);
				gameObject2.SetActive(info.rank == XRankDocument.INVALID_RANK);
			}
		}

		private void _SetTitle(GameObject title)
		{
			XRankType currentSelectRankList = this._doc.currentSelectRankList;
			bool flag = currentSelectRankList == XRankType.CampDuelRankLeft;
			if (flag)
			{
				IXUILabel ixuilabel = title.transform.Find("TitleL/Title/T").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(XStringDefineProxy.GetString("CAMPDUEL_LEFT_NAME"));
				ixuilabel = (title.transform.Find("TitleR/Title/T").GetComponent("XUILabel") as IXUILabel);
				ixuilabel.SetText(XStringDefineProxy.GetString("CAMPDUEL_RIGHT_NAME"));
			}
			Transform transform = title.transform.Find("ValueName");
			bool flag2 = transform == null;
			if (!flag2)
			{
				IXUILabel ixuilabel2 = transform.GetComponent("XUILabel") as IXUILabel;
				ixuilabel2.SetText(XStringDefineProxy.GetString(currentSelectRankList.ToString() + "_ValueName"));
			}
		}

		private void _OnRankItemClickedSp(IXUISprite sp)
		{
			this._SelectItem((uint)sp.ID);
		}

		private void _OnRankItemClicked(IXUILabelSymbol iSp)
		{
			this._SelectItem((uint)iSp.ID);
			XRankType currentSelectRankList = this._doc.currentSelectRankList;
			XBaseRankList rankList = this._doc.GetRankList(currentSelectRankList);
			XBaseRankInfo xbaseRankInfo = rankList.rankList[(int)iSp.ID];
			bool flag = currentSelectRankList == XRankType.SpriteRank;
			if (flag)
			{
				DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.singleton.SetPlayerInfo(xbaseRankInfo.id, xbaseRankInfo.name, xbaseRankInfo.setid, 0U, 1U);
				DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.singleton.SetVisibleWithAnimation(true, null);
				DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.singleton.ShowTab(Player_Info.Sprite, 0UL, 0UL);
			}
			else
			{
				XCharacterCommonMenuDocument.ReqCharacterMenuInfo(xbaseRankInfo.id, false);
			}
		}

		private void _OnRankItemClicked(IXUILabel iSp)
		{
			this._SelectItem((uint)iSp.ID);
			XRankType currentSelectRankList = this._doc.currentSelectRankList;
			XBaseRankList rankList = this._doc.GetRankList(currentSelectRankList);
			XBaseRankInfo xbaseRankInfo = rankList.rankList[(int)iSp.ID];
			XCharacterCommonMenuDocument.ReqCharacterMenuInfo(xbaseRankInfo.id, false);
		}

		private void _OnPetRankItemClicked(IXUILabel iSp)
		{
			this._SelectItem((uint)iSp.ID);
			XRankType currentSelectRankList = this._doc.currentSelectRankList;
			XBaseRankList rankList = this._doc.GetRankList(currentSelectRankList);
			XPetRankInfo xpetRankInfo = rankList.rankList[(int)iSp.ID] as XPetRankInfo;
			bool flag = XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID == xpetRankInfo.id;
			if (!flag)
			{
				DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.singleton.SetPlayerInfo(xpetRankInfo.id, xpetRankInfo.name, xpetRankInfo.setid, 0U, 1U);
				DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.singleton.SetVisibleWithAnimation(true, null);
				DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.singleton.ShowTab(Player_Info.Pet, xpetRankInfo.id, xpetRankInfo.petUID);
			}
		}

		private void _OnClickGuild(IXUILabelSymbol iSp)
		{
			this._SelectItem((uint)iSp.ID);
			int index = (int)iSp.ID;
			XBaseRankList guildRankList = this._doc.GuildRankList;
			ulong id = guildRankList.rankList[index].id;
			this._viewGuildId = id;
			string name = guildRankList.rankList[index].name;
			DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.singleton.InitGuildMenu(id, name);
		}

		private void _OnTwoNameClicked(IXUILabelSymbol label)
		{
			int index = (int)(label.ID >> 1);
			int num = (int)(label.ID & 1UL);
			this._SelectItem((uint)index);
			XRankType currentSelectRankList = this._doc.currentSelectRankList;
			XBaseRankList rankList = this._doc.GetRankList(currentSelectRankList);
			XTeamTowerRankInfo xteamTowerRankInfo = rankList.rankList[index] as XTeamTowerRankInfo;
			bool flag = xteamTowerRankInfo == null;
			if (!flag)
			{
				bool flag2 = num == 0;
				if (flag2)
				{
					XCharacterCommonMenuDocument.ReqCharacterMenuInfo(xteamTowerRankInfo.id, false);
				}
				else
				{
					XCharacterCommonMenuDocument.ReqCharacterMenuInfo(xteamTowerRankInfo.id1, false);
				}
			}
		}

		private void _OnGuildBossClicked(IXUILabelSymbol label)
		{
		}

		public bool OnShowGuildInfo(IXUIButton sp)
		{
			XGuildViewDocument specificDocument = XDocuments.GetSpecificDocument<XGuildViewDocument>(XGuildViewDocument.uuID);
			specificDocument.View(this._viewGuildId);
			DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.singleton.SetVisibleWithAnimation(false, null);
			return true;
		}

		private void _SelectItem(uint index)
		{
			this._doc.SelectItem(index);
		}

		public bool OnCampDuelReward(IXUIButton btn)
		{
			DlgHandlerBase.EnsureCreate<XCampDuelRankRewardHandler>(ref this._RankRewardHandler, base.uiBehaviour.m_OriginalRank.transform, false, null);
			this._RankRewardHandler.SetVisible(true);
			return true;
		}

		private XRankDocument _doc = null;

		private ulong _viewGuildId = 0UL;

		private XDummy _PlayerDummy = null;

		private XDummy _PetDummy = null;

		private XDummy _SpriteDummy = null;

		private uint m_PreUIType = 9999999U;

		private UnitAppearance emptyUA = null;

		private XFlowerRankHandler _FlowerRankHandler = null;

		private XCampDuelRankRewardHandler _RankRewardHandler = null;

		protected XSubSysRedPointMgr redpointMgr = new XSubSysRedPointMgr();

		public Dictionary<XRankType, uint> RankUIType = new Dictionary<XRankType, uint>(default(XFastEnumIntEqualityComparer<XRankType>));

		public Dictionary<XRankType, XRankView.SetRankItemHandler> RankItemHandlers = new Dictionary<XRankType, XRankView.SetRankItemHandler>(default(XFastEnumIntEqualityComparer<XRankType>));

		private XRankType[] m_RankTypeList = new XRankType[]
		{
			XRankType.PPTRank,
			XRankType.LevelRank,
			XRankType.GuildRank,
			XRankType.DragonGuildRank,
			XRankType.FashionRank,
			XRankType.TeamTowerRank,
			XRankType.GuildBossRank,
			XRankType.WorldBossDamageRank,
			XRankType.PetRank,
			XRankType.SpriteRank,
			XRankType.QualifyingRank,
			XRankType.SkyArenaRank,
			XRankType.CampDuelRankLeft,
			XRankType.CampDuelRankRight,
			XRankType.BigMeleeRank
		};

		public delegate void SetRankItemHandler(GameObject itemGo, XBaseRankInfo info, int index);
	}
}
