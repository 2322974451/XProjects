using System;

namespace XMainClient
{
	// Token: 0x02000F53 RID: 3923
	internal class XFadeOutEventArgs : XEventArgs
	{
		// Token: 0x0600D009 RID: 53257 RVA: 0x00303D3C File Offset: 0x00301F3C
		public XFadeOutEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_FadeOut;
		}

		// Token: 0x0600D00A RID: 53258 RVA: 0x00303D59 File Offset: 0x00301F59
		public override void Recycle()
		{
			base.Recycle();
			this.Out = 0f;
			XEventPool<XFadeOutEventArgs>.Recycle(this);
		}

		// Token: 0x04005DFE RID: 24062
		public float Out = 0f;
	}
}
