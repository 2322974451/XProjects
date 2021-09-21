using System;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C3F RID: 3135
	internal class GuildRelaxJokerHandler : GuildRelaxChildHandler
	{
		// Token: 0x0600B19A RID: 45466 RVA: 0x00221816 File Offset: 0x0021FA16
		protected override void Init()
		{
			this.m_moduleID = XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_GuildRelax_Joker);
			base.Init();
		}

		// Token: 0x0600B19B RID: 45467 RVA: 0x00221830 File Offset: 0x0021FA30
		protected override void OnGameClick(IXUITexture sp)
		{
			DlgBase<XGuildJokerView, XGuildJokerBehaviour>.singleton.SetVisibleWithAnimation(true, null);
		}

		// Token: 0x0600B19C RID: 45468 RVA: 0x00221840 File Offset: 0x0021FA40
		public override void RefreshRedPoint()
		{
			XGuildJokerDocument specificDocument = XDocuments.GetSpecificDocument<XGuildJokerDocument>(XGuildJokerDocument.uuID);
			this.m_redPoint.gameObject.SetActive(specificDocument.GameCount > 0);
		}
	}
}
