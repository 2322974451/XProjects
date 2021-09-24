using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_SkyCraftMatchNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 4938U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SkyCraftMatchNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SkyCraftMatchNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_SkyCraftMatchNtf.Process(this);
		}

		public SkyCraftMatchNtf Data = new SkyCraftMatchNtf();
	}
}
