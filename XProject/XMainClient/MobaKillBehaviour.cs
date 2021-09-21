using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C51 RID: 3153
	public class MobaKillBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600B2E0 RID: 45792 RVA: 0x0022AEC8 File Offset: 0x002290C8
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

		// Token: 0x04004516 RID: 17686
		public Transform[] m_killTypes;

		// Token: 0x04004517 RID: 17687
		public Transform m_leftHeader;

		// Token: 0x04004518 RID: 17688
		public Transform m_rightHeader;

		// Token: 0x04004519 RID: 17689
		public XUIPool m_helpMembers = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x0400451A RID: 17690
		public Transform m_helpTransform;

		// Token: 0x0400451B RID: 17691
		public IXUIPlayTweenGroup m_playGroup;

		// Token: 0x0400451C RID: 17692
		public Transform KillTransform;

		// Token: 0x0400451D RID: 17693
		public Transform MessageTransform;

		// Token: 0x0400451E RID: 17694
		public IXUILabel m_MessageLabel;
	}
}
