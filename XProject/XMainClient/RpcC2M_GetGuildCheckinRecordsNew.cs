using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020012A7 RID: 4775
	internal class RpcC2M_GetGuildCheckinRecordsNew : Rpc
	{
		// Token: 0x0600DF79 RID: 57209 RVA: 0x00334A2C File Offset: 0x00332C2C
		public override uint GetRpcType()
		{
			return 16239U;
		}

		// Token: 0x0600DF7A RID: 57210 RVA: 0x00334A43 File Offset: 0x00332C43
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetGuildCheckinRecordsArg>(stream, this.oArg);
		}

		// Token: 0x0600DF7B RID: 57211 RVA: 0x00334A53 File Offset: 0x00332C53
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetGuildCheckinRecordsRes>(stream);
		}

		// Token: 0x0600DF7C RID: 57212 RVA: 0x00334A62 File Offset: 0x00332C62
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetGuildCheckinRecordsNew.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DF7D RID: 57213 RVA: 0x00334A7E File Offset: 0x00332C7E
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetGuildCheckinRecordsNew.OnTimeout(this.oArg);
		}

		// Token: 0x04006329 RID: 25385
		public GetGuildCheckinRecordsArg oArg = new GetGuildCheckinRecordsArg();

		// Token: 0x0400632A RID: 25386
		public GetGuildCheckinRecordsRes oRes = null;
	}
}
