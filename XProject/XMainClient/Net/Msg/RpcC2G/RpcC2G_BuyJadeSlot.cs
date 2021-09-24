using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_BuyJadeSlot : Rpc
	{

		public override uint GetRpcType()
		{
			return 37813U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BuyJadeSlotArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<BuyJadeSlotRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_BuyJadeSlot.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_BuyJadeSlot.OnTimeout(this.oArg);
		}

		public BuyJadeSlotArg oArg = new BuyJadeSlotArg();

		public BuyJadeSlotRes oRes = new BuyJadeSlotRes();
	}
}
