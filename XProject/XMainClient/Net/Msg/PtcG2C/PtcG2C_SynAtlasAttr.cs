using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_SynAtlasAttr : Protocol
	{

		public override uint GetProtoType()
		{
			return 1285U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AllSynCardAttr>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<AllSynCardAttr>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_SynAtlasAttr.Process(this);
		}

		public AllSynCardAttr Data = new AllSynCardAttr();
	}
}
