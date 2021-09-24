using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_IdentifyEmblem : Rpc
	{

		public override uint GetRpcType()
		{
			return 43787U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<IdentifyEmblemArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<IdentifyEmblemRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_IdentifyEmblem.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_IdentifyEmblem.OnTimeout(this.oArg);
		}

		public IdentifyEmblemArg oArg = new IdentifyEmblemArg();

		public IdentifyEmblemRes oRes = new IdentifyEmblemRes();
	}
}
