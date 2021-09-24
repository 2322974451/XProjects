using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcC2M_GiveUpQAQuestionNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 17022U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GiveUpQuestionNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GiveUpQuestionNtf>(stream);
		}

		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		public GiveUpQuestionNtf Data = new GiveUpQuestionNtf();
	}
}
