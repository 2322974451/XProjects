using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XOnlineRewardBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			Transform transform = base.transform.FindChild("Bg/ItemTpl");
			this.m_ItemPool.SetupPool(transform.parent.gameObject, transform.gameObject, 2U, false);
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_GetReward = (base.transform.FindChild("Bg/GetReward").GetComponent("XUIButton") as IXUIButton);
			this.m_TimeTip = (base.transform.FindChild("Bg/TimeTip").GetComponent("XUILabel") as IXUILabel);
			this.m_LeftTime = (base.transform.FindChild("Bg/LeftTime").GetComponent("XUILabel") as IXUILabel);
			this.m_GetRewardLabel = (base.transform.FindChild("Bg/GetReward/Text").GetComponent("XUILabel") as IXUILabel);
			this.m_BgTween = (base.transform.FindChild("Bg").GetComponent("XUIPlayTween") as IXUITweenTool);
		}

		public IXUIButton m_Close;

		public IXUIButton m_GetReward;

		public IXUILabel m_TimeTip;

		public IXUILabel m_LeftTime;

		public IXUILabel m_GetRewardLabel;

		public XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUITweenTool m_BgTween;
	}
}
