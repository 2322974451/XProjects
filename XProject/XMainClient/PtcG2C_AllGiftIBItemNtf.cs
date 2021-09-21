using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020014BB RID: 5307
	internal class PtcG2C_AllGiftIBItemNtf : Protocol
	{
		// Token: 0x0600E7F6 RID: 59382 RVA: 0x00340BA8 File Offset: 0x0033EDA8
		public override uint GetProtoType()
		{
			return 2916U;
		}

		// Token: 0x0600E7F7 RID: 59383 RVA: 0x00340BBF File Offset: 0x0033EDBF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AllGiftIBItem>(stream, this.Data);
		}

		// Token: 0x0600E7F8 RID: 59384 RVA: 0x00340BCF File Offset: 0x0033EDCF
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<AllGiftIBItem>(stream);
		}

		// Token: 0x0600E7F9 RID: 59385 RVA: 0x00340BDE File Offset: 0x0033EDDE
		public override void Process()
		{
			Process_PtcG2C_AllGiftIBItemNtf.Process(this);
		}

		// Token: 0x040064C7 RID: 25799
		public AllGiftIBItem Data = new AllGiftIBItem();
	}
}
