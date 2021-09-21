using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200123B RID: 4667
	internal class PtcG2C_ItemFindBackNtf : Protocol
	{
		// Token: 0x0600DDBB RID: 56763 RVA: 0x0033247C File Offset: 0x0033067C
		public override uint GetProtoType()
		{
			return 28509U;
		}

		// Token: 0x0600DDBC RID: 56764 RVA: 0x00332493 File Offset: 0x00330693
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ItemFindBackData>(stream, this.Data);
		}

		// Token: 0x0600DDBD RID: 56765 RVA: 0x003324A3 File Offset: 0x003306A3
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ItemFindBackData>(stream);
		}

		// Token: 0x0600DDBE RID: 56766 RVA: 0x003324B2 File Offset: 0x003306B2
		public override void Process()
		{
			Process_PtcG2C_ItemFindBackNtf.Process(this);
		}

		// Token: 0x040062D2 RID: 25298
		public ItemFindBackData Data = new ItemFindBackData();
	}
}
