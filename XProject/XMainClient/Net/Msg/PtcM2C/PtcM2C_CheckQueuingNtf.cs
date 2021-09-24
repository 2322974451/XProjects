using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_CheckQueuingNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 25553U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<CheckQueuingNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<CheckQueuingNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_CheckQueuingNtf.Process(this);
		}

		public CheckQueuingNtf Data = new CheckQueuingNtf();
	}
}
