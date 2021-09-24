using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_NoticeGuildTerrall : Protocol
	{

		public override uint GetProtoType()
		{
			return 7704U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<NoticeGuildTerrall>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<NoticeGuildTerrall>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_NoticeGuildTerrall.Process(this);
		}

		public NoticeGuildTerrall Data = new NoticeGuildTerrall();
	}
}
