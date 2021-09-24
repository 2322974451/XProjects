using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GiftIbReqGoods : Rpc
	{

		public override uint GetRpcType()
		{
			return 18140U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GiftIbReqGoodsArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GiftIbReqGoodsRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GiftIbReqGoods.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GiftIbReqGoods.OnTimeout(this.oArg);
		}

		public GiftIbReqGoodsArg oArg = new GiftIbReqGoodsArg();

		public GiftIbReqGoodsRes oRes = null;
	}
}
