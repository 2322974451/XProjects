using System;

namespace XMainClient
{
	// Token: 0x02000F81 RID: 3969
	internal class XTeamMemberCountChangedEventArgs : XEventArgs
	{
		// Token: 0x0600D0A0 RID: 53408 RVA: 0x00304CF8 File Offset: 0x00302EF8
		public XTeamMemberCountChangedEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_TeamMemberCountChanged;
		}

		// Token: 0x0600D0A1 RID: 53409 RVA: 0x00304D0A File Offset: 0x00302F0A
		public override void Recycle()
		{
			base.Recycle();
			this.oldCount = 0U;
			this.newCount = 0U;
			XEventPool<XTeamMemberCountChangedEventArgs>.Recycle(this);
		}

		// Token: 0x04005E65 RID: 24165
		public uint oldCount;

		// Token: 0x04005E66 RID: 24166
		public uint newCount;
	}
}
