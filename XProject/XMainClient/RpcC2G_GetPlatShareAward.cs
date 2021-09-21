using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001529 RID: 5417
	internal class RpcC2G_GetPlatShareAward : Rpc
	{
		// Token: 0x0600E9BD RID: 59837 RVA: 0x00343244 File Offset: 0x00341444
		public override uint GetRpcType()
		{
			return 26922U;
		}

		// Token: 0x0600E9BE RID: 59838 RVA: 0x0034325B File Offset: 0x0034145B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetPlatShareAwardArg>(stream, this.oArg);
		}

		// Token: 0x0600E9BF RID: 59839 RVA: 0x0034326B File Offset: 0x0034146B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetPlatShareAwardRes>(stream);
		}

		// Token: 0x0600E9C0 RID: 59840 RVA: 0x0034327A File Offset: 0x0034147A
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetPlatShareAward.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E9C1 RID: 59841 RVA: 0x00343296 File Offset: 0x00341496
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetPlatShareAward.OnTimeout(this.oArg);
		}

		// Token: 0x04006520 RID: 25888
		public GetPlatShareAwardArg oArg = new GetPlatShareAwardArg();

		// Token: 0x04006521 RID: 25889
		public GetPlatShareAwardRes oRes = null;
	}
}
