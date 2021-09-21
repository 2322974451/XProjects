using System;

namespace XMainClient
{
	// Token: 0x02000FB3 RID: 4019
	internal class XNPCFavorFxChangeArgs : XEventArgs
	{
		// Token: 0x0600D10C RID: 53516 RVA: 0x003056EF File Offset: 0x003038EF
		public XNPCFavorFxChangeArgs()
		{
			this._eDefine = XEventDefine.XEvent_NpcFavorFxChange;
		}

		// Token: 0x0600D10D RID: 53517 RVA: 0x00305704 File Offset: 0x00303904
		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XNPCFavorFxChangeArgs>.Recycle(this);
		}
	}
}
