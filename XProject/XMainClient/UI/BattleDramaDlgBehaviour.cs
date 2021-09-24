using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	internal class BattleDramaDlgBehaviour : DlgBehaviourBase
	{

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

		public IUIDummy m_leftSnapshot;

		public IUIDummy m_rightSnapshot;

		public Vector3 m_leftDummyPos;

		public Vector3 m_rightDummyPos;

		public IXUILabel m_name;

		public Transform m_TaskArea;

		public IXUILabel m_RightText;

		public IXUILabel m_LeftText;
	}
}
