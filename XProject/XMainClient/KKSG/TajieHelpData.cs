using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "TajieHelpData")]
	[Serializable]
	public class TajieHelpData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "sceneID", DataFormat = DataFormat.TwosComplement)]
		public int sceneID
		{
			get
			{
				return this._sceneID ?? 0;
			}
			set
			{
				this._sceneID = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool sceneIDSpecified
		{
			get
			{
				return this._sceneID != null;
			}
			set
			{
				bool flag = value == (this._sceneID == null);
				if (flag)
				{
					this._sceneID = (value ? new int?(this.sceneID) : null);
				}
			}
		}

		private bool ShouldSerializesceneID()
		{
			return this.sceneIDSpecified;
		}

		private void ResetsceneID()
		{
			this.sceneIDSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "sceneType", DataFormat = DataFormat.TwosComplement)]
		public int sceneType
		{
			get
			{
				return this._sceneType ?? 0;
			}
			set
			{
				this._sceneType = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool sceneTypeSpecified
		{
			get
			{
				return this._sceneType != null;
			}
			set
			{
				bool flag = value == (this._sceneType == null);
				if (flag)
				{
					this._sceneType = (value ? new int?(this.sceneType) : null);
				}
			}
		}

		private bool ShouldSerializesceneType()
		{
			return this.sceneTypeSpecified;
		}

		private void ResetsceneType()
		{
			this.sceneTypeSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "dragonStatus", DataFormat = DataFormat.TwosComplement)]
		public int dragonStatus
		{
			get
			{
				return this._dragonStatus ?? 0;
			}
			set
			{
				this._dragonStatus = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool dragonStatusSpecified
		{
			get
			{
				return this._dragonStatus != null;
			}
			set
			{
				bool flag = value == (this._dragonStatus == null);
				if (flag)
				{
					this._dragonStatus = (value ? new int?(this.dragonStatus) : null);
				}
			}
		}

		private bool ShouldSerializedragonStatus()
		{
			return this.dragonStatusSpecified;
		}

		private void ResetdragonStatus()
		{
			this.dragonStatusSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "dragonWeakLeftTime", DataFormat = DataFormat.TwosComplement)]
		public int dragonWeakLeftTime
		{
			get
			{
				return this._dragonWeakLeftTime ?? 0;
			}
			set
			{
				this._dragonWeakLeftTime = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool dragonWeakLeftTimeSpecified
		{
			get
			{
				return this._dragonWeakLeftTime != null;
			}
			set
			{
				bool flag = value == (this._dragonWeakLeftTime == null);
				if (flag)
				{
					this._dragonWeakLeftTime = (value ? new int?(this.dragonWeakLeftTime) : null);
				}
			}
		}

		private bool ShouldSerializedragonWeakLeftTime()
		{
			return this.dragonWeakLeftTimeSpecified;
		}

		private void ResetdragonWeakLeftTime()
		{
			this.dragonWeakLeftTimeSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "isIconAppear", DataFormat = DataFormat.Default)]
		public bool isIconAppear
		{
			get
			{
				return this._isIconAppear ?? false;
			}
			set
			{
				this._isIconAppear = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isIconAppearSpecified
		{
			get
			{
				return this._isIconAppear != null;
			}
			set
			{
				bool flag = value == (this._isIconAppear == null);
				if (flag)
				{
					this._isIconAppear = (value ? new bool?(this.isIconAppear) : null);
				}
			}
		}

		private bool ShouldSerializeisIconAppear()
		{
			return this.isIconAppearSpecified;
		}

		private void ResetisIconAppear()
		{
			this.isIconAppearSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _sceneID;

		private int? _sceneType;

		private int? _dragonStatus;

		private int? _dragonWeakLeftTime;

		private bool? _isIconAppear;

		private IExtension extensionObject;
	}
}
