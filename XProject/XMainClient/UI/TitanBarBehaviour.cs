using System;
using System.Collections.Generic;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class TitanBarBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			Transform transform = base.transform.Find("TitanFrame/ItemTpl");
			this.m_ItemPool.SetupPool(transform.parent.gameObject, transform.gameObject, 2U, false);
		}

		public List<XTitanItem> m_ItemList = new List<XTitanItem>();

		public List<GameObject> m_ItemGoList = new List<GameObject>();

		public XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
