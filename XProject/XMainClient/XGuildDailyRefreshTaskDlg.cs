using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A58 RID: 2648
	internal class XGuildDailyRefreshTaskDlg : DlgBase<XGuildDailyRefreshTaskDlg, XGuildDailyRefreshTaskBehavior>
	{
		// Token: 0x17002F03 RID: 12035
		// (get) Token: 0x0600A0AC RID: 41132 RVA: 0x001AEFA0 File Offset: 0x001AD1A0
		public override string fileName
		{
			get
			{
				return "Guild/DailyTaskInviteDlg";
			}
		}

		// Token: 0x17002F04 RID: 12036
		// (get) Token: 0x0600A0AD RID: 41133 RVA: 0x001AEFB8 File Offset: 0x001AD1B8
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600A0AE RID: 41134 RVA: 0x001AEFCB File Offset: 0x001AD1CB
		protected override void OnLoad()
		{
			base.OnLoad();
		}

		// Token: 0x0600A0AF RID: 41135 RVA: 0x001AEFD5 File Offset: 0x001AD1D5
		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		// Token: 0x0600A0B0 RID: 41136 RVA: 0x001AEFDF File Offset: 0x001AD1DF
		protected override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x0600A0B1 RID: 41137 RVA: 0x001AEFE9 File Offset: 0x001AD1E9
		protected override void Init()
		{
			base.Init();
			this.InitProperties();
		}

		// Token: 0x0600A0B2 RID: 41138 RVA: 0x001AEFFA File Offset: 0x001AD1FA
		protected override void OnShow()
		{
			base.OnShow();
			XGuildDailyTaskDocument.Doc.SendToRefreshTasks();
		}

		// Token: 0x0600A0B3 RID: 41139 RVA: 0x001AF00F File Offset: 0x001AD20F
		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		// Token: 0x0600A0B4 RID: 41140 RVA: 0x001AF01C File Offset: 0x001AD21C
		public void RefreshContent()
		{
			base.uiBehaviour.RefreshTimesLabel.SetText(XGuildDailyTaskDocument.Doc.Refresh_num.ToString());
			List<DailyTaskRefreshRoleInfo> dailyTaskRefreshRoleInfoList = XGuildDailyTaskDocument.Doc.DailyTaskRefreshRoleInfoList;
			base.uiBehaviour.WrapContent.SetContentCount(dailyTaskRefreshRoleInfoList.Count, false);
			base.uiBehaviour.ScrollView.ResetPosition();
			base.uiBehaviour.TaskLevelSprite.SetSprite(base.uiBehaviour.TaskLevelSprite.spriteName.Substring(0, base.uiBehaviour.TaskLevelSprite.spriteName.Length - 1) + XGuildDailyTaskDocument.Doc.CurScore);
		}

		// Token: 0x0600A0B5 RID: 41141 RVA: 0x001AF0D4 File Offset: 0x001AD2D4
		private void InitProperties()
		{
			base.uiBehaviour.WrapContent.RegisterItemInitEventHandler(new WrapItemInitEventHandler(this.InitWrapContent));
			base.uiBehaviour.WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.UpdateWrapContent));
			base.uiBehaviour.AddSprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnAddRefreshTimes));
			base.uiBehaviour.CloseBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClose));
			base.uiBehaviour.HelpOtherRefresh.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnHelpOthers));
		}

		// Token: 0x0600A0B6 RID: 41142 RVA: 0x001AF174 File Offset: 0x001AD374
		private void OnHelpOthers(IXUISprite button)
		{
			this.SetVisible(false, true);
			bool inGuild = XGuildDocument.InGuild;
			if (inGuild)
			{
				DlgBase<XGuildMembersView, XGuildMembersBehaviour>.singleton.SetVisible(true, true);
			}
			else
			{
				DlgBase<XGuildListView, XGuildListBehaviour>.singleton.SetVisibleWithAnimation(true, null);
			}
		}

		// Token: 0x0600A0B7 RID: 41143 RVA: 0x001AF1B4 File Offset: 0x001AD3B4
		private bool OnClose(IXUIButton button)
		{
			this.SetVisible(false, true);
			XGuildDailyTaskDocument.Doc.SendGetDailyTaskInfo();
			return true;
		}

		// Token: 0x0600A0B8 RID: 41144 RVA: 0x001AF1DC File Offset: 0x001AD3DC
		private void OnAddRefreshTimes(IXUISprite uiSprite)
		{
			List<int> intList = XSingleton<XGlobalConfig>.singleton.GetIntList("BuyRefreshCost");
			int @int = XSingleton<XGlobalConfig>.singleton.GetInt("MaxBuyRefreshCount");
			uint todayBuyNumber = XGuildDailyTaskDocument.Doc.TodayBuyNumber;
			bool flag = (ulong)todayBuyNumber < (ulong)((long)@int);
			if (flag)
			{
				int num = intList[Mathf.Min(intList.Count - 1, (int)todayBuyNumber)];
				ulong virtualItemCount = XBagDocument.BagDoc.GetVirtualItemCount(ItemEnum.DRAGON_COIN);
				bool flag2 = (ulong)num <= virtualItemCount;
				if (flag2)
				{
					string format = XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("BuyRefreshTaskCountStr"));
					XSingleton<UiUtility>.singleton.ShowModalDialog(string.Format(format, num, (long)@int - (long)((ulong)todayBuyNumber)), new ButtonClickEventHandler(this.ConfirmToBuy));
				}
				else
				{
					DlgBase<XPurchaseView, XPurchaseBehaviour>.singleton.ShowBorad(7);
				}
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ReachedToMaxBuyNumbers"), "fece00");
			}
		}

		// Token: 0x0600A0B9 RID: 41145 RVA: 0x001AF2CC File Offset: 0x001AD4CC
		private bool ConfirmToBuy(IXUIButton button)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			XGuildDailyTaskDocument.Doc.SendToRefreshTaskOp(DailyRefreshOperType.DROT_BuyCount, 0UL);
			return true;
		}

		// Token: 0x0600A0BA RID: 41146 RVA: 0x001AF2F8 File Offset: 0x001AD4F8
		private void UpdateWrapContent(Transform itemTransform, int index)
		{
			DailyTaskRefreshRoleInfo refreshTaskItemInfo = XGuildDailyTaskDocument.Doc.GetRefreshTaskItemInfo(index);
			bool flag = refreshTaskItemInfo != null;
			if (flag)
			{
				Transform transform = itemTransform.Find("Bg");
				transform.gameObject.SetActive(refreshTaskItemInfo.roleid != XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID);
				Transform transform2 = itemTransform.Find("MySelfBg");
				transform2.gameObject.SetActive(refreshTaskItemInfo.roleid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID);
				IXUIButton ixuibutton = itemTransform.Find("BtnInvite").GetComponent("XUIButton") as IXUIButton;
				ixuibutton.ID = refreshTaskItemInfo.roleid;
				ixuibutton.SetEnable(!refreshTaskItemInfo.already_ask, false);
				string text = (refreshTaskItemInfo.roleid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID) ? XStringDefineProxy.GetString("GuildDailyRefreshTask") : XStringDefineProxy.GetString("GuildDailyAskRefresh");
				bool flag2 = refreshTaskItemInfo.already_ask && refreshTaskItemInfo.roleid != XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				if (flag2)
				{
					text = XStringDefineProxy.GetString("AlreadyAsked");
				}
				IXUILabel ixuilabel = itemTransform.Find("BtnInvite/Label").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(text);
				string text2 = (refreshTaskItemInfo.roleid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID) ? (refreshTaskItemInfo.name + XStringDefineProxy.GetString("GuildScoreLogMe")) : refreshTaskItemInfo.name;
				IXUILabel ixuilabel2 = itemTransform.Find("Info/Name").GetComponent("XUILabel") as IXUILabel;
				ixuilabel2.SetText(text2);
				IXUILabel ixuilabel3 = itemTransform.Find("Info/Times").GetComponent("XUILabel") as IXUILabel;
				string format = (refreshTaskItemInfo.roleid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID) ? XStringDefineProxy.GetString("MyselfLeftRefreshTimes") : XStringDefineProxy.GetString("GuildLeftRefreshTimes");
				ixuilabel3.SetText(string.Format(format, refreshTaskItemInfo.refresh_num));
				IXUILabel ixuilabel4 = itemTransform.Find("Luck").GetComponent("XUILabel") as IXUILabel;
				List<string> stringList = XSingleton<XGlobalConfig>.singleton.GetStringList("LuckyLevel");
				int index2 = Mathf.Min((int)(refreshTaskItemInfo.luck - 1U), stringList.Count - 1);
				ixuilabel4.SetText(stringList[index2]);
				List<string> stringList2 = XSingleton<XGlobalConfig>.singleton.GetStringList("LuckyLevelColor");
				Color color = XSingleton<UiUtility>.singleton.ConvertRGBStringToColor(stringList2[index2]);
				ixuilabel4.SetColor(color);
				IXUISprite ixuisprite = itemTransform.Find("Info/AvatarBG/Avatar").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon2((int)refreshTaskItemInfo.profession));
				Transform transform3 = itemTransform.Find("Info/AvatarBG/Relation/Guild");
				transform3.gameObject.SetActive(refreshTaskItemInfo.roleid != XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID);
				Transform transform4 = itemTransform.Find("Info/AvatarBG/Online");
				transform4.gameObject.SetActive(refreshTaskItemInfo.is_online);
			}
		}

		// Token: 0x0600A0BB RID: 41147 RVA: 0x001AF618 File Offset: 0x001AD818
		private void InitWrapContent(Transform itemTransform, int index)
		{
			IXUIButton ixuibutton = itemTransform.Find("BtnInvite").GetComponent("XUIButton") as IXUIButton;
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickToRefreshTask));
		}

		// Token: 0x0600A0BC RID: 41148 RVA: 0x001AF654 File Offset: 0x001AD854
		private bool OnClickToRefreshTask(IXUIButton button)
		{
			ulong id = button.ID;
			bool flag = XGuildDailyTaskDocument.Doc.Refresh_num > 0U;
			if (flag)
			{
				bool flag2 = id == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				if (flag2)
				{
					bool flag3 = XGuildDailyTaskDocument.Doc.CurScore == 4U;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("DailyTaskGetToBestQuality"), "fece00");
					}
					else
					{
						XGuildDailyTaskDocument.Doc.SendToRefreshTaskOp(DailyRefreshOperType.DROT_Refresh, id);
					}
				}
				else
				{
					bool flag4 = XGuildDailyTaskDocument.Doc.CurScore == 4U;
					if (flag4)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("DailyTaskGetToBestQuality"), "fece00");
					}
					else
					{
						XGuildDailyTaskDocument.Doc.SendToRefreshTaskOp(DailyRefreshOperType.DROT_AskHelp, id);
					}
				}
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("NoRefreshTaskTimes"), "fece00");
			}
			return true;
		}
	}
}
