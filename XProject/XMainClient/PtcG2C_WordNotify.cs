using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001657 RID: 5719
	internal class PtcG2C_WordNotify : Protocol
	{
		// Token: 0x0600EEAA RID: 61098 RVA: 0x0034A1E8 File Offset: 0x003483E8
		public override uint GetProtoType()
		{
			return 34052U;
		}

		// Token: 0x0600EEAB RID: 61099 RVA: 0x0034A1FF File Offset: 0x003483FF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<WordNotify>(stream, this.Data);
		}

		// Token: 0x0600EEAC RID: 61100 RVA: 0x0034A20F File Offset: 0x0034840F
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<WordNotify>(stream);
		}

		// Token: 0x0600EEAD RID: 61101 RVA: 0x0034A21E File Offset: 0x0034841E
		public override void Process()
		{
			Process_PtcG2C_WordNotify.Process(this);
		}

		// Token: 0x04006620 RID: 26144
		public WordNotify Data = new WordNotify();
	}
}
