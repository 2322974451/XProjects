using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_TowerFirstPassRewardNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 1039U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TowerFirstPassRewardData>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<TowerFirstPassRewardData>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_TowerFirstPassRewardNtf.Process(this);
		}

		public TowerFirstPassRewardData Data = new TowerFirstPassRewardData();
	}
}
