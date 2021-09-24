using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GetAncientTimesAward : Rpc
	{

		public override uint GetRpcType()
		{
			return 40517U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AncientTimesArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<AncientTimesRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetAncientTimesAward.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetAncientTimesAward.OnTimeout(this.oArg);
		}

		public AncientTimesArg oArg = new AncientTimesArg();

		public AncientTimesRes oRes = null;
	}
}
