using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001E4 RID: 484
	[ProtoContract(Name = "FirstPassGetTopRoleInfoArg")]
	[Serializable]
	public class FirstPassGetTopRoleInfoArg : IExtensible
	{
		// Token: 0x170008B9 RID: 2233
		// (get) Token: 0x06001BCD RID: 7117 RVA: 0x00036E00 File Offset: 0x00035000
		// (set) Token: 0x06001BCE RID: 7118 RVA: 0x00036E2C File Offset: 0x0003502C
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

		// Token: 0x170008BA RID: 2234
		// (get) Token: 0x06001BCF RID: 7119 RVA: 0x00036E3C File Offset: 0x0003503C
		// (set) Token: 0x06001BD0 RID: 7120 RVA: 0x00036E5C File Offset: 0x0003505C
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

		// Token: 0x06001BD1 RID: 7121 RVA: 0x00036EA0 File Offset: 0x000350A0
		private bool ShouldSerializefirstPassID()
		{
			return this.firstPassIDSpecified;
		}

		// Token: 0x06001BD2 RID: 7122 RVA: 0x00036EB8 File Offset: 0x000350B8
		private void ResetfirstPassID()
		{
			this.firstPassIDSpecified = false;
		}

		// Token: 0x06001BD3 RID: 7123 RVA: 0x00036EC4 File Offset: 0x000350C4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040006EC RID: 1772
		private int? _firstPassID;

		// Token: 0x040006ED RID: 1773
		private IExtension extensionObject;
	}
}
