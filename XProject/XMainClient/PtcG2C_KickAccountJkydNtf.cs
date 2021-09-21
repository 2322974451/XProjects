using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001663 RID: 5731
	internal class PtcG2C_KickAccountJkydNtf : Protocol
	{
		// Token: 0x0600EED8 RID: 61144 RVA: 0x0034A598 File Offset: 0x00348798
		public override uint GetProtoType()
		{
			return 39286U;
		}

		// Token: 0x0600EED9 RID: 61145 RVA: 0x0034A5AF File Offset: 0x003487AF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<KickAccountJkydMsg>(stream, this.Data);
		}

		// Token: 0x0600EEDA RID: 61146 RVA: 0x0034A5BF File Offset: 0x003487BF
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<KickAccountJkydMsg>(stream);
		}

		// Token: 0x0600EEDB RID: 61147 RVA: 0x0034A5CE File Offset: 0x003487CE
		public override void Process()
		{
			Process_PtcG2C_KickAccountJkydNtf.Process(this);
		}

		// Token: 0x04006628 RID: 26152
		public KickAccountJkydMsg Data = new KickAccountJkydMsg();
	}
}
