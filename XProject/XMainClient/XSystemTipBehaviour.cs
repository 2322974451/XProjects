using System;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XSystemTipBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			Transform transform = base.transform.FindChild("Bg/TipTpl");
			this.m_TipPool.SetupPool(transform.parent.gameObject, transform.gameObject, 10U, false);
		}

		public XUIPool m_TipPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
