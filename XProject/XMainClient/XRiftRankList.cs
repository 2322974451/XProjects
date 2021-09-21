using System;

namespace XMainClient
{
	// Token: 0x02000D68 RID: 3432
	public class XRiftRankList : XBaseRankList
	{
		// Token: 0x0600BC82 RID: 48258 RVA: 0x0026DD64 File Offset: 0x0026BF64
		public XRiftRankList()
		{
			this.type = XRankType.RiftRank;
		}

		// Token: 0x0600BC83 RID: 48259 RVA: 0x0026DD78 File Offset: 0x0026BF78
		public override XBaseRankInfo CreateNewInfo()
		{
			return new XRiftRankInfo();
		}
	}
}
