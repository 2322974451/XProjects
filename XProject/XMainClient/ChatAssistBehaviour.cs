using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000CBC RID: 3260
	internal class ChatAssistBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600B754 RID: 46932 RVA: 0x00247DD4 File Offset: 0x00245FD4
		private void Awake()
		{
			this.m_btnEmotion = (base.transform.Find("Tabs/SmallTab_emo").GetComponent("XUIButton") as IXUIButton);
			this.m_btnHistory = (base.transform.Find("Tabs/SmallTab_his").GetComponent("XUIButton") as IXUIButton);
			this.m_objEmotionTpl = base.transform.Find("ChatEmotion/template").gameObject;
			this.m_sprBg = (base.transform.Find("Bg").GetComponent("XUISprite") as IXUISprite);
			this.m_loophistoryView = (base.transform.FindChild("ChatHistory/loopscroll").GetComponent("LoopScrollView") as ILoopScrollView);
			this.m_objEmotion = base.transform.Find("ChatEmotion").gameObject;
			this.m_objHistory = base.transform.Find("ChatHistory").gameObject;
			this.m_ChatEmotionPool.SetupPool(this.m_objEmotion, this.m_objEmotionTpl, 24U, false);
		}

		// Token: 0x040047FC RID: 18428
		public IXUIButton m_btnEmotion;

		// Token: 0x040047FD RID: 18429
		public IXUIButton m_btnHistory;

		// Token: 0x040047FE RID: 18430
		public GameObject m_objEmotionTpl;

		// Token: 0x040047FF RID: 18431
		public XUIPool m_ChatEmotionPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04004800 RID: 18432
		public IXUISprite m_sprBg;

		// Token: 0x04004801 RID: 18433
		public ILoopScrollView m_loophistoryView;

		// Token: 0x04004802 RID: 18434
		public GameObject m_objEmotion;

		// Token: 0x04004803 RID: 18435
		public GameObject m_objHistory;
	}
}
