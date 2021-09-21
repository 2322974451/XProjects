using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200007C RID: 124
	[ProtoContract(Name = "RandomFriendWaitListArg")]
	[Serializable]
	public class RandomFriendWaitListArg : IExtensible
	{
		// Token: 0x1700029D RID: 669
		// (get) Token: 0x06000817 RID: 2071 RVA: 0x00012028 File Offset: 0x00010228
		// (set) Token: 0x06000818 RID: 2072 RVA: 0x00012049 File Offset: 0x00010249
		[ProtoMember(1, IsRequired = false, Name = "match", DataFormat = DataFormat.Default)]
		public string match
		{
			get
			{
				return this._match ?? "";
			}
			set
			{
				this._match = value;
			}
		}

		// Token: 0x1700029E RID: 670
		// (get) Token: 0x06000819 RID: 2073 RVA: 0x00012054 File Offset: 0x00010254
		// (set) Token: 0x0600081A RID: 2074 RVA: 0x00012070 File Offset: 0x00010270
		[XmlIgnore]
		[Browsable(false)]
		public bool matchSpecified
		{
			get
			{
				return this._match != null;
			}
			set
			{
				bool flag = value == (this._match == null);
				if (flag)
				{
					this._match = (value ? this.match : null);
				}
			}
		}

		// Token: 0x0600081B RID: 2075 RVA: 0x000120A0 File Offset: 0x000102A0
		private bool ShouldSerializematch()
		{
			return this.matchSpecified;
		}

		// Token: 0x0600081C RID: 2076 RVA: 0x000120B8 File Offset: 0x000102B8
		private void Resetmatch()
		{
			this.matchSpecified = false;
		}

		// Token: 0x0600081D RID: 2077 RVA: 0x000120C4 File Offset: 0x000102C4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400020B RID: 523
		private string _match;

		// Token: 0x0400020C RID: 524
		private IExtension extensionObject;
	}
}
