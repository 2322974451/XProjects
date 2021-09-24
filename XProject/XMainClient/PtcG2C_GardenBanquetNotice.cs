using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_GardenBanquetNotice : Protocol
	{

		public override uint GetProtoType()
		{
			return 36929U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GardenBanquetNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GardenBanquetNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_GardenBanquetNotice.Process(this);
		}

		public GardenBanquetNtf Data = new GardenBanquetNtf();
	}
}
