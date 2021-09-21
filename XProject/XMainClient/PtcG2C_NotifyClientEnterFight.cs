using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001194 RID: 4500
	internal class PtcG2C_NotifyClientEnterFight : Protocol
	{
		// Token: 0x0600DB17 RID: 56087 RVA: 0x0032E75C File Offset: 0x0032C95C
		public override uint GetProtoType()
		{
			return 65191U;
		}

		// Token: 0x0600DB18 RID: 56088 RVA: 0x0032E773 File Offset: 0x0032C973
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<NotifyEnemyEnterFight>(stream, this.Data);
		}

		// Token: 0x0600DB19 RID: 56089 RVA: 0x0032E783 File Offset: 0x0032C983
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<NotifyEnemyEnterFight>(stream);
		}

		// Token: 0x0600DB1A RID: 56090 RVA: 0x0032E792 File Offset: 0x0032C992
		public override void Process()
		{
			Process_PtcG2C_NotifyClientEnterFight.Process(this);
		}

		// Token: 0x04006253 RID: 25171
		public NotifyEnemyEnterFight Data = new NotifyEnemyEnterFight();
	}
}
