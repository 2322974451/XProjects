using System;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000992 RID: 2450
	internal class XPPTDocument : XDocComponent
	{
		// Token: 0x17002CC6 RID: 11462
		// (get) Token: 0x06009378 RID: 37752 RVA: 0x00158E0C File Offset: 0x0015700C
		public override uint ID
		{
			get
			{
				return XPPTDocument.uuID;
			}
		}

		// Token: 0x06009379 RID: 37753 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x0600937A RID: 37754 RVA: 0x00158E23 File Offset: 0x00157023
		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
			DlgBase<PPTDlg, PPTBehaviour>.singleton.UnInit();
		}

		// Token: 0x04003192 RID: 12690
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("PPTDocument");
	}
}
