using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200056C RID: 1388
	[ProtoContract(Name = "EffectMultiParams")]
	[Serializable]
	public class EffectMultiParams : IExtensible
	{
		// Token: 0x170015DE RID: 5598
		// (get) Token: 0x0600476B RID: 18283 RVA: 0x00087B44 File Offset: 0x00085D44
		// (set) Token: 0x0600476C RID: 18284 RVA: 0x00087B70 File Offset: 0x00085D70
		[ProtoMember(1, IsRequired = false, Name = "IDType", DataFormat = DataFormat.TwosComplement)]
		public uint IDType
		{
			get
			{
				return this._IDType ?? 0U;
			}
			set
			{
				this._IDType = new uint?(value);
			}
		}

		// Token: 0x170015DF RID: 5599
		// (get) Token: 0x0600476D RID: 18285 RVA: 0x00087B80 File Offset: 0x00085D80
		// (set) Token: 0x0600476E RID: 18286 RVA: 0x00087BA0 File Offset: 0x00085DA0
		[XmlIgnore]
		[Browsable(false)]
		public bool IDTypeSpecified
		{
			get
			{
				return this._IDType != null;
			}
			set
			{
				bool flag = value == (this._IDType == null);
				if (flag)
				{
					this._IDType = (value ? new uint?(this.IDType) : null);
				}
			}
		}

		// Token: 0x0600476F RID: 18287 RVA: 0x00087BE4 File Offset: 0x00085DE4
		private bool ShouldSerializeIDType()
		{
			return this.IDTypeSpecified;
		}

		// Token: 0x06004770 RID: 18288 RVA: 0x00087BFC File Offset: 0x00085DFC
		private void ResetIDType()
		{
			this.IDTypeSpecified = false;
		}

		// Token: 0x170015E0 RID: 5600
		// (get) Token: 0x06004771 RID: 18289 RVA: 0x00087C08 File Offset: 0x00085E08
		// (set) Token: 0x06004772 RID: 18290 RVA: 0x00087C34 File Offset: 0x00085E34
		[ProtoMember(2, IsRequired = false, Name = "ID", DataFormat = DataFormat.TwosComplement)]
		public uint ID
		{
			get
			{
				return this._ID ?? 0U;
			}
			set
			{
				this._ID = new uint?(value);
			}
		}

		// Token: 0x170015E1 RID: 5601
		// (get) Token: 0x06004773 RID: 18291 RVA: 0x00087C44 File Offset: 0x00085E44
		// (set) Token: 0x06004774 RID: 18292 RVA: 0x00087C64 File Offset: 0x00085E64
		[XmlIgnore]
		[Browsable(false)]
		public bool IDSpecified
		{
			get
			{
				return this._ID != null;
			}
			set
			{
				bool flag = value == (this._ID == null);
				if (flag)
				{
					this._ID = (value ? new uint?(this.ID) : null);
				}
			}
		}

		// Token: 0x06004775 RID: 18293 RVA: 0x00087CA8 File Offset: 0x00085EA8
		private bool ShouldSerializeID()
		{
			return this.IDSpecified;
		}

		// Token: 0x06004776 RID: 18294 RVA: 0x00087CC0 File Offset: 0x00085EC0
		private void ResetID()
		{
			this.IDSpecified = false;
		}

		// Token: 0x170015E2 RID: 5602
		// (get) Token: 0x06004777 RID: 18295 RVA: 0x00087CCC File Offset: 0x00085ECC
		[ProtoMember(3, Name = "effectParams", DataFormat = DataFormat.TwosComplement)]
		public List<int> effectParams
		{
			get
			{
				return this._effectParams;
			}
		}

		// Token: 0x06004778 RID: 18296 RVA: 0x00087CE4 File Offset: 0x00085EE4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040011D9 RID: 4569
		private uint? _IDType;

		// Token: 0x040011DA RID: 4570
		private uint? _ID;

		// Token: 0x040011DB RID: 4571
		private readonly List<int> _effectParams = new List<int>();

		// Token: 0x040011DC RID: 4572
		private IExtension extensionObject;
	}
}
