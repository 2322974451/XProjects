using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GetPayAllInfo : Rpc
	{

		public override uint GetRpcType()
		{
			return 41260U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetPayAllInfoArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetPayAllInfoRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetPayAllInfo.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetPayAllInfo.OnTimeout(this.oArg);
		}

		public GetPayAllInfoArg oArg = new GetPayAllInfoArg();

		public GetPayAllInfoRes oRes = new GetPayAllInfoRes();
	}
}
