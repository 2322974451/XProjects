using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200151E RID: 5406
	internal class PtcG2C_CustomBattleLoadingNtf : Protocol
	{
		// Token: 0x0600E993 RID: 59795 RVA: 0x00342F0C File Offset: 0x0034110C
		public override uint GetProtoType()
		{
			return 34402U;
		}

		// Token: 0x0600E994 RID: 59796 RVA: 0x00342F23 File Offset: 0x00341123
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<CustomBattleLoadingNtf>(stream, this.Data);
		}

		// Token: 0x0600E995 RID: 59797 RVA: 0x00342F33 File Offset: 0x00341133
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<CustomBattleLoadingNtf>(stream);
		}

		// Token: 0x0600E996 RID: 59798 RVA: 0x00342F42 File Offset: 0x00341142
		public override void Process()
		{
			Process_PtcG2C_CustomBattleLoadingNtf.Process(this);
		}

		// Token: 0x04006519 RID: 25881
		public CustomBattleLoadingNtf Data = new CustomBattleLoadingNtf();
	}
}
