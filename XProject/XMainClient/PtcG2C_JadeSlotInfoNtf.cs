using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_JadeSlotInfoNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 51248U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<JadeSlotInfo>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<JadeSlotInfo>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_JadeSlotInfoNtf.Process(this);
		}

		public JadeSlotInfo Data = new JadeSlotInfo();
	}
}
