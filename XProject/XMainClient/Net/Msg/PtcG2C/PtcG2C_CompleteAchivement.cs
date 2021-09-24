using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_CompleteAchivement : Protocol
	{

		public override uint GetProtoType()
		{
			return 26346U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AchivementInfo>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<AchivementInfo>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_CompleteAchivement.Process(this);
		}

		public AchivementInfo Data = new AchivementInfo();
	}
}
