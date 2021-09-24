using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_HorseFinalNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 57969U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<HorseFinal>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<HorseFinal>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_HorseFinalNtf.Process(this);
		}

		public HorseFinal Data = new HorseFinal();
	}
}
