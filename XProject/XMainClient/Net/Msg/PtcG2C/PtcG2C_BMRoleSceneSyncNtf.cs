using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_BMRoleSceneSyncNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 40091U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BMRoleSceneSync>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<BMRoleSceneSync>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_BMRoleSceneSyncNtf.Process(this);
		}

		public BMRoleSceneSync Data = new BMRoleSceneSync();
	}
}
