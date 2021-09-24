using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XLifeTargetDlgBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_close = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			Transform transform = base.transform.Find("Bg/Bg/Panel/TargetTpl");
			this.m_TargetPool.SetupPool(transform.parent.gameObject, transform.gameObject, 5U, false);
			this.m_ScrollView = (base.transform.FindChild("Bg/Bg/Panel").GetComponent("XUIScrollView") as IXUIScrollView);
		}

		public XUIPool m_TargetPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUIButton m_close;

		public IXUIScrollView m_ScrollView;
	}
}
