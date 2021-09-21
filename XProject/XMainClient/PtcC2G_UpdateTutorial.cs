using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001012 RID: 4114
	internal class PtcC2G_UpdateTutorial : Protocol
	{
		// Token: 0x0600D4EE RID: 54510 RVA: 0x0032294C File Offset: 0x00320B4C
		public override uint GetProtoType()
		{
			return 31917U;
		}

		// Token: 0x0600D4EF RID: 54511 RVA: 0x00322963 File Offset: 0x00320B63
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TutorialInfo>(stream, this.Data);
		}

		// Token: 0x0600D4F0 RID: 54512 RVA: 0x00322973 File Offset: 0x00320B73
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<TutorialInfo>(stream);
		}

		// Token: 0x0600D4F1 RID: 54513 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x04006108 RID: 24840
		public TutorialInfo Data = new TutorialInfo();
	}
}
