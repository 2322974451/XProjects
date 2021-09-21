using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000F01 RID: 3841
	internal class XLifeTargetDlgBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600CC12 RID: 52242 RVA: 0x002EDA04 File Offset: 0x002EBC04
		private void Awake()
		{
			this.m_close = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			Transform transform = base.transform.Find("Bg/Bg/Panel/TargetTpl");
			this.m_TargetPool.SetupPool(transform.parent.gameObject, transform.gameObject, 5U, false);
			this.m_ScrollView = (base.transform.FindChild("Bg/Bg/Panel").GetComponent("XUIScrollView") as IXUIScrollView);
		}

		// Token: 0x04005A9A RID: 23194
		public XUIPool m_TargetPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04005A9B RID: 23195
		public IXUIButton m_close;

		// Token: 0x04005A9C RID: 23196
		public IXUIScrollView m_ScrollView;
	}
}
