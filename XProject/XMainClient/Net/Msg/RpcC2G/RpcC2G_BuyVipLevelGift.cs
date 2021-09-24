using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_BuyVipLevelGift : Rpc
	{

		public override uint GetRpcType()
		{
			return 52536U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BuyVipLevelGiftArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<BuyVipLevelGiftRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_BuyVipLevelGift.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_BuyVipLevelGift.OnTimeout(this.oArg);
		}

		public BuyVipLevelGiftArg oArg = new BuyVipLevelGiftArg();

		public BuyVipLevelGiftRes oRes = new BuyVipLevelGiftRes();
	}
}
