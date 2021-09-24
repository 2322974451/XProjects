using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_FuseEquip : Rpc
	{

		public override uint GetRpcType()
		{
			return 56006U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<FuseEquipArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<FuseEquipRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_FuseEquip.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_FuseEquip.OnTimeout(this.oArg);
		}

		public FuseEquipArg oArg = new FuseEquipArg();

		public FuseEquipRes oRes = null;
	}
}
