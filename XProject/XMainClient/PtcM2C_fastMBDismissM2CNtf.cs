using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_fastMBDismissM2CNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 38301U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<FMDArg>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<FMDArg>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_fastMBDismissM2CNtf.Process(this);
		}

		public FMDArg Data = new FMDArg();
	}
}
