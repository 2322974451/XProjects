using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_HintNotifyMS : Protocol
	{

		public override uint GetProtoType()
		{
			return 15542U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<HintNotify>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<HintNotify>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_HintNotifyMS.Process(this);
		}

		public HintNotify Data = new HintNotify();
	}
}
