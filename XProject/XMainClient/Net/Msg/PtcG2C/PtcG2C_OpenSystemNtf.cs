using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_OpenSystemNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 41168U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<Systems>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<Systems>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_OpenSystemNtf.Process(this);
		}

		public Systems Data = new Systems();
	}
}
