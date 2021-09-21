using System;
using System.IO;

namespace XMainClient
{
	// Token: 0x02000ECE RID: 3790
	internal class PtcC2T_KeepAlivePingAck : Protocol
	{
		// Token: 0x0600C8E9 RID: 51433 RVA: 0x002CFAC0 File Offset: 0x002CDCC0
		public override uint GetProtoType()
		{
			return 29192U;
		}

		// Token: 0x0600C8EA RID: 51434 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void Serialize(MemoryStream stream)
		{
		}

		// Token: 0x0600C8EB RID: 51435 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void DeSerialize(MemoryStream stream)
		{
		}

		// Token: 0x0600C8EC RID: 51436 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}
	}
}
