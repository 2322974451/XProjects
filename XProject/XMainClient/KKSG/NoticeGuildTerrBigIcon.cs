using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003B5 RID: 949
	[ProtoContract(Name = "NoticeGuildTerrBigIcon")]
	[Serializable]
	public class NoticeGuildTerrBigIcon : IExtensible
	{
		// Token: 0x17000FA0 RID: 4000
		// (get) Token: 0x060032AC RID: 12972 RVA: 0x000616B0 File Offset: 0x0005F8B0
		// (set) Token: 0x060032AD RID: 12973 RVA: 0x000616DC File Offset: 0x0005F8DC
		[ProtoMember(1, IsRequired = false, Name = "isnow", DataFormat = DataFormat.Default)]
		public bool isnow
		{
			get
			{
				return this._isnow ?? false;
			}
			set
			{
				this._isnow = new bool?(value);
			}
		}

		// Token: 0x17000FA1 RID: 4001
		// (get) Token: 0x060032AE RID: 12974 RVA: 0x000616EC File Offset: 0x0005F8EC
		// (set) Token: 0x060032AF RID: 12975 RVA: 0x0006170C File Offset: 0x0005F90C
		[XmlIgnore]
		[Browsable(false)]
		public bool isnowSpecified
		{
			get
			{
				return this._isnow != null;
			}
			set
			{
				bool flag = value == (this._isnow == null);
				if (flag)
				{
					this._isnow = (value ? new bool?(this.isnow) : null);
				}
			}
		}

		// Token: 0x060032B0 RID: 12976 RVA: 0x00061750 File Offset: 0x0005F950
		private bool ShouldSerializeisnow()
		{
			return this.isnowSpecified;
		}

		// Token: 0x060032B1 RID: 12977 RVA: 0x00061768 File Offset: 0x0005F968
		private void Resetisnow()
		{
			this.isnowSpecified = false;
		}

		// Token: 0x060032B2 RID: 12978 RVA: 0x00061774 File Offset: 0x0005F974
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C9C RID: 3228
		private bool? _isnow;

		// Token: 0x04000C9D RID: 3229
		private IExtension extensionObject;
	}
}
