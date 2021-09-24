using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_ReqGuildLadderRnakInfo : Rpc
	{

		public override uint GetRpcType()
		{
			return 39925U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ReqGuildLadderRnakInfoArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ReqGuildLadderRnakInfoRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_ReqGuildLadderRnakInfo.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_ReqGuildLadderRnakInfo.OnTimeout(this.oArg);
		}

		public ReqGuildLadderRnakInfoArg oArg = new ReqGuildLadderRnakInfoArg();

		public ReqGuildLadderRnakInfoRes oRes = null;
	}
}
