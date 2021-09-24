using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_LeagueBattleReq : Rpc
	{

		public override uint GetRpcType()
		{
			return 8012U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LeagueBattleReqArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<LeagueBattleReqRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_LeagueBattleReq.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_LeagueBattleReq.OnTimeout(this.oArg);
		}

		public LeagueBattleReqArg oArg = new LeagueBattleReqArg();

		public LeagueBattleReqRes oRes = null;
	}
}
