using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_SynGuildArenaFightUnit : Protocol
	{

		public override uint GetProtoType()
		{
			return 59912U;
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
			Process_PtcG2C_SynGuildArenaFightUnit.Process(this);
		}

		public SynGuildArenaFightUnit Data = new SynGuildArenaFightUnit();
	}
}
