using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200119A RID: 4506
	internal class PtcG2C_ClientOnlyBuffNotify : Protocol
	{
		// Token: 0x0600DB2E RID: 56110 RVA: 0x0032EA5C File Offset: 0x0032CC5C
		public override uint GetProtoType()
		{
			return 35149U;
		}

		// Token: 0x0600DB2F RID: 56111 RVA: 0x0032EA73 File Offset: 0x0032CC73
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BuffList>(stream, this.Data);
		}

		// Token: 0x0600DB30 RID: 56112 RVA: 0x0032EA83 File Offset: 0x0032CC83
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<BuffList>(stream);
		}

		// Token: 0x0600DB31 RID: 56113 RVA: 0x0032EA92 File Offset: 0x0032CC92
		public override void Process()
		{
			Process_PtcG2C_ClientOnlyBuffNotify.Process(this);
		}

		// Token: 0x04006257 RID: 25175
		public BuffList Data = new BuffList();
	}
}
