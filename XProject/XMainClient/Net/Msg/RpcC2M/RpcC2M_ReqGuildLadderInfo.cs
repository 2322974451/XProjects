using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_ReqGuildLadderInfo : Rpc
	{

		public override uint GetRpcType()
		{
			return 44006U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ReqGuildLadderInfoAgr>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ReqGuildLadderInfoRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_ReqGuildLadderInfo.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_ReqGuildLadderInfo.OnTimeout(this.oArg);
		}

		public ReqGuildLadderInfoAgr oArg = new ReqGuildLadderInfoAgr();

		public ReqGuildLadderInfoRes oRes = null;
	}
}
