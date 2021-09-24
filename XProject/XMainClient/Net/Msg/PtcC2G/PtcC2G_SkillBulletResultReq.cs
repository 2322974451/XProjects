using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcC2G_SkillBulletResultReq : Protocol
	{

		public PtcC2G_SkillBulletResultReq()
		{
			this.Data.ResultAt = new Vec3();
		}

		public override uint GetProtoType()
		{
			return 15929U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SkillBulletResultReqUnit>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SkillBulletResultReqUnit>(stream);
		}

		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		public SkillBulletResultReqUnit Data = new SkillBulletResultReqUnit();
	}
}
