using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_ResWarRankSimpleInfoNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 29973U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ResWarRankSimpleInfo>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ResWarRankSimpleInfo>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_ResWarRankSimpleInfoNtf.Process(this);
		}

		public ResWarRankSimpleInfo Data = new ResWarRankSimpleInfo();
	}
}
