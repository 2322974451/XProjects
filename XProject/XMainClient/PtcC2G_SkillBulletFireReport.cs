using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020010B6 RID: 4278
	internal class PtcC2G_SkillBulletFireReport : Protocol
	{
		// Token: 0x0600D792 RID: 55186 RVA: 0x003285C6 File Offset: 0x003267C6
		public PtcC2G_SkillBulletFireReport()
		{
			this.Data.Pos = new Vec3();
		}

		// Token: 0x0600D793 RID: 55187 RVA: 0x003285EC File Offset: 0x003267EC
		public override uint GetProtoType()
		{
			return 54744U;
		}

		// Token: 0x0600D794 RID: 55188 RVA: 0x00328603 File Offset: 0x00326803
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BulletUnitData>(stream, this.Data);
		}

		// Token: 0x0600D795 RID: 55189 RVA: 0x00328613 File Offset: 0x00326813
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<BulletUnitData>(stream);
		}

		// Token: 0x0600D796 RID: 55190 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x040061AD RID: 25005
		public BulletUnitData Data = new BulletUnitData();
	}
}
