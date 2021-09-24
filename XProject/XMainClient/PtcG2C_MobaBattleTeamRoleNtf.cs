using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_MobaBattleTeamRoleNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 44930U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<MobaBattleTeamRoleData>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<MobaBattleTeamRoleData>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_MobaBattleTeamRoleNtf.Process(this);
		}

		public MobaBattleTeamRoleData Data = new MobaBattleTeamRoleData();
	}
}
