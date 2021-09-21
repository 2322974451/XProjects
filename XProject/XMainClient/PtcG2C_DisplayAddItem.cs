using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200150E RID: 5390
	internal class PtcG2C_DisplayAddItem : Protocol
	{
		// Token: 0x0600E951 RID: 59729 RVA: 0x003428A0 File Offset: 0x00340AA0
		public override uint GetProtoType()
		{
			return 55159U;
		}

		// Token: 0x0600E952 RID: 59730 RVA: 0x003428B7 File Offset: 0x00340AB7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<DisplayAddItemArg>(stream, this.Data);
		}

		// Token: 0x0600E953 RID: 59731 RVA: 0x003428C7 File Offset: 0x00340AC7
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<DisplayAddItemArg>(stream);
		}

		// Token: 0x0600E954 RID: 59732 RVA: 0x003428D6 File Offset: 0x00340AD6
		public override void Process()
		{
			Process_PtcG2C_DisplayAddItem.Process(this);
		}

		// Token: 0x0400650C RID: 25868
		public DisplayAddItemArg Data = new DisplayAddItemArg();
	}
}
