using System;
using System.Collections.Generic;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020009F7 RID: 2551
	internal class XSystemTipDocument : XDocComponent
	{
		// Token: 0x17002E5D RID: 11869
		// (get) Token: 0x06009C20 RID: 39968 RVA: 0x00191F38 File Offset: 0x00190138
		public override uint ID
		{
			get
			{
				return XSystemTipDocument.uuID;
			}
		}

		// Token: 0x06009C21 RID: 39969 RVA: 0x00191F50 File Offset: 0x00190150
		public void ShowTip(string text, string rgb)
		{
			this.m_StrQueue.Enqueue(string.Format("[{0}]{1}", rgb, text));
			bool flag = !DlgBase<XSystemTipView, XSystemTipBehaviour>.singleton.IsVisible();
			if (flag)
			{
				bool flag2 = DlgBase<XSystemTipView, XSystemTipBehaviour>.singleton.IsVisible();
				if (flag2)
				{
					DlgBase<XSystemTipView, XSystemTipBehaviour>.singleton.SetAlpha(1f);
				}
				DlgBase<XSystemTipView, XSystemTipBehaviour>.singleton.SetVisible(true, true);
			}
		}

		// Token: 0x06009C22 RID: 39970 RVA: 0x00191FB8 File Offset: 0x001901B8
		public bool TryGetTip(ref string s)
		{
			bool flag = this.m_StrQueue.Count == 0;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				s = this.m_StrQueue.Dequeue();
				result = true;
			}
			return result;
		}

		// Token: 0x17002E5E RID: 11870
		// (get) Token: 0x06009C23 RID: 39971 RVA: 0x00191FF0 File Offset: 0x001901F0
		public int LeftCount
		{
			get
			{
				return this.m_StrQueue.Count;
			}
		}

		// Token: 0x06009C24 RID: 39972 RVA: 0x0019200D File Offset: 0x0019020D
		public override void OnLeaveScene()
		{
			base.OnLeaveScene();
			this.m_StrQueue.Clear();
		}

		// Token: 0x06009C25 RID: 39973 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x040036AB RID: 13995
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("SystemTipDocument");

		// Token: 0x040036AC RID: 13996
		private Queue<string> m_StrQueue = new Queue<string>();
	}
}
