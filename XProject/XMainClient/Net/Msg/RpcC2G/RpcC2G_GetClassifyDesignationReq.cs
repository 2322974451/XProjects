using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GetClassifyDesignationReq : Rpc
	{

		public override uint GetRpcType()
		{
			return 40256U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetClassifyDesignationReq>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetClassifyDesignationRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetClassifyDesignationReq.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetClassifyDesignationReq.OnTimeout(this.oArg);
		}

		public GetClassifyDesignationReq oArg = new GetClassifyDesignationReq();

		public GetClassifyDesignationRes oRes = new GetClassifyDesignationRes();
	}
}
