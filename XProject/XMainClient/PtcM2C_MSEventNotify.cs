using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_MSEventNotify : Protocol
	{

		public override uint GetProtoType()
		{
			return 1415U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<EventNotify>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<EventNotify>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_MSEventNotify.Process(this);
		}

		public EventNotify Data = new EventNotify();
	}
}
