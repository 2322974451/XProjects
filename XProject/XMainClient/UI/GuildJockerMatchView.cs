using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x020017A7 RID: 6055
	internal class GuildJockerMatchView<T> : DlgBase<T, XGuildJokerBehaviour> where T : IXUIDlg, new()
	{
		// Token: 0x1700386B RID: 14443
		// (get) Token: 0x0600FA5D RID: 64093 RVA: 0x0039DDAC File Offset: 0x0039BFAC
		public override string fileName
		{
			get
			{
				return "Guild/GuildSystem/GuildJokerMatchDlg";
			}
		}
	}
}
