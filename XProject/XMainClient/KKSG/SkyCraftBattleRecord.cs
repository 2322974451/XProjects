using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SkyCraftBattleRecord")]
	[Serializable]
	public class SkyCraftBattleRecord : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "other_teamid", DataFormat = DataFormat.TwosComplement)]
		public ulong other_teamid
		{
			get
			{
				return this._other_teamid ?? 0UL;
			}
			set
			{
				this._other_teamid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool other_teamidSpecified
		{
			get
			{
				return this._other_teamid != null;
			}
			set
			{
				bool flag = value == (this._other_teamid == null);
				if (flag)
				{
					this._other_teamid = (value ? new ulong?(this.other_teamid) : null);
				}
			}
		}

		private bool ShouldSerializeother_teamid()
		{
			return this.other_teamidSpecified;
		}

		private void Resetother_teamid()
		{
			this.other_teamidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "other_name", DataFormat = DataFormat.Default)]
		public string other_name
		{
			get
			{
				return this._other_name ?? "";
			}
			set
			{
				this._other_name = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool other_nameSpecified
		{
			get
			{
				return this._other_name != null;
			}
			set
			{
				bool flag = value == (this._other_name == null);
				if (flag)
				{
					this._other_name = (value ? this.other_name : null);
				}
			}
		}

		private bool ShouldSerializeother_name()
		{
			return this.other_nameSpecified;
		}

		private void Resetother_name()
		{
			this.other_nameSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "score_change", DataFormat = DataFormat.TwosComplement)]
		public int score_change
		{
			get
			{
				return this._score_change ?? 0;
			}
			set
			{
				this._score_change = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool score_changeSpecified
		{
			get
			{
				return this._score_change != null;
			}
			set
			{
				bool flag = value == (this._score_change == null);
				if (flag)
				{
					this._score_change = (value ? new int?(this.score_change) : null);
				}
			}
		}

		private bool ShouldSerializescore_change()
		{
			return this.score_changeSpecified;
		}

		private void Resetscore_change()
		{
			this.score_changeSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
		public PkResultType result
		{
			get
			{
				return this._result ?? PkResultType.PkResult_Win;
			}
			set
			{
				this._result = new PkResultType?(value);
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
					this._result = (value ? new PkResultType?(this.result) : null);
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

		[ProtoMember(5, IsRequired = false, Name = "time", DataFormat = DataFormat.TwosComplement)]
		public uint time
		{
			get
			{
				return this._time ?? 0U;
			}
			set
			{
				this._time = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool timeSpecified
		{
			get
			{
				return this._time != null;
			}
			set
			{
				bool flag = value == (this._time == null);
				if (flag)
				{
					this._time = (value ? new uint?(this.time) : null);
				}
			}
		}

		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		private void Resettime()
		{
			this.timeSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public SkyCraftType type
		{
			get
			{
				return this._type ?? SkyCraftType.SCT_RacePoint;
			}
			set
			{
				this._type = new SkyCraftType?(value);
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
					this._type = (value ? new SkyCraftType?(this.type) : null);
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _other_teamid;

		private string _other_name;

		private int? _score_change;

		private PkResultType? _result;

		private uint? _time;

		private SkyCraftType? _type;

		private IExtension extensionObject;
	}
}
