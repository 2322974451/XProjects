using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x020017CE RID: 6094
	internal class MobaBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600FC7C RID: 64636 RVA: 0x003AEA78 File Offset: 0x003ACC78
		private void Awake()
		{
			this.m_Texture = (base.transform.FindChild("End/Icon").GetComponent("XUITexture") as IXUITexture);
		}

		// Token: 0x04006EFD RID: 28413
		public IXUITexture m_Texture;
	}
}
