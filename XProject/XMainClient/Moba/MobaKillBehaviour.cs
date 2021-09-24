using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	public class MobaKillBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_playGroup = (base.transform.GetComponent("XUIPlayTweenGroup") as IXUIPlayTweenGroup);
			int num = XFastEnumIntEqualityComparer<MobaKillEnum>.ToInt(MobaKillEnum.KILL_START);
			int num2 = XFastEnumIntEqualityComparer<MobaKillEnum>.ToInt(MobaKillEnum.KILL_END);
			this.m_killTypes = new Transform[num2];
			for (int i = num; i < num2; i++)
			{
				string text = string.Format("Kill/Killer/{0}Kill", i - num);
				this.m_killTypes[i] = base.transform.Find(text);
			}
			this.m_helpTransform = base.transform.Find("Kill/Killer/help");
			this.m_leftHeader = base.transform.Find("Kill/Killer/condition/blue");
			this.m_rightHeader = base.transform.Find("Kill/Killer/condition/red");
			Transform transform = base.transform.Find("Kill/Killer/help/Members/Temp");
			this.m_helpMembers.SetupPool(transform.parent.gameObject, transform.gameObject, 3U, false);
			this.KillTransform = base.transform.Find("Kill/Killer");
			this.MessageTransform = base.transform.Find("Kill/Message");
			this.m_MessageLabel = (base.transform.Find("Kill/Message/bg/p").GetComponent("XUILabel") as IXUILabel);
		}

		public Transform[] m_killTypes;

		public Transform m_leftHeader;

		public Transform m_rightHeader;

		public XUIPool m_helpMembers = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public Transform m_helpTransform;

		public IXUIPlayTweenGroup m_playGroup;

		public Transform KillTransform;

		public Transform MessageTransform;

		public IXUILabel m_MessageLabel;
	}
}
