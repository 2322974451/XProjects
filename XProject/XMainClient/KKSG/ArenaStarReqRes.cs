using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ArenaStarReqRes")]
	[Serializable]
	public class ArenaStarReqRes : IExtensible
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

		[ProtoMember(2, Name = "toproledata", DataFormat = DataFormat.Default)]
		public List<ArenaStarTopRoleData> toproledata
		{
			get
			{
				return this._toproledata;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "seasonbegintime", DataFormat = DataFormat.TwosComplement)]
		public uint seasonbegintime
		{
			get
			{
				return this._seasonbegintime ?? 0U;
			}
			set
			{
				this._seasonbegintime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool seasonbegintimeSpecified
		{
			get
			{
				return this._seasonbegintime != null;
			}
			set
			{
				bool flag = value == (this._seasonbegintime == null);
				if (flag)
				{
					this._seasonbegintime = (value ? new uint?(this.seasonbegintime) : null);
				}
			}
		}

		private bool ShouldSerializeseasonbegintime()
		{
			return this.seasonbegintimeSpecified;
		}

		private void Resetseasonbegintime()
		{
			this.seasonbegintimeSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "seasonendtime", DataFormat = DataFormat.TwosComplement)]
		public uint seasonendtime
		{
			get
			{
				return this._seasonendtime ?? 0U;
			}
			set
			{
				this._seasonendtime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool seasonendtimeSpecified
		{
			get
			{
				return this._seasonendtime != null;
			}
			set
			{
				bool flag = value == (this._seasonendtime == null);
				if (flag)
				{
					this._seasonendtime = (value ? new uint?(this.seasonendtime) : null);
				}
			}
		}

		private bool ShouldSerializeseasonendtime()
		{
			return this.seasonendtimeSpecified;
		}

		private void Resetseasonendtime()
		{
			this.seasonendtimeSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "season_num", DataFormat = DataFormat.TwosComplement)]
		public uint season_num
		{
			get
			{
				return this._season_num ?? 0U;
			}
			set
			{
				this._season_num = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool season_numSpecified
		{
			get
			{
				return this._season_num != null;
			}
			set
			{
				bool flag = value == (this._season_num == null);
				if (flag)
				{
					this._season_num = (value ? new uint?(this.season_num) : null);
				}
			}
		}

		private bool ShouldSerializeseason_num()
		{
			return this.season_numSpecified;
		}

		private void Resetseason_num()
		{
			this.season_numSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _errorcode;

		private readonly List<ArenaStarTopRoleData> _toproledata = new List<ArenaStarTopRoleData>();

		private uint? _seasonbegintime;

		private uint? _seasonendtime;

		private uint? _season_num;

		private IExtension extensionObject;
	}
}
