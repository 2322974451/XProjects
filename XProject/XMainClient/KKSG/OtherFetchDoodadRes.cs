using System;
using System.Collections.Generic;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000D9 RID: 217
	[ProtoContract(Name = "OtherFetchDoodadRes")]
	[Serializable]
	public class OtherFetchDoodadRes : IExtensible
	{
		// Token: 0x17000487 RID: 1159
		// (get) Token: 0x06000E01 RID: 3585 RVA: 0x0001D1E4 File Offset: 0x0001B3E4
		[ProtoMember(1, Name = "rollInfos", DataFormat = DataFormat.Default)]
		public List<RollInfo> rollInfos
		{
			get
			{
				return this._rollInfos;
			}
		}

		// Token: 0x17000488 RID: 1160
		// (get) Token: 0x06000E02 RID: 3586 RVA: 0x0001D1FC File Offset: 0x0001B3FC
		// (set) Token: 0x06000E03 RID: 3587 RVA: 0x0001D214 File Offset: 0x0001B414
		[ProtoMember(2, IsRequired = false, Name = "doodadInfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public EnemyDoodadInfo doodadInfo
		{
			get
			{
				return this._doodadInfo;
			}
			set
			{
				this._doodadInfo = value;
			}
		}

		// Token: 0x06000E04 RID: 3588 RVA: 0x0001D220 File Offset: 0x0001B420
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000384 RID: 900
		private readonly List<RollInfo> _rollInfos = new List<RollInfo>();

		// Token: 0x04000385 RID: 901
		private EnemyDoodadInfo _doodadInfo = null;

		// Token: 0x04000386 RID: 902
		private IExtension extensionObject;
	}
}
