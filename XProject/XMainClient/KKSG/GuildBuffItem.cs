using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006BC RID: 1724
	[ProtoContract(Name = "GuildBuffItem")]
	[Serializable]
	public class GuildBuffItem : IExtensible
	{
		// Token: 0x170023E0 RID: 9184
		// (get) Token: 0x06007152 RID: 29010 RVA: 0x000D8CF0 File Offset: 0x000D6EF0
		// (set) Token: 0x06007153 RID: 29011 RVA: 0x000D8D1C File Offset: 0x000D6F1C
		[ProtoMember(1, IsRequired = false, Name = "itemid", DataFormat = DataFormat.TwosComplement)]
		public uint itemid
		{
			get
			{
				return this._itemid ?? 0U;
			}
			set
			{
				this._itemid = new uint?(value);
			}
		}

		// Token: 0x170023E1 RID: 9185
		// (get) Token: 0x06007154 RID: 29012 RVA: 0x000D8D2C File Offset: 0x000D6F2C
		// (set) Token: 0x06007155 RID: 29013 RVA: 0x000D8D4C File Offset: 0x000D6F4C
		[XmlIgnore]
		[Browsable(false)]
		public bool itemidSpecified
		{
			get
			{
				return this._itemid != null;
			}
			set
			{
				bool flag = value == (this._itemid == null);
				if (flag)
				{
					this._itemid = (value ? new uint?(this.itemid) : null);
				}
			}
		}

		// Token: 0x06007156 RID: 29014 RVA: 0x000D8D90 File Offset: 0x000D6F90
		private bool ShouldSerializeitemid()
		{
			return this.itemidSpecified;
		}

		// Token: 0x06007157 RID: 29015 RVA: 0x000D8DA8 File Offset: 0x000D6FA8
		private void Resetitemid()
		{
			this.itemidSpecified = false;
		}

		// Token: 0x170023E2 RID: 9186
		// (get) Token: 0x06007158 RID: 29016 RVA: 0x000D8DB4 File Offset: 0x000D6FB4
		// (set) Token: 0x06007159 RID: 29017 RVA: 0x000D8DE0 File Offset: 0x000D6FE0
		[ProtoMember(2, IsRequired = false, Name = "count", DataFormat = DataFormat.TwosComplement)]
		public uint count
		{
			get
			{
				return this._count ?? 0U;
			}
			set
			{
				this._count = new uint?(value);
			}
		}

		// Token: 0x170023E3 RID: 9187
		// (get) Token: 0x0600715A RID: 29018 RVA: 0x000D8DF0 File Offset: 0x000D6FF0
		// (set) Token: 0x0600715B RID: 29019 RVA: 0x000D8E10 File Offset: 0x000D7010
		[XmlIgnore]
		[Browsable(false)]
		public bool countSpecified
		{
			get
			{
				return this._count != null;
			}
			set
			{
				bool flag = value == (this._count == null);
				if (flag)
				{
					this._count = (value ? new uint?(this.count) : null);
				}
			}
		}

		// Token: 0x0600715C RID: 29020 RVA: 0x000D8E54 File Offset: 0x000D7054
		private bool ShouldSerializecount()
		{
			return this.countSpecified;
		}

		// Token: 0x0600715D RID: 29021 RVA: 0x000D8E6C File Offset: 0x000D706C
		private void Resetcount()
		{
			this.countSpecified = false;
		}

		// Token: 0x170023E4 RID: 9188
		// (get) Token: 0x0600715E RID: 29022 RVA: 0x000D8E78 File Offset: 0x000D7078
		// (set) Token: 0x0600715F RID: 29023 RVA: 0x000D8EA5 File Offset: 0x000D70A5
		[ProtoMember(3, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
		public ulong roleid
		{
			get
			{
				return this._roleid ?? 0UL;
			}
			set
			{
				this._roleid = new ulong?(value);
			}
		}

		// Token: 0x170023E5 RID: 9189
		// (get) Token: 0x06007160 RID: 29024 RVA: 0x000D8EB4 File Offset: 0x000D70B4
		// (set) Token: 0x06007161 RID: 29025 RVA: 0x000D8ED4 File Offset: 0x000D70D4
		[XmlIgnore]
		[Browsable(false)]
		public bool roleidSpecified
		{
			get
			{
				return this._roleid != null;
			}
			set
			{
				bool flag = value == (this._roleid == null);
				if (flag)
				{
					this._roleid = (value ? new ulong?(this.roleid) : null);
				}
			}
		}

		// Token: 0x06007162 RID: 29026 RVA: 0x000D8F18 File Offset: 0x000D7118
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06007163 RID: 29027 RVA: 0x000D8F30 File Offset: 0x000D7130
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x06007164 RID: 29028 RVA: 0x000D8F3C File Offset: 0x000D713C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001B0A RID: 6922
		private uint? _itemid;

		// Token: 0x04001B0B RID: 6923
		private uint? _count;

		// Token: 0x04001B0C RID: 6924
		private ulong? _roleid;

		// Token: 0x04001B0D RID: 6925
		private IExtension extensionObject;
	}
}
