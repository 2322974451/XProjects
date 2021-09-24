using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_ItemBuffOp : Rpc
	{

		public override uint GetRpcType()
		{
			return 50404U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ItemBuffOpArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ItemBuffOpRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ItemBuffOp.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ItemBuffOp.OnTimeout(this.oArg);
		}

		public ItemBuffOpArg oArg = new ItemBuffOpArg();

		public ItemBuffOpRes oRes = new ItemBuffOpRes();
	}
}
