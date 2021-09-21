using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200047F RID: 1151
	[ProtoContract(Name = "BattleStatisticsNtf")]
	[Serializable]
	public class BattleStatisticsNtf : IExtensible
	{
		// Token: 0x17001270 RID: 4720
		// (get) Token: 0x06003C26 RID: 15398 RVA: 0x00072EC8 File Offset: 0x000710C8
		[ProtoMember(1, Name = "skillID", DataFormat = DataFormat.TwosComplement)]
		public List<uint> skillID
		{
			get
			{
				return this._skillID;
			}
		}

		// Token: 0x17001271 RID: 4721
		// (get) Token: 0x06003C27 RID: 15399 RVA: 0x00072EE0 File Offset: 0x000710E0
		[ProtoMember(2, Name = "skillCount", DataFormat = DataFormat.TwosComplement)]
		public List<int> skillCount
		{
			get
			{
				return this._skillCount;
			}
		}

		// Token: 0x17001272 RID: 4722
		// (get) Token: 0x06003C28 RID: 15400 RVA: 0x00072EF8 File Offset: 0x000710F8
		[ProtoMember(3, Name = "skillValue", DataFormat = DataFormat.TwosComplement)]
		public List<double> skillValue
		{
			get
			{
				return this._skillValue;
			}
		}

		// Token: 0x17001273 RID: 4723
		// (get) Token: 0x06003C29 RID: 15401 RVA: 0x00072F10 File Offset: 0x00071110
		[ProtoMember(4, Name = "mobID", DataFormat = DataFormat.TwosComplement)]
		public List<uint> mobID
		{
			get
			{
				return this._mobID;
			}
		}

		// Token: 0x17001274 RID: 4724
		// (get) Token: 0x06003C2A RID: 15402 RVA: 0x00072F28 File Offset: 0x00071128
		[ProtoMember(5, Name = "mobCount", DataFormat = DataFormat.TwosComplement)]
		public List<int> mobCount
		{
			get
			{
				return this._mobCount;
			}
		}

		// Token: 0x17001275 RID: 4725
		// (get) Token: 0x06003C2B RID: 15403 RVA: 0x00072F40 File Offset: 0x00071140
		[ProtoMember(6, Name = "mobValue", DataFormat = DataFormat.TwosComplement)]
		public List<double> mobValue
		{
			get
			{
				return this._mobValue;
			}
		}

		// Token: 0x06003C2C RID: 15404 RVA: 0x00072F58 File Offset: 0x00071158
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000EF6 RID: 3830
		private readonly List<uint> _skillID = new List<uint>();

		// Token: 0x04000EF7 RID: 3831
		private readonly List<int> _skillCount = new List<int>();

		// Token: 0x04000EF8 RID: 3832
		private readonly List<double> _skillValue = new List<double>();

		// Token: 0x04000EF9 RID: 3833
		private readonly List<uint> _mobID = new List<uint>();

		// Token: 0x04000EFA RID: 3834
		private readonly List<int> _mobCount = new List<int>();

		// Token: 0x04000EFB RID: 3835
		private readonly List<double> _mobValue = new List<double>();

		// Token: 0x04000EFC RID: 3836
		private IExtension extensionObject;
	}
}
