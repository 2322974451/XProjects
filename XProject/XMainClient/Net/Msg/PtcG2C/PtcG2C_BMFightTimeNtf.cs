using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_BMFightTimeNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 4101U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BMFightTime>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<BMFightTime>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_BMFightTimeNtf.Process(this);
		}

		public BMFightTime Data = new BMFightTime();
	}
}
