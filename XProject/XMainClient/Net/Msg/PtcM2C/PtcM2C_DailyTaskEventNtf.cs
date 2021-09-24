using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_DailyTaskEventNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 26376U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<DailyTaskEventNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<DailyTaskEventNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_DailyTaskEventNtf.Process(this);
		}

		public DailyTaskEventNtf Data = new DailyTaskEventNtf();
	}
}
