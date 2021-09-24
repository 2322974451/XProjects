using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GetLuckyActivityInfo : Rpc
	{

		public override uint GetRpcType()
		{
			return 384U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetLuckyActivityInfoArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetLuckyActivityInfoRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetLuckyActivityInfo.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetLuckyActivityInfo.OnTimeout(this.oArg);
		}

		public GetLuckyActivityInfoArg oArg = new GetLuckyActivityInfoArg();

		public GetLuckyActivityInfoRes oRes = null;
	}
}
