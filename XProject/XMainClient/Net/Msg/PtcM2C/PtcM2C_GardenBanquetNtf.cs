using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_GardenBanquetNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 21287U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BanquetNtfArg>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<BanquetNtfArg>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_GardenBanquetNtf.Process(this);
		}

		public BanquetNtfArg Data = new BanquetNtfArg();
	}
}
