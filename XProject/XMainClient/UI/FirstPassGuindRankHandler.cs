using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class FirstPassGuindRankHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "OperatingActivity/FirstPassGuildRank";
			}
		}

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

		protected override void OnShow()
		{
			base.OnShow();
			this._Doc.SendGuildRankInfo();
			this.CheckInGuild();
			this.RefreshTitles();
			this.SetRewardInfo();
			this.CheckTime();
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
			this.CheckInGuild();
			this.RefreshTitles();
			this.CheckTime();
		}

		public override void RefreshData()
		{
			base.RefreshData();
			this.RefreshTitles();
			this.CheckInGuild();
			this.CheckTime();
		}

		private void SetRewardInfo()
		{
			this.m_WrapContent.SetContentCount(XGuildRankDocument.m_RankRewardTable.Table.Length, false);
			this.m_ScrollView.ResetPosition();
		}

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

		private void OnIconClick(IXUISprite spr)
		{
			XItem mainItem = XBagDocument.MakeXItem((int)spr.ID, false);
			XSingleton<UiUtility>.singleton.ShowTooltipDialogWithSearchingCompare(mainItem, spr, false, 0U);
		}

		private void RefreshTitles()
		{
			this.m_MarkLabel.SetText(XStringDefineProxy.GetString("GUILD_RANK_MARK", new object[]
			{
				XSingleton<UiUtility>.singleton.TimeFormatSince1970((int)this._Doc.KeepTime, XStringDefineProxy.GetString("TIME_FORMAT_YYMMDD"), true)
			}));
			this.m_DescLabel.SetText(XStringDefineProxy.GetString("GUILD_RANK_DESC"));
		}

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

		private void DoTimer(object o = null)
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_timer);
			this.CheckTime();
		}

		protected override void OnHide()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_timer);
			base.OnHide();
		}

		public override void OnUnload()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_timer);
			base.OnUnload();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_ShowRank.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnShowRankClick));
			this.m_JoinGuild.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnJoinGuild));
		}

		private bool OnShowRankClick(IXUIButton btn)
		{
			DlgBase<XRankView, XRankBehaviour>.singleton.ShowRank(XSysDefine.XSys_Rank_Guild);
			return false;
		}

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

		private IXUILabel m_TimeLabel;

		private IXUILabel m_DescLabel;

		private IXUILabel m_MarkLabel;

		private IXUILabel m_UnJoinLabel;

		private IXUILabel m_GuildRankLabel;

		private IXUIButton m_ShowRank;

		private IXUIButton m_JoinGuild;

		private IXUIScrollView m_ScrollView;

		private IXUIWrapContent m_WrapContent;

		private uint m_timer = 0U;

		private XGuildRankDocument _Doc;
	}
}
