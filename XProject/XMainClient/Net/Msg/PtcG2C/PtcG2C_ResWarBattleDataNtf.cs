using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_ResWarBattleDataNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 18834U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ResWarAllInfo>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ResWarAllInfo>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_ResWarBattleDataNtf.Process(this);
		}

		public ResWarAllInfo Data = new ResWarAllInfo();
	}
}
