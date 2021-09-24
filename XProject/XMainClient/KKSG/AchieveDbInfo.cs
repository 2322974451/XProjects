using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "AchieveDbInfo")]
	[Serializable]
	public class AchieveDbInfo : IExtensible
	{

		[ProtoMember(1, Name = "achieveData", DataFormat = DataFormat.Default)]
		public List<StcAchieveInfo> achieveData
		{
			get
			{
				return this._achieveData;
			}
		}

		[ProtoMember(2, Name = "achieveAward", DataFormat = DataFormat.Default)]
		public List<STC_ACHIEVE_POINT_REWARD> achieveAward
		{
			get
			{
				return this._achieveAward;
			}
		}

		[ProtoMember(3, Name = "oldachievement", DataFormat = DataFormat.Default)]
		public List<StcAchieveInfo> oldachievement
		{
			get
			{
				return this._oldachievement;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<StcAchieveInfo> _achieveData = new List<StcAchieveInfo>();

		private readonly List<STC_ACHIEVE_POINT_REWARD> _achieveAward = new List<STC_ACHIEVE_POINT_REWARD>();

		private readonly List<StcAchieveInfo> _oldachievement = new List<StcAchieveInfo>();

		private IExtension extensionObject;
	}
}
