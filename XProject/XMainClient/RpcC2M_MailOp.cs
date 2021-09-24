using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_MailOp : Rpc
	{

		public override uint GetRpcType()
		{
			return 50122U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<MailOpArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<MailOpRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_MailOp.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_MailOp.OnTimeout(this.oArg);
		}

		public MailOpArg oArg = new MailOpArg();

		public MailOpRes oRes = null;
	}
}
