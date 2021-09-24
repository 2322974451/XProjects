using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcC2G_QuitRoom : Protocol
	{

		public override uint GetProtoType()
		{
			return 44925U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<QuitRoom>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<QuitRoom>(stream);
		}

		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		public QuitRoom Data = new QuitRoom();
	}
}
