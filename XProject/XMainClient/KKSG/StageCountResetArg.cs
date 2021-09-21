using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000B4 RID: 180
	[ProtoContract(Name = "StageCountResetArg")]
	[Serializable]
	public class StageCountResetArg : IExtensible
	{
		// Token: 0x170003FE RID: 1022
		// (get) Token: 0x06000C4C RID: 3148 RVA: 0x00019FBC File Offset: 0x000181BC
		// (set) Token: 0x06000C4D RID: 3149 RVA: 0x00019FE8 File Offset: 0x000181E8
		[ProtoMember(1, IsRequired = false, Name = "groupid", DataFormat = DataFormat.TwosComplement)]
		public uint groupid
		{
			get
			{
				return this._groupid ?? 0U;
			}
			set
			{
				this._groupid = new uint?(value);
			}
		}

		// Token: 0x170003FF RID: 1023
		// (get) Token: 0x06000C4E RID: 3150 RVA: 0x00019FF8 File Offset: 0x000181F8
		// (set) Token: 0x06000C4F RID: 3151 RVA: 0x0001A018 File Offset: 0x00018218
		[XmlIgnore]
		[Browsable(false)]
		public bool groupidSpecified
		{
			get
			{
				return this._groupid != null;
			}
			set
			{
				bool flag = value == (this._groupid == null);
				if (flag)
				{
					this._groupid = (value ? new uint?(this.groupid) : null);
				}
			}
		}

		// Token: 0x06000C50 RID: 3152 RVA: 0x0001A05C File Offset: 0x0001825C
		private bool ShouldSerializegroupid()
		{
			return this.groupidSpecified;
		}

		// Token: 0x06000C51 RID: 3153 RVA: 0x0001A074 File Offset: 0x00018274
		private void Resetgroupid()
		{
			this.groupidSpecified = false;
		}

		// Token: 0x06000C52 RID: 3154 RVA: 0x0001A080 File Offset: 0x00018280
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400030C RID: 780
		private uint? _groupid;

		// Token: 0x0400030D RID: 781
		private IExtension extensionObject;
	}
}
