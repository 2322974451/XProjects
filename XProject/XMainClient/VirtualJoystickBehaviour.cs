using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class VirtualJoystickBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Panel = (base.transform.FindChild("Bg").GetComponent("XUISprite") as IXUISprite);
			this.m_Joystick = (base.transform.FindChild("Bg/Joystick").GetComponent("XUISprite") as IXUISprite);
			this.m_Direction = base.transform.FindChild("Bg/Joystick/Dir").gameObject;
		}

		public IXUISprite m_Panel;

		public IXUISprite m_Joystick;

		public GameObject m_Direction;
	}
}
