using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_ForgeEquip : Rpc
	{

		public override uint GetRpcType()
		{
			return 58244U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ForgeEquipArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ForgeEquipRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ForgeEquip.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ForgeEquip.OnTimeout(this.oArg);
		}

		public ForgeEquipArg oArg = new ForgeEquipArg();

		public ForgeEquipRes oRes = null;
	}
}
