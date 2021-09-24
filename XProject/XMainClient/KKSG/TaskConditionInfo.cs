using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "TaskConditionInfo")]
	[Serializable]
	public class TaskConditionInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public TaskConnType type
		{
			get
			{
				return this._type ?? TaskConnType.TaskConn_ItemID;
			}
			set
			{
				this._type = new TaskConnType?(value);
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
					this._type = (value ? new TaskConnType?(this.type) : null);
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

		[ProtoMember(2, IsRequired = false, Name = "id", DataFormat = DataFormat.TwosComplement)]
		public uint id
		{
			get
			{
				return this._id ?? 0U;
			}
			set
			{
				this._id = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool idSpecified
		{
			get
			{
				return this._id != null;
			}
			set
			{
				bool flag = value == (this._id == null);
				if (flag)
				{
					this._id = (value ? new uint?(this.id) : null);
				}
			}
		}

		private bool ShouldSerializeid()
		{
			return this.idSpecified;
		}

		private void Resetid()
		{
			this.idSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "step", DataFormat = DataFormat.TwosComplement)]
		public uint step
		{
			get
			{
				return this._step ?? 0U;
			}
			set
			{
				this._step = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool stepSpecified
		{
			get
			{
				return this._step != null;
			}
			set
			{
				bool flag = value == (this._step == null);
				if (flag)
				{
					this._step = (value ? new uint?(this.step) : null);
				}
			}
		}

		private bool ShouldSerializestep()
		{
			return this.stepSpecified;
		}

		private void Resetstep()
		{
			this.stepSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "max_step", DataFormat = DataFormat.TwosComplement)]
		public uint max_step
		{
			get
			{
				return this._max_step ?? 0U;
			}
			set
			{
				this._max_step = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool max_stepSpecified
		{
			get
			{
				return this._max_step != null;
			}
			set
			{
				bool flag = value == (this._max_step == null);
				if (flag)
				{
					this._max_step = (value ? new uint?(this.max_step) : null);
				}
			}
		}

		private bool ShouldSerializemax_step()
		{
			return this.max_stepSpecified;
		}

		private void Resetmax_step()
		{
			this.max_stepSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private TaskConnType? _type;

		private uint? _id;

		private uint? _step;

		private uint? _max_step;

		private IExtension extensionObject;
	}
}
