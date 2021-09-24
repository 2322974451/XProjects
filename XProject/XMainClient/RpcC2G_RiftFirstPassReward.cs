using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_RiftFirstPassReward : Rpc
	{

		public override uint GetRpcType()
		{
			return 63150U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<RiftFirstPassRewardArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<RiftFirstPassRewardRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_RiftFirstPassReward.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_RiftFirstPassReward.OnTimeout(this.oArg);
		}

		public RiftFirstPassRewardArg oArg = new RiftFirstPassRewardArg();

		public RiftFirstPassRewardRes oRes = null;
	}
}
