using System;
using System.Collections.Generic;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000D81 RID: 3457
	public class XBaseRankInfo
	{
		// Token: 0x0600BCB8 RID: 48312 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public virtual void ProcessData(RankData data)
		{
		}

		// Token: 0x0600BCB9 RID: 48313 RVA: 0x0026E84C File Offset: 0x0026CA4C
		public static string GetUnderLineName(string s)
		{
			return XSingleton<XCommon>.singleton.StringCombine("[u]", s, "[-]");
		}

		// Token: 0x0600BCBA RID: 48314 RVA: 0x0026E874 File Offset: 0x0026CA74
		public virtual string GetValue()
		{
			return this.value.ToString();
		}

		// Token: 0x04004C9B RID: 19611
		public uint rank;

		// Token: 0x04004C9C RID: 19612
		public ulong id;

		// Token: 0x04004C9D RID: 19613
		public string name;

		// Token: 0x04004C9E RID: 19614
		public string formatname;

		// Token: 0x04004C9F RID: 19615
		public ulong value;

		// Token: 0x04004CA0 RID: 19616
		public uint guildicon;

		// Token: 0x04004CA1 RID: 19617
		public string guildname;

		// Token: 0x04004CA2 RID: 19618
		public StartUpType startType;

		// Token: 0x04004CA3 RID: 19619
		public List<uint> setid = new List<uint>();
	}
}
