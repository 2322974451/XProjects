using System;

namespace XMainClient
{
	// Token: 0x02000FAD RID: 4013
	internal class XActivityTaskUpdatedArgs : XEventArgs
	{
		// Token: 0x0600D100 RID: 53504 RVA: 0x003055A9 File Offset: 0x003037A9
		public XActivityTaskUpdatedArgs()
		{
			this._eDefine = XEventDefine.XEvent_ActivityTaskUpdate;
		}

		// Token: 0x0600D101 RID: 53505 RVA: 0x003055BE File Offset: 0x003037BE
		public override void Recycle()
		{
			base.Recycle();
			this.xActID = 0U;
			this.xTaskID = 0U;
			this.xProgress = 0U;
			this.xState = 0U;
			XEventPool<XActivityTaskUpdatedArgs>.Recycle(this);
		}

		// Token: 0x04005E95 RID: 24213
		public uint xActID;

		// Token: 0x04005E96 RID: 24214
		public uint xTaskID;

		// Token: 0x04005E97 RID: 24215
		public uint xProgress;

		// Token: 0x04005E98 RID: 24216
		public uint xState;
	}
}
