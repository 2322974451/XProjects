using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_PayFirstAward : Rpc
	{

		public override uint GetRpcType()
		{
			return 46058U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PayFirstAwardArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<PayFirstAwardRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_PayFirstAward.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_PayFirstAward.OnTimeout(this.oArg);
		}

		public PayFirstAwardArg oArg = new PayFirstAwardArg();

		public PayFirstAwardRes oRes = new PayFirstAwardRes();
	}
}
