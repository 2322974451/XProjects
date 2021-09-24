using System;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XPPTDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XPPTDocument.uuID;
			}
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
			DlgBase<PPTDlg, PPTBehaviour>.singleton.UnInit();
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("PPTDocument");
	}
}
