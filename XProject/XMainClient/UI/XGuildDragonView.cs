using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020018A2 RID: 6306
	internal class XGuildDragonView : DlgBase<XGuildDragonView, XGuildDragonBehaviour>
	{
		// Token: 0x17003A02 RID: 14850
		// (get) Token: 0x060106AD RID: 67245 RVA: 0x00401D38 File Offset: 0x003FFF38
		public override string fileName
		{
			get
			{
				return "Guild/GuildBossDlg";
			}
		}

		// Token: 0x17003A03 RID: 14851
		// (get) Token: 0x060106AE RID: 67246 RVA: 0x00401D50 File Offset: 0x003FFF50
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003A04 RID: 14852
		// (get) Token: 0x060106AF RID: 67247 RVA: 0x00401D64 File Offset: 0x003FFF64
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003A05 RID: 14853
		// (get) Token: 0x060106B0 RID: 67248 RVA: 0x00401D78 File Offset: 0x003FFF78
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003A06 RID: 14854
		// (get) Token: 0x060106B1 RID: 67249 RVA: 0x00401D8C File Offset: 0x003FFF8C
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003A07 RID: 14855
		// (get) Token: 0x060106B2 RID: 67250 RVA: 0x00401DA0 File Offset: 0x003FFFA0
		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060106B3 RID: 67251 RVA: 0x00401DB4 File Offset: 0x003FFFB4
		protected override void Init()
		{
			base.Init();
			this.m_LeftTime = new XLeftTimeCounter(base.uiBehaviour.m_LeftTime, false);
			this._Doc = XDocuments.GetSpecificDocument<XGuildDragonDocument>(XGuildDragonDocument.uuID);
			this._Doc.GuildDragonView = this;
			base.uiBehaviour.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.GuildRankWrapContentItemUpdated));
		}

		// Token: 0x060106B4 RID: 67252 RVA: 0x00401E1C File Offset: 0x0040001C
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

		// Token: 0x060106B5 RID: 67253 RVA: 0x00401E90 File Offset: 0x00400090
		private bool JoinGuild(IXUIButton btn)
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			DlgBase<XGuildListView, XGuildListBehaviour>.singleton.SetVisibleWithAnimation(true, null);
			return true;
		}

		// Token: 0x060106B6 RID: 67254 RVA: 0x00401EC0 File Offset: 0x004000C0
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

		// Token: 0x060106B7 RID: 67255 RVA: 0x00401F4C File Offset: 0x0040014C
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

		// Token: 0x060106B8 RID: 67256 RVA: 0x00402030 File Offset: 0x00400230
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

		// Token: 0x060106B9 RID: 67257 RVA: 0x00402136 File Offset: 0x00400336
		protected override void OnUnload()
		{
			this.m_LeftTime = null;
			this._Doc.GuildDragonView = null;
			base.OnUnload();
		}

		// Token: 0x060106BA RID: 67258 RVA: 0x00402154 File Offset: 0x00400354
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

		// Token: 0x060106BB RID: 67259 RVA: 0x004021B0 File Offset: 0x004003B0
		private void ShowTimeSection()
		{
			int num = 0;
			int num2 = 0;
			this._Doc.GetWorldBossTime(ref num, ref num2);
			string arg = string.Format("{0}:{1}", (num / 100).ToString("D2"), (num % 100).ToString("D2"));
			string arg2 = string.Format("{0}:{1}", (num2 / 100).ToString("D2"), (num2 % 100).ToString("D2"));
			base.uiBehaviour.m_OpenTime.SetText(string.Format(XStringDefineProxy.GetString("WORLDBOSS_OPEN_TIME"), arg, arg2));
		}

		// Token: 0x060106BC RID: 67260 RVA: 0x00402252 File Offset: 0x00400452
		public void SetLeftTime(float time, uint BossHp)
		{
			this.m_LeftTime.SetLeftTime(time, -1);
			base.uiBehaviour.m_LeftTime.SetVisible(time > 0f);
			this.UpdateLeftTimeState(time, BossHp);
		}

		// Token: 0x060106BD RID: 67261 RVA: 0x00402288 File Offset: 0x00400488
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

		// Token: 0x060106BE RID: 67262 RVA: 0x00402394 File Offset: 0x00400594
		private bool OnCloseClick(IXUIButton button)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x060106BF RID: 67263 RVA: 0x004023B0 File Offset: 0x004005B0
		private bool OnRankClick(IXUIButton button)
		{
			DlgBase<XRankView, XRankBehaviour>.singleton.ShowRank(XSysDefine.XSys_Rank_GuildBoss);
			return true;
		}

		// Token: 0x060106C0 RID: 67264 RVA: 0x004023D4 File Offset: 0x004005D4
		private bool OnRewardClick(IXUIButton button)
		{
			base.uiBehaviour.m_RewardPanel.SetActive(true);
			XSingleton<XBossRewardDlg>.singleton.Init(base.uiBehaviour.m_RewardPanel);
			return true;
		}

		// Token: 0x060106C1 RID: 67265 RVA: 0x00402410 File Offset: 0x00400610
		private bool OnSubscribeClick(IXUIButton button)
		{
			this.SubscribebuttonID = button.ID;
			PushSubscribeTable.RowData pushSubscribe = XPushSubscribeDocument.GetPushSubscribe(PushSubscribeOptions.GuildBoss);
			XSingleton<UiUtility>.singleton.ShowModalDialog((button.ID == 0UL) ? pushSubscribe.SubscribeDescription : pushSubscribe.CancelDescription, XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this.ReqSubscribeChange));
			return true;
		}

		// Token: 0x060106C2 RID: 67266 RVA: 0x00402478 File Offset: 0x00400678
		private bool ReqSubscribeChange(IXUIButton button)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			XPushSubscribeDocument specificDocument = XDocuments.GetSpecificDocument<XPushSubscribeDocument>(XPushSubscribeDocument.uuID);
			specificDocument.ReqSetSubscribe(PushSubscribeOptions.GuildBoss, this.SubscribebuttonID == 0UL);
			return true;
		}

		// Token: 0x060106C3 RID: 67267 RVA: 0x004024B4 File Offset: 0x004006B4
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

		// Token: 0x060106C4 RID: 67268 RVA: 0x00402574 File Offset: 0x00400774
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

		// Token: 0x060106C5 RID: 67269 RVA: 0x00402668 File Offset: 0x00400868
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

		// Token: 0x060106C6 RID: 67270 RVA: 0x00402738 File Offset: 0x00400938
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

		// Token: 0x060106C7 RID: 67271 RVA: 0x004028B4 File Offset: 0x00400AB4
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

		// Token: 0x060106C8 RID: 67272 RVA: 0x00402AE8 File Offset: 0x00400CE8
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

		// Token: 0x060106C9 RID: 67273 RVA: 0x00402BB4 File Offset: 0x00400DB4
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

		// Token: 0x060106CA RID: 67274 RVA: 0x002548EE File Offset: 0x00252AEE
		private void OnPrivilegeClick(IXUISprite btn)
		{
			DlgBase<XWelfareView, XWelfareBehaviour>.singleton.CheckActiveMemberPrivilege(MemberPrivilege.KingdomPrivilege_Commerce);
		}

		// Token: 0x0400768F RID: 30351
		public static readonly int REWARD_COUNT = 3;

		// Token: 0x04007690 RID: 30352
		private XGuildDragonDocument _Doc;

		// Token: 0x04007691 RID: 30353
		private XLeftTimeCounter m_LeftTime;

		// Token: 0x04007692 RID: 30354
		private uint mBossHp = 0U;

		// Token: 0x04007693 RID: 30355
		private ulong SubscribebuttonID = 0UL;
	}
}
