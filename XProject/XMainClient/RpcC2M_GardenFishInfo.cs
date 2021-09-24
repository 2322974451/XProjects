using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GardenFishInfo : Rpc
	{

		public override uint GetRpcType()
		{
			return 10768U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GardenFishInfoArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GardenFishInfoRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GardenFishInfo.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GardenFishInfo.OnTimeout(this.oArg);
		}

		public GardenFishInfoArg oArg = new GardenFishInfoArg();

		public GardenFishInfoRes oRes = null;
	}
}
