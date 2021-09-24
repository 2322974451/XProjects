using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_UpdateTaskStatus : Protocol
	{

		public override uint GetProtoType()
		{
			return 1609U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TaskInfo>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<TaskInfo>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_UpdateTaskStatus.Process(this);
		}

		public TaskInfo Data = new TaskInfo();
	}
}
