using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetMarriageRelationRes")]
	[Serializable]
	public class GetMarriageRelationRes : IExtensible
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

		[ProtoMember(2, Name = "infos", DataFormat = DataFormat.Default)]
		public List<RoleOutLookBrief> infos
		{
			get
			{
				return this._infos;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "marriageStatus", DataFormat = DataFormat.TwosComplement)]
		public MarriageStatus marriageStatus
		{
			get
			{
				return this._marriageStatus ?? MarriageStatus.MarriageStatus_Null;
			}
			set
			{
				this._marriageStatus = new MarriageStatus?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool marriageStatusSpecified
		{
			get
			{
				return this._marriageStatus != null;
			}
			set
			{
				bool flag = value == (this._marriageStatus == null);
				if (flag)
				{
					this._marriageStatus = (value ? new MarriageStatus?(this.marriageStatus) : null);
				}
			}
		}

		private bool ShouldSerializemarriageStatus()
		{
			return this.marriageStatusSpecified;
		}

		private void ResetmarriageStatus()
		{
			this.marriageStatusSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public WeddingType type
		{
			get
			{
				return this._type ?? WeddingType.WeddingType_Normal;
			}
			set
			{
				this._type = new WeddingType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new WeddingType?(this.type) : null);
				}
			}
		}

		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		private void Resettype()
		{
			this.typeSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "leftDivorceTime", DataFormat = DataFormat.TwosComplement)]
		public int leftDivorceTime
		{
			get
			{
				return this._leftDivorceTime ?? 0;
			}
			set
			{
				this._leftDivorceTime = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool leftDivorceTimeSpecified
		{
			get
			{
				return this._leftDivorceTime != null;
			}
			set
			{
				bool flag = value == (this._leftDivorceTime == null);
				if (flag)
				{
					this._leftDivorceTime = (value ? new int?(this.leftDivorceTime) : null);
				}
			}
		}

		private bool ShouldSerializeleftDivorceTime()
		{
			return this.leftDivorceTimeSpecified;
		}

		private void ResetleftDivorceTime()
		{
			this.leftDivorceTimeSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "applyDivorceID", DataFormat = DataFormat.TwosComplement)]
		public ulong applyDivorceID
		{
			get
			{
				return this._applyDivorceID ?? 0UL;
			}
			set
			{
				this._applyDivorceID = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool applyDivorceIDSpecified
		{
			get
			{
				return this._applyDivorceID != null;
			}
			set
			{
				bool flag = value == (this._applyDivorceID == null);
				if (flag)
				{
					this._applyDivorceID = (value ? new ulong?(this.applyDivorceID) : null);
				}
			}
		}

		private bool ShouldSerializeapplyDivorceID()
		{
			return this.applyDivorceIDSpecified;
		}

		private void ResetapplyDivorceID()
		{
			this.applyDivorceIDSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "coupleOfflineTime", DataFormat = DataFormat.TwosComplement)]
		public int coupleOfflineTime
		{
			get
			{
				return this._coupleOfflineTime ?? 0;
			}
			set
			{
				this._coupleOfflineTime = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool coupleOfflineTimeSpecified
		{
			get
			{
				return this._coupleOfflineTime != null;
			}
			set
			{
				bool flag = value == (this._coupleOfflineTime == null);
				if (flag)
				{
					this._coupleOfflineTime = (value ? new int?(this.coupleOfflineTime) : null);
				}
			}
		}

		private bool ShouldSerializecoupleOfflineTime()
		{
			return this.coupleOfflineTimeSpecified;
		}

		private void ResetcoupleOfflineTime()
		{
			this.coupleOfflineTimeSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "marriageLevel", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public MarriageLevelInfo marriageLevel
		{
			get
			{
				return this._marriageLevel;
			}
			set
			{
				this._marriageLevel = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _error;

		private readonly List<RoleOutLookBrief> _infos = new List<RoleOutLookBrief>();

		private MarriageStatus? _marriageStatus;

		private WeddingType? _type;

		private int? _leftDivorceTime;

		private ulong? _applyDivorceID;

		private int? _coupleOfflineTime;

		private MarriageLevelInfo _marriageLevel = null;

		private IExtension extensionObject;
	}
}
