using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_TowerSceneInfoNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 14948U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TowerSceneInfoData>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<TowerSceneInfoData>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_TowerSceneInfoNtf.Process(this);
		}

		public TowerSceneInfoData Data = new TowerSceneInfoData();
	}
}
