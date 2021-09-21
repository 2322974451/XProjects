using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003F7 RID: 1015
	[ProtoContract(Name = "GetGuildCampPartyRewardArg")]
	[Serializable]
	public class GetGuildCampPartyRewardArg : IExtensible
	{
		// Token: 0x1700108D RID: 4237
		// (get) Token: 0x060035D4 RID: 13780 RVA: 0x00067224 File Offset: 0x00065424
		// (set) Token: 0x060035D5 RID: 13781 RVA: 0x00067250 File Offset: 0x00065450
		[ProtoMember(1, IsRequired = false, Name = "reward_id", DataFormat = DataFormat.TwosComplement)]
		public uint reward_id
		{
			get
			{
				return this._reward_id ?? 0U;
			}
			set
			{
				this._reward_id = new uint?(value);
			}
		}

		// Token: 0x1700108E RID: 4238
		// (get) Token: 0x060035D6 RID: 13782 RVA: 0x00067260 File Offset: 0x00065460
		// (set) Token: 0x060035D7 RID: 13783 RVA: 0x00067280 File Offset: 0x00065480
		[XmlIgnore]
		[Browsable(false)]
		public bool reward_idSpecified
		{
			get
			{
				return this._reward_id != null;
			}
			set
			{
				bool flag = value == (this._reward_id == null);
				if (flag)
				{
					this._reward_id = (value ? new uint?(this.reward_id) : null);
				}
			}
		}

		// Token: 0x060035D8 RID: 13784 RVA: 0x000672C4 File Offset: 0x000654C4
		private bool ShouldSerializereward_id()
		{
			return this.reward_idSpecified;
		}

		// Token: 0x060035D9 RID: 13785 RVA: 0x000672DC File Offset: 0x000654DC
		private void Resetreward_id()
		{
			this.reward_idSpecified = false;
		}

		// Token: 0x060035DA RID: 13786 RVA: 0x000672E8 File Offset: 0x000654E8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000D5F RID: 3423
		private uint? _reward_id;

		// Token: 0x04000D60 RID: 3424
		private IExtension extensionObject;
	}
}
