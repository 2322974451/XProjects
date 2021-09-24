using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_UpdateLeagueBattleSeasonInfo : Protocol
	{

		public override uint GetProtoType()
		{
			return 42828U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<UpdateLeagueBattleSeasonInfo>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<UpdateLeagueBattleSeasonInfo>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_UpdateLeagueBattleSeasonInfo.Process(this);
		}

		public UpdateLeagueBattleSeasonInfo Data = new UpdateLeagueBattleSeasonInfo();
	}
}
