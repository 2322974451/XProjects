using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GetFlower : Rpc
	{

		public override uint GetRpcType()
		{
			return 11473U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetFlowerArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetFlowerRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetFlower.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetFlower.OnTimeout(this.oArg);
		}

		public GetFlowerArg oArg = new GetFlowerArg();

		public GetFlowerRes oRes = new GetFlowerRes();
	}
}
