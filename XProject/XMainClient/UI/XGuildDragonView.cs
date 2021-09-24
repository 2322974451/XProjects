using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XGuildDragonView : DlgBase<XGuildDragonView, XGuildDragonBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Guild/GuildBossDlg";
			}
		}

		public override int layer
		{
			get
			{
				return 1;
			}
		}

		public override bool pushstack
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

		public override bool autoload
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
			base.Init();
			this.m_LeftTime = new XLeftTimeCounter(base.uiBehaviour.m_LeftTime, false);
			this._Doc = XDocuments.GetSpecificDocument<XGuildDragonDocument>(XGuildDragonDocument.uuID);
			this._Doc.GuildDragonView = this;
			base.uiBehaviour.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.GuildRankWrapContentItemUpdated));
		}

		public void ShowGuildBossView()
		{
			XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
			bool flag = !specificDocument.bInGuild;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("MulActivity_ShowTips3"), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this.JoinGuild));
			}
			else
			{
				bool flag2 = !base.IsVisible();
				if (flag2)
				{
					this.SetVisibleWithAnimation(true, null);
				}
			}
		}

		private bool JoinGuild(IXUIButton btn)
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			DlgBase<XGuildListView, XGuildListBehaviour>.singleton.SetVisibleWithAnimation(true, null);
			return true;
		}

		protected override void OnShow()
		{
			base.OnShow();
			this._Doc.ReqGuildBossInfo();
			this._Doc.ReqBossRoleRank(false);
			this._Doc.ReqWorldBossState();
			base.uiBehaviour.m_LeftTime.SetVisible(false);
			base.uiBehaviour.m_LeftTimeHint.gameObject.SetActive(false);
			base.uiBehaviour.m_RewardPanel.SetActive(false);
			this.RefreshPrivilegeInfo();
			this.ShowTimeSection();
			this.RefreshSubscribe();
		}

		private void RefreshPrivilegeInfo()
		{
			XWelfareDocument specificDocument = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
			base.uiBehaviour.m_PrivilegeIcon.SetGrey(specificDocument.IsOwnMemberPrivilege(MemberPrivilege.KingdomPrivilege_Commerce));
			base.uiBehaviour.m_PrivilegeIcon.SetSprite(specificDocument.GetMemberPrivilegeIcon(MemberPrivilege.KingdomPrivilege_Commerce));
			base.uiBehaviour.m_PrivilegeName.SetEnabled(specificDocument.IsOwnMemberPrivilege(MemberPrivilege.KingdomPrivilege_Commerce));
			PayMemberTable.RowData memberPrivilegeConfig = specificDocument.GetMemberPrivilegeConfig(MemberPrivilege.KingdomPrivilege_Commerce);
			bool flag = memberPrivilegeConfig != null;
			if (flag)
			{
				BuffTable.RowData buffData = XSingleton<XBuffTemplateManager>.singleton.GetBuffData((int)memberPrivilegeConfig.guildBossBuffid[0], (int)memberPrivilegeConfig.guildBossBuffid[1]);
				bool flag2 = buffData != null;
				if (flag2)
				{
					base.uiBehaviour.m_PrivilegeName.SetText(XStringDefineProxy.GetString("WORLDBOSS_PRIVILEGE_BUFF", new object[]
					{
						buffData.BuffName
					}));
				}
				base.uiBehaviour.m_PrivilegeIcon.SetVisible(buffData != null);
			}
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_BtnClose.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClick));
			base.uiBehaviour.m_BtnRank.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRankClick));
			base.uiBehaviour.m_BtnGoBattle.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGoBattleClick));
			base.uiBehaviour.m_BtnReward.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRewardClick));
			base.uiBehaviour.m_BtnSubscribe.ID = 0UL;
			base.uiBehaviour.m_BtnSubscribe.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSubscribeClick));
			base.uiBehaviour.m_BtnCancelSubscribe.ID = 1UL;
			base.uiBehaviour.m_BtnCancelSubscribe.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSubscribeClick));
			base.uiBehaviour.m_Privilege.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnPrivilegeClick));
		}

		protected override void OnUnload()
		{
			this.m_LeftTime = null;
			this._Doc.GuildDragonView = null;
			base.OnUnload();
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
			bool flag = this.m_LeftTime != null;
			if (flag)
			{
				this.m_LeftTime.Update();
				bool flag2 = this.m_LeftTime.GetLeftTime() <= 0;
				if (flag2)
				{
					this.UpdateLeftTimeState(0f, this.mBossHp);
				}
			}
		}

		private void ShowTimeSection()
		{
			int num = 0;
			int num2 = 0;
			this._Doc.GetWorldBossTime(ref num, ref num2);
			string arg = string.Format("{0}:{1}", (num / 100).ToString("D2"), (num % 100).ToString("D2"));
			string arg2 = string.Format("{0}:{1}", (num2 / 100).ToString("D2"), (num2 % 100).ToString("D2"));
			base.uiBehaviour.m_OpenTime.SetText(string.Format(XStringDefineProxy.GetString("WORLDBOSS_OPEN_TIME"), arg, arg2));
		}

		public void SetLeftTime(float time, uint BossHp)
		{
			this.m_LeftTime.SetLeftTime(time, -1);
			base.uiBehaviour.m_LeftTime.SetVisible(time > 0f);
			this.UpdateLeftTimeState(time, BossHp);
		}

		private void UpdateLeftTimeState(float time, uint BossHp)
		{
			this.mBossHp = BossHp;
			bool flag = time <= 0f;
			if (flag)
			{
				base.uiBehaviour.m_LeftTimeHint.gameObject.SetActive(true);
				base.uiBehaviour.m_LeftTime.gameObject.SetActive(false);
				bool flag2 = BossHp > 0U;
				if (flag2)
				{
					base.uiBehaviour.m_LeftTimeHint.SetText(XStringDefineProxy.GetString("GUILD_BOSS_CONDITION_TIME"));
				}
				else
				{
					base.uiBehaviour.m_LeftTimeHint.SetText(XStringDefineProxy.GetString("GUILD_BOSS_CONDITION_BOSSDIE"));
				}
			}
			else
			{
				base.uiBehaviour.m_LeftTimeHint.gameObject.SetActive(false);
				bool flag3 = BossHp <= 0U;
				if (flag3)
				{
					base.uiBehaviour.m_LeftTimeHint.gameObject.SetActive(true);
					base.uiBehaviour.m_LeftTime.gameObject.SetActive(false);
					base.uiBehaviour.m_LeftTimeHint.SetText(XStringDefineProxy.GetString("GUILD_BOSS_CONDITION_BOSSDIE"));
				}
			}
		}

		private bool OnCloseClick(IXUIButton button)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private bool OnRankClick(IXUIButton button)
		{
			DlgBase<XRankView, XRankBehaviour>.singleton.ShowRank(XSysDefine.XSys_Rank_GuildBoss);
			return true;
		}

		private bool OnRewardClick(IXUIButton button)
		{
			base.uiBehaviour.m_RewardPanel.SetActive(true);
			XSingleton<XBossRewardDlg>.singleton.Init(base.uiBehaviour.m_RewardPanel);
			return true;
		}

		private bool OnSubscribeClick(IXUIButton button)
		{
			this.SubscribebuttonID = button.ID;
			PushSubscribeTable.RowData pushSubscribe = XPushSubscribeDocument.GetPushSubscribe(PushSubscribeOptions.GuildBoss);
			XSingleton<UiUtility>.singleton.ShowModalDialog((button.ID == 0UL) ? pushSubscribe.SubscribeDescription : pushSubscribe.CancelDescription, XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this.ReqSubscribeChange));
			return true;
		}

		private bool ReqSubscribeChange(IXUIButton button)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			XPushSubscribeDocument specificDocument = XDocuments.GetSpecificDocument<XPushSubscribeDocument>(XPushSubscribeDocument.uuID);
			specificDocument.ReqSetSubscribe(PushSubscribeOptions.GuildBoss, this.SubscribebuttonID == 0UL);
			return true;
		}

		public void RefreshSubscribe()
		{
			PushSubscribeTable.RowData pushSubscribe = XPushSubscribeDocument.GetPushSubscribe(PushSubscribeOptions.GuildBoss);
			XPushSubscribeDocument specificDocument = XDocuments.GetSpecificDocument<XPushSubscribeDocument>(XPushSubscribeDocument.uuID);
			bool flag = XSingleton<XClientNetwork>.singleton.AccountType == LoginType.LGOIN_WECHAT_PF && pushSubscribe.IsShow && specificDocument.OptionsDefault != null && specificDocument.OptionsDefault.Count != 0;
			if (flag)
			{
				bool curSubscribeStatus = specificDocument.GetCurSubscribeStatus(PushSubscribeOptions.GuildBoss);
				base.uiBehaviour.m_BtnSubscribe.gameObject.SetActive(!curSubscribeStatus);
				base.uiBehaviour.m_BtnCancelSubscribe.gameObject.SetActive(curSubscribeStatus);
			}
			else
			{
				base.uiBehaviour.m_BtnSubscribe.gameObject.SetActive(false);
				base.uiBehaviour.m_BtnCancelSubscribe.gameObject.SetActive(false);
			}
		}

		private bool OnGoBattleClick(IXUIButton button)
		{
			bool flag = this.m_LeftTime.GetLeftTime() > 0;
			bool result;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("GUILD_BOSS_CONDITION_TIME_NOTSTART"), "fece00");
				result = false;
			}
			else
			{
				bool flag2 = this.mBossHp <= 0U;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("GUILD_BOSS_CONDITION_BOSSDIE_HINT"), "fece00");
					result = false;
				}
				else
				{
					bool flag3 = XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_GuildDragon);
					if (flag3)
					{
						bool flag4 = XTeamDocument.GoSingleBattleBeforeNeed(new ButtonClickEventHandler(this.OnGoBattleClick), button);
						if (flag4)
						{
							return true;
						}
						this._Doc.ReqEnterScene();
					}
					else
					{
						int sysOpenLevel = XSingleton<XGameSysMgr>.singleton.GetSysOpenLevel(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_GuildDragon));
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ERR_GUILD_DRAGONOPEN", new object[]
						{
							sysOpenLevel
						}), "fece00");
					}
					result = true;
				}
			}
			return result;
		}

		public void RefreshGuildRoleRank()
		{
			List<XBaseRankInfo> rankList = this._Doc.PersonRankList.rankList;
			bool flag = rankList.Count == 0;
			if (flag)
			{
				base.uiBehaviour.m_RankPanel_EmptyRank.gameObject.SetActive(true);
				base.uiBehaviour.m_RankPanel_EmptyRank.SetText(XStringDefineProxy.GetString("GUILD_BOSS_EMPTY_RANK"));
				base.uiBehaviour.m_WrapContent.gameObject.SetActive(false);
			}
			else
			{
				base.uiBehaviour.m_RankPanel_EmptyRank.gameObject.SetActive(false);
				base.uiBehaviour.m_WrapContent.gameObject.SetActive(true);
				base.uiBehaviour.m_WrapContent.SetContentCount(rankList.Count, false);
				base.uiBehaviour.m_ScrollView.ResetPosition();
			}
		}

		private void GuildRankWrapContentItemUpdated(Transform t, int index)
		{
			List<XBaseRankInfo> rankList = this._Doc.PersonRankList.rankList;
			bool flag = index < 0 || index >= rankList.Count;
			if (!flag)
			{
				XWorldBossDamageRankInfo xworldBossDamageRankInfo = rankList[index] as XWorldBossDamageRankInfo;
				bool flag2 = xworldBossDamageRankInfo == null;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("XGuildDragonView.GuildRankWrapContentItemUpdated  is null ", null, null, null, null, null);
				}
				else
				{
					IXUISprite ixuisprite = t.FindChild("Rank").GetComponent("XUISprite") as IXUISprite;
					IXUILabel ixuilabel = t.FindChild("Rank3").GetComponent("XUILabel") as IXUILabel;
					IXUILabel ixuilabel2 = t.FindChild("Name").GetComponent("XUILabel") as IXUILabel;
					IXUILabel ixuilabel3 = t.FindChild("shanghai").GetComponent("XUILabel") as IXUILabel;
					ixuilabel3.SetText(XSingleton<UiUtility>.singleton.NumberFormatBillion((ulong)xworldBossDamageRankInfo.damage));
					ixuilabel2.SetText(xworldBossDamageRankInfo.name);
					switch (index)
					{
					case 0:
						ixuisprite.spriteName = "N1";
						ixuisprite.SetVisible(true);
						break;
					case 1:
						ixuisprite.spriteName = "N2";
						ixuisprite.SetVisible(true);
						break;
					case 2:
						ixuisprite.spriteName = "N3";
						ixuisprite.SetVisible(true);
						break;
					default:
						ixuisprite.SetVisible(false);
						ixuilabel.SetText((index + 1).ToString());
						break;
					}
				}
			}
		}

		public void _SetMyRankFrame(XBaseRankList list)
		{
			bool flag = list.rankList.Count == 0;
			if (flag)
			{
				base.uiBehaviour.outofRange.SetActive(false);
				base.uiBehaviour.rankInfo.SetActive(false);
			}
			else
			{
				XBaseRankInfo latestMyRankInfo = list.GetLatestMyRankInfo();
				bool flag2 = latestMyRankInfo == null || latestMyRankInfo.id == 0UL;
				if (flag2)
				{
					base.uiBehaviour.rankInfo.SetActive(false);
				}
				else
				{
					base.uiBehaviour.rankInfo.SetActive(true);
					IXUISprite ixuisprite = base.uiBehaviour.rankInfo.transform.FindChild("Rank").GetComponent("XUISprite") as IXUISprite;
					IXUILabel ixuilabel = base.uiBehaviour.rankInfo.transform.FindChild("Name").gameObject.GetComponent("XUILabel") as IXUILabel;
					IXUILabel ixuilabel2 = base.uiBehaviour.rankInfo.transform.FindChild("shanghai").gameObject.GetComponent("XUILabel") as IXUILabel;
					IXUILabel ixuilabel3 = base.uiBehaviour.rankInfo.transform.FindChild("Rank3").gameObject.GetComponent("XUILabel") as IXUILabel;
					ixuilabel.SetText(latestMyRankInfo.name);
					XWorldBossDamageRankInfo xworldBossDamageRankInfo = latestMyRankInfo as XWorldBossDamageRankInfo;
					float num = 0f;
					bool flag3 = xworldBossDamageRankInfo != null;
					if (flag3)
					{
						num = xworldBossDamageRankInfo.damage;
					}
					ixuilabel2.SetText(XSingleton<UiUtility>.singleton.NumberFormatBillion((ulong)num));
					switch (latestMyRankInfo.rank)
					{
					case 0U:
						ixuisprite.spriteName = "N1";
						ixuisprite.SetVisible(true);
						break;
					case 1U:
						ixuisprite.spriteName = "N2";
						ixuisprite.SetVisible(true);
						break;
					case 2U:
						ixuisprite.spriteName = "N3";
						ixuisprite.SetVisible(true);
						break;
					default:
						ixuisprite.SetVisible(false);
						ixuilabel3.SetText((latestMyRankInfo.rank + 1U).ToString());
						break;
					}
					base.uiBehaviour.outofRange.SetActive(latestMyRankInfo.rank == XRankDocument.INVALID_RANK);
				}
			}
		}

		public void ShowDropList(int order, string title, uint listDropList0, uint listDropList1)
		{
			GameObject gameObject = base.uiBehaviour.transform.FindChild("Bg/Frame/DropFrame/Item" + order).gameObject;
			bool flag = listDropList0 == uint.MaxValue && listDropList1 == uint.MaxValue;
			if (flag)
			{
				gameObject.SetActive(false);
			}
			else
			{
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, (int)listDropList0, (int)listDropList1, false);
				IXUISprite ixuisprite = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)listDropList0;
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
				IXUILabel ixuilabel = gameObject.transform.FindChild("ssssss").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(title);
			}
		}

		public void ShowCurrentBoss(AskGuildBossInfoRes oRes, string BossNamePrefix, uint BossID, uint rank)
		{
			string name = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID(BossID).Name;
			base.uiBehaviour.m_BossName.SetText(BossNamePrefix + name);
			string text = string.Empty;
			bool flag = oRes.needguildlvl > 0U;
			if (flag)
			{
				text += string.Format(XStringDefineProxy.GetString("GUILD_BOSS_CONDITION_RANK"), rank);
			}
			bool flag2 = !string.IsNullOrEmpty(text);
			if (flag2)
			{
				text += ",";
			}
			bool flag3 = oRes.needKillBossId > 0U;
			if (flag3)
			{
				text += string.Format(XStringDefineProxy.GetString("GUILD_BOSS_CONDITION_BOSS"), new object[0]);
			}
			base.uiBehaviour.m_Condition.SetText(text);
			bool flag4 = oRes.needguildlvl == 0U && oRes.needKillBossId == 0U;
			if (flag4)
			{
				base.uiBehaviour.m_ConditionTitle.SetText("");
			}
		}

		private void OnPrivilegeClick(IXUISprite btn)
		{
			DlgBase<XWelfareView, XWelfareBehaviour>.singleton.CheckActiveMemberPrivilege(MemberPrivilege.KingdomPrivilege_Commerce);
		}

		public static readonly int REWARD_COUNT = 3;

		private XGuildDragonDocument _Doc;

		private XLeftTimeCounter m_LeftTime;

		private uint mBossHp = 0U;

		private ulong SubscribebuttonID = 0UL;
	}
}
