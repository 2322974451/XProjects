using System;

namespace XMainClient
{
	// Token: 0x02000F55 RID: 3925
	internal class XAIAutoFightEventArgs : XEventArgs
	{
		// Token: 0x0600D011 RID: 53265 RVA: 0x00303DCA File Offset: 0x00301FCA
		public XAIAutoFightEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_AIAutoFight;
		}

		// Token: 0x0600D012 RID: 53266 RVA: 0x00303DDC File Offset: 0x00301FDC
		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XAIAutoFightEventArgs>.Recycle(this);
		}
	}
}
