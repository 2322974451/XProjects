using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildCardMatchNtf")]
	[Serializable]
	public class GuildCardMatchNtf : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(2, IsRequired = false, Name = "op", DataFormat = DataFormat.TwosComplement)]
		public CardMatchOp op
		{
			get
			{
				return this._op ?? CardMatchOp.CardMatch_Begin;
			}
			set
			{
				this._op = new CardMatchOp?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool opSpecified
		{
			get
			{
				return this._op != null;
			}
			set
			{
				bool flag = value == (this._op == null);
				if (flag)
				{
					this._op = (value ? new CardMatchOp?(this.op) : null);
				}
			}
		}

		private bool ShouldSerializeop()
		{
			return this.opSpecified;
		}

		private void Resetop()
		{
			this.opSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "timeleft", DataFormat = DataFormat.TwosComplement)]
		public uint timeleft
		{
			get
			{
				return this._timeleft ?? 0U;
			}
			set
			{
				this._timeleft = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool timeleftSpecified
		{
			get
			{
				return this._timeleft != null;
			}
			set
			{
				bool flag = value == (this._timeleft == null);
				if (flag)
				{
					this._timeleft = (value ? new uint?(this.timeleft) : null);
				}
			}
		}

		private bool ShouldSerializetimeleft()
		{
			return this.timeleftSpecified;
		}

		private void Resettimeleft()
		{
			this.timeleftSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "changecount", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(5, IsRequired = false, Name = "round", DataFormat = DataFormat.TwosComplement)]
		public uint round
		{
			get
			{
				return this._round ?? 0U;
			}
			set
			{
				this._round = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool roundSpecified
		{
			get
			{
				return this._round != null;
			}
			set
			{
				bool flag = value == (this._round == null);
				if (flag)
				{
					this._round = (value ? new uint?(this.round) : null);
				}
			}
		}

		private bool ShouldSerializeround()
		{
			return this.roundSpecified;
		}

		private void Resetround()
		{
			this.roundSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
		public uint result
		{
			get
			{
				return this._result ?? 0U;
			}
			set
			{
				this._result = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool resultSpecified
		{
			get
			{
				return this._result != null;
			}
			set
			{
				bool flag = value == (this._result == null);
				if (flag)
				{
					this._result = (value ? new uint?(this.result) : null);
				}
			}
		}

		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		[ProtoMember(7, Name = "cards", DataFormat = DataFormat.TwosComplement)]
		public List<uint> cards
		{
			get
			{
				return this._cards;
			}
		}

		[ProtoMember(8, IsRequired = false, Name = "iscanbegin", DataFormat = DataFormat.Default)]
		public bool iscanbegin
		{
			get
			{
				return this._iscanbegin ?? false;
			}
			set
			{
				this._iscanbegin = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool iscanbeginSpecified
		{
			get
			{
				return this._iscanbegin != null;
			}
			set
			{
				bool flag = value == (this._iscanbegin == null);
				if (flag)
				{
					this._iscanbegin = (value ? new bool?(this.iscanbegin) : null);
				}
			}
		}

		private bool ShouldSerializeiscanbegin()
		{
			return this.iscanbeginSpecified;
		}

		private void Resetiscanbegin()
		{
			this.iscanbeginSpecified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "isbegin", DataFormat = DataFormat.Default)]
		public bool isbegin
		{
			get
			{
				return this._isbegin ?? false;
			}
			set
			{
				this._isbegin = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isbeginSpecified
		{
			get
			{
				return this._isbegin != null;
			}
			set
			{
				bool flag = value == (this._isbegin == null);
				if (flag)
				{
					this._isbegin = (value ? new bool?(this.isbegin) : null);
				}
			}
		}

		private bool ShouldSerializeisbegin()
		{
			return this.isbeginSpecified;
		}

		private void Resetisbegin()
		{
			this.isbeginSpecified = false;
		}

		[ProtoMember(10, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public CardMatchState state
		{
			get
			{
				return this._state ?? CardMatchState.CardMatch_StateBegin;
			}
			set
			{
				this._state = new CardMatchState?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool stateSpecified
		{
			get
			{
				return this._state != null;
			}
			set
			{
				bool flag = value == (this._state == null);
				if (flag)
				{
					this._state = (value ? new CardMatchState?(this.state) : null);
				}
			}
		}

		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		[ProtoMember(11, IsRequired = false, Name = "store", DataFormat = DataFormat.TwosComplement)]
		public uint store
		{
			get
			{
				return this._store ?? 0U;
			}
			set
			{
				this._store = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool storeSpecified
		{
			get
			{
				return this._store != null;
			}
			set
			{
				bool flag = value == (this._store == null);
				if (flag)
				{
					this._store = (value ? new uint?(this.store) : null);
				}
			}
		}

		private bool ShouldSerializestore()
		{
			return this.storeSpecified;
		}

		private void Resetstore()
		{
			this.storeSpecified = false;
		}

		[ProtoMember(12, IsRequired = false, Name = "sign_up", DataFormat = DataFormat.Default)]
		public bool sign_up
		{
			get
			{
				return this._sign_up ?? false;
			}
			set
			{
				this._sign_up = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool sign_upSpecified
		{
			get
			{
				return this._sign_up != null;
			}
			set
			{
				bool flag = value == (this._sign_up == null);
				if (flag)
				{
					this._sign_up = (value ? new bool?(this.sign_up) : null);
				}
			}
		}

		private bool ShouldSerializesign_up()
		{
			return this.sign_upSpecified;
		}

		private void Resetsign_up()
		{
			this.sign_upSpecified = false;
		}

		[ProtoMember(13, IsRequired = false, Name = "match_type", DataFormat = DataFormat.TwosComplement)]
		public uint match_type
		{
			get
			{
				return this._match_type ?? 0U;
			}
			set
			{
				this._match_type = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool match_typeSpecified
		{
			get
			{
				return this._match_type != null;
			}
			set
			{
				bool flag = value == (this._match_type == null);
				if (flag)
				{
					this._match_type = (value ? new uint?(this.match_type) : null);
				}
			}
		}

		private bool ShouldSerializematch_type()
		{
			return this.match_typeSpecified;
		}

		private void Resetmatch_type()
		{
			this.match_typeSpecified = false;
		}

		[ProtoMember(14, Name = "items", DataFormat = DataFormat.Default)]
		public List<ItemBrief> items
		{
			get
			{
				return this._items;
			}
		}

		[ProtoMember(15, IsRequired = false, Name = "sign_up_num", DataFormat = DataFormat.TwosComplement)]
		public uint sign_up_num
		{
			get
			{
				return this._sign_up_num ?? 0U;
			}
			set
			{
				this._sign_up_num = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool sign_up_numSpecified
		{
			get
			{
				return this._sign_up_num != null;
			}
			set
			{
				bool flag = value == (this._sign_up_num == null);
				if (flag)
				{
					this._sign_up_num = (value ? new uint?(this.sign_up_num) : null);
				}
			}
		}

		private bool ShouldSerializesign_up_num()
		{
			return this.sign_up_numSpecified;
		}

		private void Resetsign_up_num()
		{
			this.sign_up_numSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _errorcode;

		private CardMatchOp? _op;

		private uint? _timeleft;

		private uint? _changecount;

		private uint? _round;

		private uint? _result;

		private readonly List<uint> _cards = new List<uint>();

		private bool? _iscanbegin;

		private bool? _isbegin;

		private CardMatchState? _state;

		private uint? _store;

		private bool? _sign_up;

		private uint? _match_type;

		private readonly List<ItemBrief> _items = new List<ItemBrief>();

		private uint? _sign_up_num;

		private IExtension extensionObject;
	}
}
