using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x02001886 RID: 6278
	internal class BattleDramaDlgBehaviour : DlgBehaviourBase
	{
		// Token: 0x0601054E RID: 66894 RVA: 0x003F55BC File Offset: 0x003F37BC
		private void Awake()
		{
			this.m_TaskArea = base.transform.FindChild("_canvas/TalkTextBg/TaskText");
			this.m_name = (base.transform.FindChild("_canvas/TalkTextBg/Text").GetComponent("XUILabel") as IXUILabel);
			this.m_RightText = (base.transform.FindChild("_canvas/TalkTextBg/TaskText/Text").GetComponent("XUILabel") as IXUILabel);
			this.m_LeftText = (base.transform.FindChild("_canvas/TalkTextBg/TaskText/PlayerText").GetComponent("XUILabel") as IXUILabel);
			this.m_leftSnapshot = (base.transform.FindChild("_canvas/LeftSnapshot").GetComponent("UIDummy") as IUIDummy);
			this.m_rightSnapshot = (base.transform.FindChild("_canvas/RightSnapshot").GetComponent("UIDummy") as IUIDummy);
			this.m_leftDummyPos = this.m_leftSnapshot.transform.localPosition;
			this.m_rightDummyPos = this.m_rightSnapshot.transform.localPosition;
		}

		// Token: 0x0400759D RID: 30109
		public IUIDummy m_leftSnapshot;

		// Token: 0x0400759E RID: 30110
		public IUIDummy m_rightSnapshot;

		// Token: 0x0400759F RID: 30111
		public Vector3 m_leftDummyPos;

		// Token: 0x040075A0 RID: 30112
		public Vector3 m_rightDummyPos;

		// Token: 0x040075A1 RID: 30113
		public IXUILabel m_name;

		// Token: 0x040075A2 RID: 30114
		public Transform m_TaskArea;

		// Token: 0x040075A3 RID: 30115
		public IXUILabel m_RightText;

		// Token: 0x040075A4 RID: 30116
		public IXUILabel m_LeftText;
	}
}
