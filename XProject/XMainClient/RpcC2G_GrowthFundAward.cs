using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001206 RID: 4614
	internal class RpcC2G_GrowthFundAward : Rpc
	{
		// Token: 0x0600DCDE RID: 56542 RVA: 0x00330EC4 File Offset: 0x0032F0C4
		public override uint GetRpcType()
		{
			return 43548U;
		}

		// Token: 0x0600DCDF RID: 56543 RVA: 0x00330EDB File Offset: 0x0032F0DB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GrowthFundAwardArg>(stream, this.oArg);
		}

		// Token: 0x0600DCE0 RID: 56544 RVA: 0x00330EEB File Offset: 0x0032F0EB
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GrowthFundAwardRes>(stream);
		}

		// Token: 0x0600DCE1 RID: 56545 RVA: 0x00330EFA File Offset: 0x0032F0FA
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GrowthFundAward.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DCE2 RID: 56546 RVA: 0x00330F16 File Offset: 0x0032F116
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GrowthFundAward.OnTimeout(this.oArg);
		}

		// Token: 0x040062A6 RID: 25254
		public GrowthFundAwardArg oArg = new GrowthFundAwardArg();

		// Token: 0x040062A7 RID: 25255
		public GrowthFundAwardRes oRes = new GrowthFundAwardRes();
	}
}
