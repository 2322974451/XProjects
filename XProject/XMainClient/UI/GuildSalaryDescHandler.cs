using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.Utility;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200176D RID: 5997
	internal class GuildSalaryDescHandler : DlgHandlerBase
	{
		// Token: 0x17003817 RID: 14359
		// (get) Token: 0x0600F796 RID: 63382 RVA: 0x00386530 File Offset: 0x00384730
		protected override string FileName
		{
			get
			{
				return "Guild/GuildSalaryDescDlg";
			}
		}

		// Token: 0x0600F797 RID: 63383 RVA: 0x00386548 File Offset: 0x00384748
		protected override void Init()
		{
			base.Init();
			this._Doc = XDocuments.GetSpecificDocument<XGuildSalaryDocument>(XGuildSalaryDocument.uuID);
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			Transform tabTpl = base.transform.FindChild("Bg/Tabs/TabTpl");
			this.m_tabControl.SetTabTpl(tabTpl);
			this.m_Progress = (base.transform.FindChild("Bg/Progress").GetComponent("XUIProgress") as IXUIProgress);
			this.m_WrapContent = (base.transform.FindChild("Bg/ScrollView/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_ScrollView = (base.transform.FindChild("Bg/ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_ScoreMark = (base.transform.FindChild("Bg/Progress/FriendTxt").GetComponent("XUILabel") as IXUILabel);
			this.m_ProgressLabel = (base.transform.FindChild("Bg/Progress/Num").GetComponent("XUILabel") as IXUILabel);
			this.m_ScoreValue = (base.transform.FindChild("Bg/P/Num").GetComponent("XUILabel") as IXUILabel);
			this.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnWrapUpdateContent));
		}

		// Token: 0x0600F798 RID: 63384 RVA: 0x003866A6 File Offset: 0x003848A6
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickClose));
		}

		// Token: 0x0600F799 RID: 63385 RVA: 0x003866C8 File Offset: 0x003848C8
		protected override void OnShow()
		{
			base.OnShow();
			this.InitTabInfos();
			this.SetBaseInfo();
		}

		// Token: 0x0600F79A RID: 63386 RVA: 0x003866E0 File Offset: 0x003848E0
		private void InitTabInfos()
		{
			List<int> tabIndexs = XGuildSalaryDocument.TabIndexs;
			List<string> tabNames = XGuildSalaryDocument.TabNames;
			this.m_tabControl.SetupTabs(tabIndexs, tabNames, new XUITabControl.UITabControlCallback(this.OnSelectTable), true, 1f, this._Doc.SelectTabs, true);
		}

		// Token: 0x0600F79B RID: 63387 RVA: 0x00386728 File Offset: 0x00384928
		private void OnSelectTable(ulong id)
		{
			int num = (int)id;
			this._Doc.SelectTabs = num;
			this.SetBaseInfo();
			bool flag = XGuildSalaryDocument.GuildSalaryDescDic.TryGetValue(num, out this.m_salaryDesc);
			if (flag)
			{
				this.m_WrapContent.SetContentCount(this.m_salaryDesc.Count, false);
			}
			else
			{
				this.m_WrapContent.SetContentCount(0, false);
			}
			this.m_ScrollView.ResetPosition();
		}

		// Token: 0x0600F79C RID: 63388 RVA: 0x0038679C File Offset: 0x0038499C
		private bool OnClickClose(IXUIButton btn)
		{
			base.SetVisible(false);
			return true;
		}

		// Token: 0x0600F79D RID: 63389 RVA: 0x003867B8 File Offset: 0x003849B8
		private void OnWrapUpdateContent(Transform t, int index)
		{
			bool flag = this.m_salaryDesc == null || index >= this.m_salaryDesc.Count;
			if (!flag)
			{
				IXUILabel ixuilabel = t.FindChild("Content").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel2 = t.FindChild("Go/Go").GetComponent("XUILabel") as IXUILabel;
				ixuilabel2.RegisterLabelClickEventHandler(new LabelClickEventHandler(this.OnClickGoHandler));
				GuildSalaryDesc.RowData rowData = this.m_salaryDesc[index];
				ixuilabel.SetText(rowData.Desc);
				ixuilabel2.SetText(rowData.GoLabel);
				ixuilabel2.ID = (ulong)((long)rowData.Go);
				ixuilabel2.SetVisible(rowData.Go > 0);
			}
		}

		// Token: 0x0600F79E RID: 63390 RVA: 0x0038687C File Offset: 0x00384A7C
		private void OnClickGoHandler(IXUILabel label)
		{
			bool flag = label.ID > 0UL;
			if (flag)
			{
				XSingleton<XGameSysMgr>.singleton.OpenSystem((int)label.ID);
			}
		}

		// Token: 0x0600F79F RID: 63391 RVA: 0x003868AC File Offset: 0x00384AAC
		private void SetBaseInfo()
		{
			XGuildSalaryInfo value = this._Doc.GetValue(this._Doc.SelectTabs);
			this.m_ScoreValue.SetText(value.Score.ToString());
			this.m_ScoreMark.SetText(XGuildSalaryDocument.GetGradeName((int)value.Grade));
			this.m_Progress.value = value.Percent;
			this.m_ProgressLabel.SetText(string.Format("{0}/{1}", value.Value, value.TotalScore));
		}

		// Token: 0x04006BD3 RID: 27603
		private IXUIButton m_Close;

		// Token: 0x04006BD4 RID: 27604
		private XUITabControl m_tabControl = new XUITabControl();

		// Token: 0x04006BD5 RID: 27605
		private IXUIProgress m_Progress;

		// Token: 0x04006BD6 RID: 27606
		private IXUILabel m_ScoreValue;

		// Token: 0x04006BD7 RID: 27607
		private IXUILabel m_ScoreMark;

		// Token: 0x04006BD8 RID: 27608
		private IXUILabel m_ProgressLabel;

		// Token: 0x04006BD9 RID: 27609
		private IXUIScrollView m_ScrollView;

		// Token: 0x04006BDA RID: 27610
		private IXUIWrapContent m_WrapContent;

		// Token: 0x04006BDB RID: 27611
		private XGuildSalaryDocument _Doc;

		// Token: 0x04006BDC RID: 27612
		private List<GuildSalaryDesc.RowData> m_salaryDesc;
	}
}
