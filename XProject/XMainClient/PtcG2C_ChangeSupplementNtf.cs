using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020010CB RID: 4299
	internal class PtcG2C_ChangeSupplementNtf : Protocol
	{
		// Token: 0x0600D7E4 RID: 55268 RVA: 0x00328C5C File Offset: 0x00326E5C
		public override uint GetProtoType()
		{
			return 11250U;
		}

		// Token: 0x0600D7E5 RID: 55269 RVA: 0x00328C73 File Offset: 0x00326E73
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ChangeSupplementNtf>(stream, this.Data);
		}

		// Token: 0x0600D7E6 RID: 55270 RVA: 0x00328C83 File Offset: 0x00326E83
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ChangeSupplementNtf>(stream);
		}

		// Token: 0x0600D7E7 RID: 55271 RVA: 0x00328C92 File Offset: 0x00326E92
		public override void Process()
		{
			Process_PtcG2C_ChangeSupplementNtf.Process(this);
		}

		// Token: 0x040061B9 RID: 25017
		public ChangeSupplementNtf Data = new ChangeSupplementNtf();
	}
}
