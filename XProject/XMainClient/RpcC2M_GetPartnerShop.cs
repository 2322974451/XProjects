using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GetPartnerShop : Rpc
	{

		public override uint GetRpcType()
		{
			return 46131U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetPartnerShopArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetPartnerShopRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetPartnerShop.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetPartnerShop.OnTimeout(this.oArg);
		}

		public GetPartnerShopArg oArg = new GetPartnerShopArg();

		public GetPartnerShopRes oRes = null;
	}
}
