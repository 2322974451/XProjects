using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_CustomBattleLoadingNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 34402U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<CustomBattleLoadingNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<CustomBattleLoadingNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_CustomBattleLoadingNtf.Process(this);
		}

		public CustomBattleLoadingNtf Data = new CustomBattleLoadingNtf();
	}
}
