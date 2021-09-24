using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_MilitaryrankNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 64945U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<MilitaryRecord>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<MilitaryRecord>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_MilitaryrankNtf.Process(this);
		}

		public MilitaryRecord Data = new MilitaryRecord();
	}
}
