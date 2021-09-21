using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020010AC RID: 4268
	internal class PtcG2C_TeamInviteNotify : Protocol
	{
		// Token: 0x0600D76D RID: 55149 RVA: 0x00327E8C File Offset: 0x0032608C
		public override uint GetProtoType()
		{
			return 4060U;
		}

		// Token: 0x0600D76E RID: 55150 RVA: 0x00327EA3 File Offset: 0x003260A3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TeamInvite>(stream, this.Data);
		}

		// Token: 0x0600D76F RID: 55151 RVA: 0x00327EB3 File Offset: 0x003260B3
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<TeamInvite>(stream);
		}

		// Token: 0x0600D770 RID: 55152 RVA: 0x00327EC2 File Offset: 0x003260C2
		public override void Process()
		{
			Process_PtcG2C_TeamInviteNotify.Process(this);
		}

		// Token: 0x040061A7 RID: 24999
		public TeamInvite Data = new TeamInvite();
	}
}
