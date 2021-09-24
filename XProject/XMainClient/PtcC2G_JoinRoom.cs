using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcC2G_JoinRoom : Protocol
	{

		public override uint GetProtoType()
		{
			return 8517U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<JoinRoom>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<JoinRoom>(stream);
		}

		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		public JoinRoom Data = new JoinRoom();
	}
}
