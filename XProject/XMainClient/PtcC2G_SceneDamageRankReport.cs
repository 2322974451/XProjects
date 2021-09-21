using System;
using System.IO;

namespace XMainClient
{
	// Token: 0x020010C5 RID: 4293
	internal class PtcC2G_SceneDamageRankReport : Protocol
	{
		// Token: 0x0600D7CC RID: 55244 RVA: 0x00328AE4 File Offset: 0x00326CE4
		public override uint GetProtoType()
		{
			return 53015U;
		}

		// Token: 0x0600D7CD RID: 55245 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void Serialize(MemoryStream stream)
		{
		}

		// Token: 0x0600D7CE RID: 55246 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void DeSerialize(MemoryStream stream)
		{
		}

		// Token: 0x0600D7CF RID: 55247 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}
	}
}
