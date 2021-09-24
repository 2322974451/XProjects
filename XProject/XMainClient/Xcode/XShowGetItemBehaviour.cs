using System;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XShowGetItemBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			Transform transform = base.transform.FindChild("Bg/TipTpl");
			this.m_ShowItemPool.SetupPool(transform.parent.gameObject, transform.gameObject, 5U, false);
			this.m_Bg = base.transform.FindChild("Bg");
		}

		public XUIPool m_ShowItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public Transform m_Bg = null;
	}
}
