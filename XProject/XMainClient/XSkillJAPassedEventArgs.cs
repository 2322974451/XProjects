using System;

namespace XMainClient
{
	// Token: 0x02000F94 RID: 3988
	internal class XSkillJAPassedEventArgs : XEventArgs
	{
		// Token: 0x0600D0C6 RID: 53446 RVA: 0x00305081 File Offset: 0x00303281
		public XSkillJAPassedEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_OnJAPassed;
		}

		// Token: 0x0600D0C7 RID: 53447 RVA: 0x0030509A File Offset: 0x0030329A
		public override void Recycle()
		{
			this.Slot = -1;
			base.Recycle();
			XEventPool<XSkillJAPassedEventArgs>.Recycle(this);
		}

		// Token: 0x04005E7B RID: 24187
		public int Slot = -1;
	}
}
