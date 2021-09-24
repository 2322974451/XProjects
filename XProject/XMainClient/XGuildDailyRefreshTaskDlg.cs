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

	internal class XGuildDailyRefreshTaskDlg : DlgBase<XGuildDailyRefreshTaskDlg, XGuildDailyRefreshTaskBehavior>
	{

		public override string fileName
		{
			get
			{
				return "Guild/DailyTaskInviteDlg";
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		protected override void OnLoad()
		{
			base.OnLoad();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		protected override void OnUnload()
		{
			base.OnUnload();
		}

		protected override void Init()
		{
			base.Init();
			this.InitProperties();
		}

		protected override void OnShow()
		{
			base.OnShow();
			XGuildDailyTaskDocument.Doc.SendToRefreshTasks();
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		public void RefreshContent()
		{
			base.uiBehaviour.RefreshTimesLabel.SetText(XGuildDailyTaskDocument.Doc.Refresh_num.ToString());
			List<DailyTaskRefreshRoleInfo> dailyTaskRefreshRoleInfoList = XGuildDailyTaskDocument.Doc.DailyTaskRefreshRoleInfoList;
			base.uiBehaviour.WrapContent.SetContentCount(dailyTaskRefreshRoleInfoList.Count, false);
			base.uiBehaviour.ScrollView.ResetPosition();
			base.uiBehaviour.TaskLevelSprite.SetSprite(base.uiBehaviour.TaskLevelSprite.spriteName.Substring(0, base.uiBehaviour.TaskLevelSprite.spriteName.Length - 1) + XGuildDailyTaskDocument.Doc.CurScore);
		}

		private void InitProperties()
		{
			base.uiBehaviour.WrapContent.RegisterItemInitEventHandler(new WrapItemInitEventHandler(this.InitWrapContent));
			base.uiBehaviour.WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.UpdateWrapContent));
			base.uiBehaviour.AddSprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnAddRefreshTimes));
			base.uiBehaviour.CloseBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClose));
			base.uiBehaviour.HelpOtherRefresh.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnHelpOthers));
		}

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

		private bool OnClose(IXUIButton button)
		{
			this.SetVisible(false, true);
			XGuildDailyTaskDocument.Doc.SendGetDailyTaskInfo();
			return true;
		}

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

		private bool ConfirmToBuy(IXUIButton button)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			XGuildDailyTaskDocument.Doc.SendToRefreshTaskOp(DailyRefreshOperType.DROT_BuyCount, 0UL);
			return true;
		}

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

		private void InitWrapContent(Transform itemTransform, int index)
		{
			IXUIButton ixuibutton = itemTransform.Find("BtnInvite").GetComponent("XUIButton") as IXUIButton;
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickToRefreshTask));
		}

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
