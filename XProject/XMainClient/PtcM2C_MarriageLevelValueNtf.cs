using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_MarriageLevelValueNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 3559U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<MarriageLevelValueNtfData>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<MarriageLevelValueNtfData>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_MarriageLevelValueNtf.Process(this);
		}

		public MarriageLevelValueNtfData Data = new MarriageLevelValueNtfData();
	}
}
