using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200131F RID: 4895
	internal class RpcC2G_GetSpActivityBigPrize : Rpc
	{
		// Token: 0x0600E16A RID: 57706 RVA: 0x003378D4 File Offset: 0x00335AD4
		public override uint GetRpcType()
		{
			return 17229U;
		}

		// Token: 0x0600E16B RID: 57707 RVA: 0x003378EB File Offset: 0x00335AEB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetSpActivityBigPrizeArg>(stream, this.oArg);
		}

		// Token: 0x0600E16C RID: 57708 RVA: 0x003378FB File Offset: 0x00335AFB
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetSpActivityBigPrizeRes>(stream);
		}

		// Token: 0x0600E16D RID: 57709 RVA: 0x0033790A File Offset: 0x00335B0A
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetSpActivityBigPrize.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E16E RID: 57710 RVA: 0x00337926 File Offset: 0x00335B26
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetSpActivityBigPrize.OnTimeout(this.oArg);
		}

		// Token: 0x0400638A RID: 25482
		public GetSpActivityBigPrizeArg oArg = new GetSpActivityBigPrizeArg();

		// Token: 0x0400638B RID: 25483
		public GetSpActivityBigPrizeRes oRes = new GetSpActivityBigPrizeRes();
	}
}
