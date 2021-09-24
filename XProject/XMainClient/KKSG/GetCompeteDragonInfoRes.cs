using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetCompeteDragonInfoRes")]
	[Serializable]
	public class GetCompeteDragonInfoRes : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "leftRewardCount", DataFormat = DataFormat.TwosComplement)]
		public int leftRewardCount
		{
			get
			{
				return this._leftRewardCount ?? 0;
			}
			set
			{
				this._leftRewardCount = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool leftRewardCountSpecified
		{
			get
			{
				return this._leftRewardCount != null;
			}
			set
			{
				bool flag = value == (this._leftRewardCount == null);
				if (flag)
				{
					this._leftRewardCount = (value ? new int?(this.leftRewardCount) : null);
				}
			}
		}

		private bool ShouldSerializeleftRewardCount()
		{
			return this.leftRewardCountSpecified;
		}

		private void ResetleftRewardCount()
		{
			this.leftRewardCountSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "totalRewardCount", DataFormat = DataFormat.TwosComplement)]
		public int totalRewardCount
		{
			get
			{
				return this._totalRewardCount ?? 0;
			}
			set
			{
				this._totalRewardCount = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool totalRewardCountSpecified
		{
			get
			{
				return this._totalRewardCount != null;
			}
			set
			{
				bool flag = value == (this._totalRewardCount == null);
				if (flag)
				{
					this._totalRewardCount = (value ? new int?(this.totalRewardCount) : null);
				}
			}
		}

		private bool ShouldSerializetotalRewardCount()
		{
			return this.totalRewardCountSpecified;
		}

		private void ResettotalRewardCount()
		{
			this.totalRewardCountSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "canCanGetRewardCount", DataFormat = DataFormat.TwosComplement)]
		public int canCanGetRewardCount
		{
			get
			{
				return this._canCanGetRewardCount ?? 0;
			}
			set
			{
				this._canCanGetRewardCount = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool canCanGetRewardCountSpecified
		{
			get
			{
				return this._canCanGetRewardCount != null;
			}
			set
			{
				bool flag = value == (this._canCanGetRewardCount == null);
				if (flag)
				{
					this._canCanGetRewardCount = (value ? new int?(this.canCanGetRewardCount) : null);
				}
			}
		}

		private bool ShouldSerializecanCanGetRewardCount()
		{
			return this.canCanGetRewardCountSpecified;
		}

		private void ResetcanCanGetRewardCount()
		{
			this.canCanGetRewardCountSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "curDNExpID", DataFormat = DataFormat.TwosComplement)]
		public uint curDNExpID
		{
			get
			{
				return this._curDNExpID ?? 0U;
			}
			set
			{
				this._curDNExpID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool curDNExpIDSpecified
		{
			get
			{
				return this._curDNExpID != null;
			}
			set
			{
				bool flag = value == (this._curDNExpID == null);
				if (flag)
				{
					this._curDNExpID = (value ? new uint?(this.curDNExpID) : null);
				}
			}
		}

		private bool ShouldSerializecurDNExpID()
		{
			return this.curDNExpIDSpecified;
		}

		private void ResetcurDNExpID()
		{
			this.curDNExpIDSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _error;

		private int? _leftRewardCount;

		private int? _totalRewardCount;

		private int? _canCanGetRewardCount;

		private uint? _curDNExpID;

		private IExtension extensionObject;
	}
}
