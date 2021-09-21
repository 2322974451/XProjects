using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020011B9 RID: 4537
	internal class PtcG2C_GmfWaitOtherLoad : Protocol
	{
		// Token: 0x0600DBAB RID: 56235 RVA: 0x0032F5B0 File Offset: 0x0032D7B0
		public override uint GetProtoType()
		{
			return 1133U;
		}

		// Token: 0x0600DBAC RID: 56236 RVA: 0x0032F5C7 File Offset: 0x0032D7C7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GmfWaitOtherArg>(stream, this.Data);
		}

		// Token: 0x0600DBAD RID: 56237 RVA: 0x0032F5D7 File Offset: 0x0032D7D7
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GmfWaitOtherArg>(stream);
		}

		// Token: 0x0600DBAE RID: 56238 RVA: 0x0032F5E6 File Offset: 0x0032D7E6
		public override void Process()
		{
			Process_PtcG2C_GmfWaitOtherLoad.Process(this);
		}

		// Token: 0x0400626E RID: 25198
		public GmfWaitOtherArg Data = new GmfWaitOtherArg();
	}
}
