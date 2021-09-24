using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_ResWarTimeNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 36825U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ResWarTime>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ResWarTime>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_ResWarTimeNtf.Process(this);
		}

		public ResWarTime Data = new ResWarTime();
	}
}
