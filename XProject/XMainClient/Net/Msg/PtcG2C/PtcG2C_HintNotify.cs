using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_HintNotify : Protocol
	{

		public override uint GetProtoType()
		{
			return 23114U;
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
			Process_PtcG2C_HintNotify.Process(this);
		}

		public HintNotify Data = new HintNotify();
	}
}
