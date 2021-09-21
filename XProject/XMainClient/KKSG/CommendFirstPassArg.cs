using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001E2 RID: 482
	[ProtoContract(Name = "CommendFirstPassArg")]
	[Serializable]
	public class CommendFirstPassArg : IExtensible
	{
		// Token: 0x170008B1 RID: 2225
		// (get) Token: 0x06001BB1 RID: 7089 RVA: 0x00036AB0 File Offset: 0x00034CB0
		// (set) Token: 0x06001BB2 RID: 7090 RVA: 0x00036ADC File Offset: 0x00034CDC
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

		// Token: 0x170008B2 RID: 2226
		// (get) Token: 0x06001BB3 RID: 7091 RVA: 0x00036AEC File Offset: 0x00034CEC
		// (set) Token: 0x06001BB4 RID: 7092 RVA: 0x00036B0C File Offset: 0x00034D0C
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

		// Token: 0x06001BB5 RID: 7093 RVA: 0x00036B50 File Offset: 0x00034D50
		private bool ShouldSerializefirstPassID()
		{
			return this.firstPassIDSpecified;
		}

		// Token: 0x06001BB6 RID: 7094 RVA: 0x00036B68 File Offset: 0x00034D68
		private void ResetfirstPassID()
		{
			this.firstPassIDSpecified = false;
		}

		// Token: 0x06001BB7 RID: 7095 RVA: 0x00036B74 File Offset: 0x00034D74
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040006E6 RID: 1766
		private int? _firstPassID;

		// Token: 0x040006E7 RID: 1767
		private IExtension extensionObject;
	}
}
