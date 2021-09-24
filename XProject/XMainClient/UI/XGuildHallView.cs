using System;
using System.Collections.Generic;
using KKSG;
using MiniJSON;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XGuildHallView : DlgBase<XGuildHallView, XGuildHallBehaviour>
	{

		public XGuildLogView LogView
		{
			get
			{
				return this._LogView;
			}
		}

		public XGuildEditAnnounceView EditAnnounceView
		{
			get
			{
				return this._EditAnnounceView;
			}
		}

		public bool Deprecated { get; set; }

		public override string fileName
		{
			get
			{
				return "Guild/GuildHallDlg";
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

		public override bool pushstack
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

		protected override void Init()
		{
			this._HallDoc = XDocuments.GetSpecificDocument<XGuildHallDocument>(XGuildHallDocument.uuID);
			this._HallDoc.GuildHallView = this;
			this._GuildDoc = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
			this._GrowthDoc = XDocuments.GetSpecificDocument<XGuildGrowthDocument>(XGuildGrowthDocument.uuID);
			DlgHandlerBase.EnsureCreate<XGuildEditAnnounceView>(ref this._EditAnnounceView, base.uiBehaviour.m_EditAnnouncePanel, null, true);
			DlgHandlerBase.EnsureCreate<XGuildLogView>(ref this._LogView, base.uiBehaviour.m_LogPanel, null, true);
			this._LogView.LogSource = this._HallDoc;
			IXUIObject[] btns = new IXUIObject[]
			{
				base.uiBehaviour.m_BtnApprove,
				base.uiBehaviour.m_BtnSignIn,
				base.uiBehaviour.m_BtnSkill,
				base.uiBehaviour.m_BtnMembers,
				base.uiBehaviour.m_BtnEnter,
				base.uiBehaviour.m_BtnGZ,
				base.uiBehaviour.m_BtnDmx,
				base.uiBehaviour.m_BtnRedPacker,
				base.uiBehaviour.m_BtnJoker
			};
			this.redpointMgr.SetupRedPoints(btns);
			XSingleton<XGameSysMgr>.singleton.RegisterSubSysRedPointMgr(XSysDefine.XSys_GuildHall, this.redpointMgr);
		}

		protected override void OnUnload()
		{
			this._HallDoc.GuildHallView = null;
			DlgHandlerBase.EnsureUnload<XGuildEditAnnounceView>(ref this._EditAnnounceView);
			DlgHandlerBase.EnsureUnload<XGuildLogView>(ref this._LogView);
			XSingleton<XGameSysMgr>.singleton.RegisterSubSysRedPointMgr(XSysDefine.XSys_GuildHall, null);
			base.OnUnload();
		}

		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnCloseBtnClick));
			base.uiBehaviour.m_BtnExit.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnExitGuildBtnClick));
			base.uiBehaviour.m_BtnSignIn.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnSignInBtnClick));
			base.uiBehaviour.m_BtnMall.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnMallClick));
			base.uiBehaviour.m_BtnDonate.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnDonationClick));
			base.uiBehaviour.m_BtnMembers.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnMembersBtnClick));
			base.uiBehaviour.m_BtnSkill.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnSkillBtnClick));
			base.uiBehaviour.m_BtnApprove.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnApproveBtnClick));
			base.uiBehaviour.m_BtnLog.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnLogBtnClick));
			base.uiBehaviour.m_BtnEditAnnounce.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnEditAnnounceBtnClick));
			base.uiBehaviour.m_BtnRank.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnRankBtnClick));
			base.uiBehaviour.m_BtnEnter.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnEnterGuildBtnClick));
			base.uiBehaviour.m_LivenessTipSprite.RegisterSpritePressEventHandler(new SpritePressEventHandler(this._OnLivenessPress));
			base.uiBehaviour.m_PopularityTipSprite.RegisterSpritePressEventHandler(new SpritePressEventHandler(this._OnPopularityTipPress));
			base.uiBehaviour.m_ExpTipsSprite.RegisterSpritePressEventHandler(new SpritePressEventHandler(this._OnExpTipsPress));
			base.uiBehaviour.m_BtnEditPortrait.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnPortraitClick));
			base.uiBehaviour.m_BtnWXGroup.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnGuildWXGroupClick));
			base.uiBehaviour.m_BtnWXGroupShare.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnGuildWXGroupShare));
			base.uiBehaviour.m_BtnQQGroup.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnGuildQQGroupClick));
			base.uiBehaviour.m_BtnGZ.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnGuildSalaryClick));
			base.uiBehaviour.m_BtnDmx.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnGuildDungeonClick));
			base.uiBehaviour.m_BtnJoker.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnGuildJokingClick));
			base.uiBehaviour.m_BtnRedPacker.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnGuildRedPackerClick));
			base.uiBehaviour.m_BtnConsider.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnGuildConsiderClick));
			base.uiBehaviour.m_BtnBuild.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnGuildBuildClick));
		}

		private void CheckOpenSystem()
		{
			int i = 0;
			int count = base.uiBehaviour.m_checkGuildList.Count;
			while (i < count)
			{
				Transform transform = base.uiBehaviour.m_checkGuildList[i].gameObject.transform.FindChild("Lock");
				bool flag = transform == null;
				if (!flag)
				{
					bool flag2 = true;
					bool flag3 = base.uiBehaviour.m_checkGuildList[i].ID > 0UL;
					if (flag3)
					{
						XSysDefine xsysDefine = (XSysDefine)base.uiBehaviour.m_checkGuildList[i].ID;
						uint unlockLevel = XGuildDocument.GuildConfig.GetUnlockLevel(xsysDefine);
						XSingleton<XDebug>.singleton.AddGreenLog(xsysDefine.ToString() + "   " + unlockLevel.ToString(), null, null, null, null, null);
						bool flag4 = this._GuildDoc.bInGuild && this._GuildDoc.Level >= unlockLevel && XSingleton<XGameSysMgr>.singleton.IsSystemOpened(xsysDefine);
						if (flag4)
						{
							flag2 = false;
							bool flag5 = xsysDefine == XSysDefine.XSys_GuildDungeon_SmallMonter;
							if (flag5)
							{
								XGuildSmallMonsterDocument specificDocument = XDocuments.GetSpecificDocument<XGuildSmallMonsterDocument>(XGuildSmallMonsterDocument.uuID);
								bool flag6 = !specificDocument.CheckEnterLevel();
								if (flag6)
								{
									flag2 = true;
								}
								DlgBase<XGuildSmallMonsterView, XGuildSmallMonsterBehaviour>.singleton.RefreshRedp();
							}
						}
					}
					else
					{
						flag2 = true;
					}
					base.uiBehaviour.m_checkGuildList[i].SetGrey(!flag2);
					transform.gameObject.SetActive(flag2);
				}
				i++;
			}
		}

		private bool _OnGuildSalaryClick(IXUIButton btn)
		{
			bool flag = !this._GuildDoc.CheckInGuild();
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				DlgBase<GuildSalayDlg, GuildSalayBehavior>.singleton.SetVisibleWithAnimation(true, null);
				result = true;
			}
			return result;
		}

		private bool _OnGuildDungeonClick(IXUIButton btn)
		{
			bool flag = !this._GuildDoc.CheckInGuild();
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = !this.TryCheckInGuildSystem(XSysDefine.XSys_GuildDungeon_SmallMonter);
				if (flag2)
				{
					result = false;
				}
				else
				{
					DlgBase<XGuildSmallMonsterView, XGuildSmallMonsterBehaviour>.singleton.SetVisibleWithAnimation(true, null);
					result = true;
				}
			}
			return result;
		}

		private bool _OnGuildJokingClick(IXUIButton btn)
		{
			bool flag = !this._GuildDoc.CheckInGuild();
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				DlgBase<XGuildJokerView, XGuildJokerBehaviour>.singleton.SetVisibleWithAnimation(true, null);
				result = true;
			}
			return result;
		}

		private bool _OnGuildRedPackerClick(IXUIButton btn)
		{
			bool flag = !this._GuildDoc.CheckInGuild();
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				DlgBase<XGuildSignRedPackageView, XGuildSignRedPackageBehaviour>.singleton.SetVisibleWithAnimation(true, null);
				result = true;
			}
			return result;
		}

		private bool _OnGuildConsiderClick(IXUIButton button)
		{
			bool flag = !this._GuildDoc.CheckInGuild();
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				DlgBase<XGuildGrowthEntranceView, XGuildGrowthEntranceBehavior>.singleton.SetVisibleWithAnimation(true, null);
				result = true;
			}
			return result;
		}

		private bool _OnGuildBuildClick(IXUIButton btn)
		{
			bool flag = !this._GuildDoc.CheckInGuild();
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				DlgBase<XGuildGrowthBuildView, XGuildGrowthBuildBehavior>.singleton.SetVisibleWithAnimation(true, null);
				result = true;
			}
			return result;
		}

		private bool TryCheckInGuildSystem(XSysDefine sys)
		{
			XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
			bool flag = !specificDocument.bInGuild;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				uint unlockLevel = XGuildDocument.GuildConfig.GetUnlockLevel(sys);
				bool flag2 = specificDocument.Level < unlockLevel;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("GUILD_MAZE_NO_GUILD_LEVEL", new object[]
					{
						unlockLevel
					}), "fece00");
					result = false;
				}
				else
				{
					bool flag3 = !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(sys);
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("GUILD_MAZE_NO_PLAYER_LEVEL", new object[]
						{
							XSingleton<XGameSysMgr>.singleton.GetSystemOpenLevel(sys)
						}), "fece00");
						result = false;
					}
					else
					{
						bool flag4 = sys == XSysDefine.XSys_GuildDungeon_SmallMonter;
						if (flag4)
						{
							XGuildSmallMonsterDocument specificDocument2 = XDocuments.GetSpecificDocument<XGuildSmallMonsterDocument>(XGuildSmallMonsterDocument.uuID);
							bool flag5 = !specificDocument2.CheckEnterLevel();
							if (flag5)
							{
								XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("GUILD_MAZE_NO_PLAYER_LEVEL", new object[]
								{
									specificDocument2.GetEnterLevel()
								}), "fece00");
								return false;
							}
						}
						result = true;
					}
				}
			}
			return result;
		}

		protected override void OnShow()
		{
			this._GrowthDoc.QueryBuffList();
			this._GuildDoc.QueryWXGroup();
			this._GuildDoc.QueryQQGroup();
			this._EditAnnounceView.SetVisible(false);
			this._LogView.SetVisible(false);
			this._HallDoc.ReqGuildBrief();
			this.RefreshPortrait();
			this.CheckOpenSystem();
			this.redpointMgr.UpdateRedPointUI();
			base.uiBehaviour.m_BtnEnter.SetVisible(XSingleton<XScene>.singleton.SceneType != SceneType.SCENE_GUILD_HALL);
			this.Refresh();
			this.RefreshGrowthBuffList();
		}

		public void RefreshGrowthBuffList()
		{
			base.uiBehaviour.m_ShielterItemPool.ReturnAll(false);
			int num = 0;
			for (int i = 1; i < this._GrowthDoc.BuffList.Count; i++)
			{
				bool flag = !this._GrowthDoc.BuffList[i].Enable;
				if (!flag)
				{
					GuildHall.RowData data = this._GrowthDoc.GetData(this._GrowthDoc.BuffList[i].BuffID, this._GrowthDoc.BuffList[i].BuffLevel);
					bool flag2 = data == null;
					if (!flag2)
					{
						GameObject gameObject = base.uiBehaviour.m_ShielterItemPool.FetchGameObject(false);
						gameObject.transform.localPosition = new Vector3(base.uiBehaviour.m_ShielterItemPool.TplPos.x + (float)(num * base.uiBehaviour.m_ShielterItemPool.TplWidth), base.uiBehaviour.m_ShielterItemPool.TplPos.y);
						IXUISprite ixuisprite = gameObject.transform.Find("HallShelterIcon").GetComponent("XUISprite") as IXUISprite;
						ixuisprite.SetGrey(this._GrowthDoc.BuffList[i].Enable);
						ixuisprite.SetSprite(data.icon, data.atlas, false);
						IXUISprite ixuisprite2 = gameObject.GetComponent("XUISprite") as IXUISprite;
						ixuisprite2.ID = (ulong)((long)i);
						ixuisprite2.RegisterSpritePressEventHandler(new SpritePressEventHandler(this.OnGrowthBuffClick));
						num++;
					}
				}
			}
			for (int j = 1; j < this._GrowthDoc.BuffList.Count; j++)
			{
				bool enable = this._GrowthDoc.BuffList[j].Enable;
				if (!enable)
				{
					GuildHall.RowData data2 = this._GrowthDoc.GetData(this._GrowthDoc.BuffList[j].BuffID, this._GrowthDoc.BuffList[j].BuffLevel);
					bool flag3 = data2 == null;
					if (!flag3)
					{
						GameObject gameObject2 = base.uiBehaviour.m_ShielterItemPool.FetchGameObject(false);
						gameObject2.transform.localPosition = new Vector3(base.uiBehaviour.m_ShielterItemPool.TplPos.x + (float)(num * base.uiBehaviour.m_ShielterItemPool.TplWidth), base.uiBehaviour.m_ShielterItemPool.TplPos.y);
						IXUISprite ixuisprite3 = gameObject2.transform.Find("HallShelterIcon").GetComponent("XUISprite") as IXUISprite;
						ixuisprite3.SetGrey(this._GrowthDoc.BuffList[j].Enable);
						ixuisprite3.SetSprite(data2.icon, data2.atlas, false);
						IXUISprite ixuisprite4 = gameObject2.GetComponent("XUISprite") as IXUISprite;
						ixuisprite4.ID = (ulong)((long)j);
						ixuisprite4.RegisterSpritePressEventHandler(new SpritePressEventHandler(this.OnGrowthBuffClick));
						num++;
					}
				}
			}
		}

		private bool OnGrowthBuffClick(IXUISprite iSp, bool state)
		{
			base.uiBehaviour.m_GrowthBuffHelpFrame.gameObject.SetActive(state);
			if (state)
			{
				base.uiBehaviour.m_GrowthBuffHelpFrame.localPosition = iSp.transform.localPosition;
				GuildHall.RowData data = this._GrowthDoc.GetData(this._GrowthDoc.BuffList[(int)iSp.ID].BuffID, this._GrowthDoc.BuffList[(int)iSp.ID].BuffLevel);
				bool flag = data == null;
				if (flag)
				{
					base.uiBehaviour.m_GrowthBuffHelpFrame.gameObject.SetActive(false);
					return false;
				}
				bool flag2 = !this._GrowthDoc.BuffList[(int)iSp.ID].Enable;
				if (flag2)
				{
					base.uiBehaviour.m_GrowthBuffHelpLabel.SetText(string.Format("{0}\n{1}", data.currentLevelDescription, XStringDefineProxy.GetString("GuildGrowthBuffLearnTips")));
				}
				else
				{
					bool flag3 = this._GrowthDoc.BuffList[(int)iSp.ID].BuffLevel == this._GrowthDoc.BuffList[(int)iSp.ID].BuffMaxLevel;
					if (flag3)
					{
						base.uiBehaviour.m_GrowthBuffHelpLabel.SetText(data.currentLevelDescription);
					}
					else
					{
						GuildHall.RowData data2 = this._GrowthDoc.GetData(this._GrowthDoc.BuffList[(int)iSp.ID].BuffID, this._GrowthDoc.BuffList[(int)iSp.ID].BuffLevel + 1U);
						bool flag4 = data2 == null;
						if (flag4)
						{
							return false;
						}
						base.uiBehaviour.m_GrowthBuffHelpLabel.SetText(string.Format("{0}\n{1}\n{2}", data.currentLevelDescription, XStringDefineProxy.GetString("GuildGrowthBuffNextLevel"), data2.currentLevelDescription));
					}
				}
			}
			return true;
		}

		private bool _OnCloseBtnClick(IXUIButton go)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private bool _OnPopularityTipPress(IXUISprite uiSprite, bool isPressed)
		{
			if (isPressed)
			{
				bool flag = !base.uiBehaviour.m_PopularityTipLabel.IsVisible();
				if (flag)
				{
					base.uiBehaviour.m_PopularityTipLabel.SetVisible(true);
				}
				base.uiBehaviour.m_PopularityTipLabel.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("GUILD_RANK_TIPS")));
			}
			else
			{
				bool flag2 = base.uiBehaviour.m_PopularityTipLabel.IsVisible();
				if (flag2)
				{
					base.uiBehaviour.m_PopularityTipLabel.SetVisible(false);
				}
			}
			return false;
		}

		private bool _OnExpTipsPress(IXUISprite uiSprite, bool isPressed)
		{
			if (isPressed)
			{
				bool flag = !base.uiBehaviour.m_ExpTipsLabel.IsVisible();
				if (flag)
				{
					base.uiBehaviour.m_ExpTipsLabel.SetVisible(true);
				}
				base.uiBehaviour.m_ExpTipsLabel.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("GUILD_EXP_TIPS")));
			}
			else
			{
				bool flag2 = base.uiBehaviour.m_ExpTipsLabel.IsVisible();
				if (flag2)
				{
					base.uiBehaviour.m_ExpTipsLabel.SetVisible(false);
				}
			}
			return true;
		}

		private bool _OnLivenessPress(IXUISprite uiSprite, bool isPressed)
		{
			if (isPressed)
			{
				bool flag = !base.uiBehaviour.m_LivenessTipsLabel.IsVisible();
				if (flag)
				{
					base.uiBehaviour.m_LivenessTipsLabel.SetVisible(true);
				}
				base.uiBehaviour.m_LivenessTipsLabel.SetText(this._GuildDoc.BasicData.GetLivenessTips());
			}
			else
			{
				bool flag2 = base.uiBehaviour.m_LivenessTipsLabel.IsVisible();
				if (flag2)
				{
					base.uiBehaviour.m_LivenessTipsLabel.SetVisible(false);
				}
			}
			return false;
		}

		private bool _OnEnterGuildBtnClick(IXUIButton go)
		{
			bool flag = !this._GuildDoc.CheckInGuild();
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				this._GuildDoc.TryEnterGuildScene();
				result = true;
			}
			return result;
		}

		private bool _OnExitGuildBtnClick(IXUIButton go)
		{
			bool flag = !this._GuildDoc.CheckInGuild();
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("GUILD_EXIT_CONFIRM"), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this._OnExitGuild));
				result = true;
			}
			return result;
		}

		private bool _OnExitGuild(IXUIButton go)
		{
			bool flag = !this._GuildDoc.CheckInGuild();
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				this._HallDoc.ReqExitGuild();
				XSingleton<UiUtility>.singleton.CloseModalDlg();
				result = true;
			}
			return result;
		}

		private bool _OnDonationClick(IXUIButton button)
		{
			bool flag = !this._GuildDoc.CheckInGuild();
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				DlgBase<XGuildDonateView, XGuildDonateBehavior>.singleton.SetVisibleWithAnimation(true, null);
				result = true;
			}
			return result;
		}

		private bool _OnMallClick(IXUIButton go)
		{
			bool flag = !this._GuildDoc.CheckInGuild();
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				bool flag2 = !this._GuildDoc.CheckUnlockLevel(XSysDefine.XSys_GuildBoon_Shop);
				if (flag2)
				{
					result = true;
				}
				else
				{
					DlgBase<MallSystemDlg, MallSystemBehaviour>.singleton.ShowShopSystem(XSysDefine.XSys_Mall_Guild, 0UL);
					result = false;
				}
			}
			return result;
		}

		private bool _OnSignInBtnClick(IXUIButton go)
		{
			bool flag = !this._GuildDoc.CheckInGuild();
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				bool flag2 = !this._GuildDoc.CheckUnlockLevel(XSysDefine.XSys_GuildHall_SignIn);
				if (flag2)
				{
					result = true;
				}
				else
				{
					DlgBase<XGuildSignInView, XGuildSignInBehaviour>.singleton.SetVisibleWithAnimation(true, null);
					result = true;
				}
			}
			return result;
		}

		private bool _OnSkillBtnClick(IXUIButton go)
		{
			bool flag = !this._GuildDoc.CheckInGuild();
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				bool flag2 = !this._GuildDoc.CheckUnlockLevel(XSysDefine.XSys_GuildHall_Skill);
				if (flag2)
				{
					result = true;
				}
				else
				{
					DlgBase<XGuildSkillView, XGuildSkillBehaviour>.singleton.SetVisibleWithAnimation(true, null);
					result = true;
				}
			}
			return result;
		}

		private bool _OnMembersBtnClick(IXUIButton go)
		{
			bool flag = !this._GuildDoc.CheckInGuild();
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				DlgBase<XGuildMembersView, XGuildMembersBehaviour>.singleton.SetVisibleWithAnimation(true, null);
				result = true;
			}
			return result;
		}

		private bool _OnApproveBtnClick(IXUIButton go)
		{
			bool flag = !this._GuildDoc.CheckPermission(GuildPermission.GPEM_APPROVAL);
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				DlgBase<XGuildApproveView, XGuildApproveBehaviour>.singleton.SetVisibleWithAnimation(true, null);
				result = true;
			}
			return result;
		}

		private bool _OnLogBtnClick(IXUIButton go)
		{
			bool flag = !this._GuildDoc.CheckInGuild();
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				this._HallDoc.ReqLogList();
				this._LogView.SetVisible(true);
				result = true;
			}
			return result;
		}

		private bool _OnEditAnnounceBtnClick(IXUIButton go)
		{
			bool flag = !this._GuildDoc.CheckPermission(GuildPermission.GPEM_ANNOUNCEMENT);
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				this._EditAnnounceView.SetVisible(true);
				result = true;
			}
			return result;
		}

		private bool _OnRankBtnClick(IXUIButton go)
		{
			DlgBase<XRankView, XRankBehaviour>.singleton.ShowRank(XSysDefine.XSys_Rank_Guild);
			return true;
		}

		private bool _OnPortraitClick(IXUIButton go)
		{
			bool flag = !this._GuildDoc.CheckPermission(GuildPermission.GPEM_ANNOUNCEMENT);
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				DlgBase<XGuildPortraitView, XGuildPortraitBehaviour>.singleton.Open(this._GuildDoc.BasicData.portraitIndex, new ButtonClickEventHandler(this._OnPortraitChanged));
				result = true;
			}
			return result;
		}

		private bool _OnPortraitChanged(IXUIButton btn)
		{
			int portraitIndex = DlgBase<XGuildPortraitView, XGuildPortraitBehaviour>.singleton.PortraitIndex;
			this._HallDoc.ReqEditPortrait(portraitIndex);
			return true;
		}

		public void RefreshPortrait()
		{
			base.uiBehaviour.m_Portrait.SetSprite(XGuildDocument.GetPortraitName(this._GuildDoc.BasicData.portraitIndex));
		}

		public void RefreshAnnouncement()
		{
			XGuildBasicData basicData = this._GuildDoc.BasicData;
			base.uiBehaviour.m_Annoucement.SetText(basicData.announcement);
		}

		public void RefreshButtonsState()
		{
			base.uiBehaviour.m_BtnApprove.SetVisible(this._GuildDoc.IHavePermission(GuildPermission.GPEM_APPROVAL));
			base.uiBehaviour.m_BtnEditAnnounce.SetVisible(this._GuildDoc.IHavePermission(GuildPermission.GPEM_ANNOUNCEMENT));
			base.uiBehaviour.m_BtnEditPortrait.SetVisible(this._GuildDoc.IHavePermission(GuildPermission.GPEM_SETTINGS));
			this.RefreshWXGroupBtn();
			this.RefreshQQGroupBtn();
			this.RefreshRedPoints();
		}

		public void RefreshRedPoints()
		{
			this.redpointMgr.UpdateRedPointUI();
		}

		public void Refresh()
		{
			XGuildBasicData basicData = this._GuildDoc.BasicData;
			base.uiBehaviour.m_BasicInfoDisplay.Set(basicData);
			this.RefreshAnnouncement();
			this.RefreshButtonsState();
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
			this.Refresh();
			this.RefreshRedPoints();
			this.RefreshPortrait();
			this.CheckOpenSystem();
			this._GrowthDoc.QueryBuffList();
			this._HallDoc.ReqGuildBrief();
		}

		public void RefreshWXGroupBtn()
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				bool flag2 = XSingleton<XLoginDocument>.singleton.Channel != XAuthorizationChannel.XAuthorization_WeChat || !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Guild_Bind_Group);
				if (flag2)
				{
					base.uiBehaviour.m_BtnWXGroup.SetVisible(false);
					base.uiBehaviour.m_BtnWXGroupShare.SetVisible(false);
				}
				else
				{
					base.uiBehaviour.m_WXGroupTip.SetVisible(false);
					bool flag3 = XSingleton<PDatabase>.singleton.wxGroupInfo != null && XSingleton<PDatabase>.singleton.wxGroupInfo.data.flag == "Success" && XSingleton<PDatabase>.singleton.wxGroupInfo.data.errorCode != -10007;
					if (flag3)
					{
						XSingleton<XDebug>.singleton.AddLog("[WXGroup RefreshWXGroupBtn] 1", null, null, null, null, null, XDebugColor.XDebug_None);
						bool flag4 = false;
						string[] array = XSingleton<PDatabase>.singleton.wxGroupInfo.data.openIdList.Split(new char[]
						{
							','
						});
						for (int i = 0; i < array.Length; i++)
						{
							bool flag5 = array[i] == XSingleton<XLoginDocument>.singleton.OpenID;
							if (flag5)
							{
								flag4 = true;
								break;
							}
						}
						bool flag6 = flag4;
						if (flag6)
						{
							XSingleton<XDebug>.singleton.AddLog("[WXGroup RefreshWXGroupBtn] 2", null, null, null, null, null, XDebugColor.XDebug_None);
							base.uiBehaviour.m_BtnWXGroup.SetVisible(false);
							base.uiBehaviour.m_BtnWXGroupShare.SetVisible(true);
						}
						else
						{
							bool flag7 = XSingleton<PDatabase>.singleton.wxGroupInfo.data.errorCode == 0;
							if (flag7)
							{
								XSingleton<XDebug>.singleton.AddLog("[WXGroup RefreshWXGroupBtn] 3", null, null, null, null, null, XDebugColor.XDebug_None);
								base.uiBehaviour.m_BtnWXGroup.SetVisible(true);
								base.uiBehaviour.m_BtnWXGroup.ID = 1UL;
								base.uiBehaviour.m_BtnWXGroup.SetCaption(XSingleton<XStringTable>.singleton.GetString("GUILD_JOIN_WX_GROUP"));
								base.uiBehaviour.m_BtnWXGroupShare.SetVisible(false);
								base.uiBehaviour.m_WXGroupTip.SetVisible(true);
								base.uiBehaviour.m_WXGroupTip.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XSingleton<XStringTable>.singleton.GetString("GUILD_JOIN_WX_GROUP_TIP")));
							}
							else
							{
								XSingleton<XDebug>.singleton.AddLog("[WXGroup RefreshWXGroupBtn] 4", null, null, null, null, null, XDebugColor.XDebug_None);
								base.uiBehaviour.m_BtnWXGroup.SetVisible(false);
								base.uiBehaviour.m_BtnWXGroupShare.SetVisible(false);
							}
						}
					}
					else
					{
						bool flag8 = XSingleton<PDatabase>.singleton.wxGroupInfo != null && XSingleton<PDatabase>.singleton.wxGroupInfo.data.flag == "Success" && XSingleton<PDatabase>.singleton.wxGroupInfo.data.errorCode == -10007;
						if (flag8)
						{
							XSingleton<XDebug>.singleton.AddLog("[WXGroup RefreshWXGroupBtn] 5", null, null, null, null, null, XDebugColor.XDebug_None);
							bool flag9 = this._GuildDoc.Position == GuildPosition.GPOS_LEADER;
							if (flag9)
							{
								base.uiBehaviour.m_BtnWXGroup.ID = 0UL;
								base.uiBehaviour.m_BtnWXGroup.SetVisible(true);
								base.uiBehaviour.m_BtnWXGroup.SetCaption(XSingleton<XStringTable>.singleton.GetString("GUILD_CREATE_WX_GROUP"));
								base.uiBehaviour.m_BtnWXGroupShare.SetVisible(false);
								base.uiBehaviour.m_WXGroupTip.SetVisible(true);
								base.uiBehaviour.m_WXGroupTip.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XSingleton<XStringTable>.singleton.GetString("GUILD_CREATE_WX_GROUP_TIP")));
							}
							else
							{
								base.uiBehaviour.m_BtnWXGroup.SetVisible(false);
								base.uiBehaviour.m_BtnWXGroupShare.SetVisible(false);
							}
						}
						else
						{
							XSingleton<XDebug>.singleton.AddLog("[WXGroup RefreshWXGroupBtn] 6", null, null, null, null, null, XDebugColor.XDebug_None);
							base.uiBehaviour.m_BtnWXGroup.SetVisible(false);
							base.uiBehaviour.m_BtnWXGroupShare.SetVisible(false);
						}
					}
				}
			}
		}

		private bool _OnGuildWXGroupClick(IXUIButton btn)
		{
			bool flag = XSingleton<XUpdater.XUpdater>.singleton.XPlatform.CheckStatus("Weixin_Installed", "");
			bool flag2 = !flag;
			bool result;
			if (flag2)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("GUILD_WX_NOT_INSTALL"), "fece00");
				result = false;
			}
			else
			{
				int num = (int)btn.ID;
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary["unionID"] = this._GuildDoc.BasicData.uid.ToString();
				dictionary["chatRoomNickName"] = XSingleton<XAttributeMgr>.singleton.XPlayerData.Name;
				bool flag3 = num == 0;
				if (flag3)
				{
					XSingleton<PDatabase>.singleton.wxGroupCallbackType = WXGroupCallBackType.Guild;
					dictionary["chatRoomName"] = this._GuildDoc.BasicData.guildName;
					string param = Json.Serialize(dictionary);
					XSingleton<XUpdater.XUpdater>.singleton.XPlatform.CreateWXGroup(param);
				}
				else
				{
					bool flag4 = num == 1;
					if (flag4)
					{
						XSingleton<PDatabase>.singleton.wxGroupCallbackType = WXGroupCallBackType.Guild;
						string param2 = Json.Serialize(dictionary);
						XSingleton<XUpdater.XUpdater>.singleton.XPlatform.JoinWXGroup(param2);
					}
				}
				result = true;
			}
			return result;
		}

		public bool _OnGuildWXGroupShare(IXUIButton btn)
		{
			bool flag = XSingleton<XUpdater.XUpdater>.singleton.XPlatform.CheckStatus("Weixin_Installed", "");
			bool flag2 = !flag;
			bool result;
			if (flag2)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("GUILD_WX_NOT_INSTALL"), "fece00");
				result = false;
			}
			else
			{
				XSingleton<PDatabase>.singleton.wxGroupCallbackType = WXGroupCallBackType.Guild;
				Dictionary<string, object> dictionary = new Dictionary<string, object>();
				dictionary["msgType"] = 1;
				dictionary["subType"] = 1;
				dictionary["unionid"] = this._GuildDoc.BasicData.uid.ToString();
				dictionary["title"] = XSingleton<XGlobalConfig>.singleton.GetValue("GuildGroupShareTitle");
				dictionary["description"] = XSingleton<XGlobalConfig>.singleton.GetValue("GuildGroupShareContent");
				dictionary["mediaTagName"] = "MSG_INVITE";
				dictionary["imgUrl"] = XSingleton<XGlobalConfig>.singleton.GetValue("GuildGroupShareImgUrl");
				dictionary["messageExt"] = "messageExt";
				dictionary["msdkExtInfo"] = "msdkExtInfo";
				string param = Json.Serialize(dictionary);
				XSingleton<XUpdater.XUpdater>.singleton.XPlatform.ShareWithWXGroup(param);
				result = true;
			}
			return result;
		}

		public void GuildGroupResult(string apiId, string result, int error)
		{
			XSingleton<XDebug>.singleton.AddLog("[WXGroup GuildGroupResult]appiId:" + apiId + ",result:" + result, null, null, null, null, null, XDebugColor.XDebug_None);
			int num = 0;
			bool flag = !int.TryParse(apiId, out num);
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddLog("[WXGroup GuildGroupResult]appiId parse failed", null, null, null, null, null, XDebugColor.XDebug_None);
			}
			else
			{
				XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
				bool flag2 = num == 6;
				if (flag2)
				{
					bool flag3 = result == "Success";
					if (flag3)
					{
						specificDocument.QueryWXGroup();
					}
					else
					{
						this.HandleErrorCode(error);
					}
				}
				else
				{
					bool flag4 = num == 8;
					if (flag4)
					{
						bool flag5 = result == "Success";
						if (flag5)
						{
							specificDocument.QueryWXGroup();
						}
						else
						{
							this.HandleErrorCode(error);
						}
					}
				}
			}
		}

		private void HandleErrorCode(int errorCode)
		{
			string key = string.Format("GUILD_GROUP_ERROR_{0}", errorCode.ToString());
			XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString(key), "fece00");
		}

		public void RefreshQQGroupBtn()
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				bool flag2 = XSingleton<XLoginDocument>.singleton.Channel != XAuthorizationChannel.XAuthorization_QQ || !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Guild_Bind_Group);
				if (flag2)
				{
					base.uiBehaviour.m_BtnQQGroup.SetVisible(false);
					base.uiBehaviour.m_QQGroupName.SetVisible(false);
				}
				else
				{
					base.uiBehaviour.m_QQGroupName.SetVisible(true);
					XSingleton<XDebug>.singleton.AddLog("[QQGroup RefreshQQGroupBtn] 1", null, null, null, null, null, XDebugColor.XDebug_None);
					bool flag3 = this._GuildDoc.qqGroupBindStatus == GuildBindStatus.GBS_Owner || this._GuildDoc.qqGroupBindStatus == GuildBindStatus.GBS_Admin || this._GuildDoc.qqGroupBindStatus == GuildBindStatus.GBS_Member;
					if (flag3)
					{
						bool flag4 = this._GuildDoc.Position == GuildPosition.GPOS_LEADER;
						if (flag4)
						{
							XSingleton<XDebug>.singleton.AddLog("[QQGroup RefreshQQGroupBtn] 2", null, null, null, null, null, XDebugColor.XDebug_None);
							base.uiBehaviour.m_BtnQQGroup.SetVisible(true);
							base.uiBehaviour.m_BtnQQGroup.ID = 1UL;
							base.uiBehaviour.m_BtnQQGroup.SetCaption(XSingleton<XStringTable>.singleton.GetString("GUILD_UNBIND_QQ_GROUP"));
							base.uiBehaviour.m_QQGroupTip.SetVisible(false);
							base.uiBehaviour.m_QQGroupName.SetText(this._GuildDoc.qqGroupName);
						}
						else
						{
							XSingleton<XDebug>.singleton.AddLog("[QQGroup RefreshQQGroupBtn] 3", null, null, null, null, null, XDebugColor.XDebug_None);
							base.uiBehaviour.m_BtnQQGroup.SetVisible(false);
							base.uiBehaviour.m_QQGroupName.SetText(this._GuildDoc.qqGroupName);
						}
					}
					else
					{
						bool flag5 = this._GuildDoc.qqGroupBindStatus == GuildBindStatus.GBS_NotBind;
						if (flag5)
						{
							bool flag6 = this._GuildDoc.Position == GuildPosition.GPOS_LEADER;
							if (flag6)
							{
								XSingleton<XDebug>.singleton.AddLog("[QQGroup RefreshQQGroupBtn] 4", null, null, null, null, null, XDebugColor.XDebug_None);
								base.uiBehaviour.m_BtnQQGroup.ID = 2UL;
								base.uiBehaviour.m_BtnQQGroup.SetVisible(true);
								base.uiBehaviour.m_BtnQQGroup.SetCaption(XSingleton<XStringTable>.singleton.GetString("GUILD_BIND_QQ_GROUP"));
								base.uiBehaviour.m_QQGroupName.SetText(XSingleton<XStringTable>.singleton.GetString("GUILD_NOT_BIN_QQ_GROUP"));
								base.uiBehaviour.m_QQGroupTip.SetVisible(true);
								base.uiBehaviour.m_QQGroupTip.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XSingleton<XStringTable>.singleton.GetString("GUILD_CREATE_QQ_GROUP_TIP")));
							}
							else
							{
								XSingleton<XDebug>.singleton.AddLog("[QQGroup RefreshQQGroupBtn] 5", null, null, null, null, null, XDebugColor.XDebug_None);
								base.uiBehaviour.m_BtnQQGroup.SetVisible(false);
								base.uiBehaviour.m_QQGroupName.SetText(XSingleton<XStringTable>.singleton.GetString("GUILD_NOT_BIN_QQ_GROUP"));
								base.uiBehaviour.m_QQGroupTip.SetVisible(false);
							}
						}
						else
						{
							bool flag7 = this._GuildDoc.qqGroupBindStatus == GuildBindStatus.GBS_NotMember;
							if (flag7)
							{
								XSingleton<XDebug>.singleton.AddLog("[QQGroup RefreshQQGroupBtn] 6", null, null, null, null, null, XDebugColor.XDebug_None);
								base.uiBehaviour.m_BtnQQGroup.SetVisible(true);
								base.uiBehaviour.m_BtnQQGroup.ID = 3UL;
								base.uiBehaviour.m_BtnQQGroup.SetCaption(XSingleton<XStringTable>.singleton.GetString("GUILD_JOIN_QQ_GROUP"));
								base.uiBehaviour.m_QQGroupName.SetText(this._GuildDoc.qqGroupName);
								base.uiBehaviour.m_QQGroupTip.SetVisible(true);
								base.uiBehaviour.m_QQGroupTip.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XSingleton<XStringTable>.singleton.GetString("GUILD_JOIN_QQ_GROUP_TIP")));
							}
						}
					}
				}
			}
		}

		private bool _OnGuildQQGroupClick(IXUIButton btn)
		{
			int num = (int)btn.ID;
			bool flag = num == 2;
			if (flag)
			{
				this._GuildDoc.BindQQGroup();
			}
			else
			{
				bool flag2 = num == 3;
				if (flag2)
				{
					this._GuildDoc.JoinQQGroup();
				}
				else
				{
					bool flag3 = num == 1;
					if (flag3)
					{
						this._GuildDoc.UnbindQQGroup();
					}
				}
			}
			return true;
		}

		private XGuildHallDocument _HallDoc;

		private XGuildDocument _GuildDoc;

		private XGuildGrowthDocument _GrowthDoc;

		private XGuildEditAnnounceView _EditAnnounceView;

		private XGuildLogView _LogView;

		private XSubSysRedPointMgr redpointMgr = new XSubSysRedPointMgr();
	}
}
