using System;

namespace XMainClient
{
	// Token: 0x02000D5B RID: 3419
	public class XPetRankList : XBaseRankList
	{
		// Token: 0x0600BC66 RID: 48230 RVA: 0x0026D95C File Offset: 0x0026BB5C
		public XPetRankList()
		{
			this.type = XRankType.PetRank;
		}

		// Token: 0x0600BC67 RID: 48231 RVA: 0x0026D970 File Offset: 0x0026BB70
		public override XBaseRankInfo CreateNewInfo()
		{
			return new XPetRankInfo();
		}
	}
}
