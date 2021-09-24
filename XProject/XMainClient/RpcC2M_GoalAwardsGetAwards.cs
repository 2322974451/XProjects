using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GoalAwardsGetAwards : Rpc
	{

		public override uint GetRpcType()
		{
			return 4985U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GoalAwardsGetAwards_C2M>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GoalAwardsGetAwards_M2C>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GoalAwardsGetAwards.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GoalAwardsGetAwards.OnTimeout(this.oArg);
		}

		public GoalAwardsGetAwards_C2M oArg = new GoalAwardsGetAwards_C2M();

		public GoalAwardsGetAwards_M2C oRes = null;
	}
}
