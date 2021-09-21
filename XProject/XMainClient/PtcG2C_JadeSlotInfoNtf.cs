using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020016AF RID: 5807
	internal class PtcG2C_JadeSlotInfoNtf : Protocol
	{
		// Token: 0x0600F017 RID: 61463 RVA: 0x0034C35C File Offset: 0x0034A55C
		public override uint GetProtoType()
		{
			return 51248U;
		}

		// Token: 0x0600F018 RID: 61464 RVA: 0x0034C373 File Offset: 0x0034A573
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<JadeSlotInfo>(stream, this.Data);
		}

		// Token: 0x0600F019 RID: 61465 RVA: 0x0034C383 File Offset: 0x0034A583
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<JadeSlotInfo>(stream);
		}

		// Token: 0x0600F01A RID: 61466 RVA: 0x0034C392 File Offset: 0x0034A592
		public override void Process()
		{
			Process_PtcG2C_JadeSlotInfoNtf.Process(this);
		}

		// Token: 0x0400666F RID: 26223
		public JadeSlotInfo Data = new JadeSlotInfo();
	}
}
