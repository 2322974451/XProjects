using System;

namespace XMainClient
{
	// Token: 0x02000F91 RID: 3985
	internal class XTitleInfoChange : XEventArgs
	{
		// Token: 0x0600D0C0 RID: 53440 RVA: 0x00304FF6 File Offset: 0x003031F6
		public XTitleInfoChange()
		{
			this._eDefine = XEventDefine.XEvent_TitleChange;
		}

		// Token: 0x0600D0C1 RID: 53441 RVA: 0x0030500B File Offset: 0x0030320B
		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XTitleInfoChange>.Recycle(this);
		}
	}
}
