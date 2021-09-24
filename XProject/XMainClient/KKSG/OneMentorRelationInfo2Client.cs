using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "OneMentorRelationInfo2Client")]
	[Serializable]
	public class OneMentorRelationInfo2Client : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "roleInfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public RoleBriefInfo roleInfo
		{
			get
			{
				return this._roleInfo;
			}
			set
			{
				this._roleInfo = value;
			}
		}

		[ProtoMember(2, Name = "relationlist", DataFormat = DataFormat.Default)]
		public List<MentorRelationStatusData> relationlist
		{
			get
			{
				return this._relationlist;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "pos", DataFormat = DataFormat.TwosComplement)]
		public int pos
		{
			get
			{
				return this._pos ?? 0;
			}
			set
			{
				this._pos = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool posSpecified
		{
			get
			{
				return this._pos != null;
			}
			set
			{
				bool flag = value == (this._pos == null);
				if (flag)
				{
					this._pos = (value ? new int?(this.pos) : null);
				}
			}
		}

		private bool ShouldSerializepos()
		{
			return this.posSpecified;
		}

		private void Resetpos()
		{
			this.posSpecified = false;
		}

		[ProtoMember(4, Name = "studentTaskList", DataFormat = DataFormat.Default)]
		public List<OneMentorTaskInfo> studentTaskList
		{
			get
			{
				return this._studentTaskList;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "inheritStatus", DataFormat = DataFormat.TwosComplement)]
		public EMentorTaskStatus inheritStatus
		{
			get
			{
				return this._inheritStatus ?? EMentorTaskStatus.EMentorTask_UnComplete;
			}
			set
			{
				this._inheritStatus = new EMentorTaskStatus?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool inheritStatusSpecified
		{
			get
			{
				return this._inheritStatus != null;
			}
			set
			{
				bool flag = value == (this._inheritStatus == null);
				if (flag)
				{
					this._inheritStatus = (value ? new EMentorTaskStatus?(this.inheritStatus) : null);
				}
			}
		}

		private bool ShouldSerializeinheritStatus()
		{
			return this.inheritStatusSpecified;
		}

		private void ResetinheritStatus()
		{
			this.inheritStatusSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "inheritApplyRoleID", DataFormat = DataFormat.TwosComplement)]
		public ulong inheritApplyRoleID
		{
			get
			{
				return this._inheritApplyRoleID ?? 0UL;
			}
			set
			{
				this._inheritApplyRoleID = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool inheritApplyRoleIDSpecified
		{
			get
			{
				return this._inheritApplyRoleID != null;
			}
			set
			{
				bool flag = value == (this._inheritApplyRoleID == null);
				if (flag)
				{
					this._inheritApplyRoleID = (value ? new ulong?(this.inheritApplyRoleID) : null);
				}
			}
		}

		private bool ShouldSerializeinheritApplyRoleID()
		{
			return this.inheritApplyRoleIDSpecified;
		}

		private void ResetinheritApplyRoleID()
		{
			this.inheritApplyRoleIDSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "curStatus", DataFormat = DataFormat.TwosComplement)]
		public MentorRelationStatus curStatus
		{
			get
			{
				return this._curStatus ?? MentorRelationStatus.MentorRelationIn;
			}
			set
			{
				this._curStatus = new MentorRelationStatus?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool curStatusSpecified
		{
			get
			{
				return this._curStatus != null;
			}
			set
			{
				bool flag = value == (this._curStatus == null);
				if (flag)
				{
					this._curStatus = (value ? new MentorRelationStatus?(this.curStatus) : null);
				}
			}
		}

		private bool ShouldSerializecurStatus()
		{
			return this.curStatusSpecified;
		}

		private void ResetcurStatus()
		{
			this.curStatusSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "breakApplyRoleID", DataFormat = DataFormat.TwosComplement)]
		public ulong breakApplyRoleID
		{
			get
			{
				return this._breakApplyRoleID ?? 0UL;
			}
			set
			{
				this._breakApplyRoleID = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool breakApplyRoleIDSpecified
		{
			get
			{
				return this._breakApplyRoleID != null;
			}
			set
			{
				bool flag = value == (this._breakApplyRoleID == null);
				if (flag)
				{
					this._breakApplyRoleID = (value ? new ulong?(this.breakApplyRoleID) : null);
				}
			}
		}

		private bool ShouldSerializebreakApplyRoleID()
		{
			return this.breakApplyRoleIDSpecified;
		}

		private void ResetbreakApplyRoleID()
		{
			this.breakApplyRoleIDSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private RoleBriefInfo _roleInfo = null;

		private readonly List<MentorRelationStatusData> _relationlist = new List<MentorRelationStatusData>();

		private int? _pos;

		private readonly List<OneMentorTaskInfo> _studentTaskList = new List<OneMentorTaskInfo>();

		private EMentorTaskStatus? _inheritStatus;

		private ulong? _inheritApplyRoleID;

		private MentorRelationStatus? _curStatus;

		private ulong? _breakApplyRoleID;

		private IExtension extensionObject;
	}
}
