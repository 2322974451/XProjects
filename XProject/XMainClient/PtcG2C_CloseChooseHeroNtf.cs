using System;
using System.IO;

namespace XMainClient
{
	// Token: 0x0200144E RID: 5198
	internal class PtcG2C_CloseChooseHeroNtf : Protocol
	{
		// Token: 0x0600E642 RID: 58946 RVA: 0x0033E344 File Offset: 0x0033C544
		public override uint GetProtoType()
		{
			return 38670U;
		}

		// Token: 0x0600E643 RID: 58947 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void Serialize(MemoryStream stream)
		{
		}

		// Token: 0x0600E644 RID: 58948 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void DeSerialize(MemoryStream stream)
		{
		}

		// Token: 0x0600E645 RID: 58949 RVA: 0x0033E35B File Offset: 0x0033C55B
		public override void Process()
		{
			Process_PtcG2C_CloseChooseHeroNtf.Process(this);
		}
	}
}
