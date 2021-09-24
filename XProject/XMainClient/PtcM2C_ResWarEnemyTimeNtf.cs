using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_ResWarEnemyTimeNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 48125U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ResWarEnemyTime>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ResWarEnemyTime>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_ResWarEnemyTimeNtf.Process(this);
		}

		public ResWarEnemyTime Data = new ResWarEnemyTime();
	}
}
