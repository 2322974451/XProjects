using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_RewardChangedNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 57873U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<RewardChanged>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<RewardChanged>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_RewardChangedNtf.Process(this);
		}

		public RewardChanged Data = new RewardChanged();
	}
}
