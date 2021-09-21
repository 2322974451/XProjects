using System;

namespace XMainClient
{
	// Token: 0x02000F88 RID: 3976
	internal class XGuildLevelChangedEventArgs : XEventArgs
	{
		// Token: 0x0600D0AE RID: 53422 RVA: 0x00304E51 File Offset: 0x00303051
		public XGuildLevelChangedEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_GuildLevelChanged;
		}

		// Token: 0x0600D0AF RID: 53423 RVA: 0x00304E6A File Offset: 0x0030306A
		public override void Recycle()
		{
			base.Recycle();
			this.level = 0U;
			XEventPool<XGuildLevelChangedEventArgs>.Recycle(this);
		}

		// Token: 0x04005E6F RID: 24175
		public uint level = 0U;
	}
}
