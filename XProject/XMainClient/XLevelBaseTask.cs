using System;

namespace XMainClient
{
	// Token: 0x02000E10 RID: 3600
	internal class XLevelBaseTask
	{
		// Token: 0x0600C209 RID: 49673 RVA: 0x00299D5B File Offset: 0x00297F5B
		public XLevelBaseTask(XLevelSpawnInfo ls)
		{
			this._spawner = ls;
		}

		// Token: 0x0600C20A RID: 49674 RVA: 0x00299D6C File Offset: 0x00297F6C
		public virtual bool Execute(float time)
		{
			return true;
		}

		// Token: 0x04005287 RID: 21127
		public int _id;

		// Token: 0x04005288 RID: 21128
		protected XLevelSpawnInfo _spawner;
	}
}
