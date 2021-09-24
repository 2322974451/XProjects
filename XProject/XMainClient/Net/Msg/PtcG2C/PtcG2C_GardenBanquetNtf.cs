using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_GardenBanquetNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 56088U;
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
			Process_PtcG2C_GardenBanquetNtf.Process(this);
		}

		public BanquetNtfArg Data = new BanquetNtfArg();
	}
}
