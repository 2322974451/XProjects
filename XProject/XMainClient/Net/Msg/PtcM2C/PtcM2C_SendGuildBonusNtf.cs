using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_SendGuildBonusNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 36841U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SendGuildBonusNtfData>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SendGuildBonusNtfData>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_SendGuildBonusNtf.Process(this);
		}

		public SendGuildBonusNtfData Data = new SendGuildBonusNtfData();
	}
}
