using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_BattleFieldRoleAgainstNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 8049U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BattleFieldRoleAgainst>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<BattleFieldRoleAgainst>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_BattleFieldRoleAgainstNtf.Process(this);
		}

		public BattleFieldRoleAgainst Data = new BattleFieldRoleAgainst();
	}
}
