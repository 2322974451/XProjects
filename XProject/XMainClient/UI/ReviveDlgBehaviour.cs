using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x0200188D RID: 6285
	internal class ReviveDlgBehaviour : DlgBehaviourBase
	{
		// Token: 0x060105C9 RID: 67017 RVA: 0x003FB608 File Offset: 0x003F9808
		private void Awake()
		{
			this.m_ReviveFrame = base.transform.Find("Frame/ReviveFrame");
			this.m_ReviveFrameTween = (this.m_ReviveFrame.GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_ReviveButton = (this.m_ReviveFrame.Find("Revive").GetComponent("XUIButton") as IXUIButton);
			this.m_CancelButton = (this.m_ReviveFrame.Find("Cancel").GetComponent("XUIButton") as IXUIButton);
			this.m_ReviveCost = (this.m_ReviveFrame.Find("Revive/Cost").GetComponent("XUILabel") as IXUILabel);
			this.m_ReviveCostIcon = (this.m_ReviveFrame.Find("Revive/Cost/Icon").GetComponent("XUISprite") as IXUISprite);
			this.m_ReviveBuff = (this.m_ReviveFrame.Find("Buff").GetComponent("XUILabel") as IXUILabel);
			this.m_ReviveLeftTime = (this.m_ReviveFrame.Find("Revive/LeftTime").GetComponent("XUILabel") as IXUILabel);
			this.m_ReviveFrame.gameObject.SetActive(false);
		}

		// Token: 0x040075ED RID: 30189
		public Transform m_ReviveFrame;

		// Token: 0x040075EE RID: 30190
		public IXUITweenTool m_ReviveFrameTween;

		// Token: 0x040075EF RID: 30191
		public IXUIButton m_ReviveButton;

		// Token: 0x040075F0 RID: 30192
		public IXUIButton m_CancelButton;

		// Token: 0x040075F1 RID: 30193
		public IXUILabel m_ReviveCost;

		// Token: 0x040075F2 RID: 30194
		public IXUISprite m_ReviveCostIcon;

		// Token: 0x040075F3 RID: 30195
		public IXUILabel m_ReviveBuff;

		// Token: 0x040075F4 RID: 30196
		public IXUILabel m_ReviveLeftTime;
	}
}
