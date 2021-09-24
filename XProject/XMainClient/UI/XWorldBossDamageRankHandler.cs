using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XWorldBossDamageRankHandler : DlgHandlerBase, IRankView
	{

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

		protected override void OnHide()
		{
			base.OnHide();
			this.bInBattle = false;
			this._KillTimer();
		}

		private void _KillTimer()
		{
			bool flag = this.timerToken > 0U;
			if (flag)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this.timerToken);
			}
			this.timerToken = 0U;
		}

		public override void OnUnload()
		{
			this._KillTimer();
			base.OnUnload();
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
		}

		protected bool OnCloseClicked(IXUIButton go)
		{
			base.SetVisible(false);
			return true;
		}

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

		public void SetGuildMemberCount(uint count)
		{
			this.m_GuildMemberNum.SetText(XStringDefineProxy.GetString("WORLDBOSS_GUILD_MEMBER_NUM", new object[]
			{
				count
			}));
		}

		public void RefreshVoice(ulong[] roles, int[] states)
		{
		}

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

		private XUIPool m_RankItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUIWrapContent m_WrapContent;

		public IXUIScrollView m_ScrollView;

		private GameObject m_MyInfo;

		private GameObject m_MyGuildInfo;

		private IXUILabel m_MyRank;

		private IXUILabel m_MyDamage;

		private IXUILabel m_MyName;

		private IXUILabel m_MyGuildName;

		private IXUILabel m_GuildMemberNum;

		private ulong m_MyID;

		private uint timerToken = 0U;

		public bool bInBattle = false;

		private int showMaxCount;

		private static readonly string NORMAL_BG = "kuang_xd";

		private static readonly string MY_BG = "button_xd1";

		public IRankSource RankSource;

		private RankeType m_SelectedType = RankeType.WorldBossDamageRank;

		private List<RankeType> m_RankTypes;

		private XUIPool m_TabPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private Dictionary<int, Transform> rankMap = new Dictionary<int, Transform>();
	}
}
