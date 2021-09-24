using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_ReqGuildTerrChallInfo : Rpc
	{

		public override uint GetRpcType()
		{
			return 9791U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ReqGuildTerrChallInfoArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ReqGuildTerrChallInfoRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_ReqGuildTerrChallInfo.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_ReqGuildTerrChallInfo.OnTimeout(this.oArg);
		}

		public ReqGuildTerrChallInfoArg oArg = new ReqGuildTerrChallInfoArg();

		public ReqGuildTerrChallInfoRes oRes = null;
	}
}
