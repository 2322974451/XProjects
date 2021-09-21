using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000F2 RID: 242
	[ProtoContract(Name = "TeleportNoticeState")]
	[Serializable]
	public class TeleportNoticeState : IExtensible
	{
		// Token: 0x17000504 RID: 1284
		// (get) Token: 0x06000F91 RID: 3985 RVA: 0x00020100 File Offset: 0x0001E300
		// (set) Token: 0x06000F92 RID: 3986 RVA: 0x0002012C File Offset: 0x0001E32C
		[ProtoMember(1, IsRequired = false, Name = "onnotice", DataFormat = DataFormat.Default)]
		public bool onnotice
		{
			get
			{
				return this._onnotice ?? false;
			}
			set
			{
				this._onnotice = new bool?(value);
			}
		}

		// Token: 0x17000505 RID: 1285
		// (get) Token: 0x06000F93 RID: 3987 RVA: 0x0002013C File Offset: 0x0001E33C
		// (set) Token: 0x06000F94 RID: 3988 RVA: 0x0002015C File Offset: 0x0001E35C
		[XmlIgnore]
		[Browsable(false)]
		public bool onnoticeSpecified
		{
			get
			{
				return this._onnotice != null;
			}
			set
			{
				bool flag = value == (this._onnotice == null);
				if (flag)
				{
					this._onnotice = (value ? new bool?(this.onnotice) : null);
				}
			}
		}

		// Token: 0x06000F95 RID: 3989 RVA: 0x000201A0 File Offset: 0x0001E3A0
		private bool ShouldSerializeonnotice()
		{
			return this.onnoticeSpecified;
		}

		// Token: 0x06000F96 RID: 3990 RVA: 0x000201B8 File Offset: 0x0001E3B8
		private void Resetonnotice()
		{
			this.onnoticeSpecified = false;
		}

		// Token: 0x06000F97 RID: 3991 RVA: 0x000201C4 File Offset: 0x0001E3C4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040003E3 RID: 995
		private bool? _onnotice;

		// Token: 0x040003E4 RID: 996
		private IExtension extensionObject;
	}
}
