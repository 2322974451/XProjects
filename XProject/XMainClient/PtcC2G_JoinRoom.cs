using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020011C8 RID: 4552
	internal class PtcC2G_JoinRoom : Protocol
	{
		// Token: 0x0600DBE7 RID: 56295 RVA: 0x0032FA30 File Offset: 0x0032DC30
		public override uint GetProtoType()
		{
			return 8517U;
		}

		// Token: 0x0600DBE8 RID: 56296 RVA: 0x0032FA47 File Offset: 0x0032DC47
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<JoinRoom>(stream, this.Data);
		}

		// Token: 0x0600DBE9 RID: 56297 RVA: 0x0032FA57 File Offset: 0x0032DC57
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<JoinRoom>(stream);
		}

		// Token: 0x0600DBEA RID: 56298 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x04006279 RID: 25209
		public JoinRoom Data = new JoinRoom();
	}
}
