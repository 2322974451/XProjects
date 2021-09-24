using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "DailyTaskAskHelpArg")]
	[Serializable]
	public class DailyTaskAskHelpArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "task_id", DataFormat = DataFormat.TwosComplement)]
		public uint task_id
		{
			get
			{
				return this._task_id ?? 0U;
			}
			set
			{
				this._task_id = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool task_idSpecified
		{
			get
			{
				return this._task_id != null;
			}
			set
			{
				bool flag = value == (this._task_id == null);
				if (flag)
				{
					this._task_id = (value ? new uint?(this.task_id) : null);
				}
			}
		}

		private bool ShouldSerializetask_id()
		{
			return this.task_idSpecified;
		}

		private void Resettask_id()
		{
			this.task_idSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "task_type", DataFormat = DataFormat.TwosComplement)]
		public PeriodTaskType task_type
		{
			get
			{
				return this._task_type ?? PeriodTaskType.PeriodTaskType_Daily;
			}
			set
			{
				this._task_type = new PeriodTaskType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool task_typeSpecified
		{
			get
			{
				return this._task_type != null;
			}
			set
			{
				bool flag = value == (this._task_type == null);
				if (flag)
				{
					this._task_type = (value ? new PeriodTaskType?(this.task_type) : null);
				}
			}
		}

		private bool ShouldSerializetask_type()
		{
			return this.task_typeSpecified;
		}

		private void Resettask_type()
		{
			this.task_typeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _task_id;

		private PeriodTaskType? _task_type;

		private IExtension extensionObject;
	}
}
