using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_FirstPassInfoReq : Rpc
	{

		public override uint GetRpcType()
		{
			return 4147U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<FirstPassInfoReqArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<FirstPassInfoReqRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_FirstPassInfoReq.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_FirstPassInfoReq.OnTimeout(this.oArg);
		}

		public FirstPassInfoReqArg oArg = new FirstPassInfoReqArg();

		public FirstPassInfoReqRes oRes = new FirstPassInfoReqRes();
	}
}
