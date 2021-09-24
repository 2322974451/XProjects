using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "MakePartnerResult")]
	[Serializable]
	public class MakePartnerResult : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode result
		{
			get
			{
				return this._result ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._result = new ErrorCode?(value);
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
					this._result = (value ? new ErrorCode?(this.result) : null);
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

		[ProtoMember(2, IsRequired = false, Name = "err_roleid", DataFormat = DataFormat.TwosComplement)]
		public ulong err_roleid
		{
			get
			{
				return this._err_roleid ?? 0UL;
			}
			set
			{
				this._err_roleid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool err_roleidSpecified
		{
			get
			{
				return this._err_roleid != null;
			}
			set
			{
				bool flag = value == (this._err_roleid == null);
				if (flag)
				{
					this._err_roleid = (value ? new ulong?(this.err_roleid) : null);
				}
			}
		}

		private bool ShouldSerializeerr_roleid()
		{
			return this.err_roleidSpecified;
		}

		private void Reseterr_roleid()
		{
			this.err_roleidSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "err_rolename", DataFormat = DataFormat.Default)]
		public string err_rolename
		{
			get
			{
				return this._err_rolename ?? "";
			}
			set
			{
				this._err_rolename = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool err_rolenameSpecified
		{
			get
			{
				return this._err_rolename != null;
			}
			set
			{
				bool flag = value == (this._err_rolename == null);
				if (flag)
				{
					this._err_rolename = (value ? this.err_rolename : null);
				}
			}
		}

		private bool ShouldSerializeerr_rolename()
		{
			return this.err_rolenameSpecified;
		}

		private void Reseterr_rolename()
		{
			this.err_rolenameSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "partnerid", DataFormat = DataFormat.TwosComplement)]
		public ulong partnerid
		{
			get
			{
				return this._partnerid ?? 0UL;
			}
			set
			{
				this._partnerid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool partneridSpecified
		{
			get
			{
				return this._partnerid != null;
			}
			set
			{
				bool flag = value == (this._partnerid == null);
				if (flag)
				{
					this._partnerid = (value ? new ulong?(this.partnerid) : null);
				}
			}
		}

		private bool ShouldSerializepartnerid()
		{
			return this.partneridSpecified;
		}

		private void Resetpartnerid()
		{
			this.partneridSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
		public uint level
		{
			get
			{
				return this._level ?? 0U;
			}
			set
			{
				this._level = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool levelSpecified
		{
			get
			{
				return this._level != null;
			}
			set
			{
				bool flag = value == (this._level == null);
				if (flag)
				{
					this._level = (value ? new uint?(this.level) : null);
				}
			}
		}

		private bool ShouldSerializelevel()
		{
			return this.levelSpecified;
		}

		private void Resetlevel()
		{
			this.levelSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "degree", DataFormat = DataFormat.TwosComplement)]
		public uint degree
		{
			get
			{
				return this._degree ?? 0U;
			}
			set
			{
				this._degree = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool degreeSpecified
		{
			get
			{
				return this._degree != null;
			}
			set
			{
				bool flag = value == (this._degree == null);
				if (flag)
				{
					this._degree = (value ? new uint?(this.degree) : null);
				}
			}
		}

		private bool ShouldSerializedegree()
		{
			return this.degreeSpecified;
		}

		private void Resetdegree()
		{
			this.degreeSpecified = false;
		}

		[ProtoMember(7, Name = "memberid", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> memberid
		{
			get
			{
				return this._memberid;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _result;

		private ulong? _err_roleid;

		private string _err_rolename;

		private ulong? _partnerid;

		private uint? _level;

		private uint? _degree;

		private readonly List<ulong> _memberid = new List<ulong>();

		private IExtension extensionObject;
	}
}
