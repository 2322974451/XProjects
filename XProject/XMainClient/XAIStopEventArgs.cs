using System;

namespace XMainClient
{
	// Token: 0x02000F5B RID: 3931
	internal class XAIStopEventArgs : XEventArgs
	{
		// Token: 0x0600D01D RID: 53277 RVA: 0x00303EF7 File Offset: 0x003020F7
		public XAIStopEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_AIStop;
		}

		// Token: 0x0600D01E RID: 53278 RVA: 0x00303F09 File Offset: 0x00302109
		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XAIStopEventArgs>.Recycle(this);
		}
	}
}
