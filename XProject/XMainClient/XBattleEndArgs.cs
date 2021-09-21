using System;

namespace XMainClient
{
	// Token: 0x02000FB0 RID: 4016
	internal class XBattleEndArgs : XEventArgs
	{
		// Token: 0x0600D106 RID: 53510 RVA: 0x00305668 File Offset: 0x00303868
		public XBattleEndArgs()
		{
			this._eDefine = XEventDefine.XEvent_BattleEnd;
		}

		// Token: 0x0600D107 RID: 53511 RVA: 0x0030567D File Offset: 0x0030387D
		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XBattleEndArgs>.Recycle(this);
		}
	}
}
