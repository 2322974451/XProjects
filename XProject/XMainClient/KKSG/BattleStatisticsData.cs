using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "BattleStatisticsData")]
	[Serializable]
	public class BattleStatisticsData : IExtensible
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

		[ProtoMember(3, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public uint type
		{
			get
			{
				return this._type ?? 0U;
			}
			set
			{
				this._type = new uint?(value);
			}
		}

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
					this._type = (value ? new uint?(this.type) : null);
				}
			}
		}

		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		private void Resettype()
		{
			this.typeSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "profession", DataFormat = DataFormat.TwosComplement)]
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

		private bool ShouldSerializeprofession()
		{
			return this.professionSpecified;
		}

		private void Resetprofession()
		{
			this.professionSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "damageall", DataFormat = DataFormat.TwosComplement)]
		public double damageall
		{
			get
			{
				return this._damageall ?? 0.0;
			}
			set
			{
				this._damageall = new double?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool damageallSpecified
		{
			get
			{
				return this._damageall != null;
			}
			set
			{
				bool flag = value == (this._damageall == null);
				if (flag)
				{
					this._damageall = (value ? new double?(this.damageall) : null);
				}
			}
		}

		private bool ShouldSerializedamageall()
		{
			return this.damageallSpecified;
		}

		private void Resetdamageall()
		{
			this.damageallSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "deadcount", DataFormat = DataFormat.TwosComplement)]
		public uint deadcount
		{
			get
			{
				return this._deadcount ?? 0U;
			}
			set
			{
				this._deadcount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool deadcountSpecified
		{
			get
			{
				return this._deadcount != null;
			}
			set
			{
				bool flag = value == (this._deadcount == null);
				if (flag)
				{
					this._deadcount = (value ? new uint?(this.deadcount) : null);
				}
			}
		}

		private bool ShouldSerializedeadcount()
		{
			return this.deadcountSpecified;
		}

		private void Resetdeadcount()
		{
			this.deadcountSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "killcount", DataFormat = DataFormat.TwosComplement)]
		public uint killcount
		{
			get
			{
				return this._killcount ?? 0U;
			}
			set
			{
				this._killcount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool killcountSpecified
		{
			get
			{
				return this._killcount != null;
			}
			set
			{
				bool flag = value == (this._killcount == null);
				if (flag)
				{
					this._killcount = (value ? new uint?(this.killcount) : null);
				}
			}
		}

		private bool ShouldSerializekillcount()
		{
			return this.killcountSpecified;
		}

		private void Resetkillcount()
		{
			this.killcountSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "killcontinue", DataFormat = DataFormat.TwosComplement)]
		public uint killcontinue
		{
			get
			{
				return this._killcontinue ?? 0U;
			}
			set
			{
				this._killcontinue = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool killcontinueSpecified
		{
			get
			{
				return this._killcontinue != null;
			}
			set
			{
				bool flag = value == (this._killcontinue == null);
				if (flag)
				{
					this._killcontinue = (value ? new uint?(this.killcontinue) : null);
				}
			}
		}

		private bool ShouldSerializekillcontinue()
		{
			return this.killcontinueSpecified;
		}

		private void Resetkillcontinue()
		{
			this.killcontinueSpecified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "treatcount", DataFormat = DataFormat.TwosComplement)]
		public uint treatcount
		{
			get
			{
				return this._treatcount ?? 0U;
			}
			set
			{
				this._treatcount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool treatcountSpecified
		{
			get
			{
				return this._treatcount != null;
			}
			set
			{
				bool flag = value == (this._treatcount == null);
				if (flag)
				{
					this._treatcount = (value ? new uint?(this.treatcount) : null);
				}
			}
		}

		private bool ShouldSerializetreatcount()
		{
			return this.treatcountSpecified;
		}

		private void Resettreatcount()
		{
			this.treatcountSpecified = false;
		}

		[ProtoMember(10, IsRequired = false, Name = "combomax", DataFormat = DataFormat.TwosComplement)]
		public uint combomax
		{
			get
			{
				return this._combomax ?? 0U;
			}
			set
			{
				this._combomax = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool combomaxSpecified
		{
			get
			{
				return this._combomax != null;
			}
			set
			{
				bool flag = value == (this._combomax == null);
				if (flag)
				{
					this._combomax = (value ? new uint?(this.combomax) : null);
				}
			}
		}

		private bool ShouldSerializecombomax()
		{
			return this.combomaxSpecified;
		}

		private void Resetcombomax()
		{
			this.combomaxSpecified = false;
		}

		[ProtoMember(11, IsRequired = false, Name = "assitnum", DataFormat = DataFormat.TwosComplement)]
		public uint assitnum
		{
			get
			{
				return this._assitnum ?? 0U;
			}
			set
			{
				this._assitnum = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool assitnumSpecified
		{
			get
			{
				return this._assitnum != null;
			}
			set
			{
				bool flag = value == (this._assitnum == null);
				if (flag)
				{
					this._assitnum = (value ? new uint?(this.assitnum) : null);
				}
			}
		}

		private bool ShouldSerializeassitnum()
		{
			return this.assitnumSpecified;
		}

		private void Resetassitnum()
		{
			this.assitnumSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _roleid;

		private string _name;

		private uint? _type;

		private uint? _profession;

		private double? _damageall;

		private uint? _deadcount;

		private uint? _killcount;

		private uint? _killcontinue;

		private uint? _treatcount;

		private uint? _combomax;

		private uint? _assitnum;

		private IExtension extensionObject;
	}
}
