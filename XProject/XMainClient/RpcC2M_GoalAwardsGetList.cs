using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GoalAwardsGetList : Rpc
	{

		public override uint GetRpcType()
		{
			return 36694U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GoalAwardsGetList_C2M>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GoalAwardsGetList_M2C>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GoalAwardsGetList.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GoalAwardsGetList.OnTimeout(this.oArg);
		}

		public GoalAwardsGetList_C2M oArg = new GoalAwardsGetList_C2M();

		public GoalAwardsGetList_M2C oRes = null;
	}
}
