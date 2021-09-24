using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_CustomBattleGMNotify : Protocol
	{

		public override uint GetProtoType()
		{
			return 65108U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<CustomBattleGMNotify>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<CustomBattleGMNotify>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_CustomBattleGMNotify.Process(this);
		}

		public CustomBattleGMNotify Data = new CustomBattleGMNotify();
	}
}
