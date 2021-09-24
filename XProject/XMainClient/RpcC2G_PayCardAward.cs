using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_PayCardAward : Rpc
	{

		public override uint GetRpcType()
		{
			return 20470U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PayCardAwardArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<PayCardAwardRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_PayCardAward.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_PayCardAward.OnTimeout(this.oArg);
		}

		public PayCardAwardArg oArg = new PayCardAwardArg();

		public PayCardAwardRes oRes = new PayCardAwardRes();
	}
}
