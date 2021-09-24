using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_BuyIBItem : Rpc
	{

		public override uint GetRpcType()
		{
			return 11547U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<IBBuyItemReq>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<IBBuyItemRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_BuyIBItem.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_BuyIBItem.OnTimeout(this.oArg);
		}

		public IBBuyItemReq oArg = new IBBuyItemReq();

		public IBBuyItemRes oRes = new IBBuyItemRes();
	}
}
