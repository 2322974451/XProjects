using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_AbsPartyNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 35041U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AbsPartyInfo>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<AbsPartyInfo>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_AbsPartyNtf.Process(this);
		}

		public AbsPartyInfo Data = new AbsPartyInfo();
	}
}
