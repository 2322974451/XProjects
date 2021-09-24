using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GetDragonGuildTaskInfo : Rpc
	{

		public override uint GetRpcType()
		{
			return 36879U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetDragonGuildTaskInfoArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetDragonGuildTaskInfoRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetDragonGuildTaskInfo.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetDragonGuildTaskInfo.OnTimeout(this.oArg);
		}

		public GetDragonGuildTaskInfoArg oArg = new GetDragonGuildTaskInfoArg();

		public GetDragonGuildTaskInfoRes oRes = null;
	}
}
