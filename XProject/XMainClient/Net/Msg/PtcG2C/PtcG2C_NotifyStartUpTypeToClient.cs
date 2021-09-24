using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_NotifyStartUpTypeToClient : Protocol
	{

		public override uint GetProtoType()
		{
			return 64412U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<NotifyStartUpTypeToClient>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<NotifyStartUpTypeToClient>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_NotifyStartUpTypeToClient.Process(this);
		}

		public NotifyStartUpTypeToClient Data = new NotifyStartUpTypeToClient();
	}
}
