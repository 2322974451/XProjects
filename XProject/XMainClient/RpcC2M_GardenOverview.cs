using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GardenOverview : Rpc
	{

		public override uint GetRpcType()
		{
			return 20766U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GardenOverviewArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GardenOverviewRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GardenOverview.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GardenOverview.OnTimeout(this.oArg);
		}

		public GardenOverviewArg oArg = new GardenOverviewArg();

		public GardenOverviewRes oRes = null;
	}
}
