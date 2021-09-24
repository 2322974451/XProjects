using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GrowthFundAward : Rpc
	{

		public override uint GetRpcType()
		{
			return 43548U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GrowthFundAwardArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GrowthFundAwardRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GrowthFundAward.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GrowthFundAward.OnTimeout(this.oArg);
		}

		public GrowthFundAwardArg oArg = new GrowthFundAwardArg();

		public GrowthFundAwardRes oRes = new GrowthFundAwardRes();
	}
}
