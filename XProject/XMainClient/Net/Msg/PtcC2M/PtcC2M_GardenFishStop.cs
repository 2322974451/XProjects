using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcC2M_GardenFishStop : Protocol
	{

		public override uint GetProtoType()
		{
			return 56656U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GardenFishStopArg>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GardenFishStopArg>(stream);
		}

		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		public GardenFishStopArg Data = new GardenFishStopArg();
	}
}
