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

	internal class XGuildDailyHandleRefreshDlg : DlgBase<XGuildDailyHandleRefreshDlg, XGuildDailyHandleRefreshBehavior>
	{

		public override string fileName
		{
			get
			{
				return "Guild/DailyTaskInvitation";
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
			XGuildDailyTaskDocument.Doc.SendToGetAskRefreshTaskInfo();
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		private void InitProperties()
		{
			base.uiBehaviour.WrapContent.RegisterItemInitEventHandler(new WrapItemInitEventHandler(this.InitWrapContent));
			base.uiBehaviour.WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.UpdateWrapContent));
			base.uiBehaviour.CloseBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickToClose));
			base.uiBehaviour.FreeTimeLabel.SetText(string.Format(XStringDefineProxy.GetString("DailyFreeHelpOthersTime"), XSingleton<XGlobalConfig>.singleton.GetInt("DailyTaskMaxHelpCount")));
		}

		private bool OnClickToClose(IXUIButton button)
		{
			this.SetVisible(false, true);
			return true;
		}

		private void InitWrapContent(Transform itemTransform, int index)
		{
			IXUIButton ixuibutton = itemTransform.Find("OK").GetComponent("XUIButton") as IXUIButton;
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickToHelp));
			IXUIButton ixuibutton2 = itemTransform.Find("Cancel").GetComponent("XUIButton") as IXUIButton;
			ixuibutton2.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickToRefuse));
		}

		private void UpdateWrapContent(Transform itemTransform, int index)
		{
			DailyTaskRefreshRoleInfo taskAskInfoByIndex = XGuildDailyTaskDocument.Doc.GetTaskAskInfoByIndex(index);
			bool flag = taskAskInfoByIndex != null;
			if (flag)
			{
				IXUIButton ixuibutton = itemTransform.Find("OK").GetComponent("XUIButton") as IXUIButton;
				ixuibutton.ID = taskAskInfoByIndex.roleid;
				IXUIButton ixuibutton2 = itemTransform.Find("Cancel").GetComponent("XUIButton") as IXUIButton;
				ixuibutton2.ID = taskAskInfoByIndex.roleid;
				IXUILabel ixuilabel = itemTransform.Find("Times").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(string.Format(XStringDefineProxy.GetString("MyselfLeftRefreshTimes"), taskAskInfoByIndex.refresh_num));
				IXUILabel ixuilabel2 = itemTransform.Find("Name").GetComponent("XUILabel") as IXUILabel;
				ixuilabel2.SetText(taskAskInfoByIndex.name);
				IXUISprite ixuisprite = itemTransform.Find("Quality").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.SetSprite(ixuisprite.spriteName.Substring(0, ixuisprite.spriteName.Length - 1) + taskAskInfoByIndex.score);
				IXUISprite ixuisprite2 = itemTransform.Find("head").GetComponent("XUISprite") as IXUISprite;
				ixuisprite2.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon2((int)taskAskInfoByIndex.profession));
			}
		}

		private bool OnClickToRefuse(IXUIButton button)
		{
			ulong id = button.ID;
			XGuildDailyTaskDocument.Doc.SendToRefreshTaskOp(DailyRefreshOperType.DROT_Refuse, id);
			return true;
		}

		private bool OnClickToHelp(IXUIButton button)
		{
			bool flag = XGuildDailyTaskDocument.Doc.HelpNum <= 0U;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("DailyHelpTimesNotEnough"), "fece00");
			}
			else
			{
				ulong id = button.ID;
				XGuildDailyTaskDocument.Doc.SendToRefreshTaskOp(DailyRefreshOperType.DROT_Refresh, id);
			}
			return true;
		}

		public void RefreshContent()
		{
			List<string> stringList = XSingleton<XGlobalConfig>.singleton.GetStringList("LuckyLevel");
			int index = Mathf.Min((int)(XGuildDailyTaskDocument.Doc.MyLuck - 1U), stringList.Count - 1);
			base.uiBehaviour.TaskLucky.SetText(stringList[index]);
			List<string> stringList2 = XSingleton<XGlobalConfig>.singleton.GetStringList("LuckyLevelColor");
			Color color = XSingleton<UiUtility>.singleton.ConvertRGBStringToColor(stringList2[index]);
			base.uiBehaviour.TaskLucky.SetColor(color);
			int @int = XSingleton<XGlobalConfig>.singleton.GetInt("DailyTaskMaxHelpCount");
			base.uiBehaviour.HelpTimesLabel.SetText(XGuildDailyTaskDocument.Doc.HelpNum + "/" + @int);
			List<DailyTaskRefreshRoleInfo> askInfoList = XGuildDailyTaskDocument.Doc.AskInfoList;
			base.uiBehaviour.WrapContent.SetContentCount(askInfoList.Count, false);
			base.uiBehaviour.ScrollView.ResetPosition();
		}
	}
}
