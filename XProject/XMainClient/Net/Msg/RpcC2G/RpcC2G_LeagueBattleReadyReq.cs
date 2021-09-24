using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_LeagueBattleReadyReq : Rpc
	{

		public override uint GetRpcType()
		{
			return 15873U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LeagueBattleReadyReqArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<LeagueBattleReadyReqRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_LeagueBattleReadyReq.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_LeagueBattleReadyReq.OnTimeout(this.oArg);
		}

		public LeagueBattleReadyReqArg oArg = new LeagueBattleReadyReqArg();

		public LeagueBattleReadyReqRes oRes = null;
	}
}
