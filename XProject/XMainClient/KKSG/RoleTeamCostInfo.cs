using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "RoleTeamCostInfo")]
	[Serializable]
	public class RoleTeamCostInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "expid", DataFormat = DataFormat.TwosComplement)]
		public uint expid
		{
			get
			{
				return this._expid ?? 0U;
			}
			set
			{
				this._expid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool expidSpecified
		{
			get
			{
				return this._expid != null;
			}
			set
			{
				bool flag = value == (this._expid == null);
				if (flag)
				{
					this._expid = (value ? new uint?(this.expid) : null);
				}
			}
		}

		private bool ShouldSerializeexpid()
		{
			return this.expidSpecified;
		}

		private void Resetexpid()
		{
			this.expidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "costindex", DataFormat = DataFormat.TwosComplement)]
		public uint costindex
		{
			get
			{
				return this._costindex ?? 0U;
			}
			set
			{
				this._costindex = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool costindexSpecified
		{
			get
			{
				return this._costindex != null;
			}
			set
			{
				bool flag = value == (this._costindex == null);
				if (flag)
				{
					this._costindex = (value ? new uint?(this.costindex) : null);
				}
			}
		}

		private bool ShouldSerializecostindex()
		{
			return this.costindexSpecified;
		}

		private void Resetcostindex()
		{
			this.costindexSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "dragoncount", DataFormat = DataFormat.TwosComplement)]
		public uint dragoncount
		{
			get
			{
				return this._dragoncount ?? 0U;
			}
			set
			{
				this._dragoncount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool dragoncountSpecified
		{
			get
			{
				return this._dragoncount != null;
			}
			set
			{
				bool flag = value == (this._dragoncount == null);
				if (flag)
				{
					this._dragoncount = (value ? new uint?(this.dragoncount) : null);
				}
			}
		}

		private bool ShouldSerializedragoncount()
		{
			return this.dragoncountSpecified;
		}

		private void Resetdragoncount()
		{
			this.dragoncountSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "updateday", DataFormat = DataFormat.TwosComplement)]
		public uint updateday
		{
			get
			{
				return this._updateday ?? 0U;
			}
			set
			{
				this._updateday = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool updatedaySpecified
		{
			get
			{
				return this._updateday != null;
			}
			set
			{
				bool flag = value == (this._updateday == null);
				if (flag)
				{
					this._updateday = (value ? new uint?(this.updateday) : null);
				}
			}
		}

		private bool ShouldSerializeupdateday()
		{
			return this.updatedaySpecified;
		}

		private void Resetupdateday()
		{
			this.updatedaySpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "getgiftvalue", DataFormat = DataFormat.TwosComplement)]
		public uint getgiftvalue
		{
			get
			{
				return this._getgiftvalue ?? 0U;
			}
			set
			{
				this._getgiftvalue = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool getgiftvalueSpecified
		{
			get
			{
				return this._getgiftvalue != null;
			}
			set
			{
				bool flag = value == (this._getgiftvalue == null);
				if (flag)
				{
					this._getgiftvalue = (value ? new uint?(this.getgiftvalue) : null);
				}
			}
		}

		private bool ShouldSerializegetgiftvalue()
		{
			return this.getgiftvalueSpecified;
		}

		private void Resetgetgiftvalue()
		{
			this.getgiftvalueSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _expid;

		private uint? _costindex;

		private uint? _dragoncount;

		private uint? _updateday;

		private uint? _getgiftvalue;

		private IExtension extensionObject;
	}
}
