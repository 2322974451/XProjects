using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_ReqGuildArenaHistory : Rpc
	{

		public override uint GetRpcType()
		{
			return 2922U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ReqGuildArenaHistoryRes>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ReqGuildArenaHistoryRse>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_ReqGuildArenaHistory.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_ReqGuildArenaHistory.OnTimeout(this.oArg);
		}

		public ReqGuildArenaHistoryRes oArg = new ReqGuildArenaHistoryRes();

		public ReqGuildArenaHistoryRse oRes = null;
	}
}
