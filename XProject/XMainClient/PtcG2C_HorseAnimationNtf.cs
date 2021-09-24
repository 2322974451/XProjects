using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_HorseAnimationNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 21212U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<HorseAnimation>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<HorseAnimation>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_HorseAnimationNtf.Process(this);
		}

		public HorseAnimation Data = new HorseAnimation();
	}
}
