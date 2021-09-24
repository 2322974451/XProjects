using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcC2M_CommitAnswerNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 12159U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<CommitAnswerNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<CommitAnswerNtf>(stream);
		}

		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		public CommitAnswerNtf Data = new CommitAnswerNtf();
	}
}
