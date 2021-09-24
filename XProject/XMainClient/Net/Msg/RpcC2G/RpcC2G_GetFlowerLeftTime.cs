using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GetFlowerLeftTime : Rpc
	{

		public override uint GetRpcType()
		{
			return 26834U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetFlowerLeftTimeArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetFlowerLeftTimeRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetFlowerLeftTime.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetFlowerLeftTime.OnTimeout(this.oArg);
		}

		public GetFlowerLeftTimeArg oArg = new GetFlowerLeftTimeArg();

		public GetFlowerLeftTimeRes oRes = new GetFlowerLeftTimeRes();
	}
}
