using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GetDragonGuildShop : Rpc
	{

		public override uint GetRpcType()
		{
			return 6075U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetDragonGuildShopArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetDragonGuildShopRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetDragonGuildShop.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetDragonGuildShop.OnTimeout(this.oArg);
		}

		public GetDragonGuildShopArg oArg = new GetDragonGuildShopArg();

		public GetDragonGuildShopRes oRes = null;
	}
}
