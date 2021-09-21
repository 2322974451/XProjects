using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200127F RID: 4735
	internal class RpcC2G_RiskBuyRequest : Rpc
	{
		// Token: 0x0600DED4 RID: 57044 RVA: 0x00333BCC File Offset: 0x00331DCC
		public override uint GetRpcType()
		{
			return 42935U;
		}

		// Token: 0x0600DED5 RID: 57045 RVA: 0x00333BE3 File Offset: 0x00331DE3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<RiskBuyRequestArg>(stream, this.oArg);
		}

		// Token: 0x0600DED6 RID: 57046 RVA: 0x00333BF3 File Offset: 0x00331DF3
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<RiskBuyRequestRes>(stream);
		}

		// Token: 0x0600DED7 RID: 57047 RVA: 0x00333C02 File Offset: 0x00331E02
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_RiskBuyRequest.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DED8 RID: 57048 RVA: 0x00333C1E File Offset: 0x00331E1E
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_RiskBuyRequest.OnTimeout(this.oArg);
		}

		// Token: 0x04006309 RID: 25353
		public RiskBuyRequestArg oArg = new RiskBuyRequestArg();

		// Token: 0x0400630A RID: 25354
		public RiskBuyRequestRes oRes = new RiskBuyRequestRes();
	}
}
