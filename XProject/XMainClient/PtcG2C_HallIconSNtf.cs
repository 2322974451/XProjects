using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020012C8 RID: 4808
	internal class PtcG2C_HallIconSNtf : Protocol
	{
		// Token: 0x0600E006 RID: 57350 RVA: 0x00335788 File Offset: 0x00333988
		public override uint GetProtoType()
		{
			return 17871U;
		}

		// Token: 0x0600E007 RID: 57351 RVA: 0x0033579F File Offset: 0x0033399F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<HallIconPara>(stream, this.Data);
		}

		// Token: 0x0600E008 RID: 57352 RVA: 0x003357AF File Offset: 0x003339AF
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<HallIconPara>(stream);
		}

		// Token: 0x0600E009 RID: 57353 RVA: 0x003357BE File Offset: 0x003339BE
		public override void Process()
		{
			Process_PtcG2C_HallIconSNtf.Process(this);
		}

		// Token: 0x04006346 RID: 25414
		public HallIconPara Data = new HallIconPara();
	}
}
