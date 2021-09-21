using System;
using System.IO;

namespace XMainClient
{
	// Token: 0x020015A6 RID: 5542
	internal class PtcC2G_BattleStatisticsReport : Protocol
	{
		// Token: 0x0600EBC0 RID: 60352 RVA: 0x00346364 File Offset: 0x00344564
		public override uint GetProtoType()
		{
			return 3612U;
		}

		// Token: 0x0600EBC1 RID: 60353 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void Serialize(MemoryStream stream)
		{
		}

		// Token: 0x0600EBC2 RID: 60354 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void DeSerialize(MemoryStream stream)
		{
		}

		// Token: 0x0600EBC3 RID: 60355 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}
	}
}
