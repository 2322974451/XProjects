using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_BFFightTimeNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 39352U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BFFightTime>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<BFFightTime>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_BFFightTimeNtf.Process(this);
		}

		public BFFightTime Data = new BFFightTime();
	}
}
