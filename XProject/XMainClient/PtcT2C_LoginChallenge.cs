using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02000ED1 RID: 3793
	internal class PtcT2C_LoginChallenge : Protocol
	{
		// Token: 0x0600C8F8 RID: 51448 RVA: 0x002CFB64 File Offset: 0x002CDD64
		public override uint GetProtoType()
		{
			return 58495U;
		}

		// Token: 0x0600C8F9 RID: 51449 RVA: 0x002CFB7B File Offset: 0x002CDD7B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LoginChallenge>(stream, this.Data);
		}

		// Token: 0x0600C8FA RID: 51450 RVA: 0x002CFB8B File Offset: 0x002CDD8B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<LoginChallenge>(stream);
		}

		// Token: 0x0600C8FB RID: 51451 RVA: 0x002CFB9A File Offset: 0x002CDD9A
		public override void Process()
		{
			Process_PtcT2C_LoginChallenge.Process(this);
		}

		// Token: 0x040058D7 RID: 22743
		public LoginChallenge Data = new LoginChallenge();
	}
}
