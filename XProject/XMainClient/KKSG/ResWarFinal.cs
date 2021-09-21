using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006C2 RID: 1730
	[ProtoContract(Name = "ResWarFinal")]
	[Serializable]
	public class ResWarFinal : IExtensible
	{
		// Token: 0x170023FA RID: 9210
		// (get) Token: 0x060071A8 RID: 29096 RVA: 0x000D9724 File Offset: 0x000D7924
		// (set) Token: 0x060071A9 RID: 29097 RVA: 0x000D9745 File Offset: 0x000D7945
		[ProtoMember(1, IsRequired = false, Name = "guildname", DataFormat = DataFormat.Default)]
		public string guildname
		{
			get
			{
				return this._guildname ?? "";
			}
			set
			{
				this._guildname = value;
			}
		}

		// Token: 0x170023FB RID: 9211
		// (get) Token: 0x060071AA RID: 29098 RVA: 0x000D9750 File Offset: 0x000D7950
		// (set) Token: 0x060071AB RID: 29099 RVA: 0x000D976C File Offset: 0x000D796C
		[XmlIgnore]
		[Browsable(false)]
		public bool guildnameSpecified
		{
			get
			{
				return this._guildname != null;
			}
			set
			{
				bool flag = value == (this._guildname == null);
				if (flag)
				{
					this._guildname = (value ? this.guildname : null);
				}
			}
		}

		// Token: 0x060071AC RID: 29100 RVA: 0x000D979C File Offset: 0x000D799C
		private bool ShouldSerializeguildname()
		{
			return this.guildnameSpecified;
		}

		// Token: 0x060071AD RID: 29101 RVA: 0x000D97B4 File Offset: 0x000D79B4
		private void Resetguildname()
		{
			this.guildnameSpecified = false;
		}

		// Token: 0x170023FC RID: 9212
		// (get) Token: 0x060071AE RID: 29102 RVA: 0x000D97C0 File Offset: 0x000D79C0
		// (set) Token: 0x060071AF RID: 29103 RVA: 0x000D97EC File Offset: 0x000D79EC
		[ProtoMember(2, IsRequired = false, Name = "res", DataFormat = DataFormat.TwosComplement)]
		public uint res
		{
			get
			{
				return this._res ?? 0U;
			}
			set
			{
				this._res = new uint?(value);
			}
		}

		// Token: 0x170023FD RID: 9213
		// (get) Token: 0x060071B0 RID: 29104 RVA: 0x000D97FC File Offset: 0x000D79FC
		// (set) Token: 0x060071B1 RID: 29105 RVA: 0x000D981C File Offset: 0x000D7A1C
		[XmlIgnore]
		[Browsable(false)]
		public bool resSpecified
		{
			get
			{
				return this._res != null;
			}
			set
			{
				bool flag = value == (this._res == null);
				if (flag)
				{
					this._res = (value ? new uint?(this.res) : null);
				}
			}
		}

		// Token: 0x060071B2 RID: 29106 RVA: 0x000D9860 File Offset: 0x000D7A60
		private bool ShouldSerializeres()
		{
			return this.resSpecified;
		}

		// Token: 0x060071B3 RID: 29107 RVA: 0x000D9878 File Offset: 0x000D7A78
		private void Resetres()
		{
			this.resSpecified = false;
		}

		// Token: 0x170023FE RID: 9214
		// (get) Token: 0x060071B4 RID: 29108 RVA: 0x000D9884 File Offset: 0x000D7A84
		[ProtoMember(3, Name = "brief", DataFormat = DataFormat.Default)]
		public List<ItemBrief> brief
		{
			get
			{
				return this._brief;
			}
		}

		// Token: 0x170023FF RID: 9215
		// (get) Token: 0x060071B5 RID: 29109 RVA: 0x000D989C File Offset: 0x000D7A9C
		// (set) Token: 0x060071B6 RID: 29110 RVA: 0x000D98C8 File Offset: 0x000D7AC8
		[ProtoMember(4, IsRequired = false, Name = "guildicon", DataFormat = DataFormat.TwosComplement)]
		public uint guildicon
		{
			get
			{
				return this._guildicon ?? 0U;
			}
			set
			{
				this._guildicon = new uint?(value);
			}
		}

		// Token: 0x17002400 RID: 9216
		// (get) Token: 0x060071B7 RID: 29111 RVA: 0x000D98D8 File Offset: 0x000D7AD8
		// (set) Token: 0x060071B8 RID: 29112 RVA: 0x000D98F8 File Offset: 0x000D7AF8
		[XmlIgnore]
		[Browsable(false)]
		public bool guildiconSpecified
		{
			get
			{
				return this._guildicon != null;
			}
			set
			{
				bool flag = value == (this._guildicon == null);
				if (flag)
				{
					this._guildicon = (value ? new uint?(this.guildicon) : null);
				}
			}
		}

		// Token: 0x060071B9 RID: 29113 RVA: 0x000D993C File Offset: 0x000D7B3C
		private bool ShouldSerializeguildicon()
		{
			return this.guildiconSpecified;
		}

		// Token: 0x060071BA RID: 29114 RVA: 0x000D9954 File Offset: 0x000D7B54
		private void Resetguildicon()
		{
			this.guildiconSpecified = false;
		}

		// Token: 0x17002401 RID: 9217
		// (get) Token: 0x060071BB RID: 29115 RVA: 0x000D9960 File Offset: 0x000D7B60
		// (set) Token: 0x060071BC RID: 29116 RVA: 0x000D998D File Offset: 0x000D7B8D
		[ProtoMember(5, IsRequired = false, Name = "guildid", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17002402 RID: 9218
		// (get) Token: 0x060071BD RID: 29117 RVA: 0x000D999C File Offset: 0x000D7B9C
		// (set) Token: 0x060071BE RID: 29118 RVA: 0x000D99BC File Offset: 0x000D7BBC
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

		// Token: 0x060071BF RID: 29119 RVA: 0x000D9A00 File Offset: 0x000D7C00
		private bool ShouldSerializeguildid()
		{
			return this.guildidSpecified;
		}

		// Token: 0x060071C0 RID: 29120 RVA: 0x000D9A18 File Offset: 0x000D7C18
		private void Resetguildid()
		{
			this.guildidSpecified = false;
		}

		// Token: 0x060071C1 RID: 29121 RVA: 0x000D9A24 File Offset: 0x000D7C24
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001B1E RID: 6942
		private string _guildname;

		// Token: 0x04001B1F RID: 6943
		private uint? _res;

		// Token: 0x04001B20 RID: 6944
		private readonly List<ItemBrief> _brief = new List<ItemBrief>();

		// Token: 0x04001B21 RID: 6945
		private uint? _guildicon;

		// Token: 0x04001B22 RID: 6946
		private ulong? _guildid;

		// Token: 0x04001B23 RID: 6947
		private IExtension extensionObject;
	}
}
