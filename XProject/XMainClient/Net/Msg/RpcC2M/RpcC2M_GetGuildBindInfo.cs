using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GetGuildBindInfo : Rpc
	{

		public override uint GetRpcType()
		{
			return 62512U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetGuildBindInfoReq>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetGuildBindInfoRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetGuildBindInfo.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetGuildBindInfo.OnTimeout(this.oArg);
		}

		public GetGuildBindInfoReq oArg = new GetGuildBindInfoReq();

		public GetGuildBindInfoRes oRes = null;
	}
}
