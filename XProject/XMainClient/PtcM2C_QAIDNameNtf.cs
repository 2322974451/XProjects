using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_QAIDNameNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 987U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<QAIDNameList>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<QAIDNameList>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_QAIDNameNtf.Process(this);
		}

		public QAIDNameList Data = new QAIDNameList();
	}
}
