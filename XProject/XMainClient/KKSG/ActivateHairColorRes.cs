using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200042C RID: 1068
	[ProtoContract(Name = "ActivateHairColorRes")]
	[Serializable]
	public class ActivateHairColorRes : IExtensible
	{
		// Token: 0x17001160 RID: 4448
		// (get) Token: 0x06003891 RID: 14481 RVA: 0x0006C458 File Offset: 0x0006A658
		// (set) Token: 0x06003892 RID: 14482 RVA: 0x0006C484 File Offset: 0x0006A684
		[ProtoMember(1, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode result
		{
			get
			{
				return this._result ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._result = new ErrorCode?(value);
			}
		}

		// Token: 0x17001161 RID: 4449
		// (get) Token: 0x06003893 RID: 14483 RVA: 0x0006C494 File Offset: 0x0006A694
		// (set) Token: 0x06003894 RID: 14484 RVA: 0x0006C4B4 File Offset: 0x0006A6B4
		[XmlIgnore]
		[Browsable(false)]
		public bool resultSpecified
		{
			get
			{
				return this._result != null;
			}
			set
			{
				bool flag = value == (this._result == null);
				if (flag)
				{
					this._result = (value ? new ErrorCode?(this.result) : null);
				}
			}
		}

		// Token: 0x06003895 RID: 14485 RVA: 0x0006C4F8 File Offset: 0x0006A6F8
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06003896 RID: 14486 RVA: 0x0006C510 File Offset: 0x0006A710
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x17001162 RID: 4450
		// (get) Token: 0x06003897 RID: 14487 RVA: 0x0006C51C File Offset: 0x0006A71C
		// (set) Token: 0x06003898 RID: 14488 RVA: 0x0006C548 File Offset: 0x0006A748
		[ProtoMember(2, IsRequired = false, Name = "hair_id", DataFormat = DataFormat.TwosComplement)]
		public uint hair_id
		{
			get
			{
				return this._hair_id ?? 0U;
			}
			set
			{
				this._hair_id = new uint?(value);
			}
		}

		// Token: 0x17001163 RID: 4451
		// (get) Token: 0x06003899 RID: 14489 RVA: 0x0006C558 File Offset: 0x0006A758
		// (set) Token: 0x0600389A RID: 14490 RVA: 0x0006C578 File Offset: 0x0006A778
		[XmlIgnore]
		[Browsable(false)]
		public bool hair_idSpecified
		{
			get
			{
				return this._hair_id != null;
			}
			set
			{
				bool flag = value == (this._hair_id == null);
				if (flag)
				{
					this._hair_id = (value ? new uint?(this.hair_id) : null);
				}
			}
		}

		// Token: 0x0600389B RID: 14491 RVA: 0x0006C5BC File Offset: 0x0006A7BC
		private bool ShouldSerializehair_id()
		{
			return this.hair_idSpecified;
		}

		// Token: 0x0600389C RID: 14492 RVA: 0x0006C5D4 File Offset: 0x0006A7D4
		private void Resethair_id()
		{
			this.hair_idSpecified = false;
		}

		// Token: 0x17001164 RID: 4452
		// (get) Token: 0x0600389D RID: 14493 RVA: 0x0006C5E0 File Offset: 0x0006A7E0
		[ProtoMember(3, Name = "hair_colorid_list", DataFormat = DataFormat.TwosComplement)]
		public List<uint> hair_colorid_list
		{
			get
			{
				return this._hair_colorid_list;
			}
		}

		// Token: 0x0600389E RID: 14494 RVA: 0x0006C5F8 File Offset: 0x0006A7F8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000E08 RID: 3592
		private ErrorCode? _result;

		// Token: 0x04000E09 RID: 3593
		private uint? _hair_id;

		// Token: 0x04000E0A RID: 3594
		private readonly List<uint> _hair_colorid_list = new List<uint>();

		// Token: 0x04000E0B RID: 3595
		private IExtension extensionObject;
	}
}
