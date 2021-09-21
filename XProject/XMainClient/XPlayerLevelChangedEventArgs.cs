using System;

namespace XMainClient
{
	// Token: 0x02000F89 RID: 3977
	internal class XPlayerLevelChangedEventArgs : XEventArgs
	{
		// Token: 0x0600D0B0 RID: 53424 RVA: 0x00304E82 File Offset: 0x00303082
		public XPlayerLevelChangedEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_PlayerLevelChange;
		}

		// Token: 0x0600D0B1 RID: 53425 RVA: 0x00304EA5 File Offset: 0x003030A5
		public override void Recycle()
		{
			base.Recycle();
			this.level = 0U;
			this.PreLevel = 0U;
			XEventPool<XPlayerLevelChangedEventArgs>.Recycle(this);
		}

		// Token: 0x04005E70 RID: 24176
		public uint level = 0U;

		// Token: 0x04005E71 RID: 24177
		public uint PreLevel = 0U;
	}
}
