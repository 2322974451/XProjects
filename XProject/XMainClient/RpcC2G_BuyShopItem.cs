using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_BuyShopItem : Rpc
	{

		public override uint GetRpcType()
		{
			return 33881U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BuyShopItemArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<BuyShopItemRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_BuyShopItem.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_BuyShopItem.OnTimeout(this.oArg);
		}

		public BuyShopItemArg oArg = new BuyShopItemArg();

		public BuyShopItemRes oRes = new BuyShopItemRes();
	}
}
