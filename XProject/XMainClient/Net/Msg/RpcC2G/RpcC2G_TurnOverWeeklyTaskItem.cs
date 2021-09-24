using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_TurnOverWeeklyTaskItem : Rpc
	{

		public override uint GetRpcType()
		{
			return 19937U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TurnOverWeeklyTaskItemArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<TurnOverWeeklyTaskItemRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_TurnOverWeeklyTaskItem.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_TurnOverWeeklyTaskItem.OnTimeout(this.oArg);
		}

		public TurnOverWeeklyTaskItemArg oArg = new TurnOverWeeklyTaskItemArg();

		public TurnOverWeeklyTaskItemRes oRes = null;
	}
}
