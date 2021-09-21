using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200187F RID: 6271
	internal class XWorldBossDamageRankHandler : DlgHandlerBase, IRankView
	{
		// Token: 0x0601050A RID: 66826 RVA: 0x003F2FCC File Offset: 0x003F11CC
		protected override void Init()
		{
			Transform transform = base.PanelObject.transform.FindChild("Bg/ScrollView");
			this.m_ScrollView = (transform.GetComponent("XUIScrollView") as IXUIScrollView);
			transform = transform.FindChild("WrapContent");
			this.m_WrapContent = (transform.GetComponent("XUIWrapContent") as IXUIWrapContent);
			transform = transform.FindChild("RankTpl");
			this.m_RankItemPool.SetupPool(transform.parent.parent.gameObject, transform.gameObject, 2U, false);
			transform = base.PanelObject.transform.FindChild("Bg/MyInfo");
			bool flag = transform != null;
			if (flag)
			{
				this.m_MyInfo = transform.gameObject;
				this.m_MyRank = (transform.FindChild("Rank").GetComponent("XUILabel") as IXUILabel);
				this.m_MyDamage = (transform.FindChild("Value").GetComponent("XUILabel") as IXUILabel);
				this.m_MyName = (this.m_MyInfo.transform.FindChild("Name").GetComponent("XUILabel") as IXUILabel);
			}
			this.m_MyGuildInfo = base.PanelObject.transform.Find("Bg/MyGuildInfo").gameObject;
			this.m_MyGuildName = (this.m_MyGuildInfo.transform.FindChild("Name").GetComponent("XUILabel") as IXUILabel);
			this.m_GuildMemberNum = (base.PanelObject.transform.Find("Bg/GuildMemberNum").GetComponent("XUILabel") as IXUILabel);
			transform = base.PanelObject.transform.FindChild("Bg/TabList/TabTpl");
			this.m_TabPool.SetupPool(transform.parent.gameObject, transform.gameObject, 2U, false);
			this.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.RankWrapContentItemUpdated));
			this.showMaxCount = int.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("WorldBossBattleDamageRankCount"));
		}

		// Token: 0x0601050B RID: 66827 RVA: 0x003F31CC File Offset: 0x003F13CC
		public override void RegisterEvent()
		{
			Transform transform = base.PanelObject.transform.FindChild("Bg/Close");
			bool flag = transform != null;
			if (flag)
			{
				IXUIButton ixuibutton = transform.GetComponent("XUIButton") as IXUIButton;
				ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			}
		}

		// Token: 0x0601050C RID: 66828 RVA: 0x003F3224 File Offset: 0x003F1424
		public void SetupRanks(List<RankeType> rankTypes, bool inBattle)
		{
			this.bInBattle = inBattle;
			this.m_TabPool.ReturnAll(false);
			this.m_RankTypes = rankTypes;
			bool flag = rankTypes.Count == 0;
			if (!flag)
			{
				Vector3 tplPos = this.m_TabPool.TplPos;
				for (int i = 0; i < rankTypes.Count; i++)
				{
					GameObject gameObject = this.m_TabPool.FetchGameObject(false);
					gameObject.transform.localPosition = new Vector3(((float)i - (float)rankTypes.Count * 0.5f + 0.5f) * (float)this.m_TabPool.TplWidth, tplPos.y);
					IXUICheckBox ixuicheckBox = gameObject.GetComponent("XUICheckBox") as IXUICheckBox;
					ixuicheckBox.ID = (ulong)((long)i);
					ixuicheckBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnTabSelectionChanged));
					bool flag2 = i == 0;
					if (flag2)
					{
						ixuicheckBox.bChecked = true;
					}
					Transform transform = gameObject.transform.FindChild("TextLabel");
					string str = this.bInBattle ? "_in" : "_out";
					string @string = XStringDefineProxy.GetString(rankTypes[i].ToString() + str);
					bool flag3 = transform != null;
					if (flag3)
					{
						IXUILabel ixuilabel = transform.GetComponent("XUILabel") as IXUILabel;
						IXUILabel ixuilabel2 = gameObject.transform.FindChild("SelectedTextLabel").GetComponent("XUILabel") as IXUILabel;
						ixuilabel.SetText(@string);
						ixuilabel2.SetText(@string);
					}
					else
					{
						IXUISprite ixuisprite = gameObject.transform.FindChild("Text").GetComponent("XUISprite") as IXUISprite;
						IXUISprite ixuisprite2 = gameObject.transform.FindChild("SelectedText").GetComponent("XUISprite") as IXUISprite;
						ixuisprite.SetSprite(@string + "0");
						ixuisprite2.SetSprite(@string + "1");
					}
				}
			}
		}

		// Token: 0x0601050D RID: 66829 RVA: 0x003F3428 File Offset: 0x003F1628
		private bool OnTabSelectionChanged(IXUICheckBox ckb)
		{
			bool flag = !ckb.bChecked;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				int num = (int)ckb.ID;
				bool flag2 = num >= this.m_RankTypes.Count;
				if (flag2)
				{
					result = true;
				}
				else
				{
					this.m_SelectedType = this.m_RankTypes[num];
					bool flag3 = this.m_MyInfo != null;
					if (flag3)
					{
						bool flag4 = this.m_SelectedType != RankeType.GuildBossRank;
						if (flag4)
						{
							this.m_MyName.SetText(XSingleton<XEntityMgr>.singleton.Player.Attributes.Name);
							this.m_MyID = XSingleton<XEntityMgr>.singleton.Player.Attributes.EntityID;
						}
						else
						{
							XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
							this.m_MyName.SetText(specificDocument.BasicData.guildName);
							this.m_MyID = specificDocument.UID;
							this.m_MyInfo.gameObject.SetActive(true);
						}
						bool flag5 = this.m_SelectedType == RankeType.WorldBossDamageRank || this.m_SelectedType == RankeType.WorldBossGuildRank || this.m_SelectedType == RankeType.WorldBossGuildRoleRank;
						if (flag5)
						{
							XGuildDocument specificDocument2 = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
							this.m_MyGuildName.SetText(specificDocument2.BasicData.guildName);
							this.m_MyInfo.gameObject.SetActive(this.m_SelectedType == RankeType.WorldBossDamageRank || this.m_SelectedType == RankeType.WorldBossGuildRoleRank);
							this.m_MyGuildInfo.gameObject.SetActive(this.m_SelectedType == RankeType.WorldBossGuildRank);
						}
					}
					bool active = this.active;
					if (active)
					{
						this._KillTimer();
						this._ReqInfo(null);
					}
					result = true;
				}
			}
			return result;
		}

		// Token: 0x0601050E RID: 66830 RVA: 0x003F35DC File Offset: 0x003F17DC
		protected override void OnShow()
		{
			base.OnShow();
			this._KillTimer();
			this._ReqInfo(null);
			bool flag = this.m_MyInfo != null;
			if (flag)
			{
				this.m_MyInfo.SetActive(false);
			}
			this.m_MyGuildInfo.SetActive(false);
		}

		// Token: 0x0601050F RID: 66831 RVA: 0x003F362C File Offset: 0x003F182C
		private void _ReqInfo(object param)
		{
			bool flag = this.RankSource != null;
			if (flag)
			{
				bool flag2 = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_GUILD_BOSS;
				if (flag2)
				{
					this.RankSource.ReqRankData(this.m_SelectedType, true);
				}
				else
				{
					bool flag3 = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_WORLDBOSS;
					if (flag3)
					{
						this.RankSource.ReqRankData(RankeType.WorldBossDamageRank, true);
						this.RankSource.ReqRankData(RankeType.WorldBossGuildRank, true);
						this.RankSource.ReqRankData(RankeType.WorldBossGuildRoleRank, true);
					}
				}
			}
			this._KillTimer();
			this.timerToken = XSingleton<XTimerMgr>.singleton.SetTimer(2f, new XTimerMgr.ElapsedEventHandler(this._ReqInfo), null);
		}

		// Token: 0x06010510 RID: 66832 RVA: 0x003F36D7 File Offset: 0x003F18D7
		protected override void OnHide()
		{
			base.OnHide();
			this.bInBattle = false;
			this._KillTimer();
		}

		// Token: 0x06010511 RID: 66833 RVA: 0x003F36F0 File Offset: 0x003F18F0
		private void _KillTimer()
		{
			bool flag = this.timerToken > 0U;
			if (flag)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this.timerToken);
			}
			this.timerToken = 0U;
		}

		// Token: 0x06010512 RID: 66834 RVA: 0x003F3723 File Offset: 0x003F1923
		public override void OnUnload()
		{
			this._KillTimer();
			base.OnUnload();
		}

		// Token: 0x06010513 RID: 66835 RVA: 0x001E669E File Offset: 0x001E489E
		public override void OnUpdate()
		{
			base.OnUpdate();
		}

		// Token: 0x06010514 RID: 66836 RVA: 0x003F3734 File Offset: 0x003F1934
		protected bool OnCloseClicked(IXUIButton go)
		{
			base.SetVisible(false);
			return true;
		}

		// Token: 0x06010515 RID: 66837 RVA: 0x003F3750 File Offset: 0x003F1950
		public void RefreshPage()
		{
			this.rankMap.Clear();
			ulong entityID = XSingleton<XEntityMgr>.singleton.Player.Attributes.EntityID;
			XBaseRankList rankList = this.RankSource.GetRankList(this.m_SelectedType);
			List<XBaseRankInfo> rankList2 = rankList.rankList;
			int num = (rankList2.Count > this.showMaxCount) ? this.showMaxCount : rankList2.Count;
			this.m_WrapContent.SetContentCount(num, false);
			this.m_ScrollView.ResetPosition();
			bool flag = this.m_MyInfo != null && XSingleton<XScene>.singleton.SceneType != SceneType.SCENE_WORLDBOSS;
			if (flag)
			{
				this.m_MyInfo.gameObject.SetActive(true);
				this.SetMyInfo(this.RankSource.GetRankList(this.m_SelectedType));
				this.m_GuildMemberNum.gameObject.SetActive(false);
			}
			bool flag2 = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_WORLDBOSS;
			if (flag2)
			{
				bool flag3 = this.m_SelectedType == RankeType.WorldBossDamageRank;
				if (flag3)
				{
					this.SetMyInfo(this.RankSource.GetRankList(RankeType.WorldBossDamageRank));
				}
				else
				{
					this.SetMyInfo(this.RankSource.GetRankList(RankeType.WorldBossGuildRoleRank));
				}
				this.SetMyGuildInfo(this.RankSource.GetRankList(RankeType.WorldBossGuildRank));
				XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
				this.m_GuildMemberNum.gameObject.SetActive(specificDocument.bInGuild);
			}
		}

		// Token: 0x06010516 RID: 66838 RVA: 0x003F38B8 File Offset: 0x003F1AB8
		private void RankWrapContentItemUpdated(Transform t, int index)
		{
			List<XBaseRankInfo> rankList = this.RankSource.GetRankList(this.m_SelectedType).rankList;
			bool flag = index < 0 || index >= rankList.Count;
			if (!flag)
			{
				XBaseRankInfo xbaseRankInfo = rankList[index];
				XWorldBossGuildRankInfo xworldBossGuildRankInfo = xbaseRankInfo as XWorldBossGuildRankInfo;
				XWorldBossDamageRankInfo xworldBossDamageRankInfo = xbaseRankInfo as XWorldBossDamageRankInfo;
				XWorldBossGuildRoleRankInfo xworldBossGuildRoleRankInfo = xbaseRankInfo as XWorldBossGuildRoleRankInfo;
				float num = 0f;
				bool flag2 = xworldBossGuildRankInfo != null;
				if (flag2)
				{
					num = xworldBossGuildRankInfo.damage;
				}
				else
				{
					bool flag3 = xworldBossDamageRankInfo != null;
					if (flag3)
					{
						num = xworldBossDamageRankInfo.damage;
					}
					else
					{
						bool flag4 = xworldBossGuildRoleRankInfo != null;
						if (flag4)
						{
							num = xworldBossGuildRoleRankInfo.damage;
						}
					}
				}
				this.rankMap[index] = t;
				IXUILabel ixuilabel = t.FindChild("Rank").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel2 = t.FindChild("Name").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel3 = t.FindChild("Value").GetComponent("XUILabel") as IXUILabel;
				IXUISpriteAnimation ixuispriteAnimation = t.FindChild("Voice").GetComponent("XUISpriteAnimation") as IXUISpriteAnimation;
				ixuispriteAnimation.StopAndReset();
				t = t.FindChild("Bg");
				bool flag5 = t != null;
				if (flag5)
				{
					IXUISprite ixuisprite = t.GetComponent("XUISprite") as IXUISprite;
					ixuisprite.SetSprite((xbaseRankInfo.id == this.m_MyID) ? XWorldBossDamageRankHandler.MY_BG : XWorldBossDamageRankHandler.NORMAL_BG);
				}
				ixuilabel.SetText(string.Format("{0}.", xbaseRankInfo.rank + 1U));
				ixuilabel2.SetText(xbaseRankInfo.name);
				ixuilabel3.SetText(XSingleton<UiUtility>.singleton.NumberFormatBillion((ulong)num));
			}
		}

		// Token: 0x06010517 RID: 66839 RVA: 0x003F3A7C File Offset: 0x003F1C7C
		public void SetMyInfo(XBaseRankList rankData)
		{
			bool flag = rankData.myRankInfo == null;
			if (flag)
			{
				this.m_MyRank.SetText(XStringDefineProxy.GetString("WORLDBOSS_NO_RANK"));
				this.m_MyDamage.SetText("0");
			}
			else
			{
				bool flag2 = rankData.myRankInfo.rank == XRankDocument.INVALID_RANK || rankData.myRankInfo.id == 0UL;
				if (flag2)
				{
					this.m_MyRank.SetText(XStringDefineProxy.GetString("WORLDBOSS_NO_RANK"));
					this.m_MyDamage.SetText("0");
				}
				else
				{
					XWorldBossDamageRankInfo xworldBossDamageRankInfo = rankData.myRankInfo as XWorldBossDamageRankInfo;
					XWorldBossGuildRoleRankInfo xworldBossGuildRoleRankInfo = rankData.myRankInfo as XWorldBossGuildRoleRankInfo;
					float num = 0f;
					bool flag3 = xworldBossDamageRankInfo != null;
					if (flag3)
					{
						num = xworldBossDamageRankInfo.damage;
					}
					else
					{
						bool flag4 = xworldBossGuildRoleRankInfo != null;
						if (flag4)
						{
							num = xworldBossGuildRoleRankInfo.damage;
						}
					}
					this.m_MyRank.SetText(string.Format("{0}. ", rankData.myRankInfo.rank + 1U));
					this.m_MyDamage.SetText(XSingleton<UiUtility>.singleton.NumberFormatBillion((ulong)num));
				}
			}
		}

		// Token: 0x06010518 RID: 66840 RVA: 0x003F3BA4 File Offset: 0x003F1DA4
		public void SetMyGuildInfo(XBaseRankList guildList)
		{
			IXUILabel ixuilabel = this.m_MyGuildInfo.transform.FindChild("Rank").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel2 = this.m_MyGuildInfo.transform.FindChild("Value").GetComponent("XUILabel") as IXUILabel;
			XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
			bool flag = !specificDocument.bInGuild;
			if (flag)
			{
				ixuilabel.SetText("");
				ixuilabel2.SetText("");
				this.m_MyGuildName.SetText("");
			}
			else
			{
				bool flag2 = guildList.myRankInfo == null;
				if (flag2)
				{
					ixuilabel.SetText(XStringDefineProxy.GetString("WORLDBOSS_NO_RANK"));
					ixuilabel2.SetText("0");
				}
				else
				{
					bool flag3 = guildList.myRankInfo.rank == XRankDocument.INVALID_RANK;
					if (flag3)
					{
						ixuilabel.SetText(XStringDefineProxy.GetString("WORLDBOSS_NO_RANK"));
						ixuilabel2.SetText("0");
					}
					else
					{
						XWorldBossGuildRankInfo xworldBossGuildRankInfo = guildList.myRankInfo as XWorldBossGuildRankInfo;
						float num = 0f;
						bool flag4 = xworldBossGuildRankInfo != null;
						if (flag4)
						{
							num = xworldBossGuildRankInfo.damage;
						}
						ixuilabel.SetText(string.Format("{0}. ", guildList.myRankInfo.rank + 1U));
						ixuilabel2.SetText(XSingleton<UiUtility>.singleton.NumberFormatBillion((ulong)num));
					}
				}
			}
		}

		// Token: 0x06010519 RID: 66841 RVA: 0x003F3D0D File Offset: 0x003F1F0D
		public void SetGuildMemberCount(uint count)
		{
			this.m_GuildMemberNum.SetText(XStringDefineProxy.GetString("WORLDBOSS_GUILD_MEMBER_NUM", new object[]
			{
				count
			}));
		}

		// Token: 0x0601051A RID: 66842 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public void RefreshVoice(ulong[] roles, int[] states)
		{
		}

		// Token: 0x0601051B RID: 66843 RVA: 0x003F3D38 File Offset: 0x003F1F38
		public void HideVoice()
		{
			List<XBaseRankInfo> rankList = this.RankSource.GetRankList(this.m_SelectedType).rankList;
			for (int i = 0; i < rankList.Count; i++)
			{
				Transform transform = this.rankMap[i].Find("voice");
				bool flag = transform != null;
				if (flag)
				{
					transform.gameObject.SetActive(false);
				}
				Transform transform2 = this.rankMap[i].Find("speak");
				bool flag2 = transform2 != null;
				if (flag2)
				{
					transform2.gameObject.SetActive(false);
				}
			}
		}

		// Token: 0x0400755B RID: 30043
		private XUIPool m_RankItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x0400755C RID: 30044
		public IXUIWrapContent m_WrapContent;

		// Token: 0x0400755D RID: 30045
		public IXUIScrollView m_ScrollView;

		// Token: 0x0400755E RID: 30046
		private GameObject m_MyInfo;

		// Token: 0x0400755F RID: 30047
		private GameObject m_MyGuildInfo;

		// Token: 0x04007560 RID: 30048
		private IXUILabel m_MyRank;

		// Token: 0x04007561 RID: 30049
		private IXUILabel m_MyDamage;

		// Token: 0x04007562 RID: 30050
		private IXUILabel m_MyName;

		// Token: 0x04007563 RID: 30051
		private IXUILabel m_MyGuildName;

		// Token: 0x04007564 RID: 30052
		private IXUILabel m_GuildMemberNum;

		// Token: 0x04007565 RID: 30053
		private ulong m_MyID;

		// Token: 0x04007566 RID: 30054
		private uint timerToken = 0U;

		// Token: 0x04007567 RID: 30055
		public bool bInBattle = false;

		// Token: 0x04007568 RID: 30056
		private int showMaxCount;

		// Token: 0x04007569 RID: 30057
		private static readonly string NORMAL_BG = "kuang_xd";

		// Token: 0x0400756A RID: 30058
		private static readonly string MY_BG = "button_xd1";

		// Token: 0x0400756B RID: 30059
		public IRankSource RankSource;

		// Token: 0x0400756C RID: 30060
		private RankeType m_SelectedType = RankeType.WorldBossDamageRank;

		// Token: 0x0400756D RID: 30061
		private List<RankeType> m_RankTypes;

		// Token: 0x0400756E RID: 30062
		private XUIPool m_TabPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x0400756F RID: 30063
		private Dictionary<int, Transform> rankMap = new Dictionary<int, Transform>();
	}
}
