using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_HeroBattleTeamMsgNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 1414U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<HeroBattleTeamMsg>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<HeroBattleTeamMsg>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_HeroBattleTeamMsgNtf.Process(this);
		}

		public HeroBattleTeamMsg Data = new HeroBattleTeamMsg();
	}
}
