using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020011EC RID: 4588
	internal class PtcC2M_TeamInviteAckC2M : Protocol
	{
		// Token: 0x0600DC76 RID: 56438 RVA: 0x00330664 File Offset: 0x0032E864
		public override uint GetProtoType()
		{
			return 15365U;
		}

		// Token: 0x0600DC77 RID: 56439 RVA: 0x0033067B File Offset: 0x0032E87B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TeamInviteAck>(stream, this.Data);
		}

		// Token: 0x0600DC78 RID: 56440 RVA: 0x0033068B File Offset: 0x0032E88B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<TeamInviteAck>(stream);
		}

		// Token: 0x0600DC79 RID: 56441 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x04006293 RID: 25235
		public TeamInviteAck Data = new TeamInviteAck();
	}
}
