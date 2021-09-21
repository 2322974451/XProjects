using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000170 RID: 368
	[ProtoContract(Name = "CreateRoleNewArg")]
	[Serializable]
	public class CreateRoleNewArg : IExtensible
	{
		// Token: 0x17000700 RID: 1792
		// (get) Token: 0x06001618 RID: 5656 RVA: 0x0002C4A4 File Offset: 0x0002A6A4
		// (set) Token: 0x06001619 RID: 5657 RVA: 0x0002C4D0 File Offset: 0x0002A6D0
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

		// Token: 0x17000701 RID: 1793
		// (get) Token: 0x0600161A RID: 5658 RVA: 0x0002C4E0 File Offset: 0x0002A6E0
		// (set) Token: 0x0600161B RID: 5659 RVA: 0x0002C500 File Offset: 0x0002A700
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

		// Token: 0x0600161C RID: 5660 RVA: 0x0002C544 File Offset: 0x0002A744
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x0600161D RID: 5661 RVA: 0x0002C55C File Offset: 0x0002A75C
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x17000702 RID: 1794
		// (get) Token: 0x0600161E RID: 5662 RVA: 0x0002C568 File Offset: 0x0002A768
		// (set) Token: 0x0600161F RID: 5663 RVA: 0x0002C589 File Offset: 0x0002A789
		[ProtoMember(2, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
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

		// Token: 0x17000703 RID: 1795
		// (get) Token: 0x06001620 RID: 5664 RVA: 0x0002C594 File Offset: 0x0002A794
		// (set) Token: 0x06001621 RID: 5665 RVA: 0x0002C5B0 File Offset: 0x0002A7B0
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

		// Token: 0x06001622 RID: 5666 RVA: 0x0002C5E0 File Offset: 0x0002A7E0
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x06001623 RID: 5667 RVA: 0x0002C5F8 File Offset: 0x0002A7F8
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x06001624 RID: 5668 RVA: 0x0002C604 File Offset: 0x0002A804
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400057D RID: 1405
		private RoleType? _type;

		// Token: 0x0400057E RID: 1406
		private string _name;

		// Token: 0x0400057F RID: 1407
		private IExtension extensionObject;
	}
}
