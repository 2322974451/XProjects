using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020010B5 RID: 4277
	internal class PtcC2G_SkillResultReq : Protocol
	{
		// Token: 0x0600D78D RID: 55181 RVA: 0x00328558 File Offset: 0x00326758
		public PtcC2G_SkillResultReq()
		{
			this.Data.ResultAt = new Vec3();
			this.Data.Pos = new Vec3();
		}

		// Token: 0x0600D78E RID: 55182 RVA: 0x00328590 File Offset: 0x00326790
		public override uint GetProtoType()
		{
			return 41958U;
		}

		// Token: 0x0600D78F RID: 55183 RVA: 0x003285A7 File Offset: 0x003267A7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SkillResultReqUnit>(stream, this.Data);
		}

		// Token: 0x0600D790 RID: 55184 RVA: 0x003285B7 File Offset: 0x003267B7
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SkillResultReqUnit>(stream);
		}

		// Token: 0x0600D791 RID: 55185 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x040061AC RID: 25004
		public SkillResultReqUnit Data = new SkillResultReqUnit();
	}
}
