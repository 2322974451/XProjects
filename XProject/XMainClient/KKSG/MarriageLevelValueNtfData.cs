using System;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200054A RID: 1354
	[ProtoContract(Name = "MarriageLevelValueNtfData")]
	[Serializable]
	public class MarriageLevelValueNtfData : IExtensible
	{
		// Token: 0x17001526 RID: 5414
		// (get) Token: 0x06004536 RID: 17718 RVA: 0x00083998 File Offset: 0x00081B98
		// (set) Token: 0x06004537 RID: 17719 RVA: 0x000839B0 File Offset: 0x00081BB0
		[ProtoMember(1, IsRequired = false, Name = "info", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public MarriageLevelInfo info
		{
			get
			{
				return this._info;
			}
			set
			{
				this._info = value;
			}
		}

		// Token: 0x06004538 RID: 17720 RVA: 0x000839BC File Offset: 0x00081BBC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400114B RID: 4427
		private MarriageLevelInfo _info = null;

		// Token: 0x0400114C RID: 4428
		private IExtension extensionObject;
	}
}
