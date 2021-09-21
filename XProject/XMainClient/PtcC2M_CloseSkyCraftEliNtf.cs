using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020014E9 RID: 5353
	internal class PtcC2M_CloseSkyCraftEliNtf : Protocol
	{
		// Token: 0x0600E8B4 RID: 59572 RVA: 0x00341950 File Offset: 0x0033FB50
		public override uint GetProtoType()
		{
			return 46239U;
		}

		// Token: 0x0600E8B5 RID: 59573 RVA: 0x00341967 File Offset: 0x0033FB67
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<CloseSkyCraftEliNtf>(stream, this.Data);
		}

		// Token: 0x0600E8B6 RID: 59574 RVA: 0x00341977 File Offset: 0x0033FB77
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<CloseSkyCraftEliNtf>(stream);
		}

		// Token: 0x0600E8B7 RID: 59575 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x040064EC RID: 25836
		public CloseSkyCraftEliNtf Data = new CloseSkyCraftEliNtf();
	}
}
