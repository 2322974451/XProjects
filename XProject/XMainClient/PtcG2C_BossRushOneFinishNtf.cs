using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_BossRushOneFinishNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 21034U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BossRushPara>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<BossRushPara>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_BossRushOneFinishNtf.Process(this);
		}

		public BossRushPara Data = new BossRushPara();
	}
}
