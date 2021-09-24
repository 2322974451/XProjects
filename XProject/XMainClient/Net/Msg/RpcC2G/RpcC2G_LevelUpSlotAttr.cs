using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_LevelUpSlotAttr : Rpc
	{

		public override uint GetRpcType()
		{
			return 62918U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LevelUpSlotAttrArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<LevelUpSlotAttrRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_LevelUpSlotAttr.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_LevelUpSlotAttr.OnTimeout(this.oArg);
		}

		public LevelUpSlotAttrArg oArg = new LevelUpSlotAttrArg();

		public LevelUpSlotAttrRes oRes = new LevelUpSlotAttrRes();
	}
}
