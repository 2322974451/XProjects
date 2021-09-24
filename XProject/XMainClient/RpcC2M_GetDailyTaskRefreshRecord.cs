using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GetDailyTaskRefreshRecord : Rpc
	{

		public override uint GetRpcType()
		{
			return 7202U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetDailyTaskRefreshRecordArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetDailyTaskRefreshRecordRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetDailyTaskRefreshRecord.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetDailyTaskRefreshRecord.OnTimeout(this.oArg);
		}

		public GetDailyTaskRefreshRecordArg oArg = new GetDailyTaskRefreshRecordArg();

		public GetDailyTaskRefreshRecordRes oRes = null;
	}
}
