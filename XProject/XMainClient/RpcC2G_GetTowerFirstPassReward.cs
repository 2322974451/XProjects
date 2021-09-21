using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020012AF RID: 4783
	internal class RpcC2G_GetTowerFirstPassReward : Rpc
	{
		// Token: 0x0600DF9B RID: 57243 RVA: 0x00334E1C File Offset: 0x0033301C
		public override uint GetRpcType()
		{
			return 55009U;
		}

		// Token: 0x0600DF9C RID: 57244 RVA: 0x00334E33 File Offset: 0x00333033
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetTowerFirstPassRewardArg>(stream, this.oArg);
		}

		// Token: 0x0600DF9D RID: 57245 RVA: 0x00334E43 File Offset: 0x00333043
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetTowerFirstPassRewardRes>(stream);
		}

		// Token: 0x0600DF9E RID: 57246 RVA: 0x00334E52 File Offset: 0x00333052
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetTowerFirstPassReward.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DF9F RID: 57247 RVA: 0x00334E6E File Offset: 0x0033306E
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetTowerFirstPassReward.OnTimeout(this.oArg);
		}

		// Token: 0x04006330 RID: 25392
		public GetTowerFirstPassRewardArg oArg = new GetTowerFirstPassRewardArg();

		// Token: 0x04006331 RID: 25393
		public GetTowerFirstPassRewardRes oRes = new GetTowerFirstPassRewardRes();
	}
}
