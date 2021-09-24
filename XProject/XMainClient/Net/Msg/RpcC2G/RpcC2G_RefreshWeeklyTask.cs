using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_RefreshWeeklyTask : Rpc
	{

		public override uint GetRpcType()
		{
			return 3384U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<RefreshWeeklyTaskArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<RefreshWeeklyTaskRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_RefreshWeeklyTask.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_RefreshWeeklyTask.OnTimeout(this.oArg);
		}

		public RefreshWeeklyTaskArg oArg = new RefreshWeeklyTaskArg();

		public RefreshWeeklyTaskRes oRes = null;
	}
}
