using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_TakeMarriageChest : Rpc
	{

		public override uint GetRpcType()
		{
			return 38713U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TakeMarriageChestArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<TakeMarriageChestRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_TakeMarriageChest.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_TakeMarriageChest.OnTimeout(this.oArg);
		}

		public TakeMarriageChestArg oArg = new TakeMarriageChestArg();

		public TakeMarriageChestRes oRes = null;
	}
}
