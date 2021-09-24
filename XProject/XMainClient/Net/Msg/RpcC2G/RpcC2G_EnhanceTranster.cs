using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_EnhanceTranster : Rpc
	{

		public override uint GetRpcType()
		{
			return 25778U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<EnhanceTransterArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<EnhanceTransterRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_EnhanceTranster.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_EnhanceTranster.OnTimeout(this.oArg);
		}

		public EnhanceTransterArg oArg = new EnhanceTransterArg();

		public EnhanceTransterRes oRes = new EnhanceTransterRes();
	}
}
