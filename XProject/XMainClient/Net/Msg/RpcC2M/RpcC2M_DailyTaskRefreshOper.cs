using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_DailyTaskRefreshOper : Rpc
	{

		public override uint GetRpcType()
		{
			return 31675U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<DailyTaskRefreshOperArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<DailyTaskRefreshOperRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_DailyTaskRefreshOper.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_DailyTaskRefreshOper.OnTimeout(this.oArg);
		}

		public DailyTaskRefreshOperArg oArg = new DailyTaskRefreshOperArg();

		public DailyTaskRefreshOperRes oRes = null;
	}
}
