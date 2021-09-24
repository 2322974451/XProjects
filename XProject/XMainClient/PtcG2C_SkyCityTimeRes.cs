using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_SkyCityTimeRes : Protocol
	{

		public override uint GetProtoType()
		{
			return 30724U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SkyCityTimeInfo>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SkyCityTimeInfo>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_SkyCityTimeRes.Process(this);
		}

		public SkyCityTimeInfo Data = new SkyCityTimeInfo();
	}
}
