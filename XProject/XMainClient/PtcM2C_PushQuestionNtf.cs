using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_PushQuestionNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 45138U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PushQuestionNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<PushQuestionNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_PushQuestionNtf.Process(this);
		}

		public PushQuestionNtf Data = new PushQuestionNtf();
	}
}
