using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_WorldChannelLeftTimesNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 37503U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<WorldChannelLeftTimesNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<WorldChannelLeftTimesNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_WorldChannelLeftTimesNtf.Process(this);
		}

		public WorldChannelLeftTimesNtf Data = new WorldChannelLeftTimesNtf();
	}
}
