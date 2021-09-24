using System;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class GuildRelaxJokerHandler : GuildRelaxChildHandler
	{

		protected override void Init()
		{
			this.m_moduleID = XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_GuildRelax_Joker);
			base.Init();
		}

		protected override void OnGameClick(IXUITexture sp)
		{
			DlgBase<XGuildJokerView, XGuildJokerBehaviour>.singleton.SetVisibleWithAnimation(true, null);
		}

		public override void RefreshRedPoint()
		{
			XGuildJokerDocument specificDocument = XDocuments.GetSpecificDocument<XGuildJokerDocument>(XGuildJokerDocument.uuID);
			this.m_redPoint.gameObject.SetActive(specificDocument.GameCount > 0);
		}
	}
}
