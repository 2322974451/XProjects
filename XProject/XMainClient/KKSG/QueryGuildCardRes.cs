using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "QueryGuildCardRes")]
	[Serializable]
	public class QueryGuildCardRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "playcount", DataFormat = DataFormat.TwosComplement)]
		public uint playcount
		{
			get
			{
				return this._playcount ?? 0U;
			}
			set
			{
				this._playcount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool playcountSpecified
		{
			get
			{
				return this._playcount != null;
			}
			set
			{
				bool flag = value == (this._playcount == null);
				if (flag)
				{
					this._playcount = (value ? new uint?(this.playcount) : null);
				}
			}
		}

		private bool ShouldSerializeplaycount()
		{
			return this.playcountSpecified;
		}

		private void Resetplaycount()
		{
			this.playcountSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "changecount", DataFormat = DataFormat.TwosComplement)]
		public uint changecount
		{
			get
			{
				return this._changecount ?? 0U;
			}
			set
			{
				this._changecount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool changecountSpecified
		{
			get
			{
				return this._changecount != null;
			}
			set
			{
				bool flag = value == (this._changecount == null);
				if (flag)
				{
					this._changecount = (value ? new uint?(this.changecount) : null);
				}
			}
		}

		private bool ShouldSerializechangecount()
		{
			return this.changecountSpecified;
		}

		private void Resetchangecount()
		{
			this.changecountSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "canplaycount", DataFormat = DataFormat.TwosComplement)]
		public uint canplaycount
		{
			get
			{
				return this._canplaycount ?? 0U;
			}
			set
			{
				this._canplaycount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool canplaycountSpecified
		{
			get
			{
				return this._canplaycount != null;
			}
			set
			{
				bool flag = value == (this._canplaycount == null);
				if (flag)
				{
					this._canplaycount = (value ? new uint?(this.canplaycount) : null);
				}
			}
		}

		private bool ShouldSerializecanplaycount()
		{
			return this.canplaycountSpecified;
		}

		private void Resetcanplaycount()
		{
			this.canplaycountSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "canchangecount", DataFormat = DataFormat.TwosComplement)]
		public uint canchangecount
		{
			get
			{
				return this._canchangecount ?? 0U;
			}
			set
			{
				this._canchangecount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool canchangecountSpecified
		{
			get
			{
				return this._canchangecount != null;
			}
			set
			{
				bool flag = value == (this._canchangecount == null);
				if (flag)
				{
					this._canchangecount = (value ? new uint?(this.canchangecount) : null);
				}
			}
		}

		private bool ShouldSerializecanchangecount()
		{
			return this.canchangecountSpecified;
		}

		private void Resetcanchangecount()
		{
			this.canchangecountSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "allcount", DataFormat = DataFormat.TwosComplement)]
		public uint allcount
		{
			get
			{
				return this._allcount ?? 0U;
			}
			set
			{
				this._allcount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool allcountSpecified
		{
			get
			{
				return this._allcount != null;
			}
			set
			{
				bool flag = value == (this._allcount == null);
				if (flag)
				{
					this._allcount = (value ? new uint?(this.allcount) : null);
				}
			}
		}

		private bool ShouldSerializeallcount()
		{
			return this.allcountSpecified;
		}

		private void Resetallcount()
		{
			this.allcountSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "canallcount", DataFormat = DataFormat.TwosComplement)]
		public uint canallcount
		{
			get
			{
				return this._canallcount ?? 0U;
			}
			set
			{
				this._canallcount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool canallcountSpecified
		{
			get
			{
				return this._canallcount != null;
			}
			set
			{
				bool flag = value == (this._canallcount == null);
				if (flag)
				{
					this._canallcount = (value ? new uint?(this.canallcount) : null);
				}
			}
		}

		private bool ShouldSerializecanallcount()
		{
			return this.canallcountSpecified;
		}

		private void Resetcanallcount()
		{
			this.canallcountSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "bestresult", DataFormat = DataFormat.TwosComplement)]
		public uint bestresult
		{
			get
			{
				return this._bestresult ?? 0U;
			}
			set
			{
				this._bestresult = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool bestresultSpecified
		{
			get
			{
				return this._bestresult != null;
			}
			set
			{
				bool flag = value == (this._bestresult == null);
				if (flag)
				{
					this._bestresult = (value ? new uint?(this.bestresult) : null);
				}
			}
		}

		private bool ShouldSerializebestresult()
		{
			return this.bestresultSpecified;
		}

		private void Resetbestresult()
		{
			this.bestresultSpecified = false;
		}

		[ProtoMember(8, Name = "bestcards", DataFormat = DataFormat.TwosComplement)]
		public List<uint> bestcards
		{
			get
			{
				return this._bestcards;
			}
		}

		[ProtoMember(9, IsRequired = false, Name = "buychangcount", DataFormat = DataFormat.TwosComplement)]
		public uint buychangcount
		{
			get
			{
				return this._buychangcount ?? 0U;
			}
			set
			{
				this._buychangcount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool buychangcountSpecified
		{
			get
			{
				return this._buychangcount != null;
			}
			set
			{
				bool flag = value == (this._buychangcount == null);
				if (flag)
				{
					this._buychangcount = (value ? new uint?(this.buychangcount) : null);
				}
			}
		}

		private bool ShouldSerializebuychangcount()
		{
			return this.buychangcountSpecified;
		}

		private void Resetbuychangcount()
		{
			this.buychangcountSpecified = false;
		}

		[ProtoMember(10, IsRequired = false, Name = "bestrole", DataFormat = DataFormat.Default)]
		public string bestrole
		{
			get
			{
				return this._bestrole ?? "";
			}
			set
			{
				this._bestrole = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool bestroleSpecified
		{
			get
			{
				return this._bestrole != null;
			}
			set
			{
				bool flag = value == (this._bestrole == null);
				if (flag)
				{
					this._bestrole = (value ? this.bestrole : null);
				}
			}
		}

		private bool ShouldSerializebestrole()
		{
			return this.bestroleSpecified;
		}

		private void Resetbestrole()
		{
			this.bestroleSpecified = false;
		}

		[ProtoMember(11, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorcode
		{
			get
			{
				return this._errorcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorcode = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool errorcodeSpecified
		{
			get
			{
				return this._errorcode != null;
			}
			set
			{
				bool flag = value == (this._errorcode == null);
				if (flag)
				{
					this._errorcode = (value ? new ErrorCode?(this.errorcode) : null);
				}
			}
		}

		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _playcount;

		private uint? _changecount;

		private uint? _canplaycount;

		private uint? _canchangecount;

		private uint? _allcount;

		private uint? _canallcount;

		private uint? _bestresult;

		private readonly List<uint> _bestcards = new List<uint>();

		private uint? _buychangcount;

		private string _bestrole;

		private ErrorCode? _errorcode;

		private IExtension extensionObject;
	}
}
