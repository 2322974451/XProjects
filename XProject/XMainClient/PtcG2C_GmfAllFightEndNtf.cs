using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_GmfAllFightEndNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 42921U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GmfAllFightEnd>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GmfAllFightEnd>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_GmfAllFightEndNtf.Process(this);
		}

		public GmfAllFightEnd Data = new GmfAllFightEnd();
	}
}
