using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_QueryLotteryCD : Rpc
	{

		public override uint GetRpcType()
		{
			return 12242U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<QueryLotteryCDArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<QueryLotteryCDRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_QueryLotteryCD.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_QueryLotteryCD.OnTimeout(this.oArg);
		}

		public QueryLotteryCDArg oArg = new QueryLotteryCDArg();

		public QueryLotteryCDRes oRes = null;
	}
}
