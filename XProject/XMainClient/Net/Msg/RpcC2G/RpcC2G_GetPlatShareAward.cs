using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GetPlatShareAward : Rpc
	{

		public override uint GetRpcType()
		{
			return 26922U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetPlatShareAwardArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetPlatShareAwardRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetPlatShareAward.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetPlatShareAward.OnTimeout(this.oArg);
		}

		public GetPlatShareAwardArg oArg = new GetPlatShareAwardArg();

		public GetPlatShareAwardRes oRes = null;
	}
}
