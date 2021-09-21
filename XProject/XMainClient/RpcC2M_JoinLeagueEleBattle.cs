using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001499 RID: 5273
	internal class RpcC2M_JoinLeagueEleBattle : Rpc
	{
		// Token: 0x0600E76C RID: 59244 RVA: 0x0034000C File Offset: 0x0033E20C
		public override uint GetRpcType()
		{
			return 43053U;
		}

		// Token: 0x0600E76D RID: 59245 RVA: 0x00340023 File Offset: 0x0033E223
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<JoinLeagueEleBattleArg>(stream, this.oArg);
		}

		// Token: 0x0600E76E RID: 59246 RVA: 0x00340033 File Offset: 0x0033E233
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<JoinLeagueEleBattleRes>(stream);
		}

		// Token: 0x0600E76F RID: 59247 RVA: 0x00340042 File Offset: 0x0033E242
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_JoinLeagueEleBattle.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E770 RID: 59248 RVA: 0x0034005E File Offset: 0x0033E25E
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_JoinLeagueEleBattle.OnTimeout(this.oArg);
		}

		// Token: 0x040064AE RID: 25774
		public JoinLeagueEleBattleArg oArg = new JoinLeagueEleBattleArg();

		// Token: 0x040064AF RID: 25775
		public JoinLeagueEleBattleRes oRes = null;
	}
}
