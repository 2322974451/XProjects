using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "BattleFieldBattleResult")]
	[Serializable]
	public class BattleFieldBattleResult : IExtensible
	{

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

		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "rank", DataFormat = DataFormat.TwosComplement)]
		public uint rank
		{
			get
			{
				return this._rank ?? 0U;
			}
			set
			{
				this._rank = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool rankSpecified
		{
			get
			{
				return this._rank != null;
			}
			set
			{
				bool flag = value == (this._rank == null);
				if (flag)
				{
					this._rank = (value ? new uint?(this.rank) : null);
				}
			}
		}

		private bool ShouldSerializerank()
		{
			return this.rankSpecified;
		}

		private void Resetrank()
		{
			this.rankSpecified = false;
		}

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

		private bool ShouldSerializepoint()
		{
			return this.pointSpecified;
		}

		private void Resetpoint()
		{
			this.pointSpecified = false;
		}

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

		private bool ShouldSerializekiller()
		{
			return this.killerSpecified;
		}

		private void Resetkiller()
		{
			this.killerSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "death", DataFormat = DataFormat.TwosComplement)]
		public uint death
		{
			get
			{
				return this._death ?? 0U;
			}
			set
			{
				this._death = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool deathSpecified
		{
			get
			{
				return this._death != null;
			}
			set
			{
				bool flag = value == (this._death == null);
				if (flag)
				{
					this._death = (value ? new uint?(this.death) : null);
				}
			}
		}

		private bool ShouldSerializedeath()
		{
			return this.deathSpecified;
		}

		private void Resetdeath()
		{
			this.deathSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "svrname", DataFormat = DataFormat.Default)]
		public string svrname
		{
			get
			{
				return this._svrname ?? "";
			}
			set
			{
				this._svrname = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool svrnameSpecified
		{
			get
			{
				return this._svrname != null;
			}
			set
			{
				bool flag = value == (this._svrname == null);
				if (flag)
				{
					this._svrname = (value ? this.svrname : null);
				}
			}
		}

		private bool ShouldSerializesvrname()
		{
			return this.svrnameSpecified;
		}

		private void Resetsvrname()
		{
			this.svrnameSpecified = false;
		}

		[ProtoMember(7, Name = "items", DataFormat = DataFormat.Default)]
		public List<ItemBrief> items
		{
			get
			{
				return this._items;
			}
		}

		[ProtoMember(8, IsRequired = false, Name = "ismvp", DataFormat = DataFormat.Default)]
		public bool ismvp
		{
			get
			{
				return this._ismvp ?? false;
			}
			set
			{
				this._ismvp = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool ismvpSpecified
		{
			get
			{
				return this._ismvp != null;
			}
			set
			{
				bool flag = value == (this._ismvp == null);
				if (flag)
				{
					this._ismvp = (value ? new bool?(this.ismvp) : null);
				}
			}
		}

		private bool ShouldSerializeismvp()
		{
			return this.ismvpSpecified;
		}

		private void Resetismvp()
		{
			this.ismvpSpecified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "hurt", DataFormat = DataFormat.TwosComplement)]
		public double hurt
		{
			get
			{
				return this._hurt ?? 0.0;
			}
			set
			{
				this._hurt = new double?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool hurtSpecified
		{
			get
			{
				return this._hurt != null;
			}
			set
			{
				bool flag = value == (this._hurt == null);
				if (flag)
				{
					this._hurt = (value ? new double?(this.hurt) : null);
				}
			}
		}

		private bool ShouldSerializehurt()
		{
			return this.hurtSpecified;
		}

		private void Resethurt()
		{
			this.hurtSpecified = false;
		}

		[ProtoMember(10, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
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

		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		private void Resetname()
		{
			this.nameSpecified = false;
		}

		[ProtoMember(11, IsRequired = false, Name = "job", DataFormat = DataFormat.TwosComplement)]
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

		private bool ShouldSerializejob()
		{
			return this.jobSpecified;
		}

		private void Resetjob()
		{
			this.jobSpecified = false;
		}

		[ProtoMember(12, IsRequired = false, Name = "killstreak", DataFormat = DataFormat.TwosComplement)]
		public uint killstreak
		{
			get
			{
				return this._killstreak ?? 0U;
			}
			set
			{
				this._killstreak = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool killstreakSpecified
		{
			get
			{
				return this._killstreak != null;
			}
			set
			{
				bool flag = value == (this._killstreak == null);
				if (flag)
				{
					this._killstreak = (value ? new uint?(this.killstreak) : null);
				}
			}
		}

		private bool ShouldSerializekillstreak()
		{
			return this.killstreakSpecified;
		}

		private void Resetkillstreak()
		{
			this.killstreakSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _roleid;

		private uint? _rank;

		private uint? _point;

		private uint? _killer;

		private uint? _death;

		private string _svrname;

		private readonly List<ItemBrief> _items = new List<ItemBrief>();

		private bool? _ismvp;

		private double? _hurt;

		private string _name;

		private uint? _job;

		private uint? _killstreak;

		private IExtension extensionObject;
	}
}
