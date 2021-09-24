using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "MobaBattleOneGameRole")]
	[Serializable]
	public class MobaBattleOneGameRole : IExtensible
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

		[ProtoMember(3, IsRequired = false, Name = "heroid", DataFormat = DataFormat.TwosComplement)]
		public uint heroid
		{
			get
			{
				return this._heroid ?? 0U;
			}
			set
			{
				this._heroid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool heroidSpecified
		{
			get
			{
				return this._heroid != null;
			}
			set
			{
				bool flag = value == (this._heroid == null);
				if (flag)
				{
					this._heroid = (value ? new uint?(this.heroid) : null);
				}
			}
		}

		private bool ShouldSerializeheroid()
		{
			return this.heroidSpecified;
		}

		private void Resetheroid()
		{
			this.heroidSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "killcount", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(5, IsRequired = false, Name = "deathcount", DataFormat = DataFormat.TwosComplement)]
		public uint deathcount
		{
			get
			{
				return this._deathcount ?? 0U;
			}
			set
			{
				this._deathcount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool deathcountSpecified
		{
			get
			{
				return this._deathcount != null;
			}
			set
			{
				bool flag = value == (this._deathcount == null);
				if (flag)
				{
					this._deathcount = (value ? new uint?(this.deathcount) : null);
				}
			}
		}

		private bool ShouldSerializedeathcount()
		{
			return this.deathcountSpecified;
		}

		private void Resetdeathcount()
		{
			this.deathcountSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "assistcount", DataFormat = DataFormat.TwosComplement)]
		public uint assistcount
		{
			get
			{
				return this._assistcount ?? 0U;
			}
			set
			{
				this._assistcount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool assistcountSpecified
		{
			get
			{
				return this._assistcount != null;
			}
			set
			{
				bool flag = value == (this._assistcount == null);
				if (flag)
				{
					this._assistcount = (value ? new uint?(this.assistcount) : null);
				}
			}
		}

		private bool ShouldSerializeassistcount()
		{
			return this.assistcountSpecified;
		}

		private void Resetassistcount()
		{
			this.assistcountSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "multikillcount", DataFormat = DataFormat.TwosComplement)]
		public uint multikillcount
		{
			get
			{
				return this._multikillcount ?? 0U;
			}
			set
			{
				this._multikillcount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool multikillcountSpecified
		{
			get
			{
				return this._multikillcount != null;
			}
			set
			{
				bool flag = value == (this._multikillcount == null);
				if (flag)
				{
					this._multikillcount = (value ? new uint?(this.multikillcount) : null);
				}
			}
		}

		private bool ShouldSerializemultikillcount()
		{
			return this.multikillcountSpecified;
		}

		private void Resetmultikillcount()
		{
			this.multikillcountSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "kda", DataFormat = DataFormat.FixedSize)]
		public float kda
		{
			get
			{
				return this._kda ?? 0f;
			}
			set
			{
				this._kda = new float?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool kdaSpecified
		{
			get
			{
				return this._kda != null;
			}
			set
			{
				bool flag = value == (this._kda == null);
				if (flag)
				{
					this._kda = (value ? new float?(this.kda) : null);
				}
			}
		}

		private bool ShouldSerializekda()
		{
			return this.kdaSpecified;
		}

		private void Resetkda()
		{
			this.kdaSpecified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "isescape", DataFormat = DataFormat.Default)]
		public bool isescape
		{
			get
			{
				return this._isescape ?? false;
			}
			set
			{
				this._isescape = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isescapeSpecified
		{
			get
			{
				return this._isescape != null;
			}
			set
			{
				bool flag = value == (this._isescape == null);
				if (flag)
				{
					this._isescape = (value ? new bool?(this.isescape) : null);
				}
			}
		}

		private bool ShouldSerializeisescape()
		{
			return this.isescapeSpecified;
		}

		private void Resetisescape()
		{
			this.isescapeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _roleid;

		private string _name;

		private uint? _heroid;

		private uint? _killcount;

		private uint? _deathcount;

		private uint? _assistcount;

		private uint? _multikillcount;

		private float? _kda;

		private bool? _isescape;

		private IExtension extensionObject;
	}
}
