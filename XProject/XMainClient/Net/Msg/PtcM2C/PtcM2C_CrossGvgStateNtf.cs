using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_CrossGvgStateNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 24216U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<CrossGvgStateNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<CrossGvgStateNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_CrossGvgStateNtf.Process(this);
		}

		public CrossGvgStateNtf Data = new CrossGvgStateNtf();
	}
}
