using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_BattleFieldReliveNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 813U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BattleFieldReliveInfo>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<BattleFieldReliveInfo>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_BattleFieldReliveNtf.Process(this);
		}

		public BattleFieldReliveInfo Data = new BattleFieldReliveInfo();
	}
}
