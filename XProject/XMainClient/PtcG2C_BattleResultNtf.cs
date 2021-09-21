using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001015 RID: 4117
	internal class PtcG2C_BattleResultNtf : Protocol
	{
		// Token: 0x0600D4FA RID: 54522 RVA: 0x00322B70 File Offset: 0x00320D70
		public override uint GetProtoType()
		{
			return 29609U;
		}

		// Token: 0x0600D4FB RID: 54523 RVA: 0x00322B87 File Offset: 0x00320D87
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<NewBattleResult>(stream, this.Data);
		}

		// Token: 0x0600D4FC RID: 54524 RVA: 0x00322B97 File Offset: 0x00320D97
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<NewBattleResult>(stream);
		}

		// Token: 0x0600D4FD RID: 54525 RVA: 0x00322BA6 File Offset: 0x00320DA6
		public override void Process()
		{
			Process_PtcG2C_BattleResultNtf.Process(this);
		}

		// Token: 0x0400610A RID: 24842
		public NewBattleResult Data = new NewBattleResult();
	}
}
