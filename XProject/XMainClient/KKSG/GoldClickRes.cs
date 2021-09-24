using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GoldClickRes")]
	[Serializable]
	public class GoldClickRes : IExtensible
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

		[ProtoMember(2, Name = "results", DataFormat = DataFormat.TwosComplement)]
		public List<uint> results
		{
			get
			{
				return this._results;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "freetimeleft", DataFormat = DataFormat.TwosComplement)]
		public uint freetimeleft
		{
			get
			{
				return this._freetimeleft ?? 0U;
			}
			set
			{
				this._freetimeleft = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool freetimeleftSpecified
		{
			get
			{
				return this._freetimeleft != null;
			}
			set
			{
				bool flag = value == (this._freetimeleft == null);
				if (flag)
				{
					this._freetimeleft = (value ? new uint?(this.freetimeleft) : null);
				}
			}
		}

		private bool ShouldSerializefreetimeleft()
		{
			return this.freetimeleftSpecified;
		}

		private void Resetfreetimeleft()
		{
			this.freetimeleftSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "freecount", DataFormat = DataFormat.TwosComplement)]
		public uint freecount
		{
			get
			{
				return this._freecount ?? 0U;
			}
			set
			{
				this._freecount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool freecountSpecified
		{
			get
			{
				return this._freecount != null;
			}
			set
			{
				bool flag = value == (this._freecount == null);
				if (flag)
				{
					this._freecount = (value ? new uint?(this.freecount) : null);
				}
			}
		}

		private bool ShouldSerializefreecount()
		{
			return this.freecountSpecified;
		}

		private void Resetfreecount()
		{
			this.freecountSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "freeallcount", DataFormat = DataFormat.TwosComplement)]
		public uint freeallcount
		{
			get
			{
				return this._freeallcount ?? 0U;
			}
			set
			{
				this._freeallcount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool freeallcountSpecified
		{
			get
			{
				return this._freeallcount != null;
			}
			set
			{
				bool flag = value == (this._freeallcount == null);
				if (flag)
				{
					this._freeallcount = (value ? new uint?(this.freeallcount) : null);
				}
			}
		}

		private bool ShouldSerializefreeallcount()
		{
			return this.freeallcountSpecified;
		}

		private void Resetfreeallcount()
		{
			this.freeallcountSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "count", DataFormat = DataFormat.TwosComplement)]
		public uint count
		{
			get
			{
				return this._count ?? 0U;
			}
			set
			{
				this._count = new uint?(value);
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
					this._count = (value ? new uint?(this.count) : null);
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

		[ProtoMember(7, IsRequired = false, Name = "allcount", DataFormat = DataFormat.TwosComplement)]
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _errorcode;

		private readonly List<uint> _results = new List<uint>();

		private uint? _freetimeleft;

		private uint? _freecount;

		private uint? _freeallcount;

		private uint? _count;

		private uint? _allcount;

		private IExtension extensionObject;
	}
}
