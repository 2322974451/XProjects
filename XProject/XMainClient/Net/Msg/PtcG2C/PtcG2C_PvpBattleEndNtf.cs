using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_PvpBattleEndNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 46438U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PvpBattleEndData>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<PvpBattleEndData>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_PvpBattleEndNtf.Process(this);
		}

		public PvpBattleEndData Data = new PvpBattleEndData();
	}
}
