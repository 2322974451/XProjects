using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_ItemCompose : Rpc
	{

		public override uint GetRpcType()
		{
			return 16118U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ItemComposeArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ItemComposeRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ItemCompose.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ItemCompose.OnTimeout(this.oArg);
		}

		public ItemComposeArg oArg = new ItemComposeArg();

		public ItemComposeRes oRes = null;
	}
}
