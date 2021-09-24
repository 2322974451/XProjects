using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "BossRushData")]
	[Serializable]
	public class BossRushData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "confid", DataFormat = DataFormat.TwosComplement)]
		public int confid
		{
			get
			{
				return this._confid ?? 0;
			}
			set
			{
				this._confid = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool confidSpecified
		{
			get
			{
				return this._confid != null;
			}
			set
			{
				bool flag = value == (this._confid == null);
				if (flag)
				{
					this._confid = (value ? new int?(this.confid) : null);
				}
			}
		}

		private bool ShouldSerializeconfid()
		{
			return this.confidSpecified;
		}

		private void Resetconfid()
		{
			this.confidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "buffid1", DataFormat = DataFormat.TwosComplement)]
		public int buffid1
		{
			get
			{
				return this._buffid1 ?? 0;
			}
			set
			{
				this._buffid1 = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool buffid1Specified
		{
			get
			{
				return this._buffid1 != null;
			}
			set
			{
				bool flag = value == (this._buffid1 == null);
				if (flag)
				{
					this._buffid1 = (value ? new int?(this.buffid1) : null);
				}
			}
		}

		private bool ShouldSerializebuffid1()
		{
			return this.buffid1Specified;
		}

		private void Resetbuffid1()
		{
			this.buffid1Specified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "buffid2", DataFormat = DataFormat.TwosComplement)]
		public int buffid2
		{
			get
			{
				return this._buffid2 ?? 0;
			}
			set
			{
				this._buffid2 = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool buffid2Specified
		{
			get
			{
				return this._buffid2 != null;
			}
			set
			{
				bool flag = value == (this._buffid2 == null);
				if (flag)
				{
					this._buffid2 = (value ? new int?(this.buffid2) : null);
				}
			}
		}

		private bool ShouldSerializebuffid2()
		{
			return this.buffid2Specified;
		}

		private void Resetbuffid2()
		{
			this.buffid2Specified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "currank", DataFormat = DataFormat.TwosComplement)]
		public int currank
		{
			get
			{
				return this._currank ?? 0;
			}
			set
			{
				this._currank = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool currankSpecified
		{
			get
			{
				return this._currank != null;
			}
			set
			{
				bool flag = value == (this._currank == null);
				if (flag)
				{
					this._currank = (value ? new int?(this.currank) : null);
				}
			}
		}

		private bool ShouldSerializecurrank()
		{
			return this.currankSpecified;
		}

		private void Resetcurrank()
		{
			this.currankSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "maxrank", DataFormat = DataFormat.TwosComplement)]
		public int maxrank
		{
			get
			{
				return this._maxrank ?? 0;
			}
			set
			{
				this._maxrank = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool maxrankSpecified
		{
			get
			{
				return this._maxrank != null;
			}
			set
			{
				bool flag = value == (this._maxrank == null);
				if (flag)
				{
					this._maxrank = (value ? new int?(this.maxrank) : null);
				}
			}
		}

		private bool ShouldSerializemaxrank()
		{
			return this.maxrankSpecified;
		}

		private void Resetmaxrank()
		{
			this.maxrankSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "currefreshcount", DataFormat = DataFormat.TwosComplement)]
		public int currefreshcount
		{
			get
			{
				return this._currefreshcount ?? 0;
			}
			set
			{
				this._currefreshcount = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool currefreshcountSpecified
		{
			get
			{
				return this._currefreshcount != null;
			}
			set
			{
				bool flag = value == (this._currefreshcount == null);
				if (flag)
				{
					this._currefreshcount = (value ? new int?(this.currefreshcount) : null);
				}
			}
		}

		private bool ShouldSerializecurrefreshcount()
		{
			return this.currefreshcountSpecified;
		}

		private void Resetcurrefreshcount()
		{
			this.currefreshcountSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "maxrefreshcount", DataFormat = DataFormat.TwosComplement)]
		public int maxrefreshcount
		{
			get
			{
				return this._maxrefreshcount ?? 0;
			}
			set
			{
				this._maxrefreshcount = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool maxrefreshcountSpecified
		{
			get
			{
				return this._maxrefreshcount != null;
			}
			set
			{
				bool flag = value == (this._maxrefreshcount == null);
				if (flag)
				{
					this._maxrefreshcount = (value ? new int?(this.maxrefreshcount) : null);
				}
			}
		}

		private bool ShouldSerializemaxrefreshcount()
		{
			return this.maxrefreshcountSpecified;
		}

		private void Resetmaxrefreshcount()
		{
			this.maxrefreshcountSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "joincounttoday", DataFormat = DataFormat.TwosComplement)]
		public int joincounttoday
		{
			get
			{
				return this._joincounttoday ?? 0;
			}
			set
			{
				this._joincounttoday = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool joincounttodaySpecified
		{
			get
			{
				return this._joincounttoday != null;
			}
			set
			{
				bool flag = value == (this._joincounttoday == null);
				if (flag)
				{
					this._joincounttoday = (value ? new int?(this.joincounttoday) : null);
				}
			}
		}

		private bool ShouldSerializejoincounttoday()
		{
			return this.joincounttodaySpecified;
		}

		private void Resetjoincounttoday()
		{
			this.joincounttodaySpecified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "joincountmax", DataFormat = DataFormat.TwosComplement)]
		public int joincountmax
		{
			get
			{
				return this._joincountmax ?? 0;
			}
			set
			{
				this._joincountmax = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool joincountmaxSpecified
		{
			get
			{
				return this._joincountmax != null;
			}
			set
			{
				bool flag = value == (this._joincountmax == null);
				if (flag)
				{
					this._joincountmax = (value ? new int?(this.joincountmax) : null);
				}
			}
		}

		private bool ShouldSerializejoincountmax()
		{
			return this.joincountmaxSpecified;
		}

		private void Resetjoincountmax()
		{
			this.joincountmaxSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _confid;

		private int? _buffid1;

		private int? _buffid2;

		private int? _currank;

		private int? _maxrank;

		private int? _currefreshcount;

		private int? _maxrefreshcount;

		private int? _joincounttoday;

		private int? _joincountmax;

		private IExtension extensionObject;
	}
}
