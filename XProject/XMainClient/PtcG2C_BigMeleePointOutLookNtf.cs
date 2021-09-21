using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200165F RID: 5727
	internal class PtcG2C_BigMeleePointOutLookNtf : Protocol
	{
		// Token: 0x0600EECA RID: 61130 RVA: 0x0034A49C File Offset: 0x0034869C
		public override uint GetProtoType()
		{
			return 25027U;
		}

		// Token: 0x0600EECB RID: 61131 RVA: 0x0034A4B3 File Offset: 0x003486B3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BigMeleePointOutLook>(stream, this.Data);
		}

		// Token: 0x0600EECC RID: 61132 RVA: 0x0034A4C3 File Offset: 0x003486C3
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<BigMeleePointOutLook>(stream);
		}

		// Token: 0x0600EECD RID: 61133 RVA: 0x0034A4D2 File Offset: 0x003486D2
		public override void Process()
		{
			Process_PtcG2C_BigMeleePointOutLookNtf.Process(this);
		}

		// Token: 0x04006626 RID: 26150
		public BigMeleePointOutLook Data = new BigMeleePointOutLook();
	}
}
