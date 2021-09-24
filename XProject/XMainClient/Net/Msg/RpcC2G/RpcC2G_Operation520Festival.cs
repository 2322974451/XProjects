using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_Operation520Festival : Rpc
	{

		public override uint GetRpcType()
		{
			return 17971U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<Operation520FestivalArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<Operation520FestivalRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_Operation520Festival.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_Operation520Festival.OnTimeout(this.oArg);
		}

		public Operation520FestivalArg oArg = new Operation520FestivalArg();

		public Operation520FestivalRes oRes = null;
	}
}
