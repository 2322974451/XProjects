using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XBriefStrengthenBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Close = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Close2 = (base.transform.Find("Bg").GetComponent("XUISprite") as IXUISprite);
			Transform transform = base.transform.FindChild("Bg/P/Tpl");
			this.m_FuncPool.SetupPool(transform.parent.gameObject, transform.gameObject, 3U, false);
			this.m_More = (base.transform.FindChild("Bg/More").GetComponent("XUILabel") as IXUILabel);
		}

		public IXUIButton m_Close;

		public IXUISprite m_Close2;

		public IXUILabel m_More;

		public XUIPool m_FuncPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
