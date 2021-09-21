using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005C8 RID: 1480
	[ProtoContract(Name = "RoleBriefInfo")]
	[Serializable]
	public class RoleBriefInfo : IExtensible
	{
		// Token: 0x170019C3 RID: 6595
		// (get) Token: 0x0600533F RID: 21311 RVA: 0x0009E5A8 File Offset: 0x0009C7A8
		// (set) Token: 0x06005340 RID: 21312 RVA: 0x0009E5D4 File Offset: 0x0009C7D4
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public RoleType type
		{
			get
			{
				return this._type ?? RoleType.Role_INVALID;
			}
			set
			{
				this._type = new RoleType?(value);
			}
		}

		// Token: 0x170019C4 RID: 6596
		// (get) Token: 0x06005341 RID: 21313 RVA: 0x0009E5E4 File Offset: 0x0009C7E4
		// (set) Token: 0x06005342 RID: 21314 RVA: 0x0009E604 File Offset: 0x0009C804
		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new RoleType?(this.type) : null);
				}
			}
		}

		// Token: 0x06005343 RID: 21315 RVA: 0x0009E648 File Offset: 0x0009C848
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06005344 RID: 21316 RVA: 0x0009E660 File Offset: 0x0009C860
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x170019C5 RID: 6597
		// (get) Token: 0x06005345 RID: 21317 RVA: 0x0009E66C File Offset: 0x0009C86C
		// (set) Token: 0x06005346 RID: 21318 RVA: 0x0009E699 File Offset: 0x0009C899
		[ProtoMember(2, IsRequired = false, Name = "roleID", DataFormat = DataFormat.TwosComplement)]
		public ulong roleID
		{
			get
			{
				return this._roleID ?? 0UL;
			}
			set
			{
				this._roleID = new ulong?(value);
			}
		}

		// Token: 0x170019C6 RID: 6598
		// (get) Token: 0x06005347 RID: 21319 RVA: 0x0009E6A8 File Offset: 0x0009C8A8
		// (set) Token: 0x06005348 RID: 21320 RVA: 0x0009E6C8 File Offset: 0x0009C8C8
		[XmlIgnore]
		[Browsable(false)]
		public bool roleIDSpecified
		{
			get
			{
				return this._roleID != null;
			}
			set
			{
				bool flag = value == (this._roleID == null);
				if (flag)
				{
					this._roleID = (value ? new ulong?(this.roleID) : null);
				}
			}
		}

		// Token: 0x06005349 RID: 21321 RVA: 0x0009E70C File Offset: 0x0009C90C
		private bool ShouldSerializeroleID()
		{
			return this.roleIDSpecified;
		}

		// Token: 0x0600534A RID: 21322 RVA: 0x0009E724 File Offset: 0x0009C924
		private void ResetroleID()
		{
			this.roleIDSpecified = false;
		}

		// Token: 0x170019C7 RID: 6599
		// (get) Token: 0x0600534B RID: 21323 RVA: 0x0009E730 File Offset: 0x0009C930
		// (set) Token: 0x0600534C RID: 21324 RVA: 0x0009E751 File Offset: 0x0009C951
		[ProtoMember(3, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
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

		// Token: 0x170019C8 RID: 6600
		// (get) Token: 0x0600534D RID: 21325 RVA: 0x0009E75C File Offset: 0x0009C95C
		// (set) Token: 0x0600534E RID: 21326 RVA: 0x0009E778 File Offset: 0x0009C978
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

		// Token: 0x0600534F RID: 21327 RVA: 0x0009E7A8 File Offset: 0x0009C9A8
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x06005350 RID: 21328 RVA: 0x0009E7C0 File Offset: 0x0009C9C0
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x170019C9 RID: 6601
		// (get) Token: 0x06005351 RID: 21329 RVA: 0x0009E7CC File Offset: 0x0009C9CC
		// (set) Token: 0x06005352 RID: 21330 RVA: 0x0009E7F8 File Offset: 0x0009C9F8
		[ProtoMember(4, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
		public int level
		{
			get
			{
				return this._level ?? 0;
			}
			set
			{
				this._level = new int?(value);
			}
		}

		// Token: 0x170019CA RID: 6602
		// (get) Token: 0x06005353 RID: 21331 RVA: 0x0009E808 File Offset: 0x0009CA08
		// (set) Token: 0x06005354 RID: 21332 RVA: 0x0009E828 File Offset: 0x0009CA28
		[XmlIgnore]
		[Browsable(false)]
		public bool levelSpecified
		{
			get
			{
				return this._level != null;
			}
			set
			{
				bool flag = value == (this._level == null);
				if (flag)
				{
					this._level = (value ? new int?(this.level) : null);
				}
			}
		}

		// Token: 0x06005355 RID: 21333 RVA: 0x0009E86C File Offset: 0x0009CA6C
		private bool ShouldSerializelevel()
		{
			return this.levelSpecified;
		}

		// Token: 0x06005356 RID: 21334 RVA: 0x0009E884 File Offset: 0x0009CA84
		private void Resetlevel()
		{
			this.levelSpecified = false;
		}

		// Token: 0x170019CB RID: 6603
		// (get) Token: 0x06005357 RID: 21335 RVA: 0x0009E890 File Offset: 0x0009CA90
		[ProtoMember(5, Name = "fashion", DataFormat = DataFormat.TwosComplement)]
		public List<uint> fashion
		{
			get
			{
				return this._fashion;
			}
		}

		// Token: 0x170019CC RID: 6604
		// (get) Token: 0x06005358 RID: 21336 RVA: 0x0009E8A8 File Offset: 0x0009CAA8
		// (set) Token: 0x06005359 RID: 21337 RVA: 0x0009E8C0 File Offset: 0x0009CAC0
		[ProtoMember(6, IsRequired = false, Name = "outlook", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public OutLook outlook
		{
			get
			{
				return this._outlook;
			}
			set
			{
				this._outlook = value;
			}
		}

		// Token: 0x170019CD RID: 6605
		// (get) Token: 0x0600535A RID: 21338 RVA: 0x0009E8CC File Offset: 0x0009CACC
		// (set) Token: 0x0600535B RID: 21339 RVA: 0x0009E8F8 File Offset: 0x0009CAF8
		[ProtoMember(7, IsRequired = false, Name = "ppt", DataFormat = DataFormat.TwosComplement)]
		public uint ppt
		{
			get
			{
				return this._ppt ?? 0U;
			}
			set
			{
				this._ppt = new uint?(value);
			}
		}

		// Token: 0x170019CE RID: 6606
		// (get) Token: 0x0600535C RID: 21340 RVA: 0x0009E908 File Offset: 0x0009CB08
		// (set) Token: 0x0600535D RID: 21341 RVA: 0x0009E928 File Offset: 0x0009CB28
		[XmlIgnore]
		[Browsable(false)]
		public bool pptSpecified
		{
			get
			{
				return this._ppt != null;
			}
			set
			{
				bool flag = value == (this._ppt == null);
				if (flag)
				{
					this._ppt = (value ? new uint?(this.ppt) : null);
				}
			}
		}

		// Token: 0x0600535E RID: 21342 RVA: 0x0009E96C File Offset: 0x0009CB6C
		private bool ShouldSerializeppt()
		{
			return this.pptSpecified;
		}

		// Token: 0x0600535F RID: 21343 RVA: 0x0009E984 File Offset: 0x0009CB84
		private void Resetppt()
		{
			this.pptSpecified = false;
		}

		// Token: 0x06005360 RID: 21344 RVA: 0x0009E990 File Offset: 0x0009CB90
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001458 RID: 5208
		private RoleType? _type;

		// Token: 0x04001459 RID: 5209
		private ulong? _roleID;

		// Token: 0x0400145A RID: 5210
		private string _name;

		// Token: 0x0400145B RID: 5211
		private int? _level;

		// Token: 0x0400145C RID: 5212
		private readonly List<uint> _fashion = new List<uint>();

		// Token: 0x0400145D RID: 5213
		private OutLook _outlook = null;

		// Token: 0x0400145E RID: 5214
		private uint? _ppt;

		// Token: 0x0400145F RID: 5215
		private IExtension extensionObject;
	}
}
