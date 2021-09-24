using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "WeeklyTaskInfo")]
	[Serializable]
	public class WeeklyTaskInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "index", DataFormat = DataFormat.TwosComplement)]
		public uint index
		{
			get
			{
				return this._index ?? 0U;
			}
			set
			{
				this._index = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool indexSpecified
		{
			get
			{
				return this._index != null;
			}
			set
			{
				bool flag = value == (this._index == null);
				if (flag)
				{
					this._index = (value ? new uint?(this.index) : null);
				}
			}
		}

		private bool ShouldSerializeindex()
		{
			return this.indexSpecified;
		}

		private void Resetindex()
		{
			this.indexSpecified = false;
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

		[ProtoMember(4, IsRequired = false, Name = "is_rewarded", DataFormat = DataFormat.Default)]
		public bool is_rewarded
		{
			get
			{
				return this._is_rewarded ?? false;
			}
			set
			{
				this._is_rewarded = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool is_rewardedSpecified
		{
			get
			{
				return this._is_rewarded != null;
			}
			set
			{
				bool flag = value == (this._is_rewarded == null);
				if (flag)
				{
					this._is_rewarded = (value ? new bool?(this.is_rewarded) : null);
				}
			}
		}

		private bool ShouldSerializeis_rewarded()
		{
			return this.is_rewardedSpecified;
		}

		private void Resetis_rewarded()
		{
			this.is_rewardedSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "ask_help", DataFormat = DataFormat.Default)]
		public bool ask_help
		{
			get
			{
				return this._ask_help ?? false;
			}
			set
			{
				this._ask_help = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool ask_helpSpecified
		{
			get
			{
				return this._ask_help != null;
			}
			set
			{
				bool flag = value == (this._ask_help == null);
				if (flag)
				{
					this._ask_help = (value ? new bool?(this.ask_help) : null);
				}
			}
		}

		private bool ShouldSerializeask_help()
		{
			return this.ask_helpSpecified;
		}

		private void Resetask_help()
		{
			this.ask_helpSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "refresh_count", DataFormat = DataFormat.TwosComplement)]
		public uint refresh_count
		{
			get
			{
				return this._refresh_count ?? 0U;
			}
			set
			{
				this._refresh_count = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool refresh_countSpecified
		{
			get
			{
				return this._refresh_count != null;
			}
			set
			{
				bool flag = value == (this._refresh_count == null);
				if (flag)
				{
					this._refresh_count = (value ? new uint?(this.refresh_count) : null);
				}
			}
		}

		private bool ShouldSerializerefresh_count()
		{
			return this.refresh_countSpecified;
		}

		private void Resetrefresh_count()
		{
			this.refresh_countSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _index;

		private uint? _id;

		private uint? _step;

		private bool? _is_rewarded;

		private bool? _ask_help;

		private uint? _refresh_count;

		private IExtension extensionObject;
	}
}
