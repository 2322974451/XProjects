using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GetDailyTaskRefreshInfo : Rpc
	{

		public override uint GetRpcType()
		{
			return 42385U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetDailyTaskRefreshInfoArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetDailyTaskRefreshInfoRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetDailyTaskRefreshInfo.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetDailyTaskRefreshInfo.OnTimeout(this.oArg);
		}

		public GetDailyTaskRefreshInfoArg oArg = new GetDailyTaskRefreshInfoArg();

		public GetDailyTaskRefreshInfoRes oRes = null;
	}
}
