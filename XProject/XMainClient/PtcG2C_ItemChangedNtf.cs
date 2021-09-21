using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001010 RID: 4112
	internal class PtcG2C_ItemChangedNtf : Protocol
	{
		// Token: 0x0600D4E7 RID: 54503 RVA: 0x003226A0 File Offset: 0x003208A0
		public override uint GetProtoType()
		{
			return 20270U;
		}

		// Token: 0x0600D4E8 RID: 54504 RVA: 0x003226B7 File Offset: 0x003208B7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ItemChanged>(stream, this.Data);
		}

		// Token: 0x0600D4E9 RID: 54505 RVA: 0x003226C7 File Offset: 0x003208C7
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ItemChanged>(stream);
		}

		// Token: 0x0600D4EA RID: 54506 RVA: 0x003226D6 File Offset: 0x003208D6
		public override void Process()
		{
			Process_PtcG2C_ItemChangedNtf.Process(this);
		}

		// Token: 0x04006107 RID: 24839
		public ItemChanged Data = new ItemChanged();
	}
}
