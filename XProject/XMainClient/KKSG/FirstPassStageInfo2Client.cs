using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "FirstPassStageInfo2Client")]
	[Serializable]
	public class FirstPassStageInfo2Client : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "firstPassID", DataFormat = DataFormat.TwosComplement)]
		public int firstPassID
		{
			get
			{
				return this._firstPassID ?? 0;
			}
			set
			{
				this._firstPassID = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool firstPassIDSpecified
		{
			get
			{
				return this._firstPassID != null;
			}
			set
			{
				bool flag = value == (this._firstPassID == null);
				if (flag)
				{
					this._firstPassID = (value ? new int?(this.firstPassID) : null);
				}
			}
		}

		private bool ShouldSerializefirstPassID()
		{
			return this.firstPassIDSpecified;
		}

		private void ResetfirstPassID()
		{
			this.firstPassIDSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "isGetReward", DataFormat = DataFormat.Default)]
		public bool isGetReward
		{
			get
			{
				return this._isGetReward ?? false;
			}
			set
			{
				this._isGetReward = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isGetRewardSpecified
		{
			get
			{
				return this._isGetReward != null;
			}
			set
			{
				bool flag = value == (this._isGetReward == null);
				if (flag)
				{
					this._isGetReward = (value ? new bool?(this.isGetReward) : null);
				}
			}
		}

		private bool ShouldSerializeisGetReward()
		{
			return this.isGetRewardSpecified;
		}

		private void ResetisGetReward()
		{
			this.isGetRewardSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "myRank", DataFormat = DataFormat.TwosComplement)]
		public int myRank
		{
			get
			{
				return this._myRank ?? 0;
			}
			set
			{
				this._myRank = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool myRankSpecified
		{
			get
			{
				return this._myRank != null;
			}
			set
			{
				bool flag = value == (this._myRank == null);
				if (flag)
				{
					this._myRank = (value ? new int?(this.myRank) : null);
				}
			}
		}

		private bool ShouldSerializemyRank()
		{
			return this.myRankSpecified;
		}

		private void ResetmyRank()
		{
			this.myRankSpecified = false;
		}

		[ProtoMember(4, IsRequired = true, Name = "totalRank", DataFormat = DataFormat.TwosComplement)]
		public int totalRank
		{
			get
			{
				return this._totalRank;
			}
			set
			{
				this._totalRank = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "hasCommended", DataFormat = DataFormat.Default)]
		public bool hasCommended
		{
			get
			{
				return this._hasCommended ?? false;
			}
			set
			{
				this._hasCommended = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool hasCommendedSpecified
		{
			get
			{
				return this._hasCommended != null;
			}
			set
			{
				bool flag = value == (this._hasCommended == null);
				if (flag)
				{
					this._hasCommended = (value ? new bool?(this.hasCommended) : null);
				}
			}
		}

		private bool ShouldSerializehasCommended()
		{
			return this.hasCommendedSpecified;
		}

		private void ResethasCommended()
		{
			this.hasCommendedSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _firstPassID;

		private bool? _isGetReward;

		private int? _myRank;

		private int _totalRank;

		private bool? _hasCommended;

		private IExtension extensionObject;
	}
}
