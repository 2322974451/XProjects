using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001560 RID: 5472
	internal class PtcG2C_BigMeleeReliveNtf : Protocol
	{
		// Token: 0x0600EA97 RID: 60055 RVA: 0x003447D0 File Offset: 0x003429D0
		public override uint GetProtoType()
		{
			return 3358U;
		}

		// Token: 0x0600EA98 RID: 60056 RVA: 0x003447E7 File Offset: 0x003429E7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BigMeleeRelive>(stream, this.Data);
		}

		// Token: 0x0600EA99 RID: 60057 RVA: 0x003447F7 File Offset: 0x003429F7
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<BigMeleeRelive>(stream);
		}

		// Token: 0x0600EA9A RID: 60058 RVA: 0x00344806 File Offset: 0x00342A06
		public override void Process()
		{
			Process_PtcG2C_BigMeleeReliveNtf.Process(this);
		}

		// Token: 0x0400654F RID: 25935
		public BigMeleeRelive Data = new BigMeleeRelive();
	}
}
