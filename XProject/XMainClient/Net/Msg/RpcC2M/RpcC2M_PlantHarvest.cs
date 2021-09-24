using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_PlantHarvest : Rpc
	{

		public override uint GetRpcType()
		{
			return 39568U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PlantHarvestArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<PlantHarvestRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_PlantHarvest.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_PlantHarvest.OnTimeout(this.oArg);
		}

		public PlantHarvestArg oArg = new PlantHarvestArg();

		public PlantHarvestRes oRes = null;
	}
}
