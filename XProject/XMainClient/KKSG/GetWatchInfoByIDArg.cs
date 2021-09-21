using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000178 RID: 376
	[ProtoContract(Name = "GetWatchInfoByIDArg")]
	[Serializable]
	public class GetWatchInfoByIDArg : IExtensible
	{
		// Token: 0x17000721 RID: 1825
		// (get) Token: 0x06001687 RID: 5767 RVA: 0x0002D164 File Offset: 0x0002B364
		// (set) Token: 0x06001688 RID: 5768 RVA: 0x0002D190 File Offset: 0x0002B390
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public int type
		{
			get
			{
				return this._type ?? 0;
			}
			set
			{
				this._type = new int?(value);
			}
		}

		// Token: 0x17000722 RID: 1826
		// (get) Token: 0x06001689 RID: 5769 RVA: 0x0002D1A0 File Offset: 0x0002B3A0
		// (set) Token: 0x0600168A RID: 5770 RVA: 0x0002D1C0 File Offset: 0x0002B3C0
		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new int?(this.type) : null);
				}
			}
		}

		// Token: 0x0600168B RID: 5771 RVA: 0x0002D204 File Offset: 0x0002B404
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x0600168C RID: 5772 RVA: 0x0002D21C File Offset: 0x0002B41C
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x0600168D RID: 5773 RVA: 0x0002D228 File Offset: 0x0002B428
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000597 RID: 1431
		private int? _type;

		// Token: 0x04000598 RID: 1432
		private IExtension extensionObject;
	}
}
