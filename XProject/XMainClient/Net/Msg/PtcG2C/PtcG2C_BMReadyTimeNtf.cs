using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_BMReadyTimeNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 8612U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BMReadyTime>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<BMReadyTime>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_BMReadyTimeNtf.Process(this);
		}

		public BMReadyTime Data = new BMReadyTime();
	}
}
