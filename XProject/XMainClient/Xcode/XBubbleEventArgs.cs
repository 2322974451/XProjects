using System;

namespace XMainClient
{

	internal class XBubbleEventArgs : XEventArgs
	{

		public XBubbleEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_Bubble;
		}

		public override void Recycle()
		{
			this.bubbletext = null;
			this.existtime = 0f;
			base.Recycle();
			XEventPool<XBubbleEventArgs>.Recycle(this);
		}

		public string bubbletext { get; set; }

		public float existtime { get; set; }

		public string speaker { get; set; }
	}
}
