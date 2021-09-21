using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006FF RID: 1791
	[ProtoContract(Name = "TerrData")]
	[Serializable]
	public class TerrData : IExtensible
	{
		// Token: 0x1700265B RID: 9819
		// (get) Token: 0x06007916 RID: 30998 RVA: 0x000E78D8 File Offset: 0x000E5AD8
		// (set) Token: 0x06007917 RID: 30999 RVA: 0x000E7904 File Offset: 0x000E5B04
		[ProtoMember(1, IsRequired = false, Name = "id", DataFormat = DataFormat.TwosComplement)]
		public uint id
		{
			get
			{
				return this._id ?? 0U;
			}
			set
			{
				this._id = new uint?(value);
			}
		}

		// Token: 0x1700265C RID: 9820
		// (get) Token: 0x06007918 RID: 31000 RVA: 0x000E7914 File Offset: 0x000E5B14
		// (set) Token: 0x06007919 RID: 31001 RVA: 0x000E7934 File Offset: 0x000E5B34
		[XmlIgnore]
		[Browsable(false)]
		public bool idSpecified
		{
			get
			{
				return this._id != null;
			}
			set
			{
				bool flag = value == (this._id == null);
				if (flag)
				{
					this._id = (value ? new uint?(this.id) : null);
				}
			}
		}

		// Token: 0x0600791A RID: 31002 RVA: 0x000E7978 File Offset: 0x000E5B78
		private bool ShouldSerializeid()
		{
			return this.idSpecified;
		}

		// Token: 0x0600791B RID: 31003 RVA: 0x000E7990 File Offset: 0x000E5B90
		private void Resetid()
		{
			this.idSpecified = false;
		}

		// Token: 0x1700265D RID: 9821
		// (get) Token: 0x0600791C RID: 31004 RVA: 0x000E799C File Offset: 0x000E5B9C
		// (set) Token: 0x0600791D RID: 31005 RVA: 0x000E79C9 File Offset: 0x000E5BC9
		[ProtoMember(2, IsRequired = false, Name = "guildid", DataFormat = DataFormat.TwosComplement)]
		public ulong guildid
		{
			get
			{
				return this._guildid ?? 0UL;
			}
			set
			{
				this._guildid = new ulong?(value);
			}
		}

		// Token: 0x1700265E RID: 9822
		// (get) Token: 0x0600791E RID: 31006 RVA: 0x000E79D8 File Offset: 0x000E5BD8
		// (set) Token: 0x0600791F RID: 31007 RVA: 0x000E79F8 File Offset: 0x000E5BF8
		[XmlIgnore]
		[Browsable(false)]
		public bool guildidSpecified
		{
			get
			{
				return this._guildid != null;
			}
			set
			{
				bool flag = value == (this._guildid == null);
				if (flag)
				{
					this._guildid = (value ? new ulong?(this.guildid) : null);
				}
			}
		}

		// Token: 0x06007920 RID: 31008 RVA: 0x000E7A3C File Offset: 0x000E5C3C
		private bool ShouldSerializeguildid()
		{
			return this.guildidSpecified;
		}

		// Token: 0x06007921 RID: 31009 RVA: 0x000E7A54 File Offset: 0x000E5C54
		private void Resetguildid()
		{
			this.guildidSpecified = false;
		}

		// Token: 0x1700265F RID: 9823
		// (get) Token: 0x06007922 RID: 31010 RVA: 0x000E7A60 File Offset: 0x000E5C60
		// (set) Token: 0x06007923 RID: 31011 RVA: 0x000E7A8C File Offset: 0x000E5C8C
		[ProtoMember(3, IsRequired = false, Name = "icon", DataFormat = DataFormat.TwosComplement)]
		public uint icon
		{
			get
			{
				return this._icon ?? 0U;
			}
			set
			{
				this._icon = new uint?(value);
			}
		}

		// Token: 0x17002660 RID: 9824
		// (get) Token: 0x06007924 RID: 31012 RVA: 0x000E7A9C File Offset: 0x000E5C9C
		// (set) Token: 0x06007925 RID: 31013 RVA: 0x000E7ABC File Offset: 0x000E5CBC
		[XmlIgnore]
		[Browsable(false)]
		public bool iconSpecified
		{
			get
			{
				return this._icon != null;
			}
			set
			{
				bool flag = value == (this._icon == null);
				if (flag)
				{
					this._icon = (value ? new uint?(this.icon) : null);
				}
			}
		}

		// Token: 0x06007926 RID: 31014 RVA: 0x000E7B00 File Offset: 0x000E5D00
		private bool ShouldSerializeicon()
		{
			return this.iconSpecified;
		}

		// Token: 0x06007927 RID: 31015 RVA: 0x000E7B18 File Offset: 0x000E5D18
		private void Reseticon()
		{
			this.iconSpecified = false;
		}

		// Token: 0x17002661 RID: 9825
		// (get) Token: 0x06007928 RID: 31016 RVA: 0x000E7B24 File Offset: 0x000E5D24
		// (set) Token: 0x06007929 RID: 31017 RVA: 0x000E7B45 File Offset: 0x000E5D45
		[ProtoMember(4, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
		public string name
		{
			get
			{
				return this._name ?? "";
			}
			set
			{
				this._name = value;
			}
		}

		// Token: 0x17002662 RID: 9826
		// (get) Token: 0x0600792A RID: 31018 RVA: 0x000E7B50 File Offset: 0x000E5D50
		// (set) Token: 0x0600792B RID: 31019 RVA: 0x000E7B6C File Offset: 0x000E5D6C
		[XmlIgnore]
		[Browsable(false)]
		public bool nameSpecified
		{
			get
			{
				return this._name != null;
			}
			set
			{
				bool flag = value == (this._name == null);
				if (flag)
				{
					this._name = (value ? this.name : null);
				}
			}
		}

		// Token: 0x0600792C RID: 31020 RVA: 0x000E7B9C File Offset: 0x000E5D9C
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x0600792D RID: 31021 RVA: 0x000E7BB4 File Offset: 0x000E5DB4
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x0600792E RID: 31022 RVA: 0x000E7BC0 File Offset: 0x000E5DC0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001C9B RID: 7323
		private uint? _id;

		// Token: 0x04001C9C RID: 7324
		private ulong? _guildid;

		// Token: 0x04001C9D RID: 7325
		private uint? _icon;

		// Token: 0x04001C9E RID: 7326
		private string _name;

		// Token: 0x04001C9F RID: 7327
		private IExtension extensionObject;
	}
}
