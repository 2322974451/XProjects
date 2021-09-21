using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E59 RID: 3673
	internal class XOnlineRewardBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600C4D5 RID: 50389 RVA: 0x002B1F34 File Offset: 0x002B0134
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

		// Token: 0x040055D8 RID: 21976
		public IXUIButton m_Close;

		// Token: 0x040055D9 RID: 21977
		public IXUIButton m_GetReward;

		// Token: 0x040055DA RID: 21978
		public IXUILabel m_TimeTip;

		// Token: 0x040055DB RID: 21979
		public IXUILabel m_LeftTime;

		// Token: 0x040055DC RID: 21980
		public IXUILabel m_GetRewardLabel;

		// Token: 0x040055DD RID: 21981
		public XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040055DE RID: 21982
		public IXUITweenTool m_BgTween;
	}
}
