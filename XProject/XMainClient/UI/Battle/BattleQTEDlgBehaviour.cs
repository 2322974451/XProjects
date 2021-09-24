using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI.Battle
{

	internal class BattleQTEDlgBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Block = base.transform.Find("Block");
			this.m_Bind = base.transform.Find("Bg/Bind");
			this.m_BindLeftButton = (this.m_Bind.Find("Left/Light").GetComponent("XUISprite") as IXUISprite);
			this.m_BindRightButton = (this.m_Bind.Find("Right/Light").GetComponent("XUISprite") as IXUISprite);
			this.m_BindArrow = this.m_Bind.Find("Arrow");
			this.m_Abnormal = base.transform.Find("Bg/AbnormalBar");
			this.m_AbnormalBar = (this.m_Abnormal.Find("Bar").GetComponent("XUISlider") as IXUISlider);
			this.m_AbnormalClickSpace = (this.m_Abnormal.Find("ClickSpace").GetComponent("XUISprite") as IXUISprite);
			this.m_AbnormalBeginTween = (this.m_Abnormal.Find("Thumb/Begin").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_AbnormalHitTween = (this.m_Abnormal.Find("Thumb/Hit").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_AbnormalSuccessTween = (this.m_Abnormal.Find("Success").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_AbnormalFailTween = (this.m_Abnormal.Find("Fail").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_AbnormalLeftTarget = this.m_Abnormal.Find("Target/Left");
			this.m_AbnormalRightTarget = this.m_Abnormal.Find("Target/Right");
			this.m_AbnormalThumb = this.m_Abnormal.Find("Thumb");
			this.m_Charge = base.transform.Find("Bg/ChargeBar");
			this.m_ChargeBar = (this.m_Charge.GetComponent("XUISlider") as IXUISlider);
		}

		public Transform m_Block;

		public Transform m_Bind;

		public IXUISprite m_BindLeftButton;

		public IXUISprite m_BindRightButton;

		public Transform m_BindArrow;

		public Transform m_Abnormal;

		public IXUISlider m_AbnormalBar;

		public IXUISprite m_AbnormalClickSpace;

		public IXUITweenTool m_AbnormalBeginTween;

		public IXUITweenTool m_AbnormalHitTween;

		public IXUITweenTool m_AbnormalSuccessTween;

		public IXUITweenTool m_AbnormalFailTween;

		public Transform m_AbnormalLeftTarget;

		public Transform m_AbnormalRightTarget;

		public Transform m_AbnormalThumb;

		public Transform m_Charge;

		public IXUISlider m_ChargeBar;
	}
}
