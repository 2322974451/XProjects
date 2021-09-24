using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_ReqGuildList : Rpc
	{

		public override uint GetRpcType()
		{
			return 46835U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<FetchGuildListArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<FetchGuildListRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_ReqGuildList.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_ReqGuildList.OnTimeout(this.oArg);
		}

		public FetchGuildListArg oArg = new FetchGuildListArg();

		public FetchGuildListRes oRes = null;
	}
}
