using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_JoinLeagueEleBattle : Rpc
	{

		public override uint GetRpcType()
		{
			return 43053U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<JoinLeagueEleBattleArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<JoinLeagueEleBattleRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_JoinLeagueEleBattle.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_JoinLeagueEleBattle.OnTimeout(this.oArg);
		}

		public JoinLeagueEleBattleArg oArg = new JoinLeagueEleBattleArg();

		public JoinLeagueEleBattleRes oRes = null;
	}
}
