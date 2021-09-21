using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200058F RID: 1423
	[ProtoContract(Name = "SkyCityRankData")]
	[Serializable]
	public class SkyCityRankData : IExtensible
	{
		// Token: 0x17001731 RID: 5937
		// (get) Token: 0x06004B65 RID: 19301 RVA: 0x0008F5D4 File Offset: 0x0008D7D4
		// (set) Token: 0x06004B66 RID: 19302 RVA: 0x0008F601 File Offset: 0x0008D801
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

		// Token: 0x17001732 RID: 5938
		// (get) Token: 0x06004B67 RID: 19303 RVA: 0x0008F610 File Offset: 0x0008D810
		// (set) Token: 0x06004B68 RID: 19304 RVA: 0x0008F630 File Offset: 0x0008D830
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

		// Token: 0x06004B69 RID: 19305 RVA: 0x0008F674 File Offset: 0x0008D874
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06004B6A RID: 19306 RVA: 0x0008F68C File Offset: 0x0008D88C
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x17001733 RID: 5939
		// (get) Token: 0x06004B6B RID: 19307 RVA: 0x0008F698 File Offset: 0x0008D898
		// (set) Token: 0x06004B6C RID: 19308 RVA: 0x0008F6B9 File Offset: 0x0008D8B9
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

		// Token: 0x17001734 RID: 5940
		// (get) Token: 0x06004B6D RID: 19309 RVA: 0x0008F6C4 File Offset: 0x0008D8C4
		// (set) Token: 0x06004B6E RID: 19310 RVA: 0x0008F6E0 File Offset: 0x0008D8E0
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

		// Token: 0x06004B6F RID: 19311 RVA: 0x0008F710 File Offset: 0x0008D910
		private bool ShouldSerializerolename()
		{
			return this.rolenameSpecified;
		}

		// Token: 0x06004B70 RID: 19312 RVA: 0x0008F728 File Offset: 0x0008D928
		private void Resetrolename()
		{
			this.rolenameSpecified = false;
		}

		// Token: 0x17001735 RID: 5941
		// (get) Token: 0x06004B71 RID: 19313 RVA: 0x0008F734 File Offset: 0x0008D934
		// (set) Token: 0x06004B72 RID: 19314 RVA: 0x0008F760 File Offset: 0x0008D960
		[ProtoMember(3, IsRequired = false, Name = "floor", DataFormat = DataFormat.TwosComplement)]
		public uint floor
		{
			get
			{
				return this._floor ?? 0U;
			}
			set
			{
				this._floor = new uint?(value);
			}
		}

		// Token: 0x17001736 RID: 5942
		// (get) Token: 0x06004B73 RID: 19315 RVA: 0x0008F770 File Offset: 0x0008D970
		// (set) Token: 0x06004B74 RID: 19316 RVA: 0x0008F790 File Offset: 0x0008D990
		[XmlIgnore]
		[Browsable(false)]
		public bool floorSpecified
		{
			get
			{
				return this._floor != null;
			}
			set
			{
				bool flag = value == (this._floor == null);
				if (flag)
				{
					this._floor = (value ? new uint?(this.floor) : null);
				}
			}
		}

		// Token: 0x06004B75 RID: 19317 RVA: 0x0008F7D4 File Offset: 0x0008D9D4
		private bool ShouldSerializefloor()
		{
			return this.floorSpecified;
		}

		// Token: 0x06004B76 RID: 19318 RVA: 0x0008F7EC File Offset: 0x0008D9EC
		private void Resetfloor()
		{
			this.floorSpecified = false;
		}

		// Token: 0x17001737 RID: 5943
		// (get) Token: 0x06004B77 RID: 19319 RVA: 0x0008F7F8 File Offset: 0x0008D9F8
		// (set) Token: 0x06004B78 RID: 19320 RVA: 0x0008F824 File Offset: 0x0008DA24
		[ProtoMember(4, IsRequired = false, Name = "killer", DataFormat = DataFormat.TwosComplement)]
		public uint killer
		{
			get
			{
				return this._killer ?? 0U;
			}
			set
			{
				this._killer = new uint?(value);
			}
		}

		// Token: 0x17001738 RID: 5944
		// (get) Token: 0x06004B79 RID: 19321 RVA: 0x0008F834 File Offset: 0x0008DA34
		// (set) Token: 0x06004B7A RID: 19322 RVA: 0x0008F854 File Offset: 0x0008DA54
		[XmlIgnore]
		[Browsable(false)]
		public bool killerSpecified
		{
			get
			{
				return this._killer != null;
			}
			set
			{
				bool flag = value == (this._killer == null);
				if (flag)
				{
					this._killer = (value ? new uint?(this.killer) : null);
				}
			}
		}

		// Token: 0x06004B7B RID: 19323 RVA: 0x0008F898 File Offset: 0x0008DA98
		private bool ShouldSerializekiller()
		{
			return this.killerSpecified;
		}

		// Token: 0x06004B7C RID: 19324 RVA: 0x0008F8B0 File Offset: 0x0008DAB0
		private void Resetkiller()
		{
			this.killerSpecified = false;
		}

		// Token: 0x17001739 RID: 5945
		// (get) Token: 0x06004B7D RID: 19325 RVA: 0x0008F8BC File Offset: 0x0008DABC
		// (set) Token: 0x06004B7E RID: 19326 RVA: 0x0008F8E8 File Offset: 0x0008DAE8
		[ProtoMember(5, IsRequired = false, Name = "job", DataFormat = DataFormat.TwosComplement)]
		public uint job
		{
			get
			{
				return this._job ?? 0U;
			}
			set
			{
				this._job = new uint?(value);
			}
		}

		// Token: 0x1700173A RID: 5946
		// (get) Token: 0x06004B7F RID: 19327 RVA: 0x0008F8F8 File Offset: 0x0008DAF8
		// (set) Token: 0x06004B80 RID: 19328 RVA: 0x0008F918 File Offset: 0x0008DB18
		[XmlIgnore]
		[Browsable(false)]
		public bool jobSpecified
		{
			get
			{
				return this._job != null;
			}
			set
			{
				bool flag = value == (this._job == null);
				if (flag)
				{
					this._job = (value ? new uint?(this.job) : null);
				}
			}
		}

		// Token: 0x06004B81 RID: 19329 RVA: 0x0008F95C File Offset: 0x0008DB5C
		private bool ShouldSerializejob()
		{
			return this.jobSpecified;
		}

		// Token: 0x06004B82 RID: 19330 RVA: 0x0008F974 File Offset: 0x0008DB74
		private void Resetjob()
		{
			this.jobSpecified = false;
		}

		// Token: 0x1700173B RID: 5947
		// (get) Token: 0x06004B83 RID: 19331 RVA: 0x0008F980 File Offset: 0x0008DB80
		// (set) Token: 0x06004B84 RID: 19332 RVA: 0x0008F9B4 File Offset: 0x0008DBB4
		[ProtoMember(6, IsRequired = false, Name = "fight", DataFormat = DataFormat.TwosComplement)]
		public double fight
		{
			get
			{
				return this._fight ?? 0.0;
			}
			set
			{
				this._fight = new double?(value);
			}
		}

		// Token: 0x1700173C RID: 5948
		// (get) Token: 0x06004B85 RID: 19333 RVA: 0x0008F9C4 File Offset: 0x0008DBC4
		// (set) Token: 0x06004B86 RID: 19334 RVA: 0x0008F9E4 File Offset: 0x0008DBE4
		[XmlIgnore]
		[Browsable(false)]
		public bool fightSpecified
		{
			get
			{
				return this._fight != null;
			}
			set
			{
				bool flag = value == (this._fight == null);
				if (flag)
				{
					this._fight = (value ? new double?(this.fight) : null);
				}
			}
		}

		// Token: 0x06004B87 RID: 19335 RVA: 0x0008FA28 File Offset: 0x0008DC28
		private bool ShouldSerializefight()
		{
			return this.fightSpecified;
		}

		// Token: 0x06004B88 RID: 19336 RVA: 0x0008FA40 File Offset: 0x0008DC40
		private void Resetfight()
		{
			this.fightSpecified = false;
		}

		// Token: 0x06004B89 RID: 19337 RVA: 0x0008FA4C File Offset: 0x0008DC4C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040012BC RID: 4796
		private ulong? _roleid;

		// Token: 0x040012BD RID: 4797
		private string _rolename;

		// Token: 0x040012BE RID: 4798
		private uint? _floor;

		// Token: 0x040012BF RID: 4799
		private uint? _killer;

		// Token: 0x040012C0 RID: 4800
		private uint? _job;

		// Token: 0x040012C1 RID: 4801
		private double? _fight;

		// Token: 0x040012C2 RID: 4802
		private IExtension extensionObject;
	}
}
