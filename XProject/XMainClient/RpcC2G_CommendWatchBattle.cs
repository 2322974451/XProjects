using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001160 RID: 4448
	internal class RpcC2G_CommendWatchBattle : Rpc
	{
		// Token: 0x0600DA4F RID: 55887 RVA: 0x0032D0E4 File Offset: 0x0032B2E4
		public override uint GetRpcType()
		{
			return 1476U;
		}

		// Token: 0x0600DA50 RID: 55888 RVA: 0x0032D0FB File Offset: 0x0032B2FB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<CommendWatchBattleArg>(stream, this.oArg);
		}

		// Token: 0x0600DA51 RID: 55889 RVA: 0x0032D10B File Offset: 0x0032B30B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<CommendWatchBattleRes>(stream);
		}

		// Token: 0x0600DA52 RID: 55890 RVA: 0x0032D11A File Offset: 0x0032B31A
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_CommendWatchBattle.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DA53 RID: 55891 RVA: 0x0032D136 File Offset: 0x0032B336
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_CommendWatchBattle.OnTimeout(this.oArg);
		}

		// Token: 0x04006231 RID: 25137
		public CommendWatchBattleArg oArg = new CommendWatchBattleArg();

		// Token: 0x04006232 RID: 25138
		public CommendWatchBattleRes oRes = new CommendWatchBattleRes();
	}
}
