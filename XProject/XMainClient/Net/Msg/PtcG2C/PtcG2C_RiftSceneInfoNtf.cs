using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_RiftSceneInfoNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 17975U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<RiftSceneInfoNtfData>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<RiftSceneInfoNtfData>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_RiftSceneInfoNtf.Process(this);
		}

		public RiftSceneInfoNtfData Data = new RiftSceneInfoNtfData();
	}
}
