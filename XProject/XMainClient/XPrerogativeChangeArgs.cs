using System;

namespace XMainClient
{
	// Token: 0x02000FB2 RID: 4018
	internal class XPrerogativeChangeArgs : XEventArgs
	{
		// Token: 0x0600D10A RID: 53514 RVA: 0x003056C2 File Offset: 0x003038C2
		public XPrerogativeChangeArgs()
		{
			this._eDefine = XEventDefine.XEvent_Prerogative;
		}

		// Token: 0x0600D10B RID: 53515 RVA: 0x003056DE File Offset: 0x003038DE
		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XPrerogativeChangeArgs>.Recycle(this);
		}

		// Token: 0x04005E9F RID: 24223
		public uint prerogativeLevel = 0U;
	}
}
