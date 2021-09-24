using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GetDailyTaskInfo : Rpc
	{

		public override uint GetRpcType()
		{
			return 52480U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetDailyTaskInfoArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetDailyTaskInfoRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetDailyTaskInfo.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetDailyTaskInfo.OnTimeout(this.oArg);
		}

		public GetDailyTaskInfoArg oArg = new GetDailyTaskInfoArg();

		public GetDailyTaskInfoRes oRes = new GetDailyTaskInfoRes();
	}
}
