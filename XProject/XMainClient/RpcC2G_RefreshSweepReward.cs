using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_RefreshSweepReward : Rpc
	{

		public override uint GetRpcType()
		{
			return 38012U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<RefreshSweepRewardArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<RefreshSweepRewardRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_RefreshSweepReward.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_RefreshSweepReward.OnTimeout(this.oArg);
		}

		public RefreshSweepRewardArg oArg = new RefreshSweepRewardArg();

		public RefreshSweepRewardRes oRes = new RefreshSweepRewardRes();
	}
}
