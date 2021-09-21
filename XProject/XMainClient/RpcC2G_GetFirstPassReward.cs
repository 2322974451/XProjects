using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001215 RID: 4629
	internal class RpcC2G_GetFirstPassReward : Rpc
	{
		// Token: 0x0600DD1C RID: 56604 RVA: 0x00331368 File Offset: 0x0032F568
		public override uint GetRpcType()
		{
			return 12301U;
		}

		// Token: 0x0600DD1D RID: 56605 RVA: 0x0033137F File Offset: 0x0032F57F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetFirstPassRewardArg>(stream, this.oArg);
		}

		// Token: 0x0600DD1E RID: 56606 RVA: 0x0033138F File Offset: 0x0032F58F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetFirstPassRewardRes>(stream);
		}

		// Token: 0x0600DD1F RID: 56607 RVA: 0x0033139E File Offset: 0x0032F59E
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetFirstPassReward.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DD20 RID: 56608 RVA: 0x003313BA File Offset: 0x0032F5BA
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetFirstPassReward.OnTimeout(this.oArg);
		}

		// Token: 0x040062B2 RID: 25266
		public GetFirstPassRewardArg oArg = new GetFirstPassRewardArg();

		// Token: 0x040062B3 RID: 25267
		public GetFirstPassRewardRes oRes = new GetFirstPassRewardRes();
	}
}
