using System;

namespace XMainClient
{
	// Token: 0x02000F64 RID: 3940
	internal class XBillboardShowCtrlEventArgs : XEventArgs
	{
		// Token: 0x0600D037 RID: 53303 RVA: 0x00304299 File Offset: 0x00302499
		public XBillboardShowCtrlEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_BillboardShowCtrl;
		}

		// Token: 0x0600D038 RID: 53304 RVA: 0x003042B2 File Offset: 0x003024B2
		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XBillboardShowCtrlEventArgs>.Recycle(this);
		}

		// Token: 0x04005E25 RID: 24101
		public bool show;

		// Token: 0x04005E26 RID: 24102
		public BillBoardHideType type = BillBoardHideType.Invalid;
	}
}
