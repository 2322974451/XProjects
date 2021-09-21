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
	// Token: 0x020018A6 RID: 6310
	internal class XGuildHallView : DlgBase<XGuildHallView, XGuildHallBehaviour>
	{
		// Token: 0x17003A08 RID: 14856
		// (get) Token: 0x060106DD RID: 67293 RVA: 0x004037D8 File Offset: 0x004019D8
		public XGuildLogView LogView
		{
			get
			{
				return this._LogView;
			}
		}

		// Token: 0x17003A09 RID: 14857
		// (get) Token: 0x060106DE RID: 67294 RVA: 0x004037F0 File Offset: 0x004019F0
		public XGuildEditAnnounceView EditAnnounceView
		{
			get
			{
				return this._EditAnnounceView;
			}
		}

		// Token: 0x17003A0A RID: 14858
		// (get) Token: 0x060106DF RID: 67295 RVA: 0x00403808 File Offset: 0x00401A08
		// (set) Token: 0x060106E0 RID: 67296 RVA: 0x00403810 File Offset: 0x00401A10
		public bool Deprecated { get; set; }

		// Token: 0x17003A0B RID: 14859
		// (get) Token: 0x060106E1 RID: 67297 RVA: 0x0040381C File Offset: 0x00401A1C
		public override string fileName
		{
			get
			{
				return "Guild/GuildHallDlg";
			}
		}

		// Token: 0x17003A0C RID: 14860
		// (get) Token: 0x060106E2 RID: 67298 RVA: 0x00403834 File Offset: 0x00401A34
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003A0D RID: 14861
		// (get) Token: 0x060106E3 RID: 67299 RVA: 0x00403848 File Offset: 0x00401A48
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003A0E RID: 14862
		// (get) Token: 0x060106E4 RID: 67300 RVA: 0x0040385C File Offset: 0x00401A5C
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003A0F RID: 14863
		// (get) Token: 0x060106E5 RID: 67301 RVA: 0x00403870 File Offset: 0x00401A70
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003A10 RID: 14864
		// (get) Token: 0x060106E6 RID: 67302 RVA: 0x00403884 File Offset: 0x00401A84
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003A11 RID: 14865
		// (get) Token: 0x060106E7 RID: 67303 RVA: 0x00403898 File Offset: 0x00401A98
		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060106E8 RID: 67304 RVA: 0x004038AC File Offset: 0x00401AAC
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

		// Token: 0x060106E9 RID: 67305 RVA: 0x004039E1 File Offset: 0x00401BE1
		protected override void OnUnload()
		{
			this._HallDoc.GuildHallView = null;
			DlgHandlerBase.EnsureUnload<XGuildEditAnnounceView>(ref this._EditAnnounceView);
			DlgHandlerBase.EnsureUnload<XGuildLogView>(ref this._LogView);
			XSingleton<XGameSysMgr>.singleton.RegisterSubSysRedPointMgr(XSysDefine.XSys_GuildHall, null);
			base.OnUnload();
		}

		// Token: 0x060106EA RID: 67306 RVA: 0x00403A20 File Offset: 0x00401C20
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

		// Token: 0x060106EB RID: 67307 RVA: 0x00403D04 File Offset: 0x00401F04
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

		// Token: 0x060106EC RID: 67308 RVA: 0x00403E90 File Offset: 0x00402090
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

		// Token: 0x060106ED RID: 67309 RVA: 0x00403EC8 File Offset: 0x004020C8
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

		// Token: 0x060106EE RID: 67310 RVA: 0x00403F14 File Offset: 0x00402114
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

		// Token: 0x060106EF RID: 67311 RVA: 0x00403F4C File Offset: 0x0040214C
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

		// Token: 0x060106F0 RID: 67312 RVA: 0x00403F84 File Offset: 0x00402184
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

		// Token: 0x060106F1 RID: 67313 RVA: 0x00403FBC File Offset: 0x004021BC
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

		// Token: 0x060106F2 RID: 67314 RVA: 0x00403FF4 File Offset: 0x004021F4
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

		// Token: 0x060106F3 RID: 67315 RVA: 0x00404120 File Offset: 0x00402320
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

		// Token: 0x060106F4 RID: 67316 RVA: 0x004041C4 File Offset: 0x004023C4
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

		// Token: 0x060106F5 RID: 67317 RVA: 0x004044F0 File Offset: 0x004026F0
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

		// Token: 0x060106F6 RID: 67318 RVA: 0x004046EC File Offset: 0x004028EC
		private bool _OnCloseBtnClick(IXUIButton go)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x060106F7 RID: 67319 RVA: 0x00404708 File Offset: 0x00402908
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

		// Token: 0x060106F8 RID: 67320 RVA: 0x0040479C File Offset: 0x0040299C
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

		// Token: 0x060106F9 RID: 67321 RVA: 0x00404830 File Offset: 0x00402A30
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

		// Token: 0x060106FA RID: 67322 RVA: 0x004048C0 File Offset: 0x00402AC0
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

		// Token: 0x060106FB RID: 67323 RVA: 0x004048F8 File Offset: 0x00402AF8
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

		// Token: 0x060106FC RID: 67324 RVA: 0x00404958 File Offset: 0x00402B58
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

		// Token: 0x060106FD RID: 67325 RVA: 0x00404998 File Offset: 0x00402B98
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

		// Token: 0x060106FE RID: 67326 RVA: 0x004049D0 File Offset: 0x00402BD0
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

		// Token: 0x060106FF RID: 67327 RVA: 0x00404A28 File Offset: 0x00402C28
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

		// Token: 0x06010700 RID: 67328 RVA: 0x00404A7C File Offset: 0x00402C7C
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

		// Token: 0x06010701 RID: 67329 RVA: 0x00404AD0 File Offset: 0x00402CD0
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

		// Token: 0x06010702 RID: 67330 RVA: 0x00404B08 File Offset: 0x00402D08
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

		// Token: 0x06010703 RID: 67331 RVA: 0x00404B40 File Offset: 0x00402D40
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

		// Token: 0x06010704 RID: 67332 RVA: 0x00404B84 File Offset: 0x00402D84
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

		// Token: 0x06010705 RID: 67333 RVA: 0x00404BBC File Offset: 0x00402DBC
		private bool _OnRankBtnClick(IXUIButton go)
		{
			DlgBase<XRankView, XRankBehaviour>.singleton.ShowRank(XSysDefine.XSys_Rank_Guild);
			return true;
		}

		// Token: 0x06010706 RID: 67334 RVA: 0x00404BE0 File Offset: 0x00402DE0
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

		// Token: 0x06010707 RID: 67335 RVA: 0x00404C34 File Offset: 0x00402E34
		private bool _OnPortraitChanged(IXUIButton btn)
		{
			int portraitIndex = DlgBase<XGuildPortraitView, XGuildPortraitBehaviour>.singleton.PortraitIndex;
			this._HallDoc.ReqEditPortrait(portraitIndex);
			return true;
		}

		// Token: 0x06010708 RID: 67336 RVA: 0x00404C5F File Offset: 0x00402E5F
		public void RefreshPortrait()
		{
			base.uiBehaviour.m_Portrait.SetSprite(XGuildDocument.GetPortraitName(this._GuildDoc.BasicData.portraitIndex));
		}

		// Token: 0x06010709 RID: 67337 RVA: 0x00404C88 File Offset: 0x00402E88
		public void RefreshAnnouncement()
		{
			XGuildBasicData basicData = this._GuildDoc.BasicData;
			base.uiBehaviour.m_Annoucement.SetText(basicData.announcement);
		}

		// Token: 0x0601070A RID: 67338 RVA: 0x00404CBC File Offset: 0x00402EBC
		public void RefreshButtonsState()
		{
			base.uiBehaviour.m_BtnApprove.SetVisible(this._GuildDoc.IHavePermission(GuildPermission.GPEM_APPROVAL));
			base.uiBehaviour.m_BtnEditAnnounce.SetVisible(this._GuildDoc.IHavePermission(GuildPermission.GPEM_ANNOUNCEMENT));
			base.uiBehaviour.m_BtnEditPortrait.SetVisible(this._GuildDoc.IHavePermission(GuildPermission.GPEM_SETTINGS));
			this.RefreshWXGroupBtn();
			this.RefreshQQGroupBtn();
			this.RefreshRedPoints();
		}

		// Token: 0x0601070B RID: 67339 RVA: 0x00404D36 File Offset: 0x00402F36
		public void RefreshRedPoints()
		{
			this.redpointMgr.UpdateRedPointUI();
		}

		// Token: 0x0601070C RID: 67340 RVA: 0x00404D48 File Offset: 0x00402F48
		public void Refresh()
		{
			XGuildBasicData basicData = this._GuildDoc.BasicData;
			base.uiBehaviour.m_BasicInfoDisplay.Set(basicData);
			this.RefreshAnnouncement();
			this.RefreshButtonsState();
		}

		// Token: 0x0601070D RID: 67341 RVA: 0x00404D82 File Offset: 0x00402F82
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

		// Token: 0x0601070E RID: 67342 RVA: 0x00404DC0 File Offset: 0x00402FC0
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

		// Token: 0x0601070F RID: 67343 RVA: 0x004051E4 File Offset: 0x004033E4
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

		// Token: 0x06010710 RID: 67344 RVA: 0x00405310 File Offset: 0x00403510
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

		// Token: 0x06010711 RID: 67345 RVA: 0x00405464 File Offset: 0x00403664
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

		// Token: 0x06010712 RID: 67346 RVA: 0x00405530 File Offset: 0x00403730
		private void HandleErrorCode(int errorCode)
		{
			string key = string.Format("GUILD_GROUP_ERROR_{0}", errorCode.ToString());
			XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString(key), "fece00");
		}

		// Token: 0x06010713 RID: 67347 RVA: 0x0040556C File Offset: 0x0040376C
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

		// Token: 0x06010714 RID: 67348 RVA: 0x00405940 File Offset: 0x00403B40
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

		// Token: 0x040076C3 RID: 30403
		private XGuildHallDocument _HallDoc;

		// Token: 0x040076C4 RID: 30404
		private XGuildDocument _GuildDoc;

		// Token: 0x040076C5 RID: 30405
		private XGuildGrowthDocument _GrowthDoc;

		// Token: 0x040076C6 RID: 30406
		private XGuildEditAnnounceView _EditAnnounceView;

		// Token: 0x040076C7 RID: 30407
		private XGuildLogView _LogView;

		// Token: 0x040076C8 RID: 30408
		private XSubSysRedPointMgr redpointMgr = new XSubSysRedPointMgr();
	}
}
