using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_AnswerAckNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 60141U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AnswerAckNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<AnswerAckNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_AnswerAckNtf.Process(this);
		}

		public AnswerAckNtf Data = new AnswerAckNtf();
	}
}
