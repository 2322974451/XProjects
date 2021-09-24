using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_FastMBConfirmM2CNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 58099U;
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
			Process_PtcM2C_FastMBConfirmM2CNtf.Process(this);
		}

		public FMBArg Data = new FMBArg();
	}
}
