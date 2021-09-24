using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_BuyJadeSlotNew : Rpc
	{

		public override uint GetRpcType()
		{
			return 37588U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BuyJadeSlotNewArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<BuyJadeSlotNewRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_BuyJadeSlotNew.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_BuyJadeSlotNew.OnTimeout(this.oArg);
		}

		public BuyJadeSlotNewArg oArg = new BuyJadeSlotNewArg();

		public BuyJadeSlotNewRes oRes = null;
	}
}
