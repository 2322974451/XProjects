using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020012A1 RID: 4769
	internal class PtcG2C_IdipPunishInfoNtf : Protocol
	{
		// Token: 0x0600DF64 RID: 57188 RVA: 0x00334890 File Offset: 0x00332A90
		public override uint GetProtoType()
		{
			return 46304U;
		}

		// Token: 0x0600DF65 RID: 57189 RVA: 0x003348A7 File Offset: 0x00332AA7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<IdipPunishInfo>(stream, this.Data);
		}

		// Token: 0x0600DF66 RID: 57190 RVA: 0x003348B7 File Offset: 0x00332AB7
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<IdipPunishInfo>(stream);
		}

		// Token: 0x0600DF67 RID: 57191 RVA: 0x003348C6 File Offset: 0x00332AC6
		public override void Process()
		{
			Process_PtcG2C_IdipPunishInfoNtf.Process(this);
		}

		// Token: 0x04006326 RID: 25382
		public IdipPunishInfo Data = new IdipPunishInfo();
	}
}
