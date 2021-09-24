using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "LiveRecord")]
	[Serializable]
	public class LiveRecord : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "mostViewedRecord", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public OneLiveRecordInfo mostViewedRecord
		{
			get
			{
				return this._mostViewedRecord;
			}
			set
			{
				this._mostViewedRecord = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "mostCommendedRecord", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public OneLiveRecordInfo mostCommendedRecord
		{
			get
			{
				return this._mostCommendedRecord;
			}
			set
			{
				this._mostCommendedRecord = value;
			}
		}

		[ProtoMember(3, Name = "recentRecords", DataFormat = DataFormat.Default)]
		public List<OneLiveRecordInfo> recentRecords
		{
			get
			{
				return this._recentRecords;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "myTotalCommendedNum", DataFormat = DataFormat.TwosComplement)]
		public uint myTotalCommendedNum
		{
			get
			{
				return this._myTotalCommendedNum ?? 0U;
			}
			set
			{
				this._myTotalCommendedNum = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool myTotalCommendedNumSpecified
		{
			get
			{
				return this._myTotalCommendedNum != null;
			}
			set
			{
				bool flag = value == (this._myTotalCommendedNum == null);
				if (flag)
				{
					this._myTotalCommendedNum = (value ? new uint?(this.myTotalCommendedNum) : null);
				}
			}
		}

		private bool ShouldSerializemyTotalCommendedNum()
		{
			return this.myTotalCommendedNumSpecified;
		}

		private void ResetmyTotalCommendedNum()
		{
			this.myTotalCommendedNumSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "myTotalViewedNum", DataFormat = DataFormat.TwosComplement)]
		public uint myTotalViewedNum
		{
			get
			{
				return this._myTotalViewedNum ?? 0U;
			}
			set
			{
				this._myTotalViewedNum = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool myTotalViewedNumSpecified
		{
			get
			{
				return this._myTotalViewedNum != null;
			}
			set
			{
				bool flag = value == (this._myTotalViewedNum == null);
				if (flag)
				{
					this._myTotalViewedNum = (value ? new uint?(this.myTotalViewedNum) : null);
				}
			}
		}

		private bool ShouldSerializemyTotalViewedNum()
		{
			return this.myTotalViewedNumSpecified;
		}

		private void ResetmyTotalViewedNum()
		{
			this.myTotalViewedNumSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "livevisible", DataFormat = DataFormat.Default)]
		public bool livevisible
		{
			get
			{
				return this._livevisible ?? false;
			}
			set
			{
				this._livevisible = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool livevisibleSpecified
		{
			get
			{
				return this._livevisible != null;
			}
			set
			{
				bool flag = value == (this._livevisible == null);
				if (flag)
				{
					this._livevisible = (value ? new bool?(this.livevisible) : null);
				}
			}
		}

		private bool ShouldSerializelivevisible()
		{
			return this.livevisibleSpecified;
		}

		private void Resetlivevisible()
		{
			this.livevisibleSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private OneLiveRecordInfo _mostViewedRecord = null;

		private OneLiveRecordInfo _mostCommendedRecord = null;

		private readonly List<OneLiveRecordInfo> _recentRecords = new List<OneLiveRecordInfo>();

		private uint? _myTotalCommendedNum;

		private uint? _myTotalViewedNum;

		private bool? _livevisible;

		private IExtension extensionObject;
	}
}
