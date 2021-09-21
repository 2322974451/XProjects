using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000BD3 RID: 3027
	public class CreateChatGroupBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600ACFA RID: 44282 RVA: 0x002007E4 File Offset: 0x001FE9E4
		private void Awake()
		{
			Transform transform = base.transform.FindChild("Bg/p/T");
			this.m_Label = (transform.GetComponent("XUILabel") as IXUILabel);
			Transform transform2 = base.transform.FindChild("Bg/ok");
			this.m_OKButton = (transform2.GetComponent("XUIButton") as IXUIButton);
			Transform transform3 = base.transform.FindChild("Bg/Close");
			this.m_sprClose = (transform3.GetComponent("XUISprite") as IXUISprite);
		}

		// Token: 0x04004110 RID: 16656
		public IXUILabel m_Label = null;

		// Token: 0x04004111 RID: 16657
		public IXUIButton m_OKButton = null;

		// Token: 0x04004112 RID: 16658
		public IXUISprite m_sprClose = null;
	}
}
