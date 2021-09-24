using System;

namespace XMainClient
{

	internal class XBillboardShowCtrlEventArgs : XEventArgs
	{

		public XBillboardShowCtrlEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_BillboardShowCtrl;
		}

		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XBillboardShowCtrlEventArgs>.Recycle(this);
		}

		public bool show;

		public BillBoardHideType type = BillBoardHideType.Invalid;
	}
}
