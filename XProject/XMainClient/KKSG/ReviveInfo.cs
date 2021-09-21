using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000062 RID: 98
	[ProtoContract(Name = "ReviveInfo")]
	[Serializable]
	public class ReviveInfo : IExtensible
	{
		// Token: 0x17000228 RID: 552
		// (get) Token: 0x060006A0 RID: 1696 RVA: 0x0000F5E0 File Offset: 0x0000D7E0
		// (set) Token: 0x060006A1 RID: 1697 RVA: 0x0000F60D File Offset: 0x0000D80D
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

		// Token: 0x17000229 RID: 553
		// (get) Token: 0x060006A2 RID: 1698 RVA: 0x0000F61C File Offset: 0x0000D81C
		// (set) Token: 0x060006A3 RID: 1699 RVA: 0x0000F63C File Offset: 0x0000D83C
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

		// Token: 0x060006A4 RID: 1700 RVA: 0x0000F680 File Offset: 0x0000D880
		private bool ShouldSerializeroleID()
		{
			return this.roleIDSpecified;
		}

		// Token: 0x060006A5 RID: 1701 RVA: 0x0000F698 File Offset: 0x0000D898
		private void ResetroleID()
		{
			this.roleIDSpecified = false;
		}

		// Token: 0x1700022A RID: 554
		// (get) Token: 0x060006A6 RID: 1702 RVA: 0x0000F6A4 File Offset: 0x0000D8A4
		[ProtoMember(2, Name = "bufflist", DataFormat = DataFormat.TwosComplement)]
		public List<uint> bufflist
		{
			get
			{
				return this._bufflist;
			}
		}

		// Token: 0x1700022B RID: 555
		// (get) Token: 0x060006A7 RID: 1703 RVA: 0x0000F6BC File Offset: 0x0000D8BC
		// (set) Token: 0x060006A8 RID: 1704 RVA: 0x0000F6E8 File Offset: 0x0000D8E8
		[ProtoMember(3, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public ReviveType type
		{
			get
			{
				return this._type ?? ReviveType.ReviveNone;
			}
			set
			{
				this._type = new ReviveType?(value);
			}
		}

		// Token: 0x1700022C RID: 556
		// (get) Token: 0x060006A9 RID: 1705 RVA: 0x0000F6F8 File Offset: 0x0000D8F8
		// (set) Token: 0x060006AA RID: 1706 RVA: 0x0000F718 File Offset: 0x0000D918
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
					this._type = (value ? new ReviveType?(this.type) : null);
				}
			}
		}

		// Token: 0x060006AB RID: 1707 RVA: 0x0000F75C File Offset: 0x0000D95C
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x060006AC RID: 1708 RVA: 0x0000F774 File Offset: 0x0000D974
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x060006AD RID: 1709 RVA: 0x0000F780 File Offset: 0x0000D980
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040001AE RID: 430
		private ulong? _roleID;

		// Token: 0x040001AF RID: 431
		private readonly List<uint> _bufflist = new List<uint>();

		// Token: 0x040001B0 RID: 432
		private ReviveType? _type;

		// Token: 0x040001B1 RID: 433
		private IExtension extensionObject;
	}
}
