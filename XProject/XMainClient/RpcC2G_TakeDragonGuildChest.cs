using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_TakeDragonGuildChest : Rpc
	{

		public override uint GetRpcType()
		{
			return 38031U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TakePartnerChestArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<TakePartnerChestRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_TakeDragonGuildChest.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_TakeDragonGuildChest.OnTimeout(this.oArg);
		}

		public TakePartnerChestArg oArg = new TakePartnerChestArg();

		public TakePartnerChestRes oRes = null;
	}
}
