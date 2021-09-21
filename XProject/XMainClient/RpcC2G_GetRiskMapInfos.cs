using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001257 RID: 4695
	internal class RpcC2G_GetRiskMapInfos : Rpc
	{
		// Token: 0x0600DE31 RID: 56881 RVA: 0x00332F38 File Offset: 0x00331138
		public override uint GetRpcType()
		{
			return 11628U;
		}

		// Token: 0x0600DE32 RID: 56882 RVA: 0x00332F4F File Offset: 0x0033114F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetRiskMapInfosArg>(stream, this.oArg);
		}

		// Token: 0x0600DE33 RID: 56883 RVA: 0x00332F5F File Offset: 0x0033115F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetRiskMapInfosRes>(stream);
		}

		// Token: 0x0600DE34 RID: 56884 RVA: 0x00332F6E File Offset: 0x0033116E
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetRiskMapInfos.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DE35 RID: 56885 RVA: 0x00332F8A File Offset: 0x0033118A
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetRiskMapInfos.OnTimeout(this.oArg);
		}

		// Token: 0x040062EA RID: 25322
		public GetRiskMapInfosArg oArg = new GetRiskMapInfosArg();

		// Token: 0x040062EB RID: 25323
		public GetRiskMapInfosRes oRes = new GetRiskMapInfosRes();
	}
}
