using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_ReqGuildRankInfo : Rpc
	{

		public override uint GetRpcType()
		{
			return 48521U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ReqGuildRankInfoArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ReqGuildRankInfoRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_ReqGuildRankInfo.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_ReqGuildRankInfo.OnTimeout(this.oArg);
		}

		public ReqGuildRankInfoArg oArg = new ReqGuildRankInfoArg();

		public ReqGuildRankInfoRes oRes = null;
	}
}
