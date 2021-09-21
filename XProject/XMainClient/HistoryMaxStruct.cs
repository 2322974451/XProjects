using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020009E3 RID: 2531
	internal class HistoryMaxStruct
	{
		// Token: 0x06009A91 RID: 39569 RVA: 0x00187A44 File Offset: 0x00185C44
		public void Replace()
		{
			bool flag = !this.IsInit;
			if (flag)
			{
				this.PreLevel = XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
				this.IsInit = true;
			}
		}

		// Token: 0x0400354B RID: 13643
		public uint PreLevel = 0U;

		// Token: 0x0400354C RID: 13644
		private bool IsInit = false;
	}
}
