using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "FetchDGAppRes")]
	[Serializable]
	public class FetchDGAppRes : IExtensible
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

		[ProtoMember(2, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> roleid
		{
			get
			{
				return this._roleid;
			}
		}

		[ProtoMember(3, Name = "rolename", DataFormat = DataFormat.Default)]
		public List<string> rolename
		{
			get
			{
				return this._rolename;
			}
		}

		[ProtoMember(4, Name = "ppt", DataFormat = DataFormat.TwosComplement)]
		public List<uint> ppt
		{
			get
			{
				return this._ppt;
			}
		}

		[ProtoMember(5, Name = "time", DataFormat = DataFormat.TwosComplement)]
		public List<uint> time
		{
			get
			{
				return this._time;
			}
		}

		[ProtoMember(6, Name = "level", DataFormat = DataFormat.TwosComplement)]
		public List<uint> level
		{
			get
			{
				return this._level;
			}
		}

		[ProtoMember(7, Name = "profession", DataFormat = DataFormat.TwosComplement)]
		public List<RoleType> profession
		{
			get
			{
				return this._profession;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _result;

		private readonly List<ulong> _roleid = new List<ulong>();

		private readonly List<string> _rolename = new List<string>();

		private readonly List<uint> _ppt = new List<uint>();

		private readonly List<uint> _time = new List<uint>();

		private readonly List<uint> _level = new List<uint>();

		private readonly List<RoleType> _profession = new List<RoleType>();

		private IExtension extensionObject;
	}
}
