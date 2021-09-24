using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_MidasExceptionNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 22947U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<MidasExceptionInfo>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<MidasExceptionInfo>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_MidasExceptionNtf.Process(this);
		}

		public MidasExceptionInfo Data = new MidasExceptionInfo();
	}
}
