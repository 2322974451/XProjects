using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020010B7 RID: 4279
	internal class PtcC2G_SkillBulletResultReq : Protocol
	{
		// Token: 0x0600D797 RID: 55191 RVA: 0x00328622 File Offset: 0x00326822
		public PtcC2G_SkillBulletResultReq()
		{
			this.Data.ResultAt = new Vec3();
		}

		// Token: 0x0600D798 RID: 55192 RVA: 0x00328648 File Offset: 0x00326848
		public override uint GetProtoType()
		{
			return 15929U;
		}

		// Token: 0x0600D799 RID: 55193 RVA: 0x0032865F File Offset: 0x0032685F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SkillBulletResultReqUnit>(stream, this.Data);
		}

		// Token: 0x0600D79A RID: 55194 RVA: 0x0032866F File Offset: 0x0032686F
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SkillBulletResultReqUnit>(stream);
		}

		// Token: 0x0600D79B RID: 55195 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x040061AE RID: 25006
		public SkillBulletResultReqUnit Data = new SkillBulletResultReqUnit();
	}
}
