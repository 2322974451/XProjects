using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_NextDayRewardNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 50036U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<NextDayRewardNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<NextDayRewardNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_NextDayRewardNtf.Process(this);
		}

		public NextDayRewardNtf Data = new NextDayRewardNtf();
	}
}
