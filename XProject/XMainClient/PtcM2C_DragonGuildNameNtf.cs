using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_DragonGuildNameNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 35553U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<DragonGuildNameNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<DragonGuildNameNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_DragonGuildNameNtf.Process(this);
		}

		public DragonGuildNameNtf Data = new DragonGuildNameNtf();
	}
}
