using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SpActivityChange")]
	[Serializable]
	public class SpActivityChange : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "actid", DataFormat = DataFormat.TwosComplement)]
		public uint actid
		{
			get
			{
				return this._actid ?? 0U;
			}
			set
			{
				this._actid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool actidSpecified
		{
			get
			{
				return this._actid != null;
			}
			set
			{
				bool flag = value == (this._actid == null);
				if (flag)
				{
					this._actid = (value ? new uint?(this.actid) : null);
				}
			}
		}

		private bool ShouldSerializeactid()
		{
			return this.actidSpecified;
		}

		private void Resetactid()
		{
			this.actidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "taskid", DataFormat = DataFormat.TwosComplement)]
		public uint taskid
		{
			get
			{
				return this._taskid ?? 0U;
			}
			set
			{
				this._taskid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool taskidSpecified
		{
			get
			{
				return this._taskid != null;
			}
			set
			{
				bool flag = value == (this._taskid == null);
				if (flag)
				{
					this._taskid = (value ? new uint?(this.taskid) : null);
				}
			}
		}

		private bool ShouldSerializetaskid()
		{
			return this.taskidSpecified;
		}

		private void Resettaskid()
		{
			this.taskidSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public uint state
		{
			get
			{
				return this._state ?? 0U;
			}
			set
			{
				this._state = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool stateSpecified
		{
			get
			{
				return this._state != null;
			}
			set
			{
				bool flag = value == (this._state == null);
				if (flag)
				{
					this._state = (value ? new uint?(this.state) : null);
				}
			}
		}

		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "progress", DataFormat = DataFormat.TwosComplement)]
		public uint progress
		{
			get
			{
				return this._progress ?? 0U;
			}
			set
			{
				this._progress = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool progressSpecified
		{
			get
			{
				return this._progress != null;
			}
			set
			{
				bool flag = value == (this._progress == null);
				if (flag)
				{
					this._progress = (value ? new uint?(this.progress) : null);
				}
			}
		}

		private bool ShouldSerializeprogress()
		{
			return this.progressSpecified;
		}

		private void Resetprogress()
		{
			this.progressSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _actid;

		private uint? _taskid;

		private uint? _state;

		private uint? _progress;

		private IExtension extensionObject;
	}
}
