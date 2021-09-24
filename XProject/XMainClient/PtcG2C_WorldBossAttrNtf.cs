using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_WorldBossAttrNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 31578U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<WorldBossAttrNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<WorldBossAttrNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_WorldBossAttrNtf.Process(this);
		}

		public WorldBossAttrNtf Data = new WorldBossAttrNtf();
	}
}
