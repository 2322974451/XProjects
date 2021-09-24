using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_BuyExtraSkillEmblemSlot : Rpc
	{

		public override uint GetRpcType()
		{
			return 17851U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BuyExtraSkillEmblemSlotArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<BuyExtraSkillEmblemSlotRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_BuyExtraSkillEmblemSlot.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_BuyExtraSkillEmblemSlot.OnTimeout(this.oArg);
		}

		public BuyExtraSkillEmblemSlotArg oArg = new BuyExtraSkillEmblemSlotArg();

		public BuyExtraSkillEmblemSlotRes oRes = null;
	}
}
