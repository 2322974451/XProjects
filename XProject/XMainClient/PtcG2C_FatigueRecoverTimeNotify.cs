using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001063 RID: 4195
	internal class PtcG2C_FatigueRecoverTimeNotify : Protocol
	{
		// Token: 0x0600D645 RID: 54853 RVA: 0x00325E10 File Offset: 0x00324010
		public override uint GetProtoType()
		{
			return 14296U;
		}

		// Token: 0x0600D646 RID: 54854 RVA: 0x00325E27 File Offset: 0x00324027
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<FatigueRecoverTimeInfo>(stream, this.Data);
		}

		// Token: 0x0600D647 RID: 54855 RVA: 0x00325E37 File Offset: 0x00324037
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<FatigueRecoverTimeInfo>(stream);
		}

		// Token: 0x0600D648 RID: 54856 RVA: 0x00325E46 File Offset: 0x00324046
		public override void Process()
		{
			Process_PtcG2C_FatigueRecoverTimeNotify.Process(this);
		}

		// Token: 0x04006170 RID: 24944
		public FatigueRecoverTimeInfo Data = new FatigueRecoverTimeInfo();
	}
}
