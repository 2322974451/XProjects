using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "NotifyMentorApplyData")]
	[Serializable]
	public class NotifyMentorApplyData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "pos", DataFormat = DataFormat.TwosComplement)]
		public EMentorRelationPosition pos
		{
			get
			{
				return this._pos ?? EMentorRelationPosition.EMentorPosMaster;
			}
			set
			{
				this._pos = new EMentorRelationPosition?(value);
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
					this._pos = (value ? new EMentorRelationPosition?(this.pos) : null);
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

		[ProtoMember(2, IsRequired = false, Name = "hasInheritOrReportTask", DataFormat = DataFormat.Default)]
		public bool hasInheritOrReportTask
		{
			get
			{
				return this._hasInheritOrReportTask ?? false;
			}
			set
			{
				this._hasInheritOrReportTask = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool hasInheritOrReportTaskSpecified
		{
			get
			{
				return this._hasInheritOrReportTask != null;
			}
			set
			{
				bool flag = value == (this._hasInheritOrReportTask == null);
				if (flag)
				{
					this._hasInheritOrReportTask = (value ? new bool?(this.hasInheritOrReportTask) : null);
				}
			}
		}

		private bool ShouldSerializehasInheritOrReportTask()
		{
			return this.hasInheritOrReportTaskSpecified;
		}

		private void ResethasInheritOrReportTask()
		{
			this.hasInheritOrReportTaskSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "hasMsg", DataFormat = DataFormat.Default)]
		public bool hasMsg
		{
			get
			{
				return this._hasMsg ?? false;
			}
			set
			{
				this._hasMsg = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool hasMsgSpecified
		{
			get
			{
				return this._hasMsg != null;
			}
			set
			{
				bool flag = value == (this._hasMsg == null);
				if (flag)
				{
					this._hasMsg = (value ? new bool?(this.hasMsg) : null);
				}
			}
		}

		private bool ShouldSerializehasMsg()
		{
			return this.hasMsgSpecified;
		}

		private void ResethasMsg()
		{
			this.hasMsgSpecified = false;
		}

		[ProtoMember(4, Name = "appliedBreakInfos", DataFormat = DataFormat.Default)]
		public List<MentorBreakApplyInfo> appliedBreakInfos
		{
			get
			{
				return this._appliedBreakInfos;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private EMentorRelationPosition? _pos;

		private bool? _hasInheritOrReportTask;

		private bool? _hasMsg;

		private readonly List<MentorBreakApplyInfo> _appliedBreakInfos = new List<MentorBreakApplyInfo>();

		private IExtension extensionObject;
	}
}
