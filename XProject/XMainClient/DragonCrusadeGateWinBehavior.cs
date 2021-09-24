using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class DragonCrusadeGateWinBehavior : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_ContinueBtn = (base.transform.FindChild("Win/Continue").GetComponent("XUIButton") as IXUIButton);
			this.m_ReturnSpr = (base.transform.FindChild("Failed/Bg/Return").GetComponent("XUISprite") as IXUISprite);
			this.m_ShareBtn = (base.transform.FindChild("Win/Share").GetComponent("XUIButton") as IXUIButton);
			this.goWin = base.transform.Find("Win").gameObject;
			this.goFailed = base.transform.Find("Failed").gameObject;
			this.m_WinPool.SetupPool(base.transform.FindChild("Win/Next").gameObject, base.transform.FindChild("Win/Next/Item").gameObject, 5U, false);
			this.m_WinFrame = (base.transform.FindChild("Win/Next").GetComponent("XUISprite") as IXUISprite);
			this.m_FailedPool.SetupPool(base.transform.FindChild("Failed/Bg/ItemList").gameObject, base.transform.FindChild("Failed/Bg/ItemList/Item").gameObject, 5U, false);
			this.m_FailedFrame = (base.transform.FindChild("Failed/Bg/ItemList").GetComponent("XUISprite") as IXUISprite);
		}

		public GameObject goWin = null;

		public GameObject goFailed = null;

		public XUIPool m_WinPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool m_FailedPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUISprite m_FailedFrame = null;

		public IXUISprite m_WinFrame = null;

		public IXUIButton m_ContinueBtn;

		public IXUISprite m_ReturnSpr;

		public IXUIButton m_ShareBtn;
	}
}
