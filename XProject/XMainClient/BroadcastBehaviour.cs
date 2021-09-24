using System;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class BroadcastBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_btnBarrage = (base.transform.Find("Bg/Btn_EndBarrage").GetComponent("XUIButton") as IXUIButton);
			this.m_btnCamera = (base.transform.Find("Bg/Btn_Camera").GetComponent("XUIButton") as IXUIButton);
			this.m_lblCamera = (base.transform.Find("Bg/Btn_Camera/T").GetComponent("XUILabel") as IXUILabel);
			this.m_btnClose = (base.transform.Find("Bg/Btn_Close").GetComponent("XUIButton") as IXUIButton);
			this.m_btnShare = (base.transform.Find("Bg/Btn_Share").GetComponent("XUIButton") as IXUIButton);
			this.loopScrool = (base.transform.FindChild("Bg/Barrages").GetComponent("LoopScrollView") as ILoopScrollView);
		}

		public ILoopScrollView loopScrool;

		public IXUIButton m_btnBarrage;

		public IXUIButton m_btnCamera;

		public IXUILabel m_lblCamera;

		public IXUIButton m_btnClose;

		public IXUIButton m_btnShare;
	}
}
