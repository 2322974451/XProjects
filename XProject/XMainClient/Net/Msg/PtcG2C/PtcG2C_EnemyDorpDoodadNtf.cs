using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_EnemyDorpDoodadNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 55996U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<EnemyDropDoodadInfo>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<EnemyDropDoodadInfo>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_EnemyDorpDoodadNtf.Process(this);
		}

		public EnemyDropDoodadInfo Data = new EnemyDropDoodadInfo();
	}
}
