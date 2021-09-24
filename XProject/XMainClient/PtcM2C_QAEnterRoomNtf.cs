using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_QAEnterRoomNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 38488U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<QAEnterRoomNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<QAEnterRoomNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_QAEnterRoomNtf.Process(this);
		}

		public QAEnterRoomNtf Data = new QAEnterRoomNtf();
	}
}
