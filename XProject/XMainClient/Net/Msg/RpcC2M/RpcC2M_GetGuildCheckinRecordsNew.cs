using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GetGuildCheckinRecordsNew : Rpc
	{

		public override uint GetRpcType()
		{
			return 16239U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetGuildCheckinRecordsArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetGuildCheckinRecordsRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetGuildCheckinRecordsNew.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetGuildCheckinRecordsNew.OnTimeout(this.oArg);
		}

		public GetGuildCheckinRecordsArg oArg = new GetGuildCheckinRecordsArg();

		public GetGuildCheckinRecordsRes oRes = null;
	}
}
