using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_QueryShopItem : Rpc
	{

		public override uint GetRpcType()
		{
			return 18079U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<QueryShopItemArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<QueryShopItemRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_QueryShopItem.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_QueryShopItem.OnTimeout(this.oArg);
		}

		public QueryShopItemArg oArg = new QueryShopItemArg();

		public QueryShopItemRes oRes = new QueryShopItemRes();
	}
}
