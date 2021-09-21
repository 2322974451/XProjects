using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000125 RID: 293
	[ProtoContract(Name = "LoginRewardGetReq")]
	[Serializable]
	public class LoginRewardGetReq : IExtensible
	{
		// Token: 0x170005CF RID: 1487
		// (get) Token: 0x06001225 RID: 4645 RVA: 0x00024E14 File Offset: 0x00023014
		// (set) Token: 0x06001226 RID: 4646 RVA: 0x00024E40 File Offset: 0x00023040
		[ProtoMember(1, IsRequired = false, Name = "day", DataFormat = DataFormat.TwosComplement)]
		public int day
		{
			get
			{
				return this._day ?? 0;
			}
			set
			{
				this._day = new int?(value);
			}
		}

		// Token: 0x170005D0 RID: 1488
		// (get) Token: 0x06001227 RID: 4647 RVA: 0x00024E50 File Offset: 0x00023050
		// (set) Token: 0x06001228 RID: 4648 RVA: 0x00024E70 File Offset: 0x00023070
		[XmlIgnore]
		[Browsable(false)]
		public bool daySpecified
		{
			get
			{
				return this._day != null;
			}
			set
			{
				bool flag = value == (this._day == null);
				if (flag)
				{
					this._day = (value ? new int?(this.day) : null);
				}
			}
		}

		// Token: 0x06001229 RID: 4649 RVA: 0x00024EB4 File Offset: 0x000230B4
		private bool ShouldSerializeday()
		{
			return this.daySpecified;
		}

		// Token: 0x0600122A RID: 4650 RVA: 0x00024ECC File Offset: 0x000230CC
		private void Resetday()
		{
			this.daySpecified = false;
		}

		// Token: 0x0600122B RID: 4651 RVA: 0x00024ED8 File Offset: 0x000230D8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400048B RID: 1163
		private int? _day;

		// Token: 0x0400048C RID: 1164
		private IExtension extensionObject;
	}
}
