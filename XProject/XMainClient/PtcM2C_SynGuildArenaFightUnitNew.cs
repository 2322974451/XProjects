using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_SynGuildArenaFightUnitNew : Protocol
	{

		public override uint GetProtoType()
		{
			return 34513U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SynGuildArenaFightUnit>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SynGuildArenaFightUnit>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_SynGuildArenaFightUnitNew.Process(this);
		}

		public SynGuildArenaFightUnit Data = new SynGuildArenaFightUnit();
	}
}
