using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_MobaHintNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 17027U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<MobaHintNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<MobaHintNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_MobaHintNtf.Process(this);
		}

		public MobaHintNtf Data = new MobaHintNtf();
	}
}
