using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000657 RID: 1623
	[ProtoContract(Name = "RolePushInfo")]
	[Serializable]
	public class RolePushInfo : IExtensible
	{
		// Token: 0x17001FE2 RID: 8162
		// (get) Token: 0x0600650F RID: 25871 RVA: 0x000C0E80 File Offset: 0x000BF080
		[ProtoMember(1, Name = "infos", DataFormat = DataFormat.Default)]
		public List<PushInfo> infos
		{
			get
			{
				return this._infos;
			}
		}

		// Token: 0x17001FE3 RID: 8163
		// (get) Token: 0x06006510 RID: 25872 RVA: 0x000C0E98 File Offset: 0x000BF098
		[ProtoMember(2, Name = "configs", DataFormat = DataFormat.Default)]
		public List<PushConfig> configs
		{
			get
			{
				return this._configs;
			}
		}

		// Token: 0x06006511 RID: 25873 RVA: 0x000C0EB0 File Offset: 0x000BF0B0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001880 RID: 6272
		private readonly List<PushInfo> _infos = new List<PushInfo>();

		// Token: 0x04001881 RID: 6273
		private readonly List<PushConfig> _configs = new List<PushConfig>();

		// Token: 0x04001882 RID: 6274
		private IExtension extensionObject;
	}
}
