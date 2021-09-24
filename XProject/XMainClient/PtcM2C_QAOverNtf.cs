using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_QAOverNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 29361U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<QAOverNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<QAOverNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_QAOverNtf.Process(this);
		}

		public QAOverNtf Data = new QAOverNtf();
	}
}
