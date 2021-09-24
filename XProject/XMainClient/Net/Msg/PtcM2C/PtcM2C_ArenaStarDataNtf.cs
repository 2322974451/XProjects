using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_ArenaStarDataNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 11371U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ArenaStarPara>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ArenaStarPara>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_ArenaStarDataNtf.Process(this);
		}

		public ArenaStarPara Data = new ArenaStarPara();
	}
}
