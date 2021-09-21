using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x02001844 RID: 6212
	internal class RewdAnimBehaviour : DlgBehaviourBase
	{
		// Token: 0x0601022E RID: 66094 RVA: 0x003DCB74 File Offset: 0x003DAD74
		private void Awake()
		{
			Transform transform = base.transform.FindChild("Bg/ItemTpl");
			this.m_btnok = (base.transform.Find("OK").GetComponent("XUIButton") as IXUIButton);
			this.m_tweenbg = (base.transform.Find("CriticalConfirm/P").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_tweentitle = (base.transform.Find("CriticalConfirm/P/titleLabel").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_TitleLabel = (base.transform.Find("CriticalConfirm/P/titleLabel").GetComponent("XUILabel") as IXUILabel);
			this.m_objTmp = base.transform.Find("items/tmp").gameObject;
		}

		// Token: 0x04007330 RID: 29488
		public GameObject m_objTmp;

		// Token: 0x04007331 RID: 29489
		public IXUIButton m_btnok;

		// Token: 0x04007332 RID: 29490
		public IXUITweenTool m_tweenbg;

		// Token: 0x04007333 RID: 29491
		public IXUITweenTool m_tweentitle;

		// Token: 0x04007334 RID: 29492
		public IXUILabel m_TitleLabel;
	}
}
