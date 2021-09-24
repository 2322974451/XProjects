using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_ChangeRiskBoxState : Rpc
	{

		public override uint GetRpcType()
		{
			return 4472U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ChangeRiskBoxStateArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ChangeRiskBoxStateRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ChangeRiskBoxState.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ChangeRiskBoxState.OnTimeout(this.oArg);
		}

		public ChangeRiskBoxStateArg oArg = new ChangeRiskBoxStateArg();

		public ChangeRiskBoxStateRes oRes = new ChangeRiskBoxStateRes();
	}
}
