using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class BattleContinueDlgBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Continue = (base.transform.FindChild("Bg/Continue").GetComponent("XUIButton") as IXUIButton);
			this.m_tween = (base.transform.FindChild("Bg/Continue").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_Next = base.transform.FindChild("Bg/Next");
			this.m_lblNum = (this.m_Next.transform.FindChild("Num").GetComponent("XUILabel") as IXUILabel);
			Transform transform = base.transform.Find("Bg/Next/Item");
			this.m_NextItemPool.SetupPool(transform.parent.gameObject, transform.gameObject, 3U, false);
		}

		public IXUIButton m_Continue;

		public IXUITweenTool m_tween;

		public Transform m_Next;

		public IXUILabel m_lblNum;

		public XUIPool m_NextItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
