using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000716 RID: 1814
	[ProtoContract(Name = "CustomBattleMatchRoleInfo")]
	[Serializable]
	public class CustomBattleMatchRoleInfo : IExtensible
	{
		// Token: 0x17002712 RID: 10002
		// (get) Token: 0x06007B49 RID: 31561 RVA: 0x000EBA60 File Offset: 0x000E9C60
		// (set) Token: 0x06007B4A RID: 31562 RVA: 0x000EBA8D File Offset: 0x000E9C8D
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

		// Token: 0x17002713 RID: 10003
		// (get) Token: 0x06007B4B RID: 31563 RVA: 0x000EBA9C File Offset: 0x000E9C9C
		// (set) Token: 0x06007B4C RID: 31564 RVA: 0x000EBABC File Offset: 0x000E9CBC
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

		// Token: 0x06007B4D RID: 31565 RVA: 0x000EBB00 File Offset: 0x000E9D00
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06007B4E RID: 31566 RVA: 0x000EBB18 File Offset: 0x000E9D18
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x17002714 RID: 10004
		// (get) Token: 0x06007B4F RID: 31567 RVA: 0x000EBB24 File Offset: 0x000E9D24
		// (set) Token: 0x06007B50 RID: 31568 RVA: 0x000EBB50 File Offset: 0x000E9D50
		[ProtoMember(2, IsRequired = false, Name = "profession", DataFormat = DataFormat.TwosComplement)]
		public uint profession
		{
			get
			{
				return this._profession ?? 0U;
			}
			set
			{
				this._profession = new uint?(value);
			}
		}

		// Token: 0x17002715 RID: 10005
		// (get) Token: 0x06007B51 RID: 31569 RVA: 0x000EBB60 File Offset: 0x000E9D60
		// (set) Token: 0x06007B52 RID: 31570 RVA: 0x000EBB80 File Offset: 0x000E9D80
		[XmlIgnore]
		[Browsable(false)]
		public bool professionSpecified
		{
			get
			{
				return this._profession != null;
			}
			set
			{
				bool flag = value == (this._profession == null);
				if (flag)
				{
					this._profession = (value ? new uint?(this.profession) : null);
				}
			}
		}

		// Token: 0x06007B53 RID: 31571 RVA: 0x000EBBC4 File Offset: 0x000E9DC4
		private bool ShouldSerializeprofession()
		{
			return this.professionSpecified;
		}

		// Token: 0x06007B54 RID: 31572 RVA: 0x000EBBDC File Offset: 0x000E9DDC
		private void Resetprofession()
		{
			this.professionSpecified = false;
		}

		// Token: 0x17002716 RID: 10006
		// (get) Token: 0x06007B55 RID: 31573 RVA: 0x000EBBE8 File Offset: 0x000E9DE8
		// (set) Token: 0x06007B56 RID: 31574 RVA: 0x000EBC09 File Offset: 0x000E9E09
		[ProtoMember(3, IsRequired = false, Name = "rolename", DataFormat = DataFormat.Default)]
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

		// Token: 0x17002717 RID: 10007
		// (get) Token: 0x06007B57 RID: 31575 RVA: 0x000EBC14 File Offset: 0x000E9E14
		// (set) Token: 0x06007B58 RID: 31576 RVA: 0x000EBC30 File Offset: 0x000E9E30
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

		// Token: 0x06007B59 RID: 31577 RVA: 0x000EBC60 File Offset: 0x000E9E60
		private bool ShouldSerializerolename()
		{
			return this.rolenameSpecified;
		}

		// Token: 0x06007B5A RID: 31578 RVA: 0x000EBC78 File Offset: 0x000E9E78
		private void Resetrolename()
		{
			this.rolenameSpecified = false;
		}

		// Token: 0x17002718 RID: 10008
		// (get) Token: 0x06007B5B RID: 31579 RVA: 0x000EBC84 File Offset: 0x000E9E84
		// (set) Token: 0x06007B5C RID: 31580 RVA: 0x000EBCB0 File Offset: 0x000E9EB0
		[ProtoMember(4, IsRequired = false, Name = "serverid", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17002719 RID: 10009
		// (get) Token: 0x06007B5D RID: 31581 RVA: 0x000EBCC0 File Offset: 0x000E9EC0
		// (set) Token: 0x06007B5E RID: 31582 RVA: 0x000EBCE0 File Offset: 0x000E9EE0
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

		// Token: 0x06007B5F RID: 31583 RVA: 0x000EBD24 File Offset: 0x000E9F24
		private bool ShouldSerializeserverid()
		{
			return this.serveridSpecified;
		}

		// Token: 0x06007B60 RID: 31584 RVA: 0x000EBD3C File Offset: 0x000E9F3C
		private void Resetserverid()
		{
			this.serveridSpecified = false;
		}

		// Token: 0x1700271A RID: 10010
		// (get) Token: 0x06007B61 RID: 31585 RVA: 0x000EBD48 File Offset: 0x000E9F48
		// (set) Token: 0x06007B62 RID: 31586 RVA: 0x000EBD74 File Offset: 0x000E9F74
		[ProtoMember(5, IsRequired = false, Name = "win", DataFormat = DataFormat.TwosComplement)]
		public uint win
		{
			get
			{
				return this._win ?? 0U;
			}
			set
			{
				this._win = new uint?(value);
			}
		}

		// Token: 0x1700271B RID: 10011
		// (get) Token: 0x06007B63 RID: 31587 RVA: 0x000EBD84 File Offset: 0x000E9F84
		// (set) Token: 0x06007B64 RID: 31588 RVA: 0x000EBDA4 File Offset: 0x000E9FA4
		[XmlIgnore]
		[Browsable(false)]
		public bool winSpecified
		{
			get
			{
				return this._win != null;
			}
			set
			{
				bool flag = value == (this._win == null);
				if (flag)
				{
					this._win = (value ? new uint?(this.win) : null);
				}
			}
		}

		// Token: 0x06007B65 RID: 31589 RVA: 0x000EBDE8 File Offset: 0x000E9FE8
		private bool ShouldSerializewin()
		{
			return this.winSpecified;
		}

		// Token: 0x06007B66 RID: 31590 RVA: 0x000EBE00 File Offset: 0x000EA000
		private void Resetwin()
		{
			this.winSpecified = false;
		}

		// Token: 0x1700271C RID: 10012
		// (get) Token: 0x06007B67 RID: 31591 RVA: 0x000EBE0C File Offset: 0x000EA00C
		// (set) Token: 0x06007B68 RID: 31592 RVA: 0x000EBE38 File Offset: 0x000EA038
		[ProtoMember(6, IsRequired = false, Name = "lose", DataFormat = DataFormat.TwosComplement)]
		public uint lose
		{
			get
			{
				return this._lose ?? 0U;
			}
			set
			{
				this._lose = new uint?(value);
			}
		}

		// Token: 0x1700271D RID: 10013
		// (get) Token: 0x06007B69 RID: 31593 RVA: 0x000EBE48 File Offset: 0x000EA048
		// (set) Token: 0x06007B6A RID: 31594 RVA: 0x000EBE68 File Offset: 0x000EA068
		[XmlIgnore]
		[Browsable(false)]
		public bool loseSpecified
		{
			get
			{
				return this._lose != null;
			}
			set
			{
				bool flag = value == (this._lose == null);
				if (flag)
				{
					this._lose = (value ? new uint?(this.lose) : null);
				}
			}
		}

		// Token: 0x06007B6B RID: 31595 RVA: 0x000EBEAC File Offset: 0x000EA0AC
		private bool ShouldSerializelose()
		{
			return this.loseSpecified;
		}

		// Token: 0x06007B6C RID: 31596 RVA: 0x000EBEC4 File Offset: 0x000EA0C4
		private void Resetlose()
		{
			this.loseSpecified = false;
		}

		// Token: 0x1700271E RID: 10014
		// (get) Token: 0x06007B6D RID: 31597 RVA: 0x000EBED0 File Offset: 0x000EA0D0
		// (set) Token: 0x06007B6E RID: 31598 RVA: 0x000EBEFC File Offset: 0x000EA0FC
		[ProtoMember(7, IsRequired = false, Name = "draw", DataFormat = DataFormat.TwosComplement)]
		public uint draw
		{
			get
			{
				return this._draw ?? 0U;
			}
			set
			{
				this._draw = new uint?(value);
			}
		}

		// Token: 0x1700271F RID: 10015
		// (get) Token: 0x06007B6F RID: 31599 RVA: 0x000EBF0C File Offset: 0x000EA10C
		// (set) Token: 0x06007B70 RID: 31600 RVA: 0x000EBF2C File Offset: 0x000EA12C
		[XmlIgnore]
		[Browsable(false)]
		public bool drawSpecified
		{
			get
			{
				return this._draw != null;
			}
			set
			{
				bool flag = value == (this._draw == null);
				if (flag)
				{
					this._draw = (value ? new uint?(this.draw) : null);
				}
			}
		}

		// Token: 0x06007B71 RID: 31601 RVA: 0x000EBF70 File Offset: 0x000EA170
		private bool ShouldSerializedraw()
		{
			return this.drawSpecified;
		}

		// Token: 0x06007B72 RID: 31602 RVA: 0x000EBF88 File Offset: 0x000EA188
		private void Resetdraw()
		{
			this.drawSpecified = false;
		}

		// Token: 0x17002720 RID: 10016
		// (get) Token: 0x06007B73 RID: 31603 RVA: 0x000EBF94 File Offset: 0x000EA194
		[ProtoMember(8, Name = "records", DataFormat = DataFormat.TwosComplement)]
		public List<uint> records
		{
			get
			{
				return this._records;
			}
		}

		// Token: 0x17002721 RID: 10017
		// (get) Token: 0x06007B74 RID: 31604 RVA: 0x000EBFAC File Offset: 0x000EA1AC
		// (set) Token: 0x06007B75 RID: 31605 RVA: 0x000EBFD8 File Offset: 0x000EA1D8
		[ProtoMember(9, IsRequired = false, Name = "timestamp", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17002722 RID: 10018
		// (get) Token: 0x06007B76 RID: 31606 RVA: 0x000EBFE8 File Offset: 0x000EA1E8
		// (set) Token: 0x06007B77 RID: 31607 RVA: 0x000EC008 File Offset: 0x000EA208
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

		// Token: 0x06007B78 RID: 31608 RVA: 0x000EC04C File Offset: 0x000EA24C
		private bool ShouldSerializetimestamp()
		{
			return this.timestampSpecified;
		}

		// Token: 0x06007B79 RID: 31609 RVA: 0x000EC064 File Offset: 0x000EA264
		private void Resettimestamp()
		{
			this.timestampSpecified = false;
		}

		// Token: 0x17002723 RID: 10019
		// (get) Token: 0x06007B7A RID: 31610 RVA: 0x000EC070 File Offset: 0x000EA270
		[ProtoMember(10, Name = "stages", DataFormat = DataFormat.Default)]
		public List<PkMatchStage> stages
		{
			get
			{
				return this._stages;
			}
		}

		// Token: 0x17002724 RID: 10020
		// (get) Token: 0x06007B7B RID: 31611 RVA: 0x000EC088 File Offset: 0x000EA288
		// (set) Token: 0x06007B7C RID: 31612 RVA: 0x000EC0B4 File Offset: 0x000EA2B4
		[ProtoMember(11, IsRequired = false, Name = "point", DataFormat = DataFormat.TwosComplement)]
		public uint point
		{
			get
			{
				return this._point ?? 0U;
			}
			set
			{
				this._point = new uint?(value);
			}
		}

		// Token: 0x17002725 RID: 10021
		// (get) Token: 0x06007B7D RID: 31613 RVA: 0x000EC0C4 File Offset: 0x000EA2C4
		// (set) Token: 0x06007B7E RID: 31614 RVA: 0x000EC0E4 File Offset: 0x000EA2E4
		[XmlIgnore]
		[Browsable(false)]
		public bool pointSpecified
		{
			get
			{
				return this._point != null;
			}
			set
			{
				bool flag = value == (this._point == null);
				if (flag)
				{
					this._point = (value ? new uint?(this.point) : null);
				}
			}
		}

		// Token: 0x06007B7F RID: 31615 RVA: 0x000EC128 File Offset: 0x000EA328
		private bool ShouldSerializepoint()
		{
			return this.pointSpecified;
		}

		// Token: 0x06007B80 RID: 31616 RVA: 0x000EC140 File Offset: 0x000EA340
		private void Resetpoint()
		{
			this.pointSpecified = false;
		}

		// Token: 0x06007B81 RID: 31617 RVA: 0x000EC14C File Offset: 0x000EA34C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001D19 RID: 7449
		private ulong? _roleid;

		// Token: 0x04001D1A RID: 7450
		private uint? _profession;

		// Token: 0x04001D1B RID: 7451
		private string _rolename;

		// Token: 0x04001D1C RID: 7452
		private uint? _serverid;

		// Token: 0x04001D1D RID: 7453
		private uint? _win;

		// Token: 0x04001D1E RID: 7454
		private uint? _lose;

		// Token: 0x04001D1F RID: 7455
		private uint? _draw;

		// Token: 0x04001D20 RID: 7456
		private readonly List<uint> _records = new List<uint>();

		// Token: 0x04001D21 RID: 7457
		private uint? _timestamp;

		// Token: 0x04001D22 RID: 7458
		private readonly List<PkMatchStage> _stages = new List<PkMatchStage>();

		// Token: 0x04001D23 RID: 7459
		private uint? _point;

		// Token: 0x04001D24 RID: 7460
		private IExtension extensionObject;
	}
}
