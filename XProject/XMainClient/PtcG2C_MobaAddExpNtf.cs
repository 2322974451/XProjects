using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_MobaAddExpNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 36674U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<MobaAddExpData>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<MobaAddExpData>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_MobaAddExpNtf.Process(this);
		}

		public MobaAddExpData Data = new MobaAddExpData();
	}
}
