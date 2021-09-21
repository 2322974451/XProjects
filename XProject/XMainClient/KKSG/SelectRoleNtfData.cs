using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000177 RID: 375
	[ProtoContract(Name = "SelectRoleNtfData")]
	[Serializable]
	public class SelectRoleNtfData : IExtensible
	{
		// Token: 0x1700071C RID: 1820
		// (get) Token: 0x06001677 RID: 5751 RVA: 0x0002CF98 File Offset: 0x0002B198
		// (set) Token: 0x06001678 RID: 5752 RVA: 0x0002CFB0 File Offset: 0x0002B1B0
		[ProtoMember(1, IsRequired = false, Name = "roleData", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public RoleAllInfo roleData
		{
			get
			{
				return this._roleData;
			}
			set
			{
				this._roleData = value;
			}
		}

		// Token: 0x1700071D RID: 1821
		// (get) Token: 0x06001679 RID: 5753 RVA: 0x0002CFBC File Offset: 0x0002B1BC
		// (set) Token: 0x0600167A RID: 5754 RVA: 0x0002CFE8 File Offset: 0x0002B1E8
		[ProtoMember(2, IsRequired = false, Name = "serverid", DataFormat = DataFormat.TwosComplement)]
		public uint serverid
		{
			get
			{
				return this._serverid ?? 0U;
			}
			set
			{
				this._serverid = new uint?(value);
			}
		}

		// Token: 0x1700071E RID: 1822
		// (get) Token: 0x0600167B RID: 5755 RVA: 0x0002CFF8 File Offset: 0x0002B1F8
		// (set) Token: 0x0600167C RID: 5756 RVA: 0x0002D018 File Offset: 0x0002B218
		[XmlIgnore]
		[Browsable(false)]
		public bool serveridSpecified
		{
			get
			{
				return this._serverid != null;
			}
			set
			{
				bool flag = value == (this._serverid == null);
				if (flag)
				{
					this._serverid = (value ? new uint?(this.serverid) : null);
				}
			}
		}

		// Token: 0x0600167D RID: 5757 RVA: 0x0002D05C File Offset: 0x0002B25C
		private bool ShouldSerializeserverid()
		{
			return this.serveridSpecified;
		}

		// Token: 0x0600167E RID: 5758 RVA: 0x0002D074 File Offset: 0x0002B274
		private void Resetserverid()
		{
			this.serveridSpecified = false;
		}

		// Token: 0x1700071F RID: 1823
		// (get) Token: 0x0600167F RID: 5759 RVA: 0x0002D080 File Offset: 0x0002B280
		// (set) Token: 0x06001680 RID: 5760 RVA: 0x0002D0AC File Offset: 0x0002B2AC
		[ProtoMember(3, IsRequired = false, Name = "backflow_firstenter", DataFormat = DataFormat.Default)]
		public bool backflow_firstenter
		{
			get
			{
				return this._backflow_firstenter ?? false;
			}
			set
			{
				this._backflow_firstenter = new bool?(value);
			}
		}

		// Token: 0x17000720 RID: 1824
		// (get) Token: 0x06001681 RID: 5761 RVA: 0x0002D0BC File Offset: 0x0002B2BC
		// (set) Token: 0x06001682 RID: 5762 RVA: 0x0002D0DC File Offset: 0x0002B2DC
		[XmlIgnore]
		[Browsable(false)]
		public bool backflow_firstenterSpecified
		{
			get
			{
				return this._backflow_firstenter != null;
			}
			set
			{
				bool flag = value == (this._backflow_firstenter == null);
				if (flag)
				{
					this._backflow_firstenter = (value ? new bool?(this.backflow_firstenter) : null);
				}
			}
		}

		// Token: 0x06001683 RID: 5763 RVA: 0x0002D120 File Offset: 0x0002B320
		private bool ShouldSerializebackflow_firstenter()
		{
			return this.backflow_firstenterSpecified;
		}

		// Token: 0x06001684 RID: 5764 RVA: 0x0002D138 File Offset: 0x0002B338
		private void Resetbackflow_firstenter()
		{
			this.backflow_firstenterSpecified = false;
		}

		// Token: 0x06001685 RID: 5765 RVA: 0x0002D144 File Offset: 0x0002B344
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000593 RID: 1427
		private RoleAllInfo _roleData = null;

		// Token: 0x04000594 RID: 1428
		private uint? _serverid;

		// Token: 0x04000595 RID: 1429
		private bool? _backflow_firstenter;

		// Token: 0x04000596 RID: 1430
		private IExtension extensionObject;
	}
}
