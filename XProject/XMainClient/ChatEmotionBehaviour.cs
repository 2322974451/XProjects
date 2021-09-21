using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000CC3 RID: 3267
	internal class ChatEmotionBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600B77C RID: 46972 RVA: 0x00248A98 File Offset: 0x00246C98
		private void Awake()
		{
			this.m_sprEmotion = (base.transform.Find("Emotion").GetComponent("XUISprite") as IXUISprite);
			this.m_sprP = (base.transform.Find("P").GetComponent("XUISprite") as IXUISprite);
			this.m_objEmotionTpl = base.transform.Find("Emotion/template").gameObject;
			this.m_ChatEmotionPool.SetupPool(this.m_sprEmotion.gameObject, this.m_objEmotionTpl, 24U, false);
		}

		// Token: 0x04004815 RID: 18453
		public IXUISprite m_sprEmotion;

		// Token: 0x04004816 RID: 18454
		public IXUISprite m_sprP;

		// Token: 0x04004817 RID: 18455
		public GameObject m_objEmotionTpl;

		// Token: 0x04004818 RID: 18456
		public XUIPool m_ChatEmotionPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
