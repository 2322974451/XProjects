using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000735 RID: 1845
	[ProtoContract(Name = "BattleFieldRank")]
	[Serializable]
	public class BattleFieldRank : IExtensible
	{
		// Token: 0x1700287C RID: 10364
		// (get) Token: 0x06007FB1 RID: 32689 RVA: 0x000F4318 File Offset: 0x000F2518
		// (set) Token: 0x06007FB2 RID: 32690 RVA: 0x000F4345 File Offset: 0x000F2545
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

		// Token: 0x1700287D RID: 10365
		// (get) Token: 0x06007FB3 RID: 32691 RVA: 0x000F4354 File Offset: 0x000F2554
		// (set) Token: 0x06007FB4 RID: 32692 RVA: 0x000F4374 File Offset: 0x000F2574
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

		// Token: 0x06007FB5 RID: 32693 RVA: 0x000F43B8 File Offset: 0x000F25B8
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06007FB6 RID: 32694 RVA: 0x000F43D0 File Offset: 0x000F25D0
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x1700287E RID: 10366
		// (get) Token: 0x06007FB7 RID: 32695 RVA: 0x000F43DC File Offset: 0x000F25DC
		// (set) Token: 0x06007FB8 RID: 32696 RVA: 0x000F43FD File Offset: 0x000F25FD
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

		// Token: 0x1700287F RID: 10367
		// (get) Token: 0x06007FB9 RID: 32697 RVA: 0x000F4408 File Offset: 0x000F2608
		// (set) Token: 0x06007FBA RID: 32698 RVA: 0x000F4424 File Offset: 0x000F2624
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

		// Token: 0x06007FBB RID: 32699 RVA: 0x000F4454 File Offset: 0x000F2654
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x06007FBC RID: 32700 RVA: 0x000F446C File Offset: 0x000F266C
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x17002880 RID: 10368
		// (get) Token: 0x06007FBD RID: 32701 RVA: 0x000F4478 File Offset: 0x000F2678
		// (set) Token: 0x06007FBE RID: 32702 RVA: 0x000F44A4 File Offset: 0x000F26A4
		[ProtoMember(3, IsRequired = false, Name = "point", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17002881 RID: 10369
		// (get) Token: 0x06007FBF RID: 32703 RVA: 0x000F44B4 File Offset: 0x000F26B4
		// (set) Token: 0x06007FC0 RID: 32704 RVA: 0x000F44D4 File Offset: 0x000F26D4
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

		// Token: 0x06007FC1 RID: 32705 RVA: 0x000F4518 File Offset: 0x000F2718
		private bool ShouldSerializepoint()
		{
			return this.pointSpecified;
		}

		// Token: 0x06007FC2 RID: 32706 RVA: 0x000F4530 File Offset: 0x000F2730
		private void Resetpoint()
		{
			this.pointSpecified = false;
		}

		// Token: 0x06007FC3 RID: 32707 RVA: 0x000F453C File Offset: 0x000F273C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001DF3 RID: 7667
		private ulong? _roleid;

		// Token: 0x04001DF4 RID: 7668
		private string _name;

		// Token: 0x04001DF5 RID: 7669
		private uint? _point;

		// Token: 0x04001DF6 RID: 7670
		private IExtension extensionObject;
	}
}
