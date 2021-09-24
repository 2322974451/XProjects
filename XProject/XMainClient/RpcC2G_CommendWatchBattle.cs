using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_CommendWatchBattle : Rpc
	{

		public override uint GetRpcType()
		{
			return 1476U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<CommendWatchBattleArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<CommendWatchBattleRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_CommendWatchBattle.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_CommendWatchBattle.OnTimeout(this.oArg);
		}

		public CommendWatchBattleArg oArg = new CommendWatchBattleArg();

		public CommendWatchBattleRes oRes = new CommendWatchBattleRes();
	}
}
