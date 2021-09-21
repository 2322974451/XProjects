using System;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001D5 RID: 469
	[ProtoContract(Name = "StartRollNtfData")]
	[Serializable]
	public class StartRollNtfData : IExtensible
	{
		// Token: 0x17000890 RID: 2192
		// (get) Token: 0x06001B38 RID: 6968 RVA: 0x00035D10 File Offset: 0x00033F10
		// (set) Token: 0x06001B39 RID: 6969 RVA: 0x00035D28 File Offset: 0x00033F28
		[ProtoMember(1, IsRequired = false, Name = "info", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public EnemyDoodadInfo info
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

		// Token: 0x06001B3A RID: 6970 RVA: 0x00035D34 File Offset: 0x00033F34
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040006C7 RID: 1735
		private EnemyDoodadInfo _info = null;

		// Token: 0x040006C8 RID: 1736
		private IExtension extensionObject;
	}
}
