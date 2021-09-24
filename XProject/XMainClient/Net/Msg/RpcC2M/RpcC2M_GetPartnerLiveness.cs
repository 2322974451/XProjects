using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GetPartnerLiveness : Rpc
	{

		public override uint GetRpcType()
		{
			return 18784U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetPartnerLivenessArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetPartnerLivenessRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetPartnerLiveness.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetPartnerLiveness.OnTimeout(this.oArg);
		}

		public GetPartnerLivenessArg oArg = new GetPartnerLivenessArg();

		public GetPartnerLivenessRes oRes = null;
	}
}
