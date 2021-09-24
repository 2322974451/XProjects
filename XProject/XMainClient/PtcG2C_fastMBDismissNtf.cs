using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_fastMBDismissNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 49087U;
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
			Process_PtcG2C_fastMBDismissNtf.Process(this);
		}

		public FMDArg Data = new FMDArg();
	}
}
