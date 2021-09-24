using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GetSpActivityBigPrize : Rpc
	{

		public override uint GetRpcType()
		{
			return 17229U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetSpActivityBigPrizeArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetSpActivityBigPrizeRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetSpActivityBigPrize.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetSpActivityBigPrize.OnTimeout(this.oArg);
		}

		public GetSpActivityBigPrizeArg oArg = new GetSpActivityBigPrizeArg();

		public GetSpActivityBigPrizeRes oRes = new GetSpActivityBigPrizeRes();
	}
}
