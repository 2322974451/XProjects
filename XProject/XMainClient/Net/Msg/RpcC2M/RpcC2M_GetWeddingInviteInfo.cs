using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GetWeddingInviteInfo : Rpc
	{

		public override uint GetRpcType()
		{
			return 2804U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetWeddingInviteInfoArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetWeddingInviteInfoRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetWeddingInviteInfo.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetWeddingInviteInfo.OnTimeout(this.oArg);
		}

		public GetWeddingInviteInfoArg oArg = new GetWeddingInviteInfoArg();

		public GetWeddingInviteInfoRes oRes = null;
	}
}
