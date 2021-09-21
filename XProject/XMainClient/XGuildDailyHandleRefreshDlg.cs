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
	// Token: 0x02000A56 RID: 2646
	internal class XGuildDailyHandleRefreshDlg : DlgBase<XGuildDailyHandleRefreshDlg, XGuildDailyHandleRefreshBehavior>
	{
		// Token: 0x17002F01 RID: 12033
		// (get) Token: 0x0600A09A RID: 41114 RVA: 0x001AE9FC File Offset: 0x001ACBFC
		public override string fileName
		{
			get
			{
				return "Guild/DailyTaskInvitation";
			}
		}

		// Token: 0x17002F02 RID: 12034
		// (get) Token: 0x0600A09B RID: 41115 RVA: 0x001AEA14 File Offset: 0x001ACC14
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600A09C RID: 41116 RVA: 0x001AEA27 File Offset: 0x001ACC27
		protected override void OnLoad()
		{
			base.OnLoad();
		}

		// Token: 0x0600A09D RID: 41117 RVA: 0x001AEA31 File Offset: 0x001ACC31
		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		// Token: 0x0600A09E RID: 41118 RVA: 0x001AEA3B File Offset: 0x001ACC3B
		protected override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x0600A09F RID: 41119 RVA: 0x001AEA45 File Offset: 0x001ACC45
		protected override void Init()
		{
			base.Init();
			this.InitProperties();
		}

		// Token: 0x0600A0A0 RID: 41120 RVA: 0x001AEA56 File Offset: 0x001ACC56
		protected override void OnShow()
		{
			base.OnShow();
			XGuildDailyTaskDocument.Doc.SendToGetAskRefreshTaskInfo();
		}

		// Token: 0x0600A0A1 RID: 41121 RVA: 0x001AEA6B File Offset: 0x001ACC6B
		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		// Token: 0x0600A0A2 RID: 41122 RVA: 0x001AEA78 File Offset: 0x001ACC78
		private void InitProperties()
		{
			base.uiBehaviour.WrapContent.RegisterItemInitEventHandler(new WrapItemInitEventHandler(this.InitWrapContent));
			base.uiBehaviour.WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.UpdateWrapContent));
			base.uiBehaviour.CloseBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickToClose));
			base.uiBehaviour.FreeTimeLabel.SetText(string.Format(XStringDefineProxy.GetString("DailyFreeHelpOthersTime"), XSingleton<XGlobalConfig>.singleton.GetInt("DailyTaskMaxHelpCount")));
		}

		// Token: 0x0600A0A3 RID: 41123 RVA: 0x001AEB14 File Offset: 0x001ACD14
		private bool OnClickToClose(IXUIButton button)
		{
			this.SetVisible(false, true);
			return true;
		}

		// Token: 0x0600A0A4 RID: 41124 RVA: 0x001AEB30 File Offset: 0x001ACD30
		private void InitWrapContent(Transform itemTransform, int index)
		{
			IXUIButton ixuibutton = itemTransform.Find("OK").GetComponent("XUIButton") as IXUIButton;
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickToHelp));
			IXUIButton ixuibutton2 = itemTransform.Find("Cancel").GetComponent("XUIButton") as IXUIButton;
			ixuibutton2.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickToRefuse));
		}

		// Token: 0x0600A0A5 RID: 41125 RVA: 0x001AEB9C File Offset: 0x001ACD9C
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

		// Token: 0x0600A0A6 RID: 41126 RVA: 0x001AED00 File Offset: 0x001ACF00
		private bool OnClickToRefuse(IXUIButton button)
		{
			ulong id = button.ID;
			XGuildDailyTaskDocument.Doc.SendToRefreshTaskOp(DailyRefreshOperType.DROT_Refuse, id);
			return true;
		}

		// Token: 0x0600A0A7 RID: 41127 RVA: 0x001AED28 File Offset: 0x001ACF28
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

		// Token: 0x0600A0A8 RID: 41128 RVA: 0x001AED84 File Offset: 0x001ACF84
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
