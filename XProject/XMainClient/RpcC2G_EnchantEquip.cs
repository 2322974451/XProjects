using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_EnchantEquip : Rpc
	{

		public override uint GetRpcType()
		{
			return 55166U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<EnchantEquipArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<EnchantEquipRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_EnchantEquip.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_EnchantEquip.OnTimeout(this.oArg);
		}

		public EnchantEquipArg oArg = new EnchantEquipArg();

		public EnchantEquipRes oRes = null;
	}
}
