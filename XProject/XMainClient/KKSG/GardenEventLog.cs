using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GardenEventLog")]
	[Serializable]
	public class GardenEventLog : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "role_id", DataFormat = DataFormat.TwosComplement)]
		public ulong role_id
		{
			get
			{
				return this._role_id ?? 0UL;
			}
			set
			{
				this._role_id = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool role_idSpecified
		{
			get
			{
				return this._role_id != null;
			}
			set
			{
				bool flag = value == (this._role_id == null);
				if (flag)
				{
					this._role_id = (value ? new ulong?(this.role_id) : null);
				}
			}
		}

		private bool ShouldSerializerole_id()
		{
			return this.role_idSpecified;
		}

		private void Resetrole_id()
		{
			this.role_idSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "role_name", DataFormat = DataFormat.Default)]
		public string role_name
		{
			get
			{
				return this._role_name ?? "";
			}
			set
			{
				this._role_name = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool role_nameSpecified
		{
			get
			{
				return this._role_name != null;
			}
			set
			{
				bool flag = value == (this._role_name == null);
				if (flag)
				{
					this._role_name = (value ? this.role_name : null);
				}
			}
		}

		private bool ShouldSerializerole_name()
		{
			return this.role_nameSpecified;
		}

		private void Resetrole_name()
		{
			this.role_nameSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "occur_time", DataFormat = DataFormat.TwosComplement)]
		public uint occur_time
		{
			get
			{
				return this._occur_time ?? 0U;
			}
			set
			{
				this._occur_time = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool occur_timeSpecified
		{
			get
			{
				return this._occur_time != null;
			}
			set
			{
				bool flag = value == (this._occur_time == null);
				if (flag)
				{
					this._occur_time = (value ? new uint?(this.occur_time) : null);
				}
			}
		}

		private bool ShouldSerializeoccur_time()
		{
			return this.occur_timeSpecified;
		}

		private void Resetoccur_time()
		{
			this.occur_timeSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "event_type", DataFormat = DataFormat.TwosComplement)]
		public uint event_type
		{
			get
			{
				return this._event_type ?? 0U;
			}
			set
			{
				this._event_type = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool event_typeSpecified
		{
			get
			{
				return this._event_type != null;
			}
			set
			{
				bool flag = value == (this._event_type == null);
				if (flag)
				{
					this._event_type = (value ? new uint?(this.event_type) : null);
				}
			}
		}

		private bool ShouldSerializeevent_type()
		{
			return this.event_typeSpecified;
		}

		private void Resetevent_type()
		{
			this.event_typeSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "target", DataFormat = DataFormat.TwosComplement)]
		public uint target
		{
			get
			{
				return this._target ?? 0U;
			}
			set
			{
				this._target = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool targetSpecified
		{
			get
			{
				return this._target != null;
			}
			set
			{
				bool flag = value == (this._target == null);
				if (flag)
				{
					this._target = (value ? new uint?(this.target) : null);
				}
			}
		}

		private bool ShouldSerializetarget()
		{
			return this.targetSpecified;
		}

		private void Resettarget()
		{
			this.targetSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "result", DataFormat = DataFormat.Default)]
		public bool result
		{
			get
			{
				return this._result ?? false;
			}
			set
			{
				this._result = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool resultSpecified
		{
			get
			{
				return this._result != null;
			}
			set
			{
				bool flag = value == (this._result == null);
				if (flag)
				{
					this._result = (value ? new bool?(this.result) : null);
				}
			}
		}

		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _role_id;

		private string _role_name;

		private uint? _occur_time;

		private uint? _event_type;

		private uint? _target;

		private bool? _result;

		private IExtension extensionObject;
	}
}
