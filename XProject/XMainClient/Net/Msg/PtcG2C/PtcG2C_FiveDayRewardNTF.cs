using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_FiveDayRewardNTF : Protocol
	{

		public override uint GetProtoType()
		{
			return 37452U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<FiveRewardState>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<FiveRewardState>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_FiveDayRewardNTF.Process(this);
		}

		public FiveRewardState Data = new FiveRewardState();
	}
}
