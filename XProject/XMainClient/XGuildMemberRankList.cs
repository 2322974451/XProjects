using System;

namespace XMainClient
{
	// Token: 0x02000D78 RID: 3448
	public class XGuildMemberRankList : XBaseRankList
	{
		// Token: 0x0600BCA5 RID: 48293 RVA: 0x0026E28C File Offset: 0x0026C48C
		public override XBaseRankInfo CreateNewInfo()
		{
			return new XGuildMemberRankInfo();
		}
	}
}
