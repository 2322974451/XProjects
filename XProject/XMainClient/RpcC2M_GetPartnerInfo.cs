using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GetPartnerInfo : Rpc
	{

		public override uint GetRpcType()
		{
			return 61123U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetPartnerInfoArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetPartnerInfoRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetPartnerInfo.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetPartnerInfo.OnTimeout(this.oArg);
		}

		public GetPartnerInfoArg oArg = new GetPartnerInfoArg();

		public GetPartnerInfoRes oRes = null;
	}
}
