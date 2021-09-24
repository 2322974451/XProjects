using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class HallFameBehavior : DlgBehaviourBase
	{

		private void Awake()
		{
			this.CloseBtn = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.RankBtn = (base.transform.Find("Bg/RankList").GetComponent("XUIButton") as IXUIButton);
			this.ShareBtn = (base.transform.Find("Bg/BtnShare").GetComponent("XUIButton") as IXUIButton);
			this.SupportBtn = (base.transform.Find("Bg/Support").GetComponent("XUIButton") as IXUIButton);
			this.HelpBtn = (base.transform.Find("Bg/Help").GetComponent("XUIButton") as IXUIButton);
			this.DateSeasonLabel = (base.transform.Find("Bg/date").GetComponent("XUILabel") as IXUILabel);
			Transform transform = base.transform.Find("Bg/Tabs/TabTpl");
			this.TabPool.SetupPool(transform.parent.gameObject, transform.gameObject, 4U, false);
			this.RoleList = base.transform.Find("Bg/RoleList");
			this.RoleDetail = base.transform.Find("Bg/RoleDetail");
			this.RecentEmpty = this.RoleDetail.Find("HistoryRecord/Emport");
			this.CurrentEmpty = this.RoleDetail.Find("Empty");
			this.EffectWidget = base.transform.Find("Bg/EffectWidget").gameObject;
		}

		public IXUIButton CloseBtn;

		public IXUIButton RankBtn;

		public IXUIButton ShareBtn;

		public IXUIButton SupportBtn;

		public IXUIButton HelpBtn;

		public IXUILabel DateSeasonLabel;

		public XUIPool TabPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public Transform RoleList;

		public Transform RoleDetail;

		public Transform RecentEmpty;

		public Transform CurrentEmpty;

		public GameObject EffectWidget;
	}
}
