using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetMyWatchRecordRes")]
	[Serializable]
	public class GetMyWatchRecordRes : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "myCommendedNum", DataFormat = DataFormat.TwosComplement)]
		public int myCommendedNum
		{
			get
			{
				return this._myCommendedNum ?? 0;
			}
			set
			{
				this._myCommendedNum = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool myCommendedNumSpecified
		{
			get
			{
				return this._myCommendedNum != null;
			}
			set
			{
				bool flag = value == (this._myCommendedNum == null);
				if (flag)
				{
					this._myCommendedNum = (value ? new int?(this.myCommendedNum) : null);
				}
			}
		}

		private bool ShouldSerializemyCommendedNum()
		{
			return this.myCommendedNumSpecified;
		}

		private void ResetmyCommendedNum()
		{
			this.myCommendedNumSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "myWatchedNum", DataFormat = DataFormat.TwosComplement)]
		public int myWatchedNum
		{
			get
			{
				return this._myWatchedNum ?? 0;
			}
			set
			{
				this._myWatchedNum = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool myWatchedNumSpecified
		{
			get
			{
				return this._myWatchedNum != null;
			}
			set
			{
				bool flag = value == (this._myWatchedNum == null);
				if (flag)
				{
					this._myWatchedNum = (value ? new int?(this.myWatchedNum) : null);
				}
			}
		}

		private bool ShouldSerializemyWatchedNum()
		{
			return this.myWatchedNumSpecified;
		}

		private void ResetmyWatchedNum()
		{
			this.myWatchedNumSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "myMostWatchedRecord", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public OneLiveRecordInfo myMostWatchedRecord
		{
			get
			{
				return this._myMostWatchedRecord;
			}
			set
			{
				this._myMostWatchedRecord = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "myMostCommendedRecord", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public OneLiveRecordInfo myMostCommendedRecord
		{
			get
			{
				return this._myMostCommendedRecord;
			}
			set
			{
				this._myMostCommendedRecord = value;
			}
		}

		[ProtoMember(6, Name = "myRecentRecords", DataFormat = DataFormat.Default)]
		public List<OneLiveRecordInfo> myRecentRecords
		{
			get
			{
				return this._myRecentRecords;
			}
		}

		[ProtoMember(7, IsRequired = false, Name = "visibleSetting", DataFormat = DataFormat.Default)]
		public bool visibleSetting
		{
			get
			{
				return this._visibleSetting ?? false;
			}
			set
			{
				this._visibleSetting = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool visibleSettingSpecified
		{
			get
			{
				return this._visibleSetting != null;
			}
			set
			{
				bool flag = value == (this._visibleSetting == null);
				if (flag)
				{
					this._visibleSetting = (value ? new bool?(this.visibleSetting) : null);
				}
			}
		}

		private bool ShouldSerializevisibleSetting()
		{
			return this.visibleSettingSpecified;
		}

		private void ResetvisibleSetting()
		{
			this.visibleSettingSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _error;

		private int? _myCommendedNum;

		private int? _myWatchedNum;

		private OneLiveRecordInfo _myMostWatchedRecord = null;

		private OneLiveRecordInfo _myMostCommendedRecord = null;

		private readonly List<OneLiveRecordInfo> _myRecentRecords = new List<OneLiveRecordInfo>();

		private bool? _visibleSetting;

		private IExtension extensionObject;
	}
}
