using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_PayNotify : Rpc
	{

		public override uint GetRpcType()
		{
			return 32125U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PayNotifyArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<PayNotifyRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_PayNotify.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_PayNotify.OnTimeout(this.oArg);
		}

		public PayNotifyArg oArg = new PayNotifyArg();

		public PayNotifyRes oRes = null;
	}
}
