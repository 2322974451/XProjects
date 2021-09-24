using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_QARoomRankNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 36888U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<QARoomRankNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<QARoomRankNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_QARoomRankNtf.Process(this);
		}

		public QARoomRankNtf Data = new QARoomRankNtf();
	}
}
