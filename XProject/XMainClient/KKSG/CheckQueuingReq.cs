using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001D8 RID: 472
	[ProtoContract(Name = "CheckQueuingReq")]
	[Serializable]
	public class CheckQueuingReq : IExtensible
	{
		// Token: 0x17000896 RID: 2198
		// (get) Token: 0x06001B4E RID: 6990 RVA: 0x00035F50 File Offset: 0x00034150
		// (set) Token: 0x06001B4F RID: 6991 RVA: 0x00035F7C File Offset: 0x0003417C
		[ProtoMember(1, IsRequired = false, Name = "iscancel", DataFormat = DataFormat.Default)]
		public bool iscancel
		{
			get
			{
				return this._iscancel ?? false;
			}
			set
			{
				this._iscancel = new bool?(value);
			}
		}

		// Token: 0x17000897 RID: 2199
		// (get) Token: 0x06001B50 RID: 6992 RVA: 0x00035F8C File Offset: 0x0003418C
		// (set) Token: 0x06001B51 RID: 6993 RVA: 0x00035FAC File Offset: 0x000341AC
		[XmlIgnore]
		[Browsable(false)]
		public bool iscancelSpecified
		{
			get
			{
				return this._iscancel != null;
			}
			set
			{
				bool flag = value == (this._iscancel == null);
				if (flag)
				{
					this._iscancel = (value ? new bool?(this.iscancel) : null);
				}
			}
		}

		// Token: 0x06001B52 RID: 6994 RVA: 0x00035FF0 File Offset: 0x000341F0
		private bool ShouldSerializeiscancel()
		{
			return this.iscancelSpecified;
		}

		// Token: 0x06001B53 RID: 6995 RVA: 0x00036008 File Offset: 0x00034208
		private void Resetiscancel()
		{
			this.iscancelSpecified = false;
		}

		// Token: 0x06001B54 RID: 6996 RVA: 0x00036014 File Offset: 0x00034214
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040006CE RID: 1742
		private bool? _iscancel;

		// Token: 0x040006CF RID: 1743
		private IExtension extensionObject;
	}
}
