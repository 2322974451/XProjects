using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000119 RID: 281
	[ProtoContract(Name = "GetAchieveRewardReq")]
	[Serializable]
	public class GetAchieveRewardReq : IExtensible
	{
		// Token: 0x170005A2 RID: 1442
		// (get) Token: 0x0600118F RID: 4495 RVA: 0x00023CD0 File Offset: 0x00021ED0
		// (set) Token: 0x06001190 RID: 4496 RVA: 0x00023CFC File Offset: 0x00021EFC
		[ProtoMember(1, IsRequired = false, Name = "achieveID", DataFormat = DataFormat.TwosComplement)]
		public uint achieveID
		{
			get
			{
				return this._achieveID ?? 0U;
			}
			set
			{
				this._achieveID = new uint?(value);
			}
		}

		// Token: 0x170005A3 RID: 1443
		// (get) Token: 0x06001191 RID: 4497 RVA: 0x00023D0C File Offset: 0x00021F0C
		// (set) Token: 0x06001192 RID: 4498 RVA: 0x00023D2C File Offset: 0x00021F2C
		[XmlIgnore]
		[Browsable(false)]
		public bool achieveIDSpecified
		{
			get
			{
				return this._achieveID != null;
			}
			set
			{
				bool flag = value == (this._achieveID == null);
				if (flag)
				{
					this._achieveID = (value ? new uint?(this.achieveID) : null);
				}
			}
		}

		// Token: 0x06001193 RID: 4499 RVA: 0x00023D70 File Offset: 0x00021F70
		private bool ShouldSerializeachieveID()
		{
			return this.achieveIDSpecified;
		}

		// Token: 0x06001194 RID: 4500 RVA: 0x00023D88 File Offset: 0x00021F88
		private void ResetachieveID()
		{
			this.achieveIDSpecified = false;
		}

		// Token: 0x06001195 RID: 4501 RVA: 0x00023D94 File Offset: 0x00021F94
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000465 RID: 1125
		private uint? _achieveID;

		// Token: 0x04000466 RID: 1126
		private IExtension extensionObject;
	}
}
