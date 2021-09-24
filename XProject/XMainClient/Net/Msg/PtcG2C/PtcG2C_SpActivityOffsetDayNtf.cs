using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_SpActivityOffsetDayNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 4059U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SpActivityOffsetDay>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SpActivityOffsetDay>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_SpActivityOffsetDayNtf.Process(this);
		}

		public SpActivityOffsetDay Data = new SpActivityOffsetDay();
	}
}
