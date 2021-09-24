using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_NoticeGuildTerrBattleWin : Protocol
	{

		public override uint GetProtoType()
		{
			return 61655U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<NoticeGuildTerrBattleWin>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<NoticeGuildTerrBattleWin>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_NoticeGuildTerrBattleWin.Process(this);
		}

		public NoticeGuildTerrBattleWin Data = new NoticeGuildTerrBattleWin();
	}
}
