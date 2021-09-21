using System;

namespace XMainClient
{
	// Token: 0x02000F86 RID: 3974
	internal class XHighlightEventArgs : XEventArgs
	{
		// Token: 0x0600D0AA RID: 53418 RVA: 0x00304DF6 File Offset: 0x00302FF6
		public XHighlightEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_Highlight;
		}

		// Token: 0x0600D0AB RID: 53419 RVA: 0x00304E0F File Offset: 0x0030300F
		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XHighlightEventArgs>.Recycle(this);
		}

		// Token: 0x04005E6D RID: 24173
		public bool Enabled = false;
	}
}
