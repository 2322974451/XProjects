using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class XFriendsBlockBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
		}

		public IXUIButton m_Close;

		public static readonly uint FUNCTION_NUM = 3U;
	}
}
