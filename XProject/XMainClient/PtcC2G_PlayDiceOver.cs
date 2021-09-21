using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200125D RID: 4701
	internal class PtcC2G_PlayDiceOver : Protocol
	{
		// Token: 0x0600DE4A RID: 56906 RVA: 0x003330B8 File Offset: 0x003312B8
		public override uint GetProtoType()
		{
			return 2064U;
		}

		// Token: 0x0600DE4B RID: 56907 RVA: 0x003330CF File Offset: 0x003312CF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PlayDiceOverData>(stream, this.Data);
		}

		// Token: 0x0600DE4C RID: 56908 RVA: 0x003330DF File Offset: 0x003312DF
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<PlayDiceOverData>(stream);
		}

		// Token: 0x0600DE4D RID: 56909 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x040062EF RID: 25327
		public PlayDiceOverData Data = new PlayDiceOverData();
	}
}
