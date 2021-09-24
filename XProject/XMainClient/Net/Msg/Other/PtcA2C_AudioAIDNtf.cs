using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcA2C_AudioAIDNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 54517U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AudioTextArg>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<AudioTextArg>(stream);
		}

		public override void Process()
		{
			Process_PtcA2C_AudioAIDNtf.Process(this);
		}

		public AudioTextArg Data = new AudioTextArg();
	}
}
