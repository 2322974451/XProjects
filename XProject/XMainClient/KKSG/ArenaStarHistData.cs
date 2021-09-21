using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000704 RID: 1796
	[ProtoContract(Name = "ArenaStarHistData")]
	[Serializable]
	public class ArenaStarHistData : IExtensible
	{
		// Token: 0x17002678 RID: 9848
		// (get) Token: 0x06007971 RID: 31089 RVA: 0x000E82C0 File Offset: 0x000E64C0
		// (set) Token: 0x06007972 RID: 31090 RVA: 0x000E82EC File Offset: 0x000E64EC
		[ProtoMember(1, IsRequired = false, Name = "rankOneNum", DataFormat = DataFormat.TwosComplement)]
		public uint rankOneNum
		{
			get
			{
				return this._rankOneNum ?? 0U;
			}
			set
			{
				this._rankOneNum = new uint?(value);
			}
		}

		// Token: 0x17002679 RID: 9849
		// (get) Token: 0x06007973 RID: 31091 RVA: 0x000E82FC File Offset: 0x000E64FC
		// (set) Token: 0x06007974 RID: 31092 RVA: 0x000E831C File Offset: 0x000E651C
		[XmlIgnore]
		[Browsable(false)]
		public bool rankOneNumSpecified
		{
			get
			{
				return this._rankOneNum != null;
			}
			set
			{
				bool flag = value == (this._rankOneNum == null);
				if (flag)
				{
					this._rankOneNum = (value ? new uint?(this.rankOneNum) : null);
				}
			}
		}

		// Token: 0x06007975 RID: 31093 RVA: 0x000E8360 File Offset: 0x000E6560
		private bool ShouldSerializerankOneNum()
		{
			return this.rankOneNumSpecified;
		}

		// Token: 0x06007976 RID: 31094 RVA: 0x000E8378 File Offset: 0x000E6578
		private void ResetrankOneNum()
		{
			this.rankOneNumSpecified = false;
		}

		// Token: 0x1700267A RID: 9850
		// (get) Token: 0x06007977 RID: 31095 RVA: 0x000E8384 File Offset: 0x000E6584
		// (set) Token: 0x06007978 RID: 31096 RVA: 0x000E83B0 File Offset: 0x000E65B0
		[ProtoMember(2, IsRequired = false, Name = "rankTenNum", DataFormat = DataFormat.TwosComplement)]
		public uint rankTenNum
		{
			get
			{
				return this._rankTenNum ?? 0U;
			}
			set
			{
				this._rankTenNum = new uint?(value);
			}
		}

		// Token: 0x1700267B RID: 9851
		// (get) Token: 0x06007979 RID: 31097 RVA: 0x000E83C0 File Offset: 0x000E65C0
		// (set) Token: 0x0600797A RID: 31098 RVA: 0x000E83E0 File Offset: 0x000E65E0
		[XmlIgnore]
		[Browsable(false)]
		public bool rankTenNumSpecified
		{
			get
			{
				return this._rankTenNum != null;
			}
			set
			{
				bool flag = value == (this._rankTenNum == null);
				if (flag)
				{
					this._rankTenNum = (value ? new uint?(this.rankTenNum) : null);
				}
			}
		}

		// Token: 0x0600797B RID: 31099 RVA: 0x000E8424 File Offset: 0x000E6624
		private bool ShouldSerializerankTenNum()
		{
			return this.rankTenNumSpecified;
		}

		// Token: 0x0600797C RID: 31100 RVA: 0x000E843C File Offset: 0x000E663C
		private void ResetrankTenNum()
		{
			this.rankTenNumSpecified = false;
		}

		// Token: 0x1700267C RID: 9852
		// (get) Token: 0x0600797D RID: 31101 RVA: 0x000E8448 File Offset: 0x000E6648
		[ProtoMember(3, Name = "rankRecent", DataFormat = DataFormat.Default)]
		public List<RankOnce> rankRecent
		{
			get
			{
				return this._rankRecent;
			}
		}

		// Token: 0x0600797E RID: 31102 RVA: 0x000E8460 File Offset: 0x000E6660
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001CB1 RID: 7345
		private uint? _rankOneNum;

		// Token: 0x04001CB2 RID: 7346
		private uint? _rankTenNum;

		// Token: 0x04001CB3 RID: 7347
		private readonly List<RankOnce> _rankRecent = new List<RankOnce>();

		// Token: 0x04001CB4 RID: 7348
		private IExtension extensionObject;
	}
}
