using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_NoticeGuildTerrWar : Protocol
	{

		public override uint GetProtoType()
		{
			return 17274U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<NoticeGuildTerrWar>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<NoticeGuildTerrWar>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_NoticeGuildTerrWar.Process(this);
		}

		public NoticeGuildTerrWar Data = new NoticeGuildTerrWar();
	}
}
