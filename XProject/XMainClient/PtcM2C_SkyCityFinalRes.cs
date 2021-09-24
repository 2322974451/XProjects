using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_SkyCityFinalRes : Protocol
	{

		public override uint GetProtoType()
		{
			return 30112U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SkyCityFinalBaseInfo>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SkyCityFinalBaseInfo>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_SkyCityFinalRes.Process(this);
		}

		public SkyCityFinalBaseInfo Data = new SkyCityFinalBaseInfo();
	}
}
