using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI.Battle
{
	// Token: 0x02001937 RID: 6455
	internal class BattleQTEDlgBehaviour : DlgBehaviourBase
	{
		// Token: 0x06010F87 RID: 69511 RVA: 0x004518A4 File Offset: 0x0044FAA4
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

		// Token: 0x04007D10 RID: 32016
		public Transform m_Block;

		// Token: 0x04007D11 RID: 32017
		public Transform m_Bind;

		// Token: 0x04007D12 RID: 32018
		public IXUISprite m_BindLeftButton;

		// Token: 0x04007D13 RID: 32019
		public IXUISprite m_BindRightButton;

		// Token: 0x04007D14 RID: 32020
		public Transform m_BindArrow;

		// Token: 0x04007D15 RID: 32021
		public Transform m_Abnormal;

		// Token: 0x04007D16 RID: 32022
		public IXUISlider m_AbnormalBar;

		// Token: 0x04007D17 RID: 32023
		public IXUISprite m_AbnormalClickSpace;

		// Token: 0x04007D18 RID: 32024
		public IXUITweenTool m_AbnormalBeginTween;

		// Token: 0x04007D19 RID: 32025
		public IXUITweenTool m_AbnormalHitTween;

		// Token: 0x04007D1A RID: 32026
		public IXUITweenTool m_AbnormalSuccessTween;

		// Token: 0x04007D1B RID: 32027
		public IXUITweenTool m_AbnormalFailTween;

		// Token: 0x04007D1C RID: 32028
		public Transform m_AbnormalLeftTarget;

		// Token: 0x04007D1D RID: 32029
		public Transform m_AbnormalRightTarget;

		// Token: 0x04007D1E RID: 32030
		public Transform m_AbnormalThumb;

		// Token: 0x04007D1F RID: 32031
		public Transform m_Charge;

		// Token: 0x04007D20 RID: 32032
		public IXUISlider m_ChargeBar;
	}
}
