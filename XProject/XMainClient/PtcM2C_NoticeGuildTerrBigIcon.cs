using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_NoticeGuildTerrBigIcon : Protocol
	{

		public override uint GetProtoType()
		{
			return 13723U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<NoticeGuildTerrBigIcon>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<NoticeGuildTerrBigIcon>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_NoticeGuildTerrBigIcon.Process(this);
		}

		public NoticeGuildTerrBigIcon Data = new NoticeGuildTerrBigIcon();
	}
}
