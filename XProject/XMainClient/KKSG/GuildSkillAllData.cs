using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildSkillAllData")]
	[Serializable]
	public class GuildSkillAllData : IExtensible
	{

		[ProtoMember(1, Name = "skillLevel", DataFormat = DataFormat.Default)]
		public List<GuildSkillData> skillLevel
		{
			get
			{
				return this._skillLevel;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "lastGuildExp", DataFormat = DataFormat.TwosComplement)]
		public int lastGuildExp
		{
			get
			{
				return this._lastGuildExp ?? 0;
			}
			set
			{
				this._lastGuildExp = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lastGuildExpSpecified
		{
			get
			{
				return this._lastGuildExp != null;
			}
			set
			{
				bool flag = value == (this._lastGuildExp == null);
				if (flag)
				{
					this._lastGuildExp = (value ? new int?(this.lastGuildExp) : null);
				}
			}
		}

		private bool ShouldSerializelastGuildExp()
		{
			return this.lastGuildExpSpecified;
		}

		private void ResetlastGuildExp()
		{
			this.lastGuildExpSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<GuildSkillData> _skillLevel = new List<GuildSkillData>();

		private int? _lastGuildExp;

		private IExtension extensionObject;
	}
}
