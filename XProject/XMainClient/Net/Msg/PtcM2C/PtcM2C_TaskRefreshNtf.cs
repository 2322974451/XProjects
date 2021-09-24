using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_TaskRefreshNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 40464U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TaskRefreshNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<TaskRefreshNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_TaskRefreshNtf.Process(this);
		}

		public TaskRefreshNtf Data = new TaskRefreshNtf();
	}
}
