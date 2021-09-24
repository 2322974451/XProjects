using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GetWeeklyTaskInfo : Rpc
	{

		public override uint GetRpcType()
		{
			return 44747U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetWeeklyTaskInfoArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetWeeklyTaskInfoRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetWeeklyTaskInfo.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetWeeklyTaskInfo.OnTimeout(this.oArg);
		}

		public GetWeeklyTaskInfoArg oArg = new GetWeeklyTaskInfoArg();

		public GetWeeklyTaskInfoRes oRes = null;
	}
}
