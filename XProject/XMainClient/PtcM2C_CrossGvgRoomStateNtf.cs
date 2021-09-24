using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_CrossGvgRoomStateNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 43720U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<CrossGvgRoomStateNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<CrossGvgRoomStateNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_CrossGvgRoomStateNtf.Process(this);
		}

		public CrossGvgRoomStateNtf Data = new CrossGvgRoomStateNtf();
	}
}
