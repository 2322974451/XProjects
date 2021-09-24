using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GetMyWatchRecord : Rpc
	{

		public override uint GetRpcType()
		{
			return 22907U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetMyWatchRecordArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetMyWatchRecordRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetMyWatchRecord.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetMyWatchRecord.OnTimeout(this.oArg);
		}

		public GetMyWatchRecordArg oArg = new GetMyWatchRecordArg();

		public GetMyWatchRecordRes oRes = new GetMyWatchRecordRes();
	}
}
