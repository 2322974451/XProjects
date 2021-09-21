using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020012C2 RID: 4802
	internal class RpcC2M_AskGuildArenaTeamInfoNew : Rpc
	{
		// Token: 0x0600DFEB RID: 57323 RVA: 0x00335508 File Offset: 0x00333708
		public override uint GetRpcType()
		{
			return 2181U;
		}

		// Token: 0x0600DFEC RID: 57324 RVA: 0x0033551F File Offset: 0x0033371F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AskGuildArenaTeamInfoArg>(stream, this.oArg);
		}

		// Token: 0x0600DFED RID: 57325 RVA: 0x0033552F File Offset: 0x0033372F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<AskGuildArenaTeamInfoRes>(stream);
		}

		// Token: 0x0600DFEE RID: 57326 RVA: 0x0033553E File Offset: 0x0033373E
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_AskGuildArenaTeamInfoNew.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DFEF RID: 57327 RVA: 0x0033555A File Offset: 0x0033375A
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_AskGuildArenaTeamInfoNew.OnTimeout(this.oArg);
		}

		// Token: 0x04006340 RID: 25408
		public AskGuildArenaTeamInfoArg oArg = new AskGuildArenaTeamInfoArg();

		// Token: 0x04006341 RID: 25409
		public AskGuildArenaTeamInfoRes oRes = null;
	}
}
