using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_BigMeleePointOutLookNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 25027U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BigMeleePointOutLook>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<BigMeleePointOutLook>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_BigMeleePointOutLookNtf.Process(this);
		}

		public BigMeleePointOutLook Data = new BigMeleePointOutLook();
	}
}
