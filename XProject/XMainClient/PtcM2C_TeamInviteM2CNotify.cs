using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020011E4 RID: 4580
	internal class PtcM2C_TeamInviteM2CNotify : Protocol
	{
		// Token: 0x0600DC58 RID: 56408 RVA: 0x0033033C File Offset: 0x0032E53C
		public override uint GetProtoType()
		{
			return 1221U;
		}

		// Token: 0x0600DC59 RID: 56409 RVA: 0x00330353 File Offset: 0x0032E553
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TeamInvite>(stream, this.Data);
		}

		// Token: 0x0600DC5A RID: 56410 RVA: 0x00330363 File Offset: 0x0032E563
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<TeamInvite>(stream);
		}

		// Token: 0x0600DC5B RID: 56411 RVA: 0x00330372 File Offset: 0x0032E572
		public override void Process()
		{
			Process_PtcM2C_TeamInviteM2CNotify.Process(this);
		}

		// Token: 0x0400628E RID: 25230
		public TeamInvite Data = new TeamInvite();
	}
}
