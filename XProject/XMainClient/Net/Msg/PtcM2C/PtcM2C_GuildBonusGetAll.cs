using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_GuildBonusGetAll : Protocol
	{

		public override uint GetProtoType()
		{
			return 55177U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildBonusGetAllData>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GuildBonusGetAllData>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_GuildBonusGetAll.Process(this);
		}

		public GuildBonusGetAllData Data = new GuildBonusGetAllData();
	}
}
