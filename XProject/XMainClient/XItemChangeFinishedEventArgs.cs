using System;

namespace XMainClient
{
	// Token: 0x02000F80 RID: 3968
	internal class XItemChangeFinishedEventArgs : XEventArgs
	{
		// Token: 0x0600D09E RID: 53406 RVA: 0x00304CD5 File Offset: 0x00302ED5
		public XItemChangeFinishedEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_ItemChangeFinished;
		}

		// Token: 0x0600D09F RID: 53407 RVA: 0x00304CE7 File Offset: 0x00302EE7
		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XItemChangeFinishedEventArgs>.Recycle(this);
		}
	}
}
