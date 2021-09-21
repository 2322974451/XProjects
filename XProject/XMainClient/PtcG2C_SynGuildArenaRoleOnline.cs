using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001198 RID: 4504
	internal class PtcG2C_SynGuildArenaRoleOnline : Protocol
	{
		// Token: 0x0600DB27 RID: 56103 RVA: 0x0032EA04 File Offset: 0x0032CC04
		public override uint GetProtoType()
		{
			return 48528U;
		}

		// Token: 0x0600DB28 RID: 56104 RVA: 0x0032EA1B File Offset: 0x0032CC1B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SynGuildArenaRoleOnline>(stream, this.Data);
		}

		// Token: 0x0600DB29 RID: 56105 RVA: 0x0032EA2B File Offset: 0x0032CC2B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SynGuildArenaRoleOnline>(stream);
		}

		// Token: 0x0600DB2A RID: 56106 RVA: 0x0032EA3A File Offset: 0x0032CC3A
		public override void Process()
		{
			Process_PtcG2C_SynGuildArenaRoleOnline.Process(this);
		}

		// Token: 0x04006256 RID: 25174
		public SynGuildArenaRoleOnline Data = new SynGuildArenaRoleOnline();
	}
}
