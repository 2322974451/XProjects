using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x0200186B RID: 6251
	internal class TitleShareBehaviour : DlgBehaviourBase
	{
		// Token: 0x06010463 RID: 66659 RVA: 0x003F0384 File Offset: 0x003EE584
		private void Awake()
		{
			this.m_snapshotTransfrom = (base.transform.FindChild("Bg/Snapshot").GetComponent("UIDummy") as IUIDummy);
			this.m_maskTexture = (base.transform.FindChild("Bg/Texture").GetComponent("XUITexture") as IXUITexture);
			this.m_currentTitle.Init(base.transform.FindChild("Bg/Current"));
			this.m_closeTips = base.transform.FindChild("Bg/KeepOn");
			this.m_message = (base.transform.FindChild("Bg/Message").GetComponent("XUILabel") as IXUILabel);
			this.m_Close = (base.transform.FindChild("Bg/P").GetComponent("XUISprite") as IXUISprite);
		}

		// Token: 0x04007507 RID: 29959
		public TitleDisplay m_currentTitle = new TitleDisplay();

		// Token: 0x04007508 RID: 29960
		public IXUITexture m_maskTexture;

		// Token: 0x04007509 RID: 29961
		public IUIDummy m_snapshotTransfrom;

		// Token: 0x0400750A RID: 29962
		public Transform m_closeTips;

		// Token: 0x0400750B RID: 29963
		public IXUILabel m_message;

		// Token: 0x0400750C RID: 29964
		public IXUISprite m_Close;
	}
}
