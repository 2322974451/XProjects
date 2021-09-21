using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001AD RID: 429
	[ProtoContract(Name = "GuildSkillAllData")]
	[Serializable]
	public class GuildSkillAllData : IExtensible
	{
		// Token: 0x170007FD RID: 2045
		// (get) Token: 0x06001955 RID: 6485 RVA: 0x000324F4 File Offset: 0x000306F4
		[ProtoMember(1, Name = "skillLevel", DataFormat = DataFormat.Default)]
		public List<GuildSkillData> skillLevel
		{
			get
			{
				return this._skillLevel;
			}
		}

		// Token: 0x170007FE RID: 2046
		// (get) Token: 0x06001956 RID: 6486 RVA: 0x0003250C File Offset: 0x0003070C
		// (set) Token: 0x06001957 RID: 6487 RVA: 0x00032538 File Offset: 0x00030738
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

		// Token: 0x170007FF RID: 2047
		// (get) Token: 0x06001958 RID: 6488 RVA: 0x00032548 File Offset: 0x00030748
		// (set) Token: 0x06001959 RID: 6489 RVA: 0x00032568 File Offset: 0x00030768
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

		// Token: 0x0600195A RID: 6490 RVA: 0x000325AC File Offset: 0x000307AC
		private bool ShouldSerializelastGuildExp()
		{
			return this.lastGuildExpSpecified;
		}

		// Token: 0x0600195B RID: 6491 RVA: 0x000325C4 File Offset: 0x000307C4
		private void ResetlastGuildExp()
		{
			this.lastGuildExpSpecified = false;
		}

		// Token: 0x0600195C RID: 6492 RVA: 0x000325D0 File Offset: 0x000307D0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400064B RID: 1611
		private readonly List<GuildSkillData> _skillLevel = new List<GuildSkillData>();

		// Token: 0x0400064C RID: 1612
		private int? _lastGuildExp;

		// Token: 0x0400064D RID: 1613
		private IExtension extensionObject;
	}
}
