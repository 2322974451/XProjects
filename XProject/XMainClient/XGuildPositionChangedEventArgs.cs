using System;

namespace XMainClient
{
	// Token: 0x02000F87 RID: 3975
	internal class XGuildPositionChangedEventArgs : XEventArgs
	{
		// Token: 0x0600D0AC RID: 53420 RVA: 0x00304E20 File Offset: 0x00303020
		public XGuildPositionChangedEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_GuildPositionChanged;
		}

		// Token: 0x0600D0AD RID: 53421 RVA: 0x00304E39 File Offset: 0x00303039
		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XGuildPositionChangedEventArgs>.Recycle(this);
			this.position = GuildPosition.GPOS_COUNT;
		}

		// Token: 0x04005E6E RID: 24174
		public GuildPosition position = GuildPosition.GPOS_COUNT;
	}
}
