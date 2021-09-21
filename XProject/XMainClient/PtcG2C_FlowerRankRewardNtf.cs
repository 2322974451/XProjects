using System;
using System.IO;

namespace XMainClient
{
	// Token: 0x0200112D RID: 4397
	internal class PtcG2C_FlowerRankRewardNtf : Protocol
	{
		// Token: 0x0600D977 RID: 55671 RVA: 0x0032B258 File Offset: 0x00329458
		public override uint GetProtoType()
		{
			return 14326U;
		}

		// Token: 0x0600D978 RID: 55672 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void Serialize(MemoryStream stream)
		{
		}

		// Token: 0x0600D979 RID: 55673 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void DeSerialize(MemoryStream stream)
		{
		}

		// Token: 0x0600D97A RID: 55674 RVA: 0x0032B26F File Offset: 0x0032946F
		public override void Process()
		{
			Process_PtcG2C_FlowerRankRewardNtf.Process(this);
		}
	}
}
