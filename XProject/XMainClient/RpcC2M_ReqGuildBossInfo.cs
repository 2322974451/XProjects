using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001262 RID: 4706
	internal class RpcC2M_ReqGuildBossInfo : Rpc
	{
		// Token: 0x0600DE61 RID: 56929 RVA: 0x00333290 File Offset: 0x00331490
		public override uint GetRpcType()
		{
			return 38917U;
		}

		// Token: 0x0600DE62 RID: 56930 RVA: 0x003332A7 File Offset: 0x003314A7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AskGuildBossInfoArg>(stream, this.oArg);
		}

		// Token: 0x0600DE63 RID: 56931 RVA: 0x003332B7 File Offset: 0x003314B7
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<AskGuildBossInfoRes>(stream);
		}

		// Token: 0x0600DE64 RID: 56932 RVA: 0x003332C6 File Offset: 0x003314C6
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_ReqGuildBossInfo.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DE65 RID: 56933 RVA: 0x003332E2 File Offset: 0x003314E2
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_ReqGuildBossInfo.OnTimeout(this.oArg);
		}

		// Token: 0x040062F4 RID: 25332
		public AskGuildBossInfoArg oArg = new AskGuildBossInfoArg();

		// Token: 0x040062F5 RID: 25333
		public AskGuildBossInfoRes oRes = null;
	}
}
