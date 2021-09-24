using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_AuctionAllReq : Rpc
	{

		public override uint GetRpcType()
		{
			return 38875U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AuctionAllReqArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<AuctionAllReqRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_AuctionAllReq.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_AuctionAllReq.OnTimeout(this.oArg);
		}

		public AuctionAllReqArg oArg = new AuctionAllReqArg();

		public AuctionAllReqRes oRes = null;
	}
}
