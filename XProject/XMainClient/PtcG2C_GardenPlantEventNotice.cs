using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_GardenPlantEventNotice : Protocol
	{

		public override uint GetProtoType()
		{
			return 60686U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GardenPlantEventNoticeArg>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GardenPlantEventNoticeArg>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_GardenPlantEventNotice.Process(this);
		}

		public GardenPlantEventNoticeArg Data = new GardenPlantEventNoticeArg();
	}
}
