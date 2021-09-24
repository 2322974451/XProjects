using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_ItemSell : Rpc
	{

		public override uint GetRpcType()
		{
			return 34826U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ItemSellArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ItemSellRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ItemSell.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ItemSell.OnTimeout(this.oArg);
		}

		public ItemSellArg oArg = new ItemSellArg();

		public ItemSellRes oRes = null;
	}
}
