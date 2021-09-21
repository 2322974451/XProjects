using System;
using System.IO;

namespace XMainClient
{
	// Token: 0x020015B1 RID: 5553
	internal class PtcG2C_HorseFailTipsNtf : Protocol
	{
		// Token: 0x0600EBEA RID: 60394 RVA: 0x003465F0 File Offset: 0x003447F0
		public override uint GetProtoType()
		{
			return 2357U;
		}

		// Token: 0x0600EBEB RID: 60395 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void Serialize(MemoryStream stream)
		{
		}

		// Token: 0x0600EBEC RID: 60396 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void DeSerialize(MemoryStream stream)
		{
		}

		// Token: 0x0600EBED RID: 60397 RVA: 0x00346607 File Offset: 0x00344807
		public override void Process()
		{
			Process_PtcG2C_HorseFailTipsNtf.Process(this);
		}
	}
}
