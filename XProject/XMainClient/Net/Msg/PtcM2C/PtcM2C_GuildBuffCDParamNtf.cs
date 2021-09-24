using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_GuildBuffCDParamNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 4703U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildBuffCDParam>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GuildBuffCDParam>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_GuildBuffCDParamNtf.Process(this);
		}

		public GuildBuffCDParam Data = new GuildBuffCDParam();
	}
}
