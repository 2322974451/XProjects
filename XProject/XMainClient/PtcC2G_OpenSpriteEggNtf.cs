using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200128E RID: 4750
	internal class PtcC2G_OpenSpriteEggNtf : Protocol
	{
		// Token: 0x0600DF14 RID: 57108 RVA: 0x0033406C File Offset: 0x0033226C
		public override uint GetProtoType()
		{
			return 47965U;
		}

		// Token: 0x0600DF15 RID: 57109 RVA: 0x00334083 File Offset: 0x00332283
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<OpenSpriteEgg>(stream, this.Data);
		}

		// Token: 0x0600DF16 RID: 57110 RVA: 0x00334093 File Offset: 0x00332293
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<OpenSpriteEgg>(stream);
		}

		// Token: 0x0600DF17 RID: 57111 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x04006316 RID: 25366
		public OpenSpriteEgg Data = new OpenSpriteEgg();
	}
}
