using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000174 RID: 372
	[ProtoContract(Name = "SelectRoleNewArg")]
	[Serializable]
	public class SelectRoleNewArg : IExtensible
	{
		// Token: 0x1700070E RID: 1806
		// (get) Token: 0x06001647 RID: 5703 RVA: 0x0002C9F4 File Offset: 0x0002ABF4
		// (set) Token: 0x06001648 RID: 5704 RVA: 0x0002CA20 File Offset: 0x0002AC20
		[ProtoMember(1, IsRequired = false, Name = "index", DataFormat = DataFormat.TwosComplement)]
		public int index
		{
			get
			{
				return this._index ?? 0;
			}
			set
			{
				this._index = new int?(value);
			}
		}

		// Token: 0x1700070F RID: 1807
		// (get) Token: 0x06001649 RID: 5705 RVA: 0x0002CA30 File Offset: 0x0002AC30
		// (set) Token: 0x0600164A RID: 5706 RVA: 0x0002CA50 File Offset: 0x0002AC50
		[XmlIgnore]
		[Browsable(false)]
		public bool indexSpecified
		{
			get
			{
				return this._index != null;
			}
			set
			{
				bool flag = value == (this._index == null);
				if (flag)
				{
					this._index = (value ? new int?(this.index) : null);
				}
			}
		}

		// Token: 0x0600164B RID: 5707 RVA: 0x0002CA94 File Offset: 0x0002AC94
		private bool ShouldSerializeindex()
		{
			return this.indexSpecified;
		}

		// Token: 0x0600164C RID: 5708 RVA: 0x0002CAAC File Offset: 0x0002ACAC
		private void Resetindex()
		{
			this.indexSpecified = false;
		}

		// Token: 0x0600164D RID: 5709 RVA: 0x0002CAB8 File Offset: 0x0002ACB8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000589 RID: 1417
		private int? _index;

		// Token: 0x0400058A RID: 1418
		private IExtension extensionObject;
	}
}
