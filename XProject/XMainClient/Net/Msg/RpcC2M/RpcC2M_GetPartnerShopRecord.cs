using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GetPartnerShopRecord : Rpc
	{

		public override uint GetRpcType()
		{
			return 56970U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetPartnerShopRecordArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetPartnerShopRecordRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetPartnerShopRecord.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetPartnerShopRecord.OnTimeout(this.oArg);
		}

		public GetPartnerShopRecordArg oArg = new GetPartnerShopRecordArg();

		public GetPartnerShopRecordRes oRes = null;
	}
}
