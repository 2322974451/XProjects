using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200052C RID: 1324
	[ProtoContract(Name = "CampDuelActivityOperationArg")]
	[Serializable]
	public class CampDuelActivityOperationArg : IExtensible
	{
		// Token: 0x170014CC RID: 5324
		// (get) Token: 0x06004408 RID: 17416 RVA: 0x000816C0 File Offset: 0x0007F8C0
		// (set) Token: 0x06004409 RID: 17417 RVA: 0x000816EC File Offset: 0x0007F8EC
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public uint type
		{
			get
			{
				return this._type ?? 0U;
			}
			set
			{
				this._type = new uint?(value);
			}
		}

		// Token: 0x170014CD RID: 5325
		// (get) Token: 0x0600440A RID: 17418 RVA: 0x000816FC File Offset: 0x0007F8FC
		// (set) Token: 0x0600440B RID: 17419 RVA: 0x0008171C File Offset: 0x0007F91C
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
					this._type = (value ? new uint?(this.type) : null);
				}
			}
		}

		// Token: 0x0600440C RID: 17420 RVA: 0x00081760 File Offset: 0x0007F960
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x0600440D RID: 17421 RVA: 0x00081778 File Offset: 0x0007F978
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x170014CE RID: 5326
		// (get) Token: 0x0600440E RID: 17422 RVA: 0x00081784 File Offset: 0x0007F984
		// (set) Token: 0x0600440F RID: 17423 RVA: 0x000817B0 File Offset: 0x0007F9B0
		[ProtoMember(2, IsRequired = false, Name = "arg", DataFormat = DataFormat.TwosComplement)]
		public uint arg
		{
			get
			{
				return this._arg ?? 0U;
			}
			set
			{
				this._arg = new uint?(value);
			}
		}

		// Token: 0x170014CF RID: 5327
		// (get) Token: 0x06004410 RID: 17424 RVA: 0x000817C0 File Offset: 0x0007F9C0
		// (set) Token: 0x06004411 RID: 17425 RVA: 0x000817E0 File Offset: 0x0007F9E0
		[XmlIgnore]
		[Browsable(false)]
		public bool argSpecified
		{
			get
			{
				return this._arg != null;
			}
			set
			{
				bool flag = value == (this._arg == null);
				if (flag)
				{
					this._arg = (value ? new uint?(this.arg) : null);
				}
			}
		}

		// Token: 0x06004412 RID: 17426 RVA: 0x00081824 File Offset: 0x0007FA24
		private bool ShouldSerializearg()
		{
			return this.argSpecified;
		}

		// Token: 0x06004413 RID: 17427 RVA: 0x0008183C File Offset: 0x0007FA3C
		private void Resetarg()
		{
			this.argSpecified = false;
		}

		// Token: 0x06004414 RID: 17428 RVA: 0x00081848 File Offset: 0x0007FA48
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040010F8 RID: 4344
		private uint? _type;

		// Token: 0x040010F9 RID: 4345
		private uint? _arg;

		// Token: 0x040010FA RID: 4346
		private IExtension extensionObject;
	}
}
