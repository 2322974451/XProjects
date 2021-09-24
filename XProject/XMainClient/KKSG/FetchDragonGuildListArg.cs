using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "FetchDragonGuildListArg")]
	[Serializable]
	public class FetchDragonGuildListArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "start", DataFormat = DataFormat.TwosComplement)]
		public int start
		{
			get
			{
				return this._start ?? 0;
			}
			set
			{
				this._start = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool startSpecified
		{
			get
			{
				return this._start != null;
			}
			set
			{
				bool flag = value == (this._start == null);
				if (flag)
				{
					this._start = (value ? new int?(this.start) : null);
				}
			}
		}

		private bool ShouldSerializestart()
		{
			return this.startSpecified;
		}

		private void Resetstart()
		{
			this.startSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "count", DataFormat = DataFormat.TwosComplement)]
		public int count
		{
			get
			{
				return this._count ?? 0;
			}
			set
			{
				this._count = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool countSpecified
		{
			get
			{
				return this._count != null;
			}
			set
			{
				bool flag = value == (this._count == null);
				if (flag)
				{
					this._count = (value ? new int?(this.count) : null);
				}
			}
		}

		private bool ShouldSerializecount()
		{
			return this.countSpecified;
		}

		private void Resetcount()
		{
			this.countSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "reason", DataFormat = DataFormat.TwosComplement)]
		public int reason
		{
			get
			{
				return this._reason ?? 0;
			}
			set
			{
				this._reason = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool reasonSpecified
		{
			get
			{
				return this._reason != null;
			}
			set
			{
				bool flag = value == (this._reason == null);
				if (flag)
				{
					this._reason = (value ? new int?(this.reason) : null);
				}
			}
		}

		private bool ShouldSerializereason()
		{
			return this.reasonSpecified;
		}

		private void Resetreason()
		{
			this.reasonSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "sortType", DataFormat = DataFormat.TwosComplement)]
		public int sortType
		{
			get
			{
				return this._sortType ?? 0;
			}
			set
			{
				this._sortType = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool sortTypeSpecified
		{
			get
			{
				return this._sortType != null;
			}
			set
			{
				bool flag = value == (this._sortType == null);
				if (flag)
				{
					this._sortType = (value ? new int?(this.sortType) : null);
				}
			}
		}

		private bool ShouldSerializesortType()
		{
			return this.sortTypeSpecified;
		}

		private void ResetsortType()
		{
			this.sortTypeSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "reverse", DataFormat = DataFormat.Default)]
		public bool reverse
		{
			get
			{
				return this._reverse ?? false;
			}
			set
			{
				this._reverse = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool reverseSpecified
		{
			get
			{
				return this._reverse != null;
			}
			set
			{
				bool flag = value == (this._reverse == null);
				if (flag)
				{
					this._reverse = (value ? new bool?(this.reverse) : null);
				}
			}
		}

		private bool ShouldSerializereverse()
		{
			return this.reverseSpecified;
		}

		private void Resetreverse()
		{
			this.reverseSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _start;

		private int? _count;

		private int? _reason;

		private int? _sortType;

		private bool? _reverse;

		private string _name;

		private IExtension extensionObject;
	}
}
