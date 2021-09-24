using System;

namespace XMainClient
{

	internal class XHighlightEventArgs : XEventArgs
	{

		public XHighlightEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_Highlight;
		}

		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XHighlightEventArgs>.Recycle(this);
		}

		public bool Enabled = false;
	}
}
