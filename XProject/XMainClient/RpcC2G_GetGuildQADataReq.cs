using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GetGuildQADataReq : Rpc
	{

		public override uint GetRpcType()
		{
			return 35568U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetGuildQADataReq>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetGuildQADataRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetGuildQADataReq.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetGuildQADataReq.OnTimeout(this.oArg);
		}

		public GetGuildQADataReq oArg = new GetGuildQADataReq();

		public GetGuildQADataRes oRes = new GetGuildQADataRes();
	}
}
