using System;

namespace XMainClient
{

	internal class XFadeOutEventArgs : XEventArgs
	{

		public XFadeOutEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_FadeOut;
		}

		public override void Recycle()
		{
			base.Recycle();
			this.Out = 0f;
			XEventPool<XFadeOutEventArgs>.Recycle(this);
		}

		public float Out = 0f;
	}
}
