using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_MulActivityStateChange : Protocol
	{

		public override uint GetProtoType()
		{
			return 13448U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<MulActivityCha>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<MulActivityCha>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_MulActivityStateChange.Process(this);
		}

		public MulActivityCha Data = new MulActivityCha();
	}
}
