using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_EntityTargetChangeNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 9303U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<EntityTargetData>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<EntityTargetData>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_EntityTargetChangeNtf.Process(this);
		}

		public EntityTargetData Data = new EntityTargetData();
	}
}
