using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_HorseCountDownTimeNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 65307U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<HorseCountDownTime>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<HorseCountDownTime>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_HorseCountDownTimeNtf.Process(this);
		}

		public HorseCountDownTime Data = new HorseCountDownTime();
	}
}
