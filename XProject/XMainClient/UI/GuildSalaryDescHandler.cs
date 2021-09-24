using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.Utility;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class GuildSalaryDescHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "Guild/GuildSalaryDescDlg";
			}
		}

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

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickClose));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.InitTabInfos();
			this.SetBaseInfo();
		}

		private void InitTabInfos()
		{
			List<int> tabIndexs = XGuildSalaryDocument.TabIndexs;
			List<string> tabNames = XGuildSalaryDocument.TabNames;
			this.m_tabControl.SetupTabs(tabIndexs, tabNames, new XUITabControl.UITabControlCallback(this.OnSelectTable), true, 1f, this._Doc.SelectTabs, true);
		}

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

		private bool OnClickClose(IXUIButton btn)
		{
			base.SetVisible(false);
			return true;
		}

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

		private void OnClickGoHandler(IXUILabel label)
		{
			bool flag = label.ID > 0UL;
			if (flag)
			{
				XSingleton<XGameSysMgr>.singleton.OpenSystem((int)label.ID);
			}
		}

		private void SetBaseInfo()
		{
			XGuildSalaryInfo value = this._Doc.GetValue(this._Doc.SelectTabs);
			this.m_ScoreValue.SetText(value.Score.ToString());
			this.m_ScoreMark.SetText(XGuildSalaryDocument.GetGradeName((int)value.Grade));
			this.m_Progress.value = value.Percent;
			this.m_ProgressLabel.SetText(string.Format("{0}/{1}", value.Value, value.TotalScore));
		}

		private IXUIButton m_Close;

		private XUITabControl m_tabControl = new XUITabControl();

		private IXUIProgress m_Progress;

		private IXUILabel m_ScoreValue;

		private IXUILabel m_ScoreMark;

		private IXUILabel m_ProgressLabel;

		private IXUIScrollView m_ScrollView;

		private IXUIWrapContent m_WrapContent;

		private XGuildSalaryDocument _Doc;

		private List<GuildSalaryDesc.RowData> m_salaryDesc;
	}
}
