using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001129 RID: 4393
	internal class RpcC2G_GetFlowerLeftTime : Rpc
	{
		// Token: 0x0600D965 RID: 55653 RVA: 0x0032B0C8 File Offset: 0x003292C8
		public override uint GetRpcType()
		{
			return 26834U;
		}

		// Token: 0x0600D966 RID: 55654 RVA: 0x0032B0DF File Offset: 0x003292DF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetFlowerLeftTimeArg>(stream, this.oArg);
		}

		// Token: 0x0600D967 RID: 55655 RVA: 0x0032B0EF File Offset: 0x003292EF
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetFlowerLeftTimeRes>(stream);
		}

		// Token: 0x0600D968 RID: 55656 RVA: 0x0032B0FE File Offset: 0x003292FE
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetFlowerLeftTime.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D969 RID: 55657 RVA: 0x0032B11A File Offset: 0x0032931A
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetFlowerLeftTime.OnTimeout(this.oArg);
		}

		// Token: 0x04006202 RID: 25090
		public GetFlowerLeftTimeArg oArg = new GetFlowerLeftTimeArg();

		// Token: 0x04006203 RID: 25091
		public GetFlowerLeftTimeRes oRes = new GetFlowerLeftTimeRes();
	}
}
