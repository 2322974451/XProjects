using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000607 RID: 1543
	[ProtoContract(Name = "PvpRoleBrief")]
	[Serializable]
	public class PvpRoleBrief : IExtensible
	{
		// Token: 0x17001D23 RID: 7459
		// (get) Token: 0x06005CF4 RID: 23796 RVA: 0x000B11F8 File Offset: 0x000AF3F8
		// (set) Token: 0x06005CF5 RID: 23797 RVA: 0x000B1225 File Offset: 0x000AF425
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

		// Token: 0x17001D24 RID: 7460
		// (get) Token: 0x06005CF6 RID: 23798 RVA: 0x000B1234 File Offset: 0x000AF434
		// (set) Token: 0x06005CF7 RID: 23799 RVA: 0x000B1254 File Offset: 0x000AF454
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

		// Token: 0x06005CF8 RID: 23800 RVA: 0x000B1298 File Offset: 0x000AF498
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06005CF9 RID: 23801 RVA: 0x000B12B0 File Offset: 0x000AF4B0
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x17001D25 RID: 7461
		// (get) Token: 0x06005CFA RID: 23802 RVA: 0x000B12BC File Offset: 0x000AF4BC
		// (set) Token: 0x06005CFB RID: 23803 RVA: 0x000B12DD File Offset: 0x000AF4DD
		[ProtoMember(2, IsRequired = false, Name = "rolename", DataFormat = DataFormat.Default)]
		public string rolename
		{
			get
			{
				return this._rolename ?? "";
			}
			set
			{
				this._rolename = value;
			}
		}

		// Token: 0x17001D26 RID: 7462
		// (get) Token: 0x06005CFC RID: 23804 RVA: 0x000B12E8 File Offset: 0x000AF4E8
		// (set) Token: 0x06005CFD RID: 23805 RVA: 0x000B1304 File Offset: 0x000AF504
		[XmlIgnore]
		[Browsable(false)]
		public bool rolenameSpecified
		{
			get
			{
				return this._rolename != null;
			}
			set
			{
				bool flag = value == (this._rolename == null);
				if (flag)
				{
					this._rolename = (value ? this.rolename : null);
				}
			}
		}

		// Token: 0x06005CFE RID: 23806 RVA: 0x000B1334 File Offset: 0x000AF534
		private bool ShouldSerializerolename()
		{
			return this.rolenameSpecified;
		}

		// Token: 0x06005CFF RID: 23807 RVA: 0x000B134C File Offset: 0x000AF54C
		private void Resetrolename()
		{
			this.rolenameSpecified = false;
		}

		// Token: 0x17001D27 RID: 7463
		// (get) Token: 0x06005D00 RID: 23808 RVA: 0x000B1358 File Offset: 0x000AF558
		// (set) Token: 0x06005D01 RID: 23809 RVA: 0x000B1384 File Offset: 0x000AF584
		[ProtoMember(3, IsRequired = false, Name = "rolelevel", DataFormat = DataFormat.TwosComplement)]
		public uint rolelevel
		{
			get
			{
				return this._rolelevel ?? 0U;
			}
			set
			{
				this._rolelevel = new uint?(value);
			}
		}

		// Token: 0x17001D28 RID: 7464
		// (get) Token: 0x06005D02 RID: 23810 RVA: 0x000B1394 File Offset: 0x000AF594
		// (set) Token: 0x06005D03 RID: 23811 RVA: 0x000B13B4 File Offset: 0x000AF5B4
		[XmlIgnore]
		[Browsable(false)]
		public bool rolelevelSpecified
		{
			get
			{
				return this._rolelevel != null;
			}
			set
			{
				bool flag = value == (this._rolelevel == null);
				if (flag)
				{
					this._rolelevel = (value ? new uint?(this.rolelevel) : null);
				}
			}
		}

		// Token: 0x06005D04 RID: 23812 RVA: 0x000B13F8 File Offset: 0x000AF5F8
		private bool ShouldSerializerolelevel()
		{
			return this.rolelevelSpecified;
		}

		// Token: 0x06005D05 RID: 23813 RVA: 0x000B1410 File Offset: 0x000AF610
		private void Resetrolelevel()
		{
			this.rolelevelSpecified = false;
		}

		// Token: 0x17001D29 RID: 7465
		// (get) Token: 0x06005D06 RID: 23814 RVA: 0x000B141C File Offset: 0x000AF61C
		// (set) Token: 0x06005D07 RID: 23815 RVA: 0x000B1448 File Offset: 0x000AF648
		[ProtoMember(4, IsRequired = false, Name = "roleprofession", DataFormat = DataFormat.TwosComplement)]
		public uint roleprofession
		{
			get
			{
				return this._roleprofession ?? 0U;
			}
			set
			{
				this._roleprofession = new uint?(value);
			}
		}

		// Token: 0x17001D2A RID: 7466
		// (get) Token: 0x06005D08 RID: 23816 RVA: 0x000B1458 File Offset: 0x000AF658
		// (set) Token: 0x06005D09 RID: 23817 RVA: 0x000B1478 File Offset: 0x000AF678
		[XmlIgnore]
		[Browsable(false)]
		public bool roleprofessionSpecified
		{
			get
			{
				return this._roleprofession != null;
			}
			set
			{
				bool flag = value == (this._roleprofession == null);
				if (flag)
				{
					this._roleprofession = (value ? new uint?(this.roleprofession) : null);
				}
			}
		}

		// Token: 0x06005D0A RID: 23818 RVA: 0x000B14BC File Offset: 0x000AF6BC
		private bool ShouldSerializeroleprofession()
		{
			return this.roleprofessionSpecified;
		}

		// Token: 0x06005D0B RID: 23819 RVA: 0x000B14D4 File Offset: 0x000AF6D4
		private void Resetroleprofession()
		{
			this.roleprofessionSpecified = false;
		}

		// Token: 0x17001D2B RID: 7467
		// (get) Token: 0x06005D0C RID: 23820 RVA: 0x000B14E0 File Offset: 0x000AF6E0
		// (set) Token: 0x06005D0D RID: 23821 RVA: 0x000B150C File Offset: 0x000AF70C
		[ProtoMember(5, IsRequired = false, Name = "roleserverid", DataFormat = DataFormat.TwosComplement)]
		public uint roleserverid
		{
			get
			{
				return this._roleserverid ?? 0U;
			}
			set
			{
				this._roleserverid = new uint?(value);
			}
		}

		// Token: 0x17001D2C RID: 7468
		// (get) Token: 0x06005D0E RID: 23822 RVA: 0x000B151C File Offset: 0x000AF71C
		// (set) Token: 0x06005D0F RID: 23823 RVA: 0x000B153C File Offset: 0x000AF73C
		[XmlIgnore]
		[Browsable(false)]
		public bool roleserveridSpecified
		{
			get
			{
				return this._roleserverid != null;
			}
			set
			{
				bool flag = value == (this._roleserverid == null);
				if (flag)
				{
					this._roleserverid = (value ? new uint?(this.roleserverid) : null);
				}
			}
		}

		// Token: 0x06005D10 RID: 23824 RVA: 0x000B1580 File Offset: 0x000AF780
		private bool ShouldSerializeroleserverid()
		{
			return this.roleserveridSpecified;
		}

		// Token: 0x06005D11 RID: 23825 RVA: 0x000B1598 File Offset: 0x000AF798
		private void Resetroleserverid()
		{
			this.roleserveridSpecified = false;
		}

		// Token: 0x06005D12 RID: 23826 RVA: 0x000B15A4 File Offset: 0x000AF7A4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001698 RID: 5784
		private ulong? _roleid;

		// Token: 0x04001699 RID: 5785
		private string _rolename;

		// Token: 0x0400169A RID: 5786
		private uint? _rolelevel;

		// Token: 0x0400169B RID: 5787
		private uint? _roleprofession;

		// Token: 0x0400169C RID: 5788
		private uint? _roleserverid;

		// Token: 0x0400169D RID: 5789
		private IExtension extensionObject;
	}
}
