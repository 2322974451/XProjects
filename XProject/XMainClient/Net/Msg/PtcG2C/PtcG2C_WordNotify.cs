using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_WordNotify : Protocol
	{

		public override uint GetProtoType()
		{
			return 34052U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<WordNotify>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<WordNotify>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_WordNotify.Process(this);
		}

		public WordNotify Data = new WordNotify();
	}
}
