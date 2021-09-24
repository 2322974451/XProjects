using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcC2G_QTEOperation : Protocol
	{

		public override uint GetProtoType()
		{
			return 11413U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<QTEOperation>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<QTEOperation>(stream);
		}

		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		public QTEOperation Data = new QTEOperation();
	}
}
