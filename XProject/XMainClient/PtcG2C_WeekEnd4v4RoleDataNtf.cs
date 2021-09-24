using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_WeekEnd4v4RoleDataNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 54598U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<WeekEnd4v4BattleAllRoleData>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<WeekEnd4v4BattleAllRoleData>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_WeekEnd4v4RoleDataNtf.Process(this);
		}

		public WeekEnd4v4BattleAllRoleData Data = new WeekEnd4v4BattleAllRoleData();
	}
}
