using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_ReEnterRiskBattle : Rpc
	{

		public override uint GetRpcType()
		{
			return 1615U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ReEnterRiskBattleArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ReEnterRiskBattleRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ReEnterRiskBattle.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ReEnterRiskBattle.OnTimeout(this.oArg);
		}

		public ReEnterRiskBattleArg oArg = new ReEnterRiskBattleArg();

		public ReEnterRiskBattleRes oRes = new ReEnterRiskBattleRes();
	}
}
