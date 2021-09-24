using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_NotifyClientEnterFight : Protocol
	{

		public override uint GetProtoType()
		{
			return 65191U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<NotifyEnemyEnterFight>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<NotifyEnemyEnterFight>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_NotifyClientEnterFight.Process(this);
		}

		public NotifyEnemyEnterFight Data = new NotifyEnemyEnterFight();
	}
}
