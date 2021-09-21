using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001B0 RID: 432
	[ProtoContract(Name = "BuffList")]
	[Serializable]
	public class BuffList : IExtensible
	{
		// Token: 0x17000808 RID: 2056
		// (get) Token: 0x0600197A RID: 6522 RVA: 0x00032954 File Offset: 0x00030B54
		// (set) Token: 0x0600197B RID: 6523 RVA: 0x00032981 File Offset: 0x00030B81
		[ProtoMember(1, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17000809 RID: 2057
		// (get) Token: 0x0600197C RID: 6524 RVA: 0x00032990 File Offset: 0x00030B90
		// (set) Token: 0x0600197D RID: 6525 RVA: 0x000329B0 File Offset: 0x00030BB0
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

		// Token: 0x0600197E RID: 6526 RVA: 0x000329F4 File Offset: 0x00030BF4
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x0600197F RID: 6527 RVA: 0x00032A0C File Offset: 0x00030C0C
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x1700080A RID: 2058
		// (get) Token: 0x06001980 RID: 6528 RVA: 0x00032A18 File Offset: 0x00030C18
		[ProtoMember(2, Name = "buffs", DataFormat = DataFormat.Default)]
		public List<Buff> buffs
		{
			get
			{
				return this._buffs;
			}
		}

		// Token: 0x1700080B RID: 2059
		// (get) Token: 0x06001981 RID: 6529 RVA: 0x00032A30 File Offset: 0x00030C30
		// (set) Token: 0x06001982 RID: 6530 RVA: 0x00032A5D File Offset: 0x00030C5D
		[ProtoMember(3, IsRequired = false, Name = "casterid", DataFormat = DataFormat.TwosComplement)]
		public ulong casterid
		{
			get
			{
				return this._casterid ?? 0UL;
			}
			set
			{
				this._casterid = new ulong?(value);
			}
		}

		// Token: 0x1700080C RID: 2060
		// (get) Token: 0x06001983 RID: 6531 RVA: 0x00032A6C File Offset: 0x00030C6C
		// (set) Token: 0x06001984 RID: 6532 RVA: 0x00032A8C File Offset: 0x00030C8C
		[XmlIgnore]
		[Browsable(false)]
		public bool casteridSpecified
		{
			get
			{
				return this._casterid != null;
			}
			set
			{
				bool flag = value == (this._casterid == null);
				if (flag)
				{
					this._casterid = (value ? new ulong?(this.casterid) : null);
				}
			}
		}

		// Token: 0x06001985 RID: 6533 RVA: 0x00032AD0 File Offset: 0x00030CD0
		private bool ShouldSerializecasterid()
		{
			return this.casteridSpecified;
		}

		// Token: 0x06001986 RID: 6534 RVA: 0x00032AE8 File Offset: 0x00030CE8
		private void Resetcasterid()
		{
			this.casteridSpecified = false;
		}

		// Token: 0x06001987 RID: 6535 RVA: 0x00032AF4 File Offset: 0x00030CF4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000654 RID: 1620
		private ulong? _roleid;

		// Token: 0x04000655 RID: 1621
		private readonly List<Buff> _buffs = new List<Buff>();

		// Token: 0x04000656 RID: 1622
		private ulong? _casterid;

		// Token: 0x04000657 RID: 1623
		private IExtension extensionObject;
	}
}
