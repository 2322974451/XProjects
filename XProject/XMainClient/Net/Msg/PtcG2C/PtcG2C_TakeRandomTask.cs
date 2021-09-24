using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_TakeRandomTask : Protocol
	{

		public override uint GetProtoType()
		{
			return 8442U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<randomtask>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<randomtask>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_TakeRandomTask.Process(this);
		}

		public randomtask Data = new randomtask();
	}
}
