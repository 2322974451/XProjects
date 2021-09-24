using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetMyRiftInfoRes")]
	[Serializable]
	public class GetMyRiftInfoRes : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "curRiftID", DataFormat = DataFormat.TwosComplement)]
		public int curRiftID
		{
			get
			{
				return this._curRiftID ?? 0;
			}
			set
			{
				this._curRiftID = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool curRiftIDSpecified
		{
			get
			{
				return this._curRiftID != null;
			}
			set
			{
				bool flag = value == (this._curRiftID == null);
				if (flag)
				{
					this._curRiftID = (value ? new int?(this.curRiftID) : null);
				}
			}
		}

		private bool ShouldSerializecurRiftID()
		{
			return this.curRiftIDSpecified;
		}

		private void ResetcurRiftID()
		{
			this.curRiftIDSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "curRiftFloor", DataFormat = DataFormat.TwosComplement)]
		public int curRiftFloor
		{
			get
			{
				return this._curRiftFloor ?? 0;
			}
			set
			{
				this._curRiftFloor = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool curRiftFloorSpecified
		{
			get
			{
				return this._curRiftFloor != null;
			}
			set
			{
				bool flag = value == (this._curRiftFloor == null);
				if (flag)
				{
					this._curRiftFloor = (value ? new int?(this.curRiftFloor) : null);
				}
			}
		}

		private bool ShouldSerializecurRiftFloor()
		{
			return this.curRiftFloorSpecified;
		}

		private void ResetcurRiftFloor()
		{
			this.curRiftFloorSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "curSceneID", DataFormat = DataFormat.TwosComplement)]
		public int curSceneID
		{
			get
			{
				return this._curSceneID ?? 0;
			}
			set
			{
				this._curSceneID = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool curSceneIDSpecified
		{
			get
			{
				return this._curSceneID != null;
			}
			set
			{
				bool flag = value == (this._curSceneID == null);
				if (flag)
				{
					this._curSceneID = (value ? new int?(this.curSceneID) : null);
				}
			}
		}

		private bool ShouldSerializecurSceneID()
		{
			return this.curSceneIDSpecified;
		}

		private void ResetcurSceneID()
		{
			this.curSceneIDSpecified = false;
		}

		[ProtoMember(5, Name = "buffIDs", DataFormat = DataFormat.Default)]
		public List<Buff> buffIDs
		{
			get
			{
				return this._buffIDs;
			}
		}

		[ProtoMember(6, Name = "gotItemsCount", DataFormat = DataFormat.Default)]
		public List<MapIntItem> gotItemsCount
		{
			get
			{
				return this._gotItemsCount;
			}
		}

		[ProtoMember(7, IsRequired = false, Name = "isInActiviyTime", DataFormat = DataFormat.Default)]
		public bool isInActiviyTime
		{
			get
			{
				return this._isInActiviyTime ?? false;
			}
			set
			{
				this._isInActiviyTime = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isInActiviyTimeSpecified
		{
			get
			{
				return this._isInActiviyTime != null;
			}
			set
			{
				bool flag = value == (this._isInActiviyTime == null);
				if (flag)
				{
					this._isInActiviyTime = (value ? new bool?(this.isInActiviyTime) : null);
				}
			}
		}

		private bool ShouldSerializeisInActiviyTime()
		{
			return this.isInActiviyTimeSpecified;
		}

		private void ResetisInActiviyTime()
		{
			this.isInActiviyTimeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _error;

		private int? _curRiftID;

		private int? _curRiftFloor;

		private int? _curSceneID;

		private readonly List<Buff> _buffIDs = new List<Buff>();

		private readonly List<MapIntItem> _gotItemsCount = new List<MapIntItem>();

		private bool? _isInActiviyTime;

		private IExtension extensionObject;
	}
}
