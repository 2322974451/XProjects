using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GetOtherMentorStatus : Rpc
	{

		public override uint GetRpcType()
		{
			return 4896U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetOtherMentorStatusArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetOtherMentorStatusRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetOtherMentorStatus.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetOtherMentorStatus.OnTimeout(this.oArg);
		}

		public GetOtherMentorStatusArg oArg = new GetOtherMentorStatusArg();

		public GetOtherMentorStatusRes oRes = null;
	}
}
