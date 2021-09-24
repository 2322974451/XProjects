using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GardenSteal : Rpc
	{

		public override uint GetRpcType()
		{
			return 12696U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GardenStealArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GardenStealRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GardenSteal.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GardenSteal.OnTimeout(this.oArg);
		}

		public GardenStealArg oArg = new GardenStealArg();

		public GardenStealRes oRes = null;
	}
}
