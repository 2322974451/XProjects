using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class ItemAccessDlgBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Item = base.transform.FindChild("Bg/Item").gameObject;
			this.m_BossItem = base.transform.FindChild("Bg/Boss").gameObject;
			this.m_bossDec = (this.m_BossItem.transform.Find("Des").GetComponent("XUILabel") as IXUILabel);
			Transform transform = base.transform.FindChild("Bg/ListPanel/ItemTpl");
			this.m_RecordPool.SetupPool(transform.parent.gameObject, transform.gameObject, 4U, false);
			this.m_RecordScrollView = (base.transform.FindChild("Bg/ListPanel").GetComponent("XUIScrollView") as IXUIScrollView);
		}

		public GameObject m_Item;

		public XUIPool m_RecordPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUIScrollView m_RecordScrollView;

		public IXUIButton m_Close;

		public GameObject m_BossItem;

		public IXUILabel m_bossDec;
	}
}
