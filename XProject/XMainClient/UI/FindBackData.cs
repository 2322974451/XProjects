using System;
using System.Collections.Generic;
using KKSG;

namespace XMainClient.UI
{
	// Token: 0x020018EF RID: 6383
	internal class FindBackData
	{
		// Token: 0x04007905 RID: 30981
		public int findid = 0;

		// Token: 0x04007906 RID: 30982
		public int maxfindback = 0;

		// Token: 0x04007907 RID: 30983
		public int findindex = 0;

		// Token: 0x04007908 RID: 30984
		public bool isfind = false;

		// Token: 0x04007909 RID: 30985
		public int findbacklevel = 0;

		// Token: 0x0400790A RID: 30986
		public List<ItemFindBackInfo2Client> findbackinfo = new List<ItemFindBackInfo2Client>();

		// Token: 0x0400790B RID: 30987
		public Dictionary<int, List<int>> goldItemCount = new Dictionary<int, List<int>>();

		// Token: 0x0400790C RID: 30988
		public Dictionary<int, List<int>> dragonCoinItemCount = new Dictionary<int, List<int>>();
	}
}
