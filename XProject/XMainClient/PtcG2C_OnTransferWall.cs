using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_OnTransferWall : Protocol
	{

		public override uint GetProtoType()
		{
			return 37585U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<NotifyTransferWall>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<NotifyTransferWall>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_OnTransferWall.Process(this);
		}

		public NotifyTransferWall Data = new NotifyTransferWall();
	}
}
