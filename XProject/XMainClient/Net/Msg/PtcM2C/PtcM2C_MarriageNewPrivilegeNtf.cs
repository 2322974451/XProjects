using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_MarriageNewPrivilegeNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 50551U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<MarriageNewPrivilegeNtfData>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<MarriageNewPrivilegeNtfData>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_MarriageNewPrivilegeNtf.Process(this);
		}

		public MarriageNewPrivilegeNtfData Data = new MarriageNewPrivilegeNtfData();
	}
}
