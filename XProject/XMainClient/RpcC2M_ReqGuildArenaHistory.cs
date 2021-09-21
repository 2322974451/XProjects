using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200137F RID: 4991
	internal class RpcC2M_ReqGuildArenaHistory : Rpc
	{
		// Token: 0x0600E2F2 RID: 58098 RVA: 0x00339BF0 File Offset: 0x00337DF0
		public override uint GetRpcType()
		{
			return 2922U;
		}

		// Token: 0x0600E2F3 RID: 58099 RVA: 0x00339C07 File Offset: 0x00337E07
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ReqGuildArenaHistoryRes>(stream, this.oArg);
		}

		// Token: 0x0600E2F4 RID: 58100 RVA: 0x00339C17 File Offset: 0x00337E17
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ReqGuildArenaHistoryRse>(stream);
		}

		// Token: 0x0600E2F5 RID: 58101 RVA: 0x00339C26 File Offset: 0x00337E26
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_ReqGuildArenaHistory.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E2F6 RID: 58102 RVA: 0x00339C42 File Offset: 0x00337E42
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_ReqGuildArenaHistory.OnTimeout(this.oArg);
		}

		// Token: 0x040063D6 RID: 25558
		public ReqGuildArenaHistoryRes oArg = new ReqGuildArenaHistoryRes();

		// Token: 0x040063D7 RID: 25559
		public ReqGuildArenaHistoryRse oRes = null;
	}
}
