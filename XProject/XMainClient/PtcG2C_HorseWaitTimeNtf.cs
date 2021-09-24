using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_HorseWaitTimeNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 34138U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<HorseWaitTime>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<HorseWaitTime>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_HorseWaitTimeNtf.Process(this);
		}

		public HorseWaitTime Data = new HorseWaitTime();
	}
}
