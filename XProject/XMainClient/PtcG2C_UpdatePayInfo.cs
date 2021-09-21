using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001047 RID: 4167
	internal class PtcG2C_UpdatePayInfo : Protocol
	{
		// Token: 0x0600D5D2 RID: 54738 RVA: 0x00325018 File Offset: 0x00323218
		public override uint GetProtoType()
		{
			return 22775U;
		}

		// Token: 0x0600D5D3 RID: 54739 RVA: 0x0032502F File Offset: 0x0032322F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PayInfo>(stream, this.Data);
		}

		// Token: 0x0600D5D4 RID: 54740 RVA: 0x0032503F File Offset: 0x0032323F
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<PayInfo>(stream);
		}

		// Token: 0x0600D5D5 RID: 54741 RVA: 0x0032504E File Offset: 0x0032324E
		public override void Process()
		{
			Process_PtcG2C_UpdatePayInfo.Process(this);
		}

		// Token: 0x04006154 RID: 24916
		public PayInfo Data = new PayInfo();
	}
}
