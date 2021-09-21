using System;

namespace XMainClient
{
	// Token: 0x02000FAF RID: 4015
	internal class XEvent_HomeFeastingArgs : XEventArgs
	{
		// Token: 0x0600D104 RID: 53508 RVA: 0x0030562D File Offset: 0x0030382D
		public XEvent_HomeFeastingArgs()
		{
			this._eDefine = XEventDefine.XEvent_HomeFeasting;
			this.time = 0U;
		}

		// Token: 0x0600D105 RID: 53509 RVA: 0x00305650 File Offset: 0x00303850
		public override void Recycle()
		{
			base.Recycle();
			this.time = 0U;
			XEventPool<XEvent_HomeFeastingArgs>.Recycle(this);
		}

		// Token: 0x04005E9C RID: 24220
		public uint time = 0U;
	}
}
