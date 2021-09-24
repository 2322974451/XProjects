using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_DecomposeEquipment : Rpc
	{

		public override uint GetRpcType()
		{
			return 6556U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<DecomposeEquipmentArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<DecomposeEquipmentRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_DecomposeEquipment.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_DecomposeEquipment.OnTimeout(this.oArg);
		}

		public DecomposeEquipmentArg oArg = new DecomposeEquipmentArg();

		public DecomposeEquipmentRes oRes = new DecomposeEquipmentRes();
	}
}
