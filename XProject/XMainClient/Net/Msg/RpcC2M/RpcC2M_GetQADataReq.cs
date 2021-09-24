using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GetQADataReq : Rpc
	{

		public override uint GetRpcType()
		{
			return 26871U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetQADataReq>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetQADataRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetQADataReq.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetQADataReq.OnTimeout(this.oArg);
		}

		public GetQADataReq oArg = new GetQADataReq();

		public GetQADataRes oRes = null;
	}
}
