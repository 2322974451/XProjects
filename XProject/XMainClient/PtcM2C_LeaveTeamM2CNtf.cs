using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020011E0 RID: 4576
	internal class PtcM2C_LeaveTeamM2CNtf : Protocol
	{
		// Token: 0x0600DC4A RID: 56394 RVA: 0x00330240 File Offset: 0x0032E440
		public override uint GetProtoType()
		{
			return 23306U;
		}

		// Token: 0x0600DC4B RID: 56395 RVA: 0x00330257 File Offset: 0x0032E457
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ErrorInfo>(stream, this.Data);
		}

		// Token: 0x0600DC4C RID: 56396 RVA: 0x00330267 File Offset: 0x0032E467
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ErrorInfo>(stream);
		}

		// Token: 0x0600DC4D RID: 56397 RVA: 0x00330276 File Offset: 0x0032E476
		public override void Process()
		{
			Process_PtcM2C_LeaveTeamM2CNtf.Process(this);
		}

		// Token: 0x0400628C RID: 25228
		public ErrorInfo Data = new ErrorInfo();
	}
}
