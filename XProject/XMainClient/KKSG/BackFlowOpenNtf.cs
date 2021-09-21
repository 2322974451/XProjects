using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004A2 RID: 1186
	[ProtoContract(Name = "BackFlowOpenNtf")]
	[Serializable]
	public class BackFlowOpenNtf : IExtensible
	{
		// Token: 0x170012E8 RID: 4840
		// (get) Token: 0x06003DB2 RID: 15794 RVA: 0x00075BC0 File Offset: 0x00073DC0
		// (set) Token: 0x06003DB3 RID: 15795 RVA: 0x00075BEC File Offset: 0x00073DEC
		[ProtoMember(1, IsRequired = false, Name = "isopen", DataFormat = DataFormat.Default)]
		public bool isopen
		{
			get
			{
				return this._isopen ?? false;
			}
			set
			{
				this._isopen = new bool?(value);
			}
		}

		// Token: 0x170012E9 RID: 4841
		// (get) Token: 0x06003DB4 RID: 15796 RVA: 0x00075BFC File Offset: 0x00073DFC
		// (set) Token: 0x06003DB5 RID: 15797 RVA: 0x00075C1C File Offset: 0x00073E1C
		[XmlIgnore]
		[Browsable(false)]
		public bool isopenSpecified
		{
			get
			{
				return this._isopen != null;
			}
			set
			{
				bool flag = value == (this._isopen == null);
				if (flag)
				{
					this._isopen = (value ? new bool?(this.isopen) : null);
				}
			}
		}

		// Token: 0x06003DB6 RID: 15798 RVA: 0x00075C60 File Offset: 0x00073E60
		private bool ShouldSerializeisopen()
		{
			return this.isopenSpecified;
		}

		// Token: 0x06003DB7 RID: 15799 RVA: 0x00075C78 File Offset: 0x00073E78
		private void Resetisopen()
		{
			this.isopenSpecified = false;
		}

		// Token: 0x06003DB8 RID: 15800 RVA: 0x00075C84 File Offset: 0x00073E84
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000F5F RID: 3935
		private bool? _isopen;

		// Token: 0x04000F60 RID: 3936
		private IExtension extensionObject;
	}
}
