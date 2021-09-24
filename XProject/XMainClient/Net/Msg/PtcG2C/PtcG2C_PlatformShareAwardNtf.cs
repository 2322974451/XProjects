using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_PlatformShareAwardNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 24055U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PlatformShareAwardPara>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<PlatformShareAwardPara>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_PlatformShareAwardNtf.Process(this);
		}

		public PlatformShareAwardPara Data = new PlatformShareAwardPara();
	}
}
