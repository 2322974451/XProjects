using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_ReachAchieveNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 1479U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ReachAchieveNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ReachAchieveNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_ReachAchieveNtf.Process(this);
		}

		public ReachAchieveNtf Data = new ReachAchieveNtf();
	}
}
