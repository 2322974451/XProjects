using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_ResWarGuildBriefNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 35338U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ResWarGuildBrief>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ResWarGuildBrief>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_ResWarGuildBriefNtf.Process(this);
		}

		public ResWarGuildBrief Data = new ResWarGuildBrief();
	}
}
