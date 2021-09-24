using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GetSkyCraftRecord : Rpc
	{

		public override uint GetRpcType()
		{
			return 39327U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetSkyCraftRecordArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetSkyCraftRecordRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetSkyCraftRecord.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetSkyCraftRecord.OnTimeout(this.oArg);
		}

		public GetSkyCraftRecordArg oArg = new GetSkyCraftRecordArg();

		public GetSkyCraftRecordRes oRes = null;
	}
}
