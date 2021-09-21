using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005B3 RID: 1459
	[ProtoContract(Name = "FlowerInfo2Client")]
	[Serializable]
	public class FlowerInfo2Client : IExtensible
	{
		// Token: 0x170018BD RID: 6333
		// (get) Token: 0x0600501E RID: 20510 RVA: 0x00098620 File Offset: 0x00096820
		// (set) Token: 0x0600501F RID: 20511 RVA: 0x0009864D File Offset: 0x0009684D
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

		// Token: 0x170018BE RID: 6334
		// (get) Token: 0x06005020 RID: 20512 RVA: 0x0009865C File Offset: 0x0009685C
		// (set) Token: 0x06005021 RID: 20513 RVA: 0x0009867C File Offset: 0x0009687C
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

		// Token: 0x06005022 RID: 20514 RVA: 0x000986C0 File Offset: 0x000968C0
		private bool ShouldSerializeroleID()
		{
			return this.roleIDSpecified;
		}

		// Token: 0x06005023 RID: 20515 RVA: 0x000986D8 File Offset: 0x000968D8
		private void ResetroleID()
		{
			this.roleIDSpecified = false;
		}

		// Token: 0x170018BF RID: 6335
		// (get) Token: 0x06005024 RID: 20516 RVA: 0x000986E4 File Offset: 0x000968E4
		// (set) Token: 0x06005025 RID: 20517 RVA: 0x00098710 File Offset: 0x00096910
		[ProtoMember(2, IsRequired = false, Name = "itemID", DataFormat = DataFormat.TwosComplement)]
		public uint itemID
		{
			get
			{
				return this._itemID ?? 0U;
			}
			set
			{
				this._itemID = new uint?(value);
			}
		}

		// Token: 0x170018C0 RID: 6336
		// (get) Token: 0x06005026 RID: 20518 RVA: 0x00098720 File Offset: 0x00096920
		// (set) Token: 0x06005027 RID: 20519 RVA: 0x00098740 File Offset: 0x00096940
		[XmlIgnore]
		[Browsable(false)]
		public bool itemIDSpecified
		{
			get
			{
				return this._itemID != null;
			}
			set
			{
				bool flag = value == (this._itemID == null);
				if (flag)
				{
					this._itemID = (value ? new uint?(this.itemID) : null);
				}
			}
		}

		// Token: 0x06005028 RID: 20520 RVA: 0x00098784 File Offset: 0x00096984
		private bool ShouldSerializeitemID()
		{
			return this.itemIDSpecified;
		}

		// Token: 0x06005029 RID: 20521 RVA: 0x0009879C File Offset: 0x0009699C
		private void ResetitemID()
		{
			this.itemIDSpecified = false;
		}

		// Token: 0x170018C1 RID: 6337
		// (get) Token: 0x0600502A RID: 20522 RVA: 0x000987A8 File Offset: 0x000969A8
		// (set) Token: 0x0600502B RID: 20523 RVA: 0x000987D4 File Offset: 0x000969D4
		[ProtoMember(3, IsRequired = false, Name = "count", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170018C2 RID: 6338
		// (get) Token: 0x0600502C RID: 20524 RVA: 0x000987E4 File Offset: 0x000969E4
		// (set) Token: 0x0600502D RID: 20525 RVA: 0x00098804 File Offset: 0x00096A04
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

		// Token: 0x0600502E RID: 20526 RVA: 0x00098848 File Offset: 0x00096A48
		private bool ShouldSerializecount()
		{
			return this.countSpecified;
		}

		// Token: 0x0600502F RID: 20527 RVA: 0x00098860 File Offset: 0x00096A60
		private void Resetcount()
		{
			this.countSpecified = false;
		}

		// Token: 0x170018C3 RID: 6339
		// (get) Token: 0x06005030 RID: 20528 RVA: 0x0009886C File Offset: 0x00096A6C
		// (set) Token: 0x06005031 RID: 20529 RVA: 0x00098898 File Offset: 0x00096A98
		[ProtoMember(4, IsRequired = false, Name = "timestamp", DataFormat = DataFormat.TwosComplement)]
		public uint timestamp
		{
			get
			{
				return this._timestamp ?? 0U;
			}
			set
			{
				this._timestamp = new uint?(value);
			}
		}

		// Token: 0x170018C4 RID: 6340
		// (get) Token: 0x06005032 RID: 20530 RVA: 0x000988A8 File Offset: 0x00096AA8
		// (set) Token: 0x06005033 RID: 20531 RVA: 0x000988C8 File Offset: 0x00096AC8
		[XmlIgnore]
		[Browsable(false)]
		public bool timestampSpecified
		{
			get
			{
				return this._timestamp != null;
			}
			set
			{
				bool flag = value == (this._timestamp == null);
				if (flag)
				{
					this._timestamp = (value ? new uint?(this.timestamp) : null);
				}
			}
		}

		// Token: 0x06005034 RID: 20532 RVA: 0x0009890C File Offset: 0x00096B0C
		private bool ShouldSerializetimestamp()
		{
			return this.timestampSpecified;
		}

		// Token: 0x06005035 RID: 20533 RVA: 0x00098924 File Offset: 0x00096B24
		private void Resettimestamp()
		{
			this.timestampSpecified = false;
		}

		// Token: 0x170018C5 RID: 6341
		// (get) Token: 0x06005036 RID: 20534 RVA: 0x00098930 File Offset: 0x00096B30
		// (set) Token: 0x06005037 RID: 20535 RVA: 0x00098951 File Offset: 0x00096B51
		[ProtoMember(5, IsRequired = false, Name = "roleName", DataFormat = DataFormat.Default)]
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

		// Token: 0x170018C6 RID: 6342
		// (get) Token: 0x06005038 RID: 20536 RVA: 0x0009895C File Offset: 0x00096B5C
		// (set) Token: 0x06005039 RID: 20537 RVA: 0x00098978 File Offset: 0x00096B78
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

		// Token: 0x0600503A RID: 20538 RVA: 0x000989A8 File Offset: 0x00096BA8
		private bool ShouldSerializeroleName()
		{
			return this.roleNameSpecified;
		}

		// Token: 0x0600503B RID: 20539 RVA: 0x000989C0 File Offset: 0x00096BC0
		private void ResetroleName()
		{
			this.roleNameSpecified = false;
		}

		// Token: 0x0600503C RID: 20540 RVA: 0x000989CC File Offset: 0x00096BCC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040013B8 RID: 5048
		private ulong? _roleID;

		// Token: 0x040013B9 RID: 5049
		private uint? _itemID;

		// Token: 0x040013BA RID: 5050
		private uint? _count;

		// Token: 0x040013BB RID: 5051
		private uint? _timestamp;

		// Token: 0x040013BC RID: 5052
		private string _roleName;

		// Token: 0x040013BD RID: 5053
		private IExtension extensionObject;
	}
}
