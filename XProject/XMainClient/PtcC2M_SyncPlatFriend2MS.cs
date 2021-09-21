using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200133F RID: 4927
	internal class PtcC2M_SyncPlatFriend2MS : Protocol
	{
		// Token: 0x0600E1EE RID: 57838 RVA: 0x00338514 File Offset: 0x00336714
		public override uint GetProtoType()
		{
			return 38885U;
		}

		// Token: 0x0600E1EF RID: 57839 RVA: 0x0033852B File Offset: 0x0033672B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SyncPlatFriend2MSData>(stream, this.Data);
		}

		// Token: 0x0600E1F0 RID: 57840 RVA: 0x0033853B File Offset: 0x0033673B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SyncPlatFriend2MSData>(stream);
		}

		// Token: 0x0600E1F1 RID: 57841 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x040063A4 RID: 25508
		public SyncPlatFriend2MSData Data = new SyncPlatFriend2MSData();
	}
}
