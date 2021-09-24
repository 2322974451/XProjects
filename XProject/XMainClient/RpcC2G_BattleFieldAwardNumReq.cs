using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_BattleFieldAwardNumReq : Rpc
	{

		public override uint GetRpcType()
		{
			return 59171U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BattleFieldAwardNumArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<BattleFieldAwardNumRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_BattleFieldAwardNumReq.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_BattleFieldAwardNumReq.OnTimeout(this.oArg);
		}

		public BattleFieldAwardNumArg oArg = new BattleFieldAwardNumArg();

		public BattleFieldAwardNumRes oRes = null;
	}
}
