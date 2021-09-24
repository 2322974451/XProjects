using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PetChangeNotfiy")]
	[Serializable]
	public class PetChangeNotfiy : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public PetOP type
		{
			get
			{
				return this._type ?? PetOP.PetFellow;
			}
			set
			{
				this._type = new PetOP?(value);
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
					this._type = (value ? new PetOP?(this.type) : null);
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

		[ProtoMember(2, Name = "pet", DataFormat = DataFormat.Default)]
		public List<PetSingle> pet
		{
			get
			{
				return this._pet;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "delexp", DataFormat = DataFormat.TwosComplement)]
		public uint delexp
		{
			get
			{
				return this._delexp ?? 0U;
			}
			set
			{
				this._delexp = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool delexpSpecified
		{
			get
			{
				return this._delexp != null;
			}
			set
			{
				bool flag = value == (this._delexp == null);
				if (flag)
				{
					this._delexp = (value ? new uint?(this.delexp) : null);
				}
			}
		}

		private bool ShouldSerializedelexp()
		{
			return this.delexpSpecified;
		}

		private void Resetdelexp()
		{
			this.delexpSpecified = false;
		}

		[ProtoMember(4, Name = "getskills", DataFormat = DataFormat.Default)]
		public List<petGetSkill> getskills
		{
			get
			{
				return this._getskills;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "delskillid", DataFormat = DataFormat.TwosComplement)]
		public uint delskillid
		{
			get
			{
				return this._delskillid ?? 0U;
			}
			set
			{
				this._delskillid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool delskillidSpecified
		{
			get
			{
				return this._delskillid != null;
			}
			set
			{
				bool flag = value == (this._delskillid == null);
				if (flag)
				{
					this._delskillid = (value ? new uint?(this.delskillid) : null);
				}
			}
		}

		private bool ShouldSerializedelskillid()
		{
			return this.delskillidSpecified;
		}

		private void Resetdelskillid()
		{
			this.delskillidSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private PetOP? _type;

		private readonly List<PetSingle> _pet = new List<PetSingle>();

		private uint? _delexp;

		private readonly List<petGetSkill> _getskills = new List<petGetSkill>();

		private uint? _delskillid;

		private IExtension extensionObject;
	}
}
