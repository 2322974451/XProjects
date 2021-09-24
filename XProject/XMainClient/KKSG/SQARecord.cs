using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SQARecord")]
	[Serializable]
	public class SQARecord : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "cur_qa_type", DataFormat = DataFormat.TwosComplement)]
		public uint cur_qa_type
		{
			get
			{
				return this._cur_qa_type ?? 0U;
			}
			set
			{
				this._cur_qa_type = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool cur_qa_typeSpecified
		{
			get
			{
				return this._cur_qa_type != null;
			}
			set
			{
				bool flag = value == (this._cur_qa_type == null);
				if (flag)
				{
					this._cur_qa_type = (value ? new uint?(this.cur_qa_type) : null);
				}
			}
		}

		private bool ShouldSerializecur_qa_type()
		{
			return this.cur_qa_typeSpecified;
		}

		private void Resetcur_qa_type()
		{
			this.cur_qa_typeSpecified = false;
		}

		[ProtoMember(2, Name = "trigger_time", DataFormat = DataFormat.Default)]
		public List<MapKeyValue> trigger_time
		{
			get
			{
				return this._trigger_time;
			}
		}

		[ProtoMember(3, Name = "used_count", DataFormat = DataFormat.Default)]
		public List<MapKeyValue> used_count
		{
			get
			{
				return this._used_count;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "last_reset_time", DataFormat = DataFormat.TwosComplement)]
		public uint last_reset_time
		{
			get
			{
				return this._last_reset_time ?? 0U;
			}
			set
			{
				this._last_reset_time = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool last_reset_timeSpecified
		{
			get
			{
				return this._last_reset_time != null;
			}
			set
			{
				bool flag = value == (this._last_reset_time == null);
				if (flag)
				{
					this._last_reset_time = (value ? new uint?(this.last_reset_time) : null);
				}
			}
		}

		private bool ShouldSerializelast_reset_time()
		{
			return this.last_reset_timeSpecified;
		}

		private void Resetlast_reset_time()
		{
			this.last_reset_timeSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "last_end_time", DataFormat = DataFormat.TwosComplement)]
		public uint last_end_time
		{
			get
			{
				return this._last_end_time ?? 0U;
			}
			set
			{
				this._last_end_time = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool last_end_timeSpecified
		{
			get
			{
				return this._last_end_time != null;
			}
			set
			{
				bool flag = value == (this._last_end_time == null);
				if (flag)
				{
					this._last_end_time = (value ? new uint?(this.last_end_time) : null);
				}
			}
		}

		private bool ShouldSerializelast_end_time()
		{
			return this.last_end_timeSpecified;
		}

		private void Resetlast_end_time()
		{
			this.last_end_timeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _cur_qa_type;

		private readonly List<MapKeyValue> _trigger_time = new List<MapKeyValue>();

		private readonly List<MapKeyValue> _used_count = new List<MapKeyValue>();

		private uint? _last_reset_time;

		private uint? _last_end_time;

		private IExtension extensionObject;
	}
}
