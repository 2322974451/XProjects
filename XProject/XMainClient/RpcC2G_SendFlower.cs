using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_SendFlower : Rpc
	{

		public override uint GetRpcType()
		{
			return 16310U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SendFlowerArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<SendFlowerRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_SendFlower.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_SendFlower.OnTimeout(this.oArg);
		}

		public SendFlowerArg oArg = new SendFlowerArg();

		public SendFlowerRes oRes = new SendFlowerRes();
	}
}
