using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	internal class GuildJockerMatchView<T> : DlgBase<T, XGuildJokerBehaviour> where T : IXUIDlg, new()
	{

		public override string fileName
		{
			get
			{
				return "Guild/GuildSystem/GuildJokerMatchDlg";
			}
		}
	}
}
