using System;

namespace XMainClient
{

	internal class XFadeInEventArgs : XEventArgs
	{

		public XFadeInEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_FadeIn;
		}

		public override void Recycle()
		{
			base.Recycle();
			this.In = 0f;
			XEventPool<XFadeInEventArgs>.Recycle(this);
		}

		public float In = 0f;
	}
}
