using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GetPartnerDetailInfo : Rpc
	{

		public override uint GetRpcType()
		{
			return 31275U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetPartnerDetailInfoArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetPartnerDetailInfoRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetPartnerDetailInfo.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetPartnerDetailInfo.OnTimeout(this.oArg);
		}

		public GetPartnerDetailInfoArg oArg = new GetPartnerDetailInfoArg();

		public GetPartnerDetailInfoRes oRes = null;
	}
}
