using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_HeroBattleTeamRoleNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 25720U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<HeroBattleTeamRoleData>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<HeroBattleTeamRoleData>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_HeroBattleTeamRoleNtf.Process(this);
		}

		public HeroBattleTeamRoleData Data = new HeroBattleTeamRoleData();
	}
}
