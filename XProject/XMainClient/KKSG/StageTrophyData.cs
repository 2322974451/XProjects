using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "StageTrophyData")]
	[Serializable]
	public class StageTrophyData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "scene_id", DataFormat = DataFormat.TwosComplement)]
		public uint scene_id
		{
			get
			{
				return this._scene_id ?? 0U;
			}
			set
			{
				this._scene_id = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool scene_idSpecified
		{
			get
			{
				return this._scene_id != null;
			}
			set
			{
				bool flag = value == (this._scene_id == null);
				if (flag)
				{
					this._scene_id = (value ? new uint?(this.scene_id) : null);
				}
			}
		}

		private bool ShouldSerializescene_id()
		{
			return this.scene_idSpecified;
		}

		private void Resetscene_id()
		{
			this.scene_idSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "pass_count", DataFormat = DataFormat.TwosComplement)]
		public uint pass_count
		{
			get
			{
				return this._pass_count ?? 0U;
			}
			set
			{
				this._pass_count = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool pass_countSpecified
		{
			get
			{
				return this._pass_count != null;
			}
			set
			{
				bool flag = value == (this._pass_count == null);
				if (flag)
				{
					this._pass_count = (value ? new uint?(this.pass_count) : null);
				}
			}
		}

		private bool ShouldSerializepass_count()
		{
			return this.pass_countSpecified;
		}

		private void Resetpass_count()
		{
			this.pass_countSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "quickly_pass_time", DataFormat = DataFormat.TwosComplement)]
		public uint quickly_pass_time
		{
			get
			{
				return this._quickly_pass_time ?? 0U;
			}
			set
			{
				this._quickly_pass_time = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool quickly_pass_timeSpecified
		{
			get
			{
				return this._quickly_pass_time != null;
			}
			set
			{
				bool flag = value == (this._quickly_pass_time == null);
				if (flag)
				{
					this._quickly_pass_time = (value ? new uint?(this.quickly_pass_time) : null);
				}
			}
		}

		private bool ShouldSerializequickly_pass_time()
		{
			return this.quickly_pass_timeSpecified;
		}

		private void Resetquickly_pass_time()
		{
			this.quickly_pass_timeSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "hight_damage", DataFormat = DataFormat.TwosComplement)]
		public ulong hight_damage
		{
			get
			{
				return this._hight_damage ?? 0UL;
			}
			set
			{
				this._hight_damage = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool hight_damageSpecified
		{
			get
			{
				return this._hight_damage != null;
			}
			set
			{
				bool flag = value == (this._hight_damage == null);
				if (flag)
				{
					this._hight_damage = (value ? new ulong?(this.hight_damage) : null);
				}
			}
		}

		private bool ShouldSerializehight_damage()
		{
			return this.hight_damageSpecified;
		}

		private void Resethight_damage()
		{
			this.hight_damageSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "hight_treat", DataFormat = DataFormat.TwosComplement)]
		public ulong hight_treat
		{
			get
			{
				return this._hight_treat ?? 0UL;
			}
			set
			{
				this._hight_treat = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool hight_treatSpecified
		{
			get
			{
				return this._hight_treat != null;
			}
			set
			{
				bool flag = value == (this._hight_treat == null);
				if (flag)
				{
					this._hight_treat = (value ? new ulong?(this.hight_treat) : null);
				}
			}
		}

		private bool ShouldSerializehight_treat()
		{
			return this.hight_treatSpecified;
		}

		private void Resethight_treat()
		{
			this.hight_treatSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "help_count", DataFormat = DataFormat.TwosComplement)]
		public uint help_count
		{
			get
			{
				return this._help_count ?? 0U;
			}
			set
			{
				this._help_count = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool help_countSpecified
		{
			get
			{
				return this._help_count != null;
			}
			set
			{
				bool flag = value == (this._help_count == null);
				if (flag)
				{
					this._help_count = (value ? new uint?(this.help_count) : null);
				}
			}
		}

		private bool ShouldSerializehelp_count()
		{
			return this.help_countSpecified;
		}

		private void Resethelp_count()
		{
			this.help_countSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "no_deathpass_count", DataFormat = DataFormat.TwosComplement)]
		public uint no_deathpass_count
		{
			get
			{
				return this._no_deathpass_count ?? 0U;
			}
			set
			{
				this._no_deathpass_count = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool no_deathpass_countSpecified
		{
			get
			{
				return this._no_deathpass_count != null;
			}
			set
			{
				bool flag = value == (this._no_deathpass_count == null);
				if (flag)
				{
					this._no_deathpass_count = (value ? new uint?(this.no_deathpass_count) : null);
				}
			}
		}

		private bool ShouldSerializeno_deathpass_count()
		{
			return this.no_deathpass_countSpecified;
		}

		private void Resetno_deathpass_count()
		{
			this.no_deathpass_countSpecified = false;
		}

		[ProtoMember(8, Name = "get_trophy_detail", DataFormat = DataFormat.Default)]
		public List<TrophyGetTypeDetail> get_trophy_detail
		{
			get
			{
				return this._get_trophy_detail;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _scene_id;

		private uint? _pass_count;

		private uint? _quickly_pass_time;

		private ulong? _hight_damage;

		private ulong? _hight_treat;

		private uint? _help_count;

		private uint? _no_deathpass_count;

		private readonly List<TrophyGetTypeDetail> _get_trophy_detail = new List<TrophyGetTypeDetail>();

		private IExtension extensionObject;
	}
}
