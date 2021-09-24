using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_InvHistoryC2MReq : Rpc
	{

		public override uint GetRpcType()
		{
			return 29978U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<InvHistoryArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<InvHistoryRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_InvHistoryC2MReq.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_InvHistoryC2MReq.OnTimeout(this.oArg);
		}

		public InvHistoryArg oArg = new InvHistoryArg();

		public InvHistoryRes oRes;
	}
}
