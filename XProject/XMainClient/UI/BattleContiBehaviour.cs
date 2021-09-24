using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class BattleContiBehaviour : DlgBehaviourBase
	{

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

		public IXUILabel m_killer;

		public IXUILabel m_deader;

		public IXUISprite m_KillText;

		public Transform m_Parent;

		public Transform m_InfoTpl;

		public IXUITweenTool[] m_Killicon = new IXUITweenTool[XBattleCaptainPVPDocument.CONTINUOUS_KILL + 1U];

		public IXUITweenTool m_AssitIcon;

		public IXPositionGroup m_KillInfoGroup = null;
	}
}
