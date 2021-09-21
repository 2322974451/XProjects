using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200100A RID: 4106
	internal class PtcG2C_AttributeChangeNotify : Protocol
	{
		// Token: 0x0600D4D0 RID: 54480 RVA: 0x0032227C File Offset: 0x0032047C
		public override uint GetProtoType()
		{
			return 57626U;
		}

		// Token: 0x0600D4D1 RID: 54481 RVA: 0x00322293 File Offset: 0x00320493
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ChangedAttribute>(stream, this.Data);
		}

		// Token: 0x0600D4D2 RID: 54482 RVA: 0x003222A3 File Offset: 0x003204A3
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ChangedAttribute>(stream);
		}

		// Token: 0x0600D4D3 RID: 54483 RVA: 0x003222B2 File Offset: 0x003204B2
		public override void Process()
		{
			Process_PtcG2C_AttributeChangeNotify.Process(this);
		}

		// Token: 0x04006103 RID: 24835
		public ChangedAttribute Data = new ChangedAttribute();
	}
}
