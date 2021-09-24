using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcC2G_SkillBulletFireReport : Protocol
	{

		public PtcC2G_SkillBulletFireReport()
		{
			this.Data.Pos = new Vec3();
		}

		public override uint GetProtoType()
		{
			return 54744U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BulletUnitData>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<BulletUnitData>(stream);
		}

		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		public BulletUnitData Data = new BulletUnitData();
	}
}
