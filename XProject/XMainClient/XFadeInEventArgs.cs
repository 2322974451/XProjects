using System;

namespace XMainClient
{
	// Token: 0x02000F52 RID: 3922
	internal class XFadeInEventArgs : XEventArgs
	{
		// Token: 0x0600D007 RID: 53255 RVA: 0x00303D03 File Offset: 0x00301F03
		public XFadeInEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_FadeIn;
		}

		// Token: 0x0600D008 RID: 53256 RVA: 0x00303D20 File Offset: 0x00301F20
		public override void Recycle()
		{
			base.Recycle();
			this.In = 0f;
			XEventPool<XFadeInEventArgs>.Recycle(this);
		}

		// Token: 0x04005DFD RID: 24061
		public float In = 0f;
	}
}
