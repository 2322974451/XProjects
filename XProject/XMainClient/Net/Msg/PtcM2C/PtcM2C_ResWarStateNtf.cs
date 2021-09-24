using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_ResWarStateNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 18481U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ResWarStateInfo>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ResWarStateInfo>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_ResWarStateNtf.Process(this);
		}

		public ResWarStateInfo Data = new ResWarStateInfo();
	}
}
