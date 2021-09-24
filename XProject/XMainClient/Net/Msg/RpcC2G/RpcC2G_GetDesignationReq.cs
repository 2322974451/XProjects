using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GetDesignationReq : Rpc
	{

		public override uint GetRpcType()
		{
			return 44412U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetDesignationReq>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetDesignationRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetDesignationReq.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetDesignationReq.OnTimeout(this.oArg);
		}

		public GetDesignationReq oArg = new GetDesignationReq();

		public GetDesignationRes oRes = new GetDesignationRes();
	}
}
