using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_MobaSignaling : Rpc
	{

		public override uint GetRpcType()
		{
			return 52475U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<MobaSignalingArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<MobaSignalingRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_MobaSignaling.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_MobaSignaling.OnTimeout(this.oArg);
		}

		public MobaSignalingArg oArg = new MobaSignalingArg();

		public MobaSignalingRes oRes = null;
	}
}
