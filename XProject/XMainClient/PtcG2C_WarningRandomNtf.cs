using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020015B7 RID: 5559
	internal class PtcG2C_WarningRandomNtf : Protocol
	{
		// Token: 0x0600EC01 RID: 60417 RVA: 0x003467C0 File Offset: 0x003449C0
		public override uint GetProtoType()
		{
			return 8594U;
		}

		// Token: 0x0600EC02 RID: 60418 RVA: 0x003467D7 File Offset: 0x003449D7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<WarningRandomSet>(stream, this.Data);
		}

		// Token: 0x0600EC03 RID: 60419 RVA: 0x003467E7 File Offset: 0x003449E7
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<WarningRandomSet>(stream);
		}

		// Token: 0x0600EC04 RID: 60420 RVA: 0x003467F6 File Offset: 0x003449F6
		public override void Process()
		{
			Process_PtcG2C_WarningRandomNtf.Process(this);
		}

		// Token: 0x04006595 RID: 26005
		public WarningRandomSet Data = new WarningRandomSet();
	}
}
