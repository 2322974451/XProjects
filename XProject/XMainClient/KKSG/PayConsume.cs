using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PayConsume")]
	[Serializable]
	public class PayConsume : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "lastconsumetime", DataFormat = DataFormat.TwosComplement)]
		public uint lastconsumetime
		{
			get
			{
				return this._lastconsumetime ?? 0U;
			}
			set
			{
				this._lastconsumetime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lastconsumetimeSpecified
		{
			get
			{
				return this._lastconsumetime != null;
			}
			set
			{
				bool flag = value == (this._lastconsumetime == null);
				if (flag)
				{
					this._lastconsumetime = (value ? new uint?(this.lastconsumetime) : null);
				}
			}
		}

		private bool ShouldSerializelastconsumetime()
		{
			return this.lastconsumetimeSpecified;
		}

		private void Resetlastconsumetime()
		{
			this.lastconsumetimeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "consumescore", DataFormat = DataFormat.TwosComplement)]
		public uint consumescore
		{
			get
			{
				return this._consumescore ?? 0U;
			}
			set
			{
				this._consumescore = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool consumescoreSpecified
		{
			get
			{
				return this._consumescore != null;
			}
			set
			{
				bool flag = value == (this._consumescore == null);
				if (flag)
				{
					this._consumescore = (value ? new uint?(this.consumescore) : null);
				}
			}
		}

		private bool ShouldSerializeconsumescore()
		{
			return this.consumescoreSpecified;
		}

		private void Resetconsumescore()
		{
			this.consumescoreSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "maxconsumelv", DataFormat = DataFormat.TwosComplement)]
		public uint maxconsumelv
		{
			get
			{
				return this._maxconsumelv ?? 0U;
			}
			set
			{
				this._maxconsumelv = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool maxconsumelvSpecified
		{
			get
			{
				return this._maxconsumelv != null;
			}
			set
			{
				bool flag = value == (this._maxconsumelv == null);
				if (flag)
				{
					this._maxconsumelv = (value ? new uint?(this.maxconsumelv) : null);
				}
			}
		}

		private bool ShouldSerializemaxconsumelv()
		{
			return this.maxconsumelvSpecified;
		}

		private void Resetmaxconsumelv()
		{
			this.maxconsumelvSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "thismonthcost", DataFormat = DataFormat.TwosComplement)]
		public uint thismonthcost
		{
			get
			{
				return this._thismonthcost ?? 0U;
			}
			set
			{
				this._thismonthcost = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool thismonthcostSpecified
		{
			get
			{
				return this._thismonthcost != null;
			}
			set
			{
				bool flag = value == (this._thismonthcost == null);
				if (flag)
				{
					this._thismonthcost = (value ? new uint?(this.thismonthcost) : null);
				}
			}
		}

		private bool ShouldSerializethismonthcost()
		{
			return this.thismonthcostSpecified;
		}

		private void Resetthismonthcost()
		{
			this.thismonthcostSpecified = false;
		}

		[ProtoMember(5, Name = "setid", DataFormat = DataFormat.TwosComplement)]
		public List<uint> setid
		{
			get
			{
				return this._setid;
			}
		}

		[ProtoMember(6, IsRequired = false, Name = "lastcheckdowntime", DataFormat = DataFormat.TwosComplement)]
		public uint lastcheckdowntime
		{
			get
			{
				return this._lastcheckdowntime ?? 0U;
			}
			set
			{
				this._lastcheckdowntime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lastcheckdowntimeSpecified
		{
			get
			{
				return this._lastcheckdowntime != null;
			}
			set
			{
				bool flag = value == (this._lastcheckdowntime == null);
				if (flag)
				{
					this._lastcheckdowntime = (value ? new uint?(this.lastcheckdowntime) : null);
				}
			}
		}

		private bool ShouldSerializelastcheckdowntime()
		{
			return this.lastcheckdowntimeSpecified;
		}

		private void Resetlastcheckdowntime()
		{
			this.lastcheckdowntimeSpecified = false;
		}

		[ProtoMember(7, Name = "activateid", DataFormat = DataFormat.TwosComplement)]
		public List<uint> activateid
		{
			get
			{
				return this._activateid;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _lastconsumetime;

		private uint? _consumescore;

		private uint? _maxconsumelv;

		private uint? _thismonthcost;

		private readonly List<uint> _setid = new List<uint>();

		private uint? _lastcheckdowntime;

		private readonly List<uint> _activateid = new List<uint>();

		private IExtension extensionObject;
	}
}
