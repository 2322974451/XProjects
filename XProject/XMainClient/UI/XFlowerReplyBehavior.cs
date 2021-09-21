using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x02001828 RID: 6184
	internal class XFlowerReplyBehavior : DlgBehaviourBase
	{
		// Token: 0x060100DD RID: 65757 RVA: 0x003D3ED8 File Offset: 0x003D20D8
		private void Awake()
		{
			this.m_SpeakPanel = base.transform.FindChild("Bg/SpeakPanel");
			this.m_SenderName = (base.transform.FindChild("Bg/SenderName").GetComponent("XUILabel") as IXUILabel);
			this.m_SenderCount = (base.transform.FindChild("Bg/SendCount").GetComponent("XUILabel") as IXUILabel);
			this.m_FlowerName = (base.transform.FindChild("Bg/FlowerName").GetComponent("XUILabel") as IXUILabel);
			this.m_QuickThx = (base.transform.FindChild("Bg/BtnTHx").GetComponent("XUIButton") as IXUIButton);
			this.m_Voice = (base.transform.FindChild("Bg/speak").GetComponent("XUIButton") as IXUIButton);
			this.m_Close = (base.transform.FindChild("InputBlocker").GetComponent("XUISprite") as IXUISprite);
			this.m_ThxContent = (base.transform.FindChild("Bg/ThxContent").GetComponent("XUILabel") as IXUILabel);
			GameObject gameObject = base.transform.FindChild("Bg/Bg2").gameObject;
			GameObject gameObject2 = base.transform.FindChild("Bg/Bg2_Advance").gameObject;
			GameObject gameObject3 = base.transform.FindChild("Bg/Bg2_Elite").gameObject;
			this.m_ReplayBgList.Add(gameObject);
			this.m_ReplayBgList.Add(gameObject2);
			this.m_ReplayBgList.Add(gameObject3);
		}

		// Token: 0x04007269 RID: 29289
		public IXUILabel m_SenderName = null;

		// Token: 0x0400726A RID: 29290
		public IXUILabel m_SenderCount = null;

		// Token: 0x0400726B RID: 29291
		public IXUILabel m_FlowerName = null;

		// Token: 0x0400726C RID: 29292
		public IXUILabel m_ThxContent = null;

		// Token: 0x0400726D RID: 29293
		public IXUISprite m_Close = null;

		// Token: 0x0400726E RID: 29294
		public IXUIButton m_Voice = null;

		// Token: 0x0400726F RID: 29295
		public IXUIButton m_QuickThx = null;

		// Token: 0x04007270 RID: 29296
		public Transform m_SpeakPanel = null;

		// Token: 0x04007271 RID: 29297
		public List<GameObject> m_ReplayBgList = new List<GameObject>();
	}
}
