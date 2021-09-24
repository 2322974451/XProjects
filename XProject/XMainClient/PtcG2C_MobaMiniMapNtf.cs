using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_MobaMiniMapNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 32069U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<MobaMiniMapData>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<MobaMiniMapData>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_MobaMiniMapNtf.Process(this);
		}

		public MobaMiniMapData Data = new MobaMiniMapData();
	}
}
