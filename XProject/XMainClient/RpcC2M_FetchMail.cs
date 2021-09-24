using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_FetchMail : Rpc
	{

		public override uint GetRpcType()
		{
			return 12373U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<FetchMailArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<FetchMailRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_FetchMail.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_FetchMail.OnTimeout(this.oArg);
		}

		public FetchMailArg oArg = new FetchMailArg();

		public FetchMailRes oRes = null;
	}
}
