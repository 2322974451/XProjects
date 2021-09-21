using System;
using System.IO;

namespace XMainClient
{
	// Token: 0x0200149C RID: 5276
	internal class PtcM2C_KickFMAuchor : Protocol
	{
		// Token: 0x0600E77A RID: 59258 RVA: 0x00340118 File Offset: 0x0033E318
		public override uint GetProtoType()
		{
			return 33806U;
		}

		// Token: 0x0600E77B RID: 59259 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void Serialize(MemoryStream stream)
		{
		}

		// Token: 0x0600E77C RID: 59260 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void DeSerialize(MemoryStream stream)
		{
		}

		// Token: 0x0600E77D RID: 59261 RVA: 0x0034012F File Offset: 0x0033E32F
		public override void Process()
		{
			Process_PtcM2C_KickFMAuchor.Process(this);
		}
	}
}
