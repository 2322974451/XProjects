using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020012A3 RID: 4771
	internal class PtcM2C_IdipPunishInfoMsNtf : Protocol
	{
		// Token: 0x0600DF6B RID: 57195 RVA: 0x0033490C File Offset: 0x00332B0C
		public override uint GetProtoType()
		{
			return 8208U;
		}

		// Token: 0x0600DF6C RID: 57196 RVA: 0x00334923 File Offset: 0x00332B23
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<IdipPunishInfo>(stream, this.Data);
		}

		// Token: 0x0600DF6D RID: 57197 RVA: 0x00334933 File Offset: 0x00332B33
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<IdipPunishInfo>(stream);
		}

		// Token: 0x0600DF6E RID: 57198 RVA: 0x00334942 File Offset: 0x00332B42
		public override void Process()
		{
			Process_PtcM2C_IdipPunishInfoMsNtf.Process(this);
		}

		// Token: 0x04006327 RID: 25383
		public IdipPunishInfo Data = new IdipPunishInfo();
	}
}
