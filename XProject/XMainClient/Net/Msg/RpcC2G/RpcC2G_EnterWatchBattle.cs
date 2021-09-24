using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_EnterWatchBattle : Rpc
	{

		public override uint GetRpcType()
		{
			return 47590U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<EnterWatchBattleArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<EnterWatchBattleRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_EnterWatchBattle.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_EnterWatchBattle.OnTimeout(this.oArg);
		}

		public EnterWatchBattleArg oArg = new EnterWatchBattleArg();

		public EnterWatchBattleRes oRes = new EnterWatchBattleRes();
	}
}
