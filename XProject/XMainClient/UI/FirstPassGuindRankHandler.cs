using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017DE RID: 6110
	internal class FirstPassGuindRankHandler : DlgHandlerBase
	{
		// Token: 0x170038B2 RID: 14514
		// (get) Token: 0x0600FD32 RID: 64818 RVA: 0x003B4498 File Offset: 0x003B2698
		protected override string FileName
		{
			get
			{
				return "OperatingActivity/FirstPassGuildRank";
			}
		}

		// Token: 0x0600FD33 RID: 64819 RVA: 0x003B44B0 File Offset: 0x003B26B0
		protected override void Init()
		{
			base.Init();
			this._Doc = XDocuments.GetSpecificDocument<XGuildRankDocument>(XGuildRankDocument.uuID);
			this.m_TimeLabel = (base.transform.FindChild("Titles/Time").GetComponent("XUILabel") as IXUILabel);
			this.m_DescLabel = (base.transform.FindChild("Titles/Desc").GetComponent("XUILabel") as IXUILabel);
			this.m_MarkLabel = (base.transform.FindChild("Titles/Mark").GetComponent("XUILabel") as IXUILabel);
			this.m_UnJoinLabel = (base.transform.FindChild("Control/UnJoin").GetComponent("XUILabel") as IXUILabel);
			this.m_GuildRankLabel = (base.transform.FindChild("Control/Rank").GetComponent("XUILabel") as IXUILabel);
			this.m_ShowRank = (base.transform.FindChild("Control/ShowRank").GetComponent("XUIButton") as IXUIButton);
			this.m_JoinGuild = (base.transform.FindChild("Control/JoinGuild").GetComponent("XUIButton") as IXUIButton);
			this.m_ScrollView = (base.transform.FindChild("RankContent/ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_WrapContent = (base.transform.FindChild("RankContent/ScrollView/GuildList").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnWrapContentUpdate));
		}

		// Token: 0x0600FD34 RID: 64820 RVA: 0x003B463A File Offset: 0x003B283A
		protected override void OnShow()
		{
			base.OnShow();
			this._Doc.SendGuildRankInfo();
			this.CheckInGuild();
			this.RefreshTitles();
			this.SetRewardInfo();
			this.CheckTime();
		}

		// Token: 0x0600FD35 RID: 64821 RVA: 0x003B466C File Offset: 0x003B286C
		public override void StackRefresh()
		{
			base.StackRefresh();
			this.CheckInGuild();
			this.RefreshTitles();
			this.CheckTime();
		}

		// Token: 0x0600FD36 RID: 64822 RVA: 0x003B468B File Offset: 0x003B288B
		public override void RefreshData()
		{
			base.RefreshData();
			this.RefreshTitles();
			this.CheckInGuild();
			this.CheckTime();
		}

		// Token: 0x0600FD37 RID: 64823 RVA: 0x003B46AA File Offset: 0x003B28AA
		private void SetRewardInfo()
		{
			this.m_WrapContent.SetContentCount(XGuildRankDocument.m_RankRewardTable.Table.Length, false);
			this.m_ScrollView.ResetPosition();
		}

		// Token: 0x0600FD38 RID: 64824 RVA: 0x003B46D4 File Offset: 0x003B28D4
		private void OnWrapContentUpdate(Transform t, int index)
		{
			GuildRankRewardTable.RowData rowData = XGuildRankDocument.m_RankRewardTable.Table[index];
			IXUILabel ixuilabel = t.FindChild("Rank").GetComponent("XUILabel") as IXUILabel;
			IXUISprite ixuisprite = t.FindChild("IndexSprite").GetComponent("XUISprite") as IXUISprite;
			bool flag = rowData.Rank[0] == rowData.Rank[1];
			if (flag)
			{
				bool flag2 = rowData.Rank[0] <= 3U;
				if (flag2)
				{
					ixuisprite.SetAlpha(1f);
					ixuilabel.Alpha = 0f;
					ixuisprite.SetSprite(XSingleton<XCommon>.singleton.StringCombine("N", rowData.Rank[0].ToString()));
				}
				else
				{
					ixuisprite.SetAlpha(0f);
					ixuilabel.Alpha = 1f;
					ixuilabel.SetText(XStringDefineProxy.GetString("Qualifying_Rank_Reward_Desc1", new object[]
					{
						rowData.Rank[0]
					}));
				}
			}
			else
			{
				ixuisprite.SetAlpha(0f);
				ixuilabel.Alpha = 1f;
				ixuilabel.SetText(XStringDefineProxy.GetString("Qualifying_Rank_Reward_Desc4", new object[]
				{
					rowData.Rank[0],
					rowData.Rank[1]
				}));
			}
			this.SetRewardList(t.FindChild("Leader"), ref rowData.LeaderReward);
			this.SetRewardList(t.FindChild("Officer"), ref rowData.OfficerRreward);
			this.SetRewardList(t.FindChild("Member"), ref rowData.MemberReward);
		}

		// Token: 0x0600FD39 RID: 64825 RVA: 0x003B4890 File Offset: 0x003B2A90
		private void SetRewardList(Transform t, ref SeqListRef<uint> rewards)
		{
			IXUIList ixuilist = t.GetComponent("XUIList") as IXUIList;
			int i = 0;
			int num = 3;
			while (i < num)
			{
				Transform transform = t.FindChild(XSingleton<XCommon>.singleton.StringCombine("Item", i.ToString()));
				bool flag = i < rewards.Count;
				if (flag)
				{
					transform.gameObject.SetActive(true);
					IXUISprite ixuisprite = transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
					ixuisprite.ID = (ulong)rewards[i, 0];
					XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(transform.gameObject, (int)rewards[i, 0], (int)rewards[i, 1], false);
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnIconClick));
				}
				else
				{
					transform.gameObject.SetActive(false);
				}
				i++;
			}
			ixuilist.Refresh();
		}

		// Token: 0x0600FD3A RID: 64826 RVA: 0x003B4988 File Offset: 0x003B2B88
		private void OnIconClick(IXUISprite spr)
		{
			XItem mainItem = XBagDocument.MakeXItem((int)spr.ID, false);
			XSingleton<UiUtility>.singleton.ShowTooltipDialogWithSearchingCompare(mainItem, spr, false, 0U);
		}

		// Token: 0x0600FD3B RID: 64827 RVA: 0x003B49B4 File Offset: 0x003B2BB4
		private void RefreshTitles()
		{
			this.m_MarkLabel.SetText(XStringDefineProxy.GetString("GUILD_RANK_MARK", new object[]
			{
				XSingleton<UiUtility>.singleton.TimeFormatSince1970((int)this._Doc.KeepTime, XStringDefineProxy.GetString("TIME_FORMAT_YYMMDD"), true)
			}));
			this.m_DescLabel.SetText(XStringDefineProxy.GetString("GUILD_RANK_DESC"));
		}

		// Token: 0x0600FD3C RID: 64828 RVA: 0x003B4A18 File Offset: 0x003B2C18
		private void CheckTime()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_timer);
			bool flag = this._Doc.LastTime > 0;
			if (flag)
			{
				XGuildRankDocument doc = this._Doc;
				int lastTime = doc.LastTime;
				doc.LastTime = lastTime - 1;
				this.m_timer = XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this.DoTimer), null);
				bool flag2 = this._Doc.LastTime >= 86400;
				if (flag2)
				{
					this.m_TimeLabel.SetText(XStringDefineProxy.GetString("GUILD_RANK_TIME", new object[]
					{
						XSingleton<UiUtility>.singleton.TimeFormatSince1970((int)this._Doc.EndTime, XStringDefineProxy.GetString("TIME_FORMAT_YYMMDD"), true),
						XStringDefineProxy.GetString("GUILD_QUALIFER_STYLE1", new object[]
						{
							XSingleton<UiUtility>.singleton.TimeDuarationFormatString(this._Doc.LastTime, 2)
						})
					}));
				}
				else
				{
					this.m_TimeLabel.SetText(XStringDefineProxy.GetString("GUILD_RANK_TIME", new object[]
					{
						XSingleton<UiUtility>.singleton.TimeFormatSince1970((int)this._Doc.EndTime, XStringDefineProxy.GetString("TIME_FORMAT_YYMMDD"), true),
						XStringDefineProxy.GetString("GUILD_QUALIFER_STYLE1", new object[]
						{
							XSingleton<UiUtility>.singleton.TimeDuarationFormatString(this._Doc.LastTime, 5)
						})
					}));
				}
			}
			else
			{
				this.m_TimeLabel.SetText(XStringDefineProxy.GetString("GUILD_RANK_TIME", new object[]
				{
					XSingleton<UiUtility>.singleton.TimeFormatSince1970((int)this._Doc.EndTime, XStringDefineProxy.GetString("TIME_FORMAT_YYMMDD"), true),
					XStringDefineProxy.GetString("GUILD_QUALIFER_STYLE2")
				}));
			}
		}

		// Token: 0x0600FD3D RID: 64829 RVA: 0x003B4BCB File Offset: 0x003B2DCB
		private void DoTimer(object o = null)
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_timer);
			this.CheckTime();
		}

		// Token: 0x0600FD3E RID: 64830 RVA: 0x003B4BE6 File Offset: 0x003B2DE6
		protected override void OnHide()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_timer);
			base.OnHide();
		}

		// Token: 0x0600FD3F RID: 64831 RVA: 0x003B4C01 File Offset: 0x003B2E01
		public override void OnUnload()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_timer);
			base.OnUnload();
		}

		// Token: 0x0600FD40 RID: 64832 RVA: 0x003B4C1C File Offset: 0x003B2E1C
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_ShowRank.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnShowRankClick));
			this.m_JoinGuild.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnJoinGuild));
		}

		// Token: 0x0600FD41 RID: 64833 RVA: 0x003B4C58 File Offset: 0x003B2E58
		private bool OnShowRankClick(IXUIButton btn)
		{
			DlgBase<XRankView, XRankBehaviour>.singleton.ShowRank(XSysDefine.XSys_Rank_Guild);
			return false;
		}

		// Token: 0x0600FD42 RID: 64834 RVA: 0x003B4C7C File Offset: 0x003B2E7C
		private bool OnJoinGuild(IXUIButton btn)
		{
			bool flag = XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Guild);
			if (flag)
			{
				XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
				bool flag2 = specificDocument != null;
				if (flag2)
				{
					specificDocument.TryShowGuildHallUI();
				}
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("GUILD_UNJION"), "fece00");
			}
			return true;
		}

		// Token: 0x0600FD43 RID: 64835 RVA: 0x003B4CDC File Offset: 0x003B2EDC
		private void CheckInGuild()
		{
			XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
			bool bInGuild = specificDocument.bInGuild;
			if (bInGuild)
			{
				this.m_JoinGuild.SetVisible(false);
				this.m_UnJoinLabel.SetVisible(false);
				this.m_GuildRankLabel.SetVisible(true);
				this.m_GuildRankLabel.SetText(this._Doc.RankIndex.ToString());
			}
			else
			{
				this.m_JoinGuild.SetVisible(true);
				this.m_UnJoinLabel.SetVisible(true);
				this.m_GuildRankLabel.SetVisible(false);
			}
		}

		// Token: 0x04006F7B RID: 28539
		private IXUILabel m_TimeLabel;

		// Token: 0x04006F7C RID: 28540
		private IXUILabel m_DescLabel;

		// Token: 0x04006F7D RID: 28541
		private IXUILabel m_MarkLabel;

		// Token: 0x04006F7E RID: 28542
		private IXUILabel m_UnJoinLabel;

		// Token: 0x04006F7F RID: 28543
		private IXUILabel m_GuildRankLabel;

		// Token: 0x04006F80 RID: 28544
		private IXUIButton m_ShowRank;

		// Token: 0x04006F81 RID: 28545
		private IXUIButton m_JoinGuild;

		// Token: 0x04006F82 RID: 28546
		private IXUIScrollView m_ScrollView;

		// Token: 0x04006F83 RID: 28547
		private IXUIWrapContent m_WrapContent;

		// Token: 0x04006F84 RID: 28548
		private uint m_timer = 0U;

		// Token: 0x04006F85 RID: 28549
		private XGuildRankDocument _Doc;
	}
}
