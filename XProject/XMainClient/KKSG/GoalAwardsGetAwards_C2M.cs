using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004D5 RID: 1237
	[ProtoContract(Name = "GoalAwardsGetAwards_C2M")]
	[Serializable]
	public class GoalAwardsGetAwards_C2M : IExtensible
	{
		// Token: 0x170013A0 RID: 5024
		// (get) Token: 0x0600401D RID: 16413 RVA: 0x0007A1E0 File Offset: 0x000783E0
		// (set) Token: 0x0600401E RID: 16414 RVA: 0x0007A20C File Offset: 0x0007840C
		[ProtoMember(1, IsRequired = false, Name = "goalAwardsID", DataFormat = DataFormat.TwosComplement)]
		public uint goalAwardsID
		{
			get
			{
				return this._goalAwardsID ?? 0U;
			}
			set
			{
				this._goalAwardsID = new uint?(value);
			}
		}

		// Token: 0x170013A1 RID: 5025
		// (get) Token: 0x0600401F RID: 16415 RVA: 0x0007A21C File Offset: 0x0007841C
		// (set) Token: 0x06004020 RID: 16416 RVA: 0x0007A23C File Offset: 0x0007843C
		[XmlIgnore]
		[Browsable(false)]
		public bool goalAwardsIDSpecified
		{
			get
			{
				return this._goalAwardsID != null;
			}
			set
			{
				bool flag = value == (this._goalAwardsID == null);
				if (flag)
				{
					this._goalAwardsID = (value ? new uint?(this.goalAwardsID) : null);
				}
			}
		}

		// Token: 0x06004021 RID: 16417 RVA: 0x0007A280 File Offset: 0x00078480
		private bool ShouldSerializegoalAwardsID()
		{
			return this.goalAwardsIDSpecified;
		}

		// Token: 0x06004022 RID: 16418 RVA: 0x0007A298 File Offset: 0x00078498
		private void ResetgoalAwardsID()
		{
			this.goalAwardsIDSpecified = false;
		}

		// Token: 0x06004023 RID: 16419 RVA: 0x0007A2A4 File Offset: 0x000784A4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000FF7 RID: 4087
		private uint? _goalAwardsID;

		// Token: 0x04000FF8 RID: 4088
		private IExtension extensionObject;
	}
}
