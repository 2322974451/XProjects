using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcC2G_SkillResultReq : Protocol
	{

		public PtcC2G_SkillResultReq()
		{
			this.Data.ResultAt = new Vec3();
			this.Data.Pos = new Vec3();
		}

		public override uint GetProtoType()
		{
			return 41958U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SkillResultReqUnit>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SkillResultReqUnit>(stream);
		}

		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		public SkillResultReqUnit Data = new SkillResultReqUnit();
	}
}
