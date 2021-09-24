using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	internal class ReviveDlgBehaviour : DlgBehaviourBase
	{

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

		public Transform m_ReviveFrame;

		public IXUITweenTool m_ReviveFrameTween;

		public IXUIButton m_ReviveButton;

		public IXUIButton m_CancelButton;

		public IXUILabel m_ReviveCost;

		public IXUISprite m_ReviveCostIcon;

		public IXUILabel m_ReviveBuff;

		public IXUILabel m_ReviveLeftTime;
	}
}
