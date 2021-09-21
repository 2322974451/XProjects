using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000F15 RID: 3861
	internal class VirtualJoystickBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600CCE2 RID: 52450 RVA: 0x002F3828 File Offset: 0x002F1A28
		private void Awake()
		{
			this.m_Panel = (base.transform.FindChild("Bg").GetComponent("XUISprite") as IXUISprite);
			this.m_Joystick = (base.transform.FindChild("Bg/Joystick").GetComponent("XUISprite") as IXUISprite);
			this.m_Direction = base.transform.FindChild("Bg/Joystick/Dir").gameObject;
		}

		// Token: 0x04005B19 RID: 23321
		public IXUISprite m_Panel;

		// Token: 0x04005B1A RID: 23322
		public IXUISprite m_Joystick;

		// Token: 0x04005B1B RID: 23323
		public GameObject m_Direction;
	}
}
