using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_RiskBuyRequest : Rpc
	{

		public override uint GetRpcType()
		{
			return 42935U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<RiskBuyRequestArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<RiskBuyRequestRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_RiskBuyRequest.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_RiskBuyRequest.OnTimeout(this.oArg);
		}

		public RiskBuyRequestArg oArg = new RiskBuyRequestArg();

		public RiskBuyRequestRes oRes = new RiskBuyRequestRes();
	}
}
