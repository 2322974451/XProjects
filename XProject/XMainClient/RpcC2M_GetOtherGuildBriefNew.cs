using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GetOtherGuildBriefNew : Rpc
	{

		public override uint GetRpcType()
		{
			return 16797U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetOtherGuildBriefArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetOtherGuildBriefRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetOtherGuildBriefNew.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetOtherGuildBriefNew.OnTimeout(this.oArg);
		}

		public GetOtherGuildBriefArg oArg = new GetOtherGuildBriefArg();

		public GetOtherGuildBriefRes oRes = null;
	}
}
