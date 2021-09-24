using System;

namespace XMainClient
{

	internal class XItemChangeFinishedEventArgs : XEventArgs
	{

		public XItemChangeFinishedEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_ItemChangeFinished;
		}

		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XItemChangeFinishedEventArgs>.Recycle(this);
		}
	}
}
