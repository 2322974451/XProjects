using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_ResWarMineDataNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 57215U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ResWarMineData>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ResWarMineData>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_ResWarMineDataNtf.Process(this);
		}

		public ResWarMineData Data = new ResWarMineData();
	}
}
