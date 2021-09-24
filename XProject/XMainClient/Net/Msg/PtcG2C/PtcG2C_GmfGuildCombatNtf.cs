using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_GmfGuildCombatNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 55102U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GmfGuildCombatPara>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GmfGuildCombatPara>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_GmfGuildCombatNtf.Process(this);
		}

		public GmfGuildCombatPara Data = new GmfGuildCombatPara();
	}
}
