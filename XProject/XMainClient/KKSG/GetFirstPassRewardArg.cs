using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001E0 RID: 480
	[ProtoContract(Name = "GetFirstPassRewardArg")]
	[Serializable]
	public class GetFirstPassRewardArg : IExtensible
	{
		// Token: 0x170008AD RID: 2221
		// (get) Token: 0x06001BA1 RID: 7073 RVA: 0x000368E8 File Offset: 0x00034AE8
		// (set) Token: 0x06001BA2 RID: 7074 RVA: 0x00036914 File Offset: 0x00034B14
		[ProtoMember(1, IsRequired = false, Name = "firstPassID", DataFormat = DataFormat.TwosComplement)]
		public int firstPassID
		{
			get
			{
				return this._firstPassID ?? 0;
			}
			set
			{
				this._firstPassID = new int?(value);
			}
		}

		// Token: 0x170008AE RID: 2222
		// (get) Token: 0x06001BA3 RID: 7075 RVA: 0x00036924 File Offset: 0x00034B24
		// (set) Token: 0x06001BA4 RID: 7076 RVA: 0x00036944 File Offset: 0x00034B44
		[XmlIgnore]
		[Browsable(false)]
		public bool firstPassIDSpecified
		{
			get
			{
				return this._firstPassID != null;
			}
			set
			{
				bool flag = value == (this._firstPassID == null);
				if (flag)
				{
					this._firstPassID = (value ? new int?(this.firstPassID) : null);
				}
			}
		}

		// Token: 0x06001BA5 RID: 7077 RVA: 0x00036988 File Offset: 0x00034B88
		private bool ShouldSerializefirstPassID()
		{
			return this.firstPassIDSpecified;
		}

		// Token: 0x06001BA6 RID: 7078 RVA: 0x000369A0 File Offset: 0x00034BA0
		private void ResetfirstPassID()
		{
			this.firstPassIDSpecified = false;
		}

		// Token: 0x06001BA7 RID: 7079 RVA: 0x000369AC File Offset: 0x00034BAC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040006E2 RID: 1762
		private int? _firstPassID;

		// Token: 0x040006E3 RID: 1763
		private IExtension extensionObject;
	}
}
