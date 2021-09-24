using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_FetchEnemyDoodadNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 50480U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<OtherFetchDoodadRes>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<OtherFetchDoodadRes>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_FetchEnemyDoodadNtf.Process(this);
		}

		public OtherFetchDoodadRes Data = new OtherFetchDoodadRes();
	}
}
