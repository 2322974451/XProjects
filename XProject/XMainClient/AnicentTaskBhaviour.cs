using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class AnicentTaskBhaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.boxTpl = base.transform.Find("Bg/TaskTitle/option1").gameObject;
			this.m_content = (base.transform.Find("Bg/condition/condition1").GetComponent("XUILabel") as IXUILabel);
			this.m_time = (base.transform.Find("Bg/condition/Time").GetComponent("XUILabel") as IXUILabel);
			this.itemTpl = base.transform.Find("Bg/condition/ItemList/ItemTpl").gameObject;
			this.itemTpl.SetActive(false);
			this.m_btnClose = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_tabpool.SetupPool(this.boxTpl.transform.parent.gameObject, this.boxTpl, 2U, false);
			this.m_rwdpool.SetupPool(this.itemTpl.transform.parent.gameObject, this.itemTpl, 2U, false);
		}

		public GameObject boxTpl;

		public GameObject itemTpl;

		public IXUILabel m_time;

		public IXUILabel m_content;

		public XUIPool m_tabpool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool m_rwdpool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUIButton m_btnClose;
	}
}
