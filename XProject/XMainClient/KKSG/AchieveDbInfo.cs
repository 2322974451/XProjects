using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000664 RID: 1636
	[ProtoContract(Name = "AchieveDbInfo")]
	[Serializable]
	public class AchieveDbInfo : IExtensible
	{
		// Token: 0x1700209C RID: 8348
		// (get) Token: 0x06006743 RID: 26435 RVA: 0x000C5494 File Offset: 0x000C3694
		[ProtoMember(1, Name = "achieveData", DataFormat = DataFormat.Default)]
		public List<StcAchieveInfo> achieveData
		{
			get
			{
				return this._achieveData;
			}
		}

		// Token: 0x1700209D RID: 8349
		// (get) Token: 0x06006744 RID: 26436 RVA: 0x000C54AC File Offset: 0x000C36AC
		[ProtoMember(2, Name = "achieveAward", DataFormat = DataFormat.Default)]
		public List<STC_ACHIEVE_POINT_REWARD> achieveAward
		{
			get
			{
				return this._achieveAward;
			}
		}

		// Token: 0x1700209E RID: 8350
		// (get) Token: 0x06006745 RID: 26437 RVA: 0x000C54C4 File Offset: 0x000C36C4
		[ProtoMember(3, Name = "oldachievement", DataFormat = DataFormat.Default)]
		public List<StcAchieveInfo> oldachievement
		{
			get
			{
				return this._oldachievement;
			}
		}

		// Token: 0x06006746 RID: 26438 RVA: 0x000C54DC File Offset: 0x000C36DC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040018F0 RID: 6384
		private readonly List<StcAchieveInfo> _achieveData = new List<StcAchieveInfo>();

		// Token: 0x040018F1 RID: 6385
		private readonly List<STC_ACHIEVE_POINT_REWARD> _achieveAward = new List<STC_ACHIEVE_POINT_REWARD>();

		// Token: 0x040018F2 RID: 6386
		private readonly List<StcAchieveInfo> _oldachievement = new List<StcAchieveInfo>();

		// Token: 0x040018F3 RID: 6387
		private IExtension extensionObject;
	}
}
