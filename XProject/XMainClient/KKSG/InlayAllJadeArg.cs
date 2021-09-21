using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000557 RID: 1367
	[ProtoContract(Name = "InlayAllJadeArg")]
	[Serializable]
	public class InlayAllJadeArg : IExtensible
	{
		// Token: 0x17001554 RID: 5460
		// (get) Token: 0x060045D7 RID: 17879 RVA: 0x00084B48 File Offset: 0x00082D48
		// (set) Token: 0x060045D8 RID: 17880 RVA: 0x00084B69 File Offset: 0x00082D69
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

		// Token: 0x17001555 RID: 5461
		// (get) Token: 0x060045D9 RID: 17881 RVA: 0x00084B74 File Offset: 0x00082D74
		// (set) Token: 0x060045DA RID: 17882 RVA: 0x00084B90 File Offset: 0x00082D90
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

		// Token: 0x060045DB RID: 17883 RVA: 0x00084BC0 File Offset: 0x00082DC0
		private bool ShouldSerializeuid()
		{
			return this.uidSpecified;
		}

		// Token: 0x060045DC RID: 17884 RVA: 0x00084BD8 File Offset: 0x00082DD8
		private void Resetuid()
		{
			this.uidSpecified = false;
		}

		// Token: 0x060045DD RID: 17885 RVA: 0x00084BE4 File Offset: 0x00082DE4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001170 RID: 4464
		private string _uid;

		// Token: 0x04001171 RID: 4465
		private IExtension extensionObject;
	}
}
