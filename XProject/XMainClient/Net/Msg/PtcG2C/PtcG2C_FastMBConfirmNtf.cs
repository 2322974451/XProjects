using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_FastMBConfirmNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 51623U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<FMBArg>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<FMBArg>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_FastMBConfirmNtf.Process(this);
		}

		public FMBArg Data = new FMBArg();
	}
}
