using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_BattleFieldRankReq : Rpc
	{

		public override uint GetRpcType()
		{
			return 4893U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BattleFieldRankArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<BattleFieldRankRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_BattleFieldRankReq.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_BattleFieldRankReq.OnTimeout(this.oArg);
		}

		public BattleFieldRankArg oArg = new BattleFieldRankArg();

		public BattleFieldRankRes oRes = null;
	}
}
