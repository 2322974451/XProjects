using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001017 RID: 4119
	internal class PtcG2C_CompleteAchivement : Protocol
	{
		// Token: 0x0600D501 RID: 54529 RVA: 0x00322D0C File Offset: 0x00320F0C
		public override uint GetProtoType()
		{
			return 26346U;
		}

		// Token: 0x0600D502 RID: 54530 RVA: 0x00322D23 File Offset: 0x00320F23
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AchivementInfo>(stream, this.Data);
		}

		// Token: 0x0600D503 RID: 54531 RVA: 0x00322D33 File Offset: 0x00320F33
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<AchivementInfo>(stream);
		}

		// Token: 0x0600D504 RID: 54532 RVA: 0x00322D42 File Offset: 0x00320F42
		public override void Process()
		{
			Process_PtcG2C_CompleteAchivement.Process(this);
		}

		// Token: 0x0400610B RID: 24843
		public AchivementInfo Data = new AchivementInfo();
	}
}
