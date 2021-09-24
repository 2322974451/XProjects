using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_FirstPassRewardNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 19007U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<FirstPassRewardNtfData>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<FirstPassRewardNtfData>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_FirstPassRewardNtf.Process(this);
		}

		public FirstPassRewardNtfData Data = new FirstPassRewardNtfData();
	}
}
