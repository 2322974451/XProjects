using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001744 RID: 5956
	internal class BattleContiBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600F65C RID: 63068 RVA: 0x0037E1E4 File Offset: 0x0037C3E4
		private void Awake()
		{
			this.m_Parent = base.transform.FindChild("Bg/KillInfoParent");
			this.m_InfoTpl = base.transform.FindChild("Bg/KillInfoParent/InfoTpl");
			this.m_killer = (base.transform.FindChild("Bg/KillInfoParent/InfoTpl/Bg/killer").GetComponent("XUILabel") as IXUILabel);
			this.m_deader = (base.transform.FindChild("Bg/KillInfoParent/InfoTpl/Bg/dead").GetComponent("XUILabel") as IXUILabel);
			this.m_KillText = (base.transform.FindChild("Bg/Continuous/KillText").GetComponent("XUISprite") as IXUISprite);
			this.m_AssitIcon = (base.transform.FindChild("Bg/Continuous/AssistIcon").GetComponent("XUIPlayTween") as IXUITweenTool);
			int num = 1;
			while ((long)num <= (long)((ulong)XBattleCaptainPVPDocument.CONTINUOUS_KILL))
			{
				this.m_Killicon[num] = (base.transform.FindChild(string.Format("Bg/Continuous/Killicon{0}", num)).GetComponent("XUIPlayTween") as IXUITweenTool);
				num++;
			}
			this.m_KillInfoGroup = (this.m_Parent.GetComponent("PositionGroup") as IXPositionGroup);
		}

		// Token: 0x04006AD8 RID: 27352
		public IXUILabel m_killer;

		// Token: 0x04006AD9 RID: 27353
		public IXUILabel m_deader;

		// Token: 0x04006ADA RID: 27354
		public IXUISprite m_KillText;

		// Token: 0x04006ADB RID: 27355
		public Transform m_Parent;

		// Token: 0x04006ADC RID: 27356
		public Transform m_InfoTpl;

		// Token: 0x04006ADD RID: 27357
		public IXUITweenTool[] m_Killicon = new IXUITweenTool[XBattleCaptainPVPDocument.CONTINUOUS_KILL + 1U];

		// Token: 0x04006ADE RID: 27358
		public IXUITweenTool m_AssitIcon;

		// Token: 0x04006ADF RID: 27359
		public IXPositionGroup m_KillInfoGroup = null;
	}
}
