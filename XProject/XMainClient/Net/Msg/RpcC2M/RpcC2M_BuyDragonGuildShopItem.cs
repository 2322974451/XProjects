using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_BuyDragonGuildShopItem : Rpc
	{

		public override uint GetRpcType()
		{
			return 24893U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BuyDragonGuildShopItemArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<BuyDragonGuildShopItemRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_BuyDragonGuildShopItem.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_BuyDragonGuildShopItem.OnTimeout(this.oArg);
		}

		public BuyDragonGuildShopItemArg oArg = new BuyDragonGuildShopItemArg();

		public BuyDragonGuildShopItemRes oRes = null;
	}
}
