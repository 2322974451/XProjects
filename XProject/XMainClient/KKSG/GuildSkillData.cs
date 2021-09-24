using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildSkillData")]
	[Serializable]
	public class GuildSkillData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "SkillId", DataFormat = DataFormat.TwosComplement)]
		public int SkillId
		{
			get
			{
				return this._SkillId ?? 0;
			}
			set
			{
				this._SkillId = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool SkillIdSpecified
		{
			get
			{
				return this._SkillId != null;
			}
			set
			{
				bool flag = value == (this._SkillId == null);
				if (flag)
				{
					this._SkillId = (value ? new int?(this.SkillId) : null);
				}
			}
		}

		private bool ShouldSerializeSkillId()
		{
			return this.SkillIdSpecified;
		}

		private void ResetSkillId()
		{
			this.SkillIdSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "MaxLvl", DataFormat = DataFormat.TwosComplement)]
		public int MaxLvl
		{
			get
			{
				return this._MaxLvl ?? 0;
			}
			set
			{
				this._MaxLvl = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool MaxLvlSpecified
		{
			get
			{
				return this._MaxLvl != null;
			}
			set
			{
				bool flag = value == (this._MaxLvl == null);
				if (flag)
				{
					this._MaxLvl = (value ? new int?(this.MaxLvl) : null);
				}
			}
		}

		private bool ShouldSerializeMaxLvl()
		{
			return this.MaxLvlSpecified;
		}

		private void ResetMaxLvl()
		{
			this.MaxLvlSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _SkillId;

		private int? _MaxLvl;

		private IExtension extensionObject;
	}
}
