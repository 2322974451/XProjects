using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	internal class XGuildGrowthDonateBehavior : DlgBehaviourBase
	{

		private void Awake()
		{
			this.RecordDlg = base.transform.Find("RecordDlg").gameObject;
			this.RecordDlgScrollView = (base.transform.Find("RecordDlg/ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.RecordWrapContent = (base.transform.Find("RecordDlg/ScrollView/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.ScrollView = (base.transform.Find("Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			this.WrapContent = (base.transform.Find("Panel/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.CloseBtn = (base.transform.Find("Close").GetComponent("XUIButton") as IXUIButton);
			this.RecordBtn = (base.transform.Find("RecordBtn").GetComponent("XUIButton") as IXUIButton);
		}

		public GameObject RecordDlg;

		public IXUIScrollView ScrollView;

		public IXUIWrapContent WrapContent;

		public IXUIButton CloseBtn;

		public IXUIButton RecordBtn;

		public IXUIScrollView RecordDlgScrollView;

		public IXUIWrapContent RecordWrapContent;
	}
}
