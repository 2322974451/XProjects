using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005B4 RID: 1460
	[ProtoContract(Name = "ReceiveRoleFlowerInfo2Client")]
	[Serializable]
	public class ReceiveRoleFlowerInfo2Client : IExtensible
	{
		// Token: 0x170018C7 RID: 6343
		// (get) Token: 0x0600503E RID: 20542 RVA: 0x00098A00 File Offset: 0x00096C00
		// (set) Token: 0x0600503F RID: 20543 RVA: 0x00098A2D File Offset: 0x00096C2D
		[ProtoMember(1, IsRequired = false, Name = "roleID", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170018C8 RID: 6344
		// (get) Token: 0x06005040 RID: 20544 RVA: 0x00098A3C File Offset: 0x00096C3C
		// (set) Token: 0x06005041 RID: 20545 RVA: 0x00098A5C File Offset: 0x00096C5C
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

		// Token: 0x06005042 RID: 20546 RVA: 0x00098AA0 File Offset: 0x00096CA0
		private bool ShouldSerializeroleID()
		{
			return this.roleIDSpecified;
		}

		// Token: 0x06005043 RID: 20547 RVA: 0x00098AB8 File Offset: 0x00096CB8
		private void ResetroleID()
		{
			this.roleIDSpecified = false;
		}

		// Token: 0x170018C9 RID: 6345
		// (get) Token: 0x06005044 RID: 20548 RVA: 0x00098AC4 File Offset: 0x00096CC4
		// (set) Token: 0x06005045 RID: 20549 RVA: 0x00098AE5 File Offset: 0x00096CE5
		[ProtoMember(2, IsRequired = false, Name = "roleName", DataFormat = DataFormat.Default)]
		public string roleName
		{
			get
			{
				return this._roleName ?? "";
			}
			set
			{
				this._roleName = value;
			}
		}

		// Token: 0x170018CA RID: 6346
		// (get) Token: 0x06005046 RID: 20550 RVA: 0x00098AF0 File Offset: 0x00096CF0
		// (set) Token: 0x06005047 RID: 20551 RVA: 0x00098B0C File Offset: 0x00096D0C
		[XmlIgnore]
		[Browsable(false)]
		public bool roleNameSpecified
		{
			get
			{
				return this._roleName != null;
			}
			set
			{
				bool flag = value == (this._roleName == null);
				if (flag)
				{
					this._roleName = (value ? this.roleName : null);
				}
			}
		}

		// Token: 0x06005048 RID: 20552 RVA: 0x00098B3C File Offset: 0x00096D3C
		private bool ShouldSerializeroleName()
		{
			return this.roleNameSpecified;
		}

		// Token: 0x06005049 RID: 20553 RVA: 0x00098B54 File Offset: 0x00096D54
		private void ResetroleName()
		{
			this.roleNameSpecified = false;
		}

		// Token: 0x170018CB RID: 6347
		// (get) Token: 0x0600504A RID: 20554 RVA: 0x00098B60 File Offset: 0x00096D60
		[ProtoMember(3, Name = "flowers", DataFormat = DataFormat.Default)]
		public List<MapIntItem> flowers
		{
			get
			{
				return this._flowers;
			}
		}

		// Token: 0x0600504B RID: 20555 RVA: 0x00098B78 File Offset: 0x00096D78
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040013BE RID: 5054
		private ulong? _roleID;

		// Token: 0x040013BF RID: 5055
		private string _roleName;

		// Token: 0x040013C0 RID: 5056
		private readonly List<MapIntItem> _flowers = new List<MapIntItem>();

		// Token: 0x040013C1 RID: 5057
		private IExtension extensionObject;
	}
}
