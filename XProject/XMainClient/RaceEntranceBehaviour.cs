using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000CAB RID: 3243
	internal class RaceEntranceBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600B69D RID: 46749 RVA: 0x002437A0 File Offset: 0x002419A0
		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Help = (base.transform.FindChild("Bg/Help").GetComponent("XUIButton") as IXUIButton);
			this.m_SingleJoin = (base.transform.FindChild("Bg/SingleJoin").GetComponent("XUIButton") as IXUIButton);
			this.m_GameRule = (base.transform.FindChild("Bg/GameRule").GetComponent("XUILabel") as IXUILabel);
			Transform transform = base.transform.FindChild("Bg/Reward/RewardList/ItemTpl");
			this.m_RewardPool.SetupPool(null, transform.gameObject, 3U, false);
		}

		// Token: 0x04004777 RID: 18295
		public IXUIButton m_Close;

		// Token: 0x04004778 RID: 18296
		public IXUIButton m_Help;

		// Token: 0x04004779 RID: 18297
		public IXUIButton m_SingleJoin;

		// Token: 0x0400477A RID: 18298
		public IXUILabel m_GameRule;

		// Token: 0x0400477B RID: 18299
		public XUIPool m_RewardPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
