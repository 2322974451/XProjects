using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_GoalAwardsRedPoint : Protocol
	{

		public override uint GetProtoType()
		{
			return 11570U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GoalAwardsRedPointNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GoalAwardsRedPointNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_GoalAwardsRedPoint.Process(this);
		}

		public GoalAwardsRedPointNtf Data = new GoalAwardsRedPointNtf();
	}
}
