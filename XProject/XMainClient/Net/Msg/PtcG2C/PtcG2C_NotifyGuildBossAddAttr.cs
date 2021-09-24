using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_NotifyGuildBossAddAttr : Protocol
	{

		public override uint GetProtoType()
		{
			return 42027U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AddAttrCount>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<AddAttrCount>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_NotifyGuildBossAddAttr.Process(this);
		}

		public AddAttrCount Data = new AddAttrCount();
	}
}
