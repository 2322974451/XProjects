using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001162 RID: 4450
	internal class RpcC2G_BossRushReq : Rpc
	{
		// Token: 0x0600DA58 RID: 55896 RVA: 0x0032D1F8 File Offset: 0x0032B3F8
		public override uint GetRpcType()
		{
			return 44074U;
		}

		// Token: 0x0600DA59 RID: 55897 RVA: 0x0032D20F File Offset: 0x0032B40F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BossRushArg>(stream, this.oArg);
		}

		// Token: 0x0600DA5A RID: 55898 RVA: 0x0032D21F File Offset: 0x0032B41F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<BossRushRes>(stream);
		}

		// Token: 0x0600DA5B RID: 55899 RVA: 0x0032D22E File Offset: 0x0032B42E
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_BossRushReq.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DA5C RID: 55900 RVA: 0x0032D24A File Offset: 0x0032B44A
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_BossRushReq.OnTimeout(this.oArg);
		}

		// Token: 0x04006233 RID: 25139
		public BossRushArg oArg = new BossRushArg();

		// Token: 0x04006234 RID: 25140
		public BossRushRes oRes = new BossRushRes();
	}
}
