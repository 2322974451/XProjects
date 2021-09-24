using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_ReqGuildTerrIntellInfo : Rpc
	{

		public override uint GetRpcType()
		{
			return 43276U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ReqGuildTerrIntellInfoArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ReqGuildTerrIntellInfoRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_ReqGuildTerrIntellInfo.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_ReqGuildTerrIntellInfo.OnTimeout(this.oArg);
		}

		public ReqGuildTerrIntellInfoArg oArg = new ReqGuildTerrIntellInfoArg();

		public ReqGuildTerrIntellInfoRes oRes = null;
	}
}
