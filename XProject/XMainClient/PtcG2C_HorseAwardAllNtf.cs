using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_HorseAwardAllNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 5990U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<HorseAwardAll>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<HorseAwardAll>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_HorseAwardAllNtf.Process(this);
		}

		public HorseAwardAll Data = new HorseAwardAll();
	}
}
