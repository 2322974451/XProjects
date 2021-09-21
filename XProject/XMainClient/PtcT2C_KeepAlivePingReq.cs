using System;
using System.IO;

namespace XMainClient
{
	// Token: 0x02000ED0 RID: 3792
	internal class PtcT2C_KeepAlivePingReq : Protocol
	{
		// Token: 0x0600C8F3 RID: 51443 RVA: 0x002CFB2C File Offset: 0x002CDD2C
		public override uint GetProtoType()
		{
			return 49142U;
		}

		// Token: 0x0600C8F4 RID: 51444 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void Serialize(MemoryStream stream)
		{
		}

		// Token: 0x0600C8F5 RID: 51445 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void DeSerialize(MemoryStream stream)
		{
		}

		// Token: 0x0600C8F6 RID: 51446 RVA: 0x002CFB43 File Offset: 0x002CDD43
		public override void Process()
		{
			Process_PtcT2C_KeepAlivePingReq.Process(this);
		}
	}
}
