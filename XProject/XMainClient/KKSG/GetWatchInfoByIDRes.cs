using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetWatchInfoByIDRes")]
	[Serializable]
	public class GetWatchInfoByIDRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "error", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode error
		{
			get
			{
				return this._error ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._error = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool errorSpecified
		{
			get
			{
				return this._error != null;
			}
			set
			{
				bool flag = value == (this._error == null);
				if (flag)
				{
					this._error = (value ? new ErrorCode?(this.error) : null);
				}
			}
		}

		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "curTime", DataFormat = DataFormat.TwosComplement)]
		public int curTime
		{
			get
			{
				return this._curTime ?? 0;
			}
			set
			{
				this._curTime = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool curTimeSpecified
		{
			get
			{
				return this._curTime != null;
			}
			set
			{
				bool flag = value == (this._curTime == null);
				if (flag)
				{
					this._curTime = (value ? new int?(this.curTime) : null);
				}
			}
		}

		private bool ShouldSerializecurTime()
		{
			return this.curTimeSpecified;
		}

		private void ResetcurTime()
		{
			this.curTimeSpecified = false;
		}

		[ProtoMember(3, Name = "liveRecords", DataFormat = DataFormat.Default)]
		public List<OneLiveRecordInfo> liveRecords
		{
			get
			{
				return this._liveRecords;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _error;

		private int? _curTime;

		private readonly List<OneLiveRecordInfo> _liveRecords = new List<OneLiveRecordInfo>();

		private IExtension extensionObject;
	}
}
