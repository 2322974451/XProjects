using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GetMyMentorInfo : Rpc
	{

		public override uint GetRpcType()
		{
			return 8287U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetMyMentorInfoArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetMyMentorInfoRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetMyMentorInfo.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetMyMentorInfo.OnTimeout(this.oArg);
		}

		public GetMyMentorInfoArg oArg = new GetMyMentorInfoArg();

		public GetMyMentorInfoRes oRes = null;
	}
}
