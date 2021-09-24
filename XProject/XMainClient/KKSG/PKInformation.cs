using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PKInformation")]
	[Serializable]
	public class PKInformation : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "pk_record", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PkRecord pk_record
		{
			get
			{
				return this._pk_record;
			}
			set
			{
				this._pk_record = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "pk_rank", DataFormat = DataFormat.TwosComplement)]
		public uint pk_rank
		{
			get
			{
				return this._pk_rank ?? 0U;
			}
			set
			{
				this._pk_rank = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool pk_rankSpecified
		{
			get
			{
				return this._pk_rank != null;
			}
			set
			{
				bool flag = value == (this._pk_rank == null);
				if (flag)
				{
					this._pk_rank = (value ? new uint?(this.pk_rank) : null);
				}
			}
		}

		private bool ShouldSerializepk_rank()
		{
			return this.pk_rankSpecified;
		}

		private void Resetpk_rank()
		{
			this.pk_rankSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "pk_profession_rank", DataFormat = DataFormat.TwosComplement)]
		public uint pk_profession_rank
		{
			get
			{
				return this._pk_profession_rank ?? 0U;
			}
			set
			{
				this._pk_profession_rank = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool pk_profession_rankSpecified
		{
			get
			{
				return this._pk_profession_rank != null;
			}
			set
			{
				bool flag = value == (this._pk_profession_rank == null);
				if (flag)
				{
					this._pk_profession_rank = (value ? new uint?(this.pk_profession_rank) : null);
				}
			}
		}

		private bool ShouldSerializepk_profession_rank()
		{
			return this.pk_profession_rankSpecified;
		}

		private void Resetpk_profession_rank()
		{
			this.pk_profession_rankSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "pk_max_score", DataFormat = DataFormat.TwosComplement)]
		public uint pk_max_score
		{
			get
			{
				return this._pk_max_score ?? 0U;
			}
			set
			{
				this._pk_max_score = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool pk_max_scoreSpecified
		{
			get
			{
				return this._pk_max_score != null;
			}
			set
			{
				bool flag = value == (this._pk_max_score == null);
				if (flag)
				{
					this._pk_max_score = (value ? new uint?(this.pk_max_score) : null);
				}
			}
		}

		private bool ShouldSerializepk_max_score()
		{
			return this.pk_max_scoreSpecified;
		}

		private void Resetpk_max_score()
		{
			this.pk_max_scoreSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "pk_all_roles_rate", DataFormat = DataFormat.Default)]
		public string pk_all_roles_rate
		{
			get
			{
				return this._pk_all_roles_rate ?? "";
			}
			set
			{
				this._pk_all_roles_rate = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool pk_all_roles_rateSpecified
		{
			get
			{
				return this._pk_all_roles_rate != null;
			}
			set
			{
				bool flag = value == (this._pk_all_roles_rate == null);
				if (flag)
				{
					this._pk_all_roles_rate = (value ? this.pk_all_roles_rate : null);
				}
			}
		}

		private bool ShouldSerializepk_all_roles_rate()
		{
			return this.pk_all_roles_rateSpecified;
		}

		private void Resetpk_all_roles_rate()
		{
			this.pk_all_roles_rateSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "pk_warrior_rate", DataFormat = DataFormat.Default)]
		public string pk_warrior_rate
		{
			get
			{
				return this._pk_warrior_rate ?? "";
			}
			set
			{
				this._pk_warrior_rate = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool pk_warrior_rateSpecified
		{
			get
			{
				return this._pk_warrior_rate != null;
			}
			set
			{
				bool flag = value == (this._pk_warrior_rate == null);
				if (flag)
				{
					this._pk_warrior_rate = (value ? this.pk_warrior_rate : null);
				}
			}
		}

		private bool ShouldSerializepk_warrior_rate()
		{
			return this.pk_warrior_rateSpecified;
		}

		private void Resetpk_warrior_rate()
		{
			this.pk_warrior_rateSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "pk_archer_rate", DataFormat = DataFormat.Default)]
		public string pk_archer_rate
		{
			get
			{
				return this._pk_archer_rate ?? "";
			}
			set
			{
				this._pk_archer_rate = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool pk_archer_rateSpecified
		{
			get
			{
				return this._pk_archer_rate != null;
			}
			set
			{
				bool flag = value == (this._pk_archer_rate == null);
				if (flag)
				{
					this._pk_archer_rate = (value ? this.pk_archer_rate : null);
				}
			}
		}

		private bool ShouldSerializepk_archer_rate()
		{
			return this.pk_archer_rateSpecified;
		}

		private void Resetpk_archer_rate()
		{
			this.pk_archer_rateSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "pk_minister_rate", DataFormat = DataFormat.Default)]
		public string pk_minister_rate
		{
			get
			{
				return this._pk_minister_rate ?? "";
			}
			set
			{
				this._pk_minister_rate = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool pk_minister_rateSpecified
		{
			get
			{
				return this._pk_minister_rate != null;
			}
			set
			{
				bool flag = value == (this._pk_minister_rate == null);
				if (flag)
				{
					this._pk_minister_rate = (value ? this.pk_minister_rate : null);
				}
			}
		}

		private bool ShouldSerializepk_minister_rate()
		{
			return this.pk_minister_rateSpecified;
		}

		private void Resetpk_minister_rate()
		{
			this.pk_minister_rateSpecified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "pk_master_rate", DataFormat = DataFormat.Default)]
		public string pk_master_rate
		{
			get
			{
				return this._pk_master_rate ?? "";
			}
			set
			{
				this._pk_master_rate = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool pk_master_rateSpecified
		{
			get
			{
				return this._pk_master_rate != null;
			}
			set
			{
				bool flag = value == (this._pk_master_rate == null);
				if (flag)
				{
					this._pk_master_rate = (value ? this.pk_master_rate : null);
				}
			}
		}

		private bool ShouldSerializepk_master_rate()
		{
			return this.pk_master_rateSpecified;
		}

		private void Resetpk_master_rate()
		{
			this.pk_master_rateSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private PkRecord _pk_record = null;

		private uint? _pk_rank;

		private uint? _pk_profession_rank;

		private uint? _pk_max_score;

		private string _pk_all_roles_rate;

		private string _pk_warrior_rate;

		private string _pk_archer_rate;

		private string _pk_minister_rate;

		private string _pk_master_rate;

		private IExtension extensionObject;
	}
}
