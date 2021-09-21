using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200131D RID: 4893
	internal class RpcC2G_GetSpActivityReward : Rpc
	{
		// Token: 0x0600E161 RID: 57697 RVA: 0x0033777C File Offset: 0x0033597C
		public override uint GetRpcType()
		{
			return 7905U;
		}

		// Token: 0x0600E162 RID: 57698 RVA: 0x00337793 File Offset: 0x00335993
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetSpActivityRewardArg>(stream, this.oArg);
		}

		// Token: 0x0600E163 RID: 57699 RVA: 0x003377A3 File Offset: 0x003359A3
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetSpActivityRewardRes>(stream);
		}

		// Token: 0x0600E164 RID: 57700 RVA: 0x003377B2 File Offset: 0x003359B2
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetSpActivityReward.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E165 RID: 57701 RVA: 0x003377CE File Offset: 0x003359CE
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetSpActivityReward.OnTimeout(this.oArg);
		}

		// Token: 0x04006388 RID: 25480
		public GetSpActivityRewardArg oArg = new GetSpActivityRewardArg();

		// Token: 0x04006389 RID: 25481
		public GetSpActivityRewardRes oRes = new GetSpActivityRewardRes();
	}
}
