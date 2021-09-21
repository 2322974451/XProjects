using System;

namespace XMainClient
{
	// Token: 0x02000F8E RID: 3982
	internal class XBigMeleeEnemyChange : XEventArgs
	{
		// Token: 0x0600D0BA RID: 53434 RVA: 0x00304F80 File Offset: 0x00303180
		public XBigMeleeEnemyChange()
		{
			this._eDefine = XEventDefine.XEvent_BigMeleeEnemyChange;
		}

		// Token: 0x0600D0BB RID: 53435 RVA: 0x00304F95 File Offset: 0x00303195
		public override void Recycle()
		{
			base.Recycle();
			this.isEnemy = false;
			XEventPool<XBigMeleeEnemyChange>.Recycle(this);
		}

		// Token: 0x04005E75 RID: 24181
		public bool isEnemy;
	}
}
