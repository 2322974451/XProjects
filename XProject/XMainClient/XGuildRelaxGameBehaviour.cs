using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000E44 RID: 3652
	internal class XGuildRelaxGameBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600C42D RID: 50221 RVA: 0x002AC724 File Offset: 0x002AA924
		private void Awake()
		{
			this.m_GameTemp = base.transform.FindChild("Bg/GameList/GameTpl").gameObject;
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_GameScrollView = (base.transform.FindChild("Bg/GameList").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_GameTemp.gameObject.SetActive(false);
		}

		// Token: 0x04005541 RID: 21825
		public IXUIButton m_Close;

		// Token: 0x04005542 RID: 21826
		public GameObject m_GameTemp;

		// Token: 0x04005543 RID: 21827
		public IXUIScrollView m_GameScrollView;
	}
}
