using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GetDragonGuildShopRecord : Rpc
	{

		public override uint GetRpcType()
		{
			return 3114U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetDragonGuildShopRecordArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetDragonGuildShopRecordRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetDragonGuildShopRecord.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetDragonGuildShopRecord.OnTimeout(this.oArg);
		}

		public GetDragonGuildShopRecordArg oArg = new GetDragonGuildShopRecordArg();

		public GetDragonGuildShopRecordRes oRes = null;
	}
}
