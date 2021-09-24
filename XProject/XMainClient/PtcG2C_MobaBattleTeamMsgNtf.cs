using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_MobaBattleTeamMsgNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 14987U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<MobaBattleTeamMsg>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<MobaBattleTeamMsg>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_MobaBattleTeamMsgNtf.Process(this);
		}

		public MobaBattleTeamMsg Data = new MobaBattleTeamMsg();
	}
}
