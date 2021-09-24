using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GetActivityInfo : Rpc
	{

		public override uint GetRpcType()
		{
			return 43911U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetActivityInfoArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetActivityInfoRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetActivityInfo.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetActivityInfo.OnTimeout(this.oArg);
		}

		public GetActivityInfoArg oArg = new GetActivityInfoArg();

		public GetActivityInfoRes oRes = new GetActivityInfoRes();
	}
}
