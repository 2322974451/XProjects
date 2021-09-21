using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020012F1 RID: 4849
	internal class PtcC2M_GuildCardMatchReq : Protocol
	{
		// Token: 0x0600E0AD RID: 57517 RVA: 0x003366C0 File Offset: 0x003348C0
		public override uint GetProtoType()
		{
			return 21904U;
		}

		// Token: 0x0600E0AE RID: 57518 RVA: 0x003366D7 File Offset: 0x003348D7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildCardMatchReq>(stream, this.Data);
		}

		// Token: 0x0600E0AF RID: 57519 RVA: 0x003366E7 File Offset: 0x003348E7
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GuildCardMatchReq>(stream);
		}

		// Token: 0x0600E0B0 RID: 57520 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x04006366 RID: 25446
		public GuildCardMatchReq Data = new GuildCardMatchReq();
	}
}
