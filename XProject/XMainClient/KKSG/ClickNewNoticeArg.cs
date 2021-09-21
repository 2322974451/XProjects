using System;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003A9 RID: 937
	[ProtoContract(Name = "ClickNewNoticeArg")]
	[Serializable]
	public class ClickNewNoticeArg : IExtensible
	{
		// Token: 0x17000F8D RID: 3981
		// (get) Token: 0x0600325F RID: 12895 RVA: 0x00060E8C File Offset: 0x0005F08C
		// (set) Token: 0x06003260 RID: 12896 RVA: 0x00060EA4 File Offset: 0x0005F0A4
		[ProtoMember(1, IsRequired = false, Name = "info", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PlatNotice info
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

		// Token: 0x06003261 RID: 12897 RVA: 0x00060EB0 File Offset: 0x0005F0B0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C85 RID: 3205
		private PlatNotice _info = null;

		// Token: 0x04000C86 RID: 3206
		private IExtension extensionObject;
	}
}
