using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_PlantCultivation : Rpc
	{

		public override uint GetRpcType()
		{
			return 61295U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PlantCultivationArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<PlantCultivationRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_PlantCultivation.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_PlantCultivation.OnTimeout(this.oArg);
		}

		public PlantCultivationArg oArg = new PlantCultivationArg();

		public PlantCultivationRes oRes = null;
	}
}
