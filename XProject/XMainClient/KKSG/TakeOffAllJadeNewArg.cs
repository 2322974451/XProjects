using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000551 RID: 1361
	[ProtoContract(Name = "TakeOffAllJadeNewArg")]
	[Serializable]
	public class TakeOffAllJadeNewArg : IExtensible
	{
		// Token: 0x17001545 RID: 5445
		// (get) Token: 0x060045A0 RID: 17824 RVA: 0x00084550 File Offset: 0x00082750
		// (set) Token: 0x060045A1 RID: 17825 RVA: 0x00084571 File Offset: 0x00082771
		[ProtoMember(1, IsRequired = false, Name = "uid", DataFormat = DataFormat.Default)]
		public string uid
		{
			get
			{
				return this._uid ?? "";
			}
			set
			{
				this._uid = value;
			}
		}

		// Token: 0x17001546 RID: 5446
		// (get) Token: 0x060045A2 RID: 17826 RVA: 0x0008457C File Offset: 0x0008277C
		// (set) Token: 0x060045A3 RID: 17827 RVA: 0x00084598 File Offset: 0x00082798
		[XmlIgnore]
		[Browsable(false)]
		public bool uidSpecified
		{
			get
			{
				return this._uid != null;
			}
			set
			{
				bool flag = value == (this._uid == null);
				if (flag)
				{
					this._uid = (value ? this.uid : null);
				}
			}
		}

		// Token: 0x060045A4 RID: 17828 RVA: 0x000845C8 File Offset: 0x000827C8
		private bool ShouldSerializeuid()
		{
			return this.uidSpecified;
		}

		// Token: 0x060045A5 RID: 17829 RVA: 0x000845E0 File Offset: 0x000827E0
		private void Resetuid()
		{
			this.uidSpecified = false;
		}

		// Token: 0x060045A6 RID: 17830 RVA: 0x000845EC File Offset: 0x000827EC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001162 RID: 4450
		private string _uid;

		// Token: 0x04001163 RID: 4451
		private IExtension extensionObject;
	}
}
