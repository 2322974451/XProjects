using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_GprOneBattleEndNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 39421U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GprOneBattleEnd>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GprOneBattleEnd>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_GprOneBattleEndNtf.Process(this);
		}

		public GprOneBattleEnd Data = new GprOneBattleEnd();
	}
}
