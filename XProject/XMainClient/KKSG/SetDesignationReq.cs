using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200010D RID: 269
	[ProtoContract(Name = "SetDesignationReq")]
	[Serializable]
	public class SetDesignationReq : IExtensible
	{
		// Token: 0x1700057C RID: 1404
		// (get) Token: 0x0600110D RID: 4365 RVA: 0x00022DEC File Offset: 0x00020FEC
		// (set) Token: 0x0600110E RID: 4366 RVA: 0x00022E18 File Offset: 0x00021018
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

		// Token: 0x1700057D RID: 1405
		// (get) Token: 0x0600110F RID: 4367 RVA: 0x00022E28 File Offset: 0x00021028
		// (set) Token: 0x06001110 RID: 4368 RVA: 0x00022E48 File Offset: 0x00021048
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

		// Token: 0x06001111 RID: 4369 RVA: 0x00022E8C File Offset: 0x0002108C
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06001112 RID: 4370 RVA: 0x00022EA4 File Offset: 0x000210A4
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x1700057E RID: 1406
		// (get) Token: 0x06001113 RID: 4371 RVA: 0x00022EB0 File Offset: 0x000210B0
		// (set) Token: 0x06001114 RID: 4372 RVA: 0x00022EDC File Offset: 0x000210DC
		[ProtoMember(2, IsRequired = false, Name = "designationID", DataFormat = DataFormat.TwosComplement)]
		public uint designationID
		{
			get
			{
				return this._designationID ?? 0U;
			}
			set
			{
				this._designationID = new uint?(value);
			}
		}

		// Token: 0x1700057F RID: 1407
		// (get) Token: 0x06001115 RID: 4373 RVA: 0x00022EEC File Offset: 0x000210EC
		// (set) Token: 0x06001116 RID: 4374 RVA: 0x00022F0C File Offset: 0x0002110C
		[XmlIgnore]
		[Browsable(false)]
		public bool designationIDSpecified
		{
			get
			{
				return this._designationID != null;
			}
			set
			{
				bool flag = value == (this._designationID == null);
				if (flag)
				{
					this._designationID = (value ? new uint?(this.designationID) : null);
				}
			}
		}

		// Token: 0x06001117 RID: 4375 RVA: 0x00022F50 File Offset: 0x00021150
		private bool ShouldSerializedesignationID()
		{
			return this.designationIDSpecified;
		}

		// Token: 0x06001118 RID: 4376 RVA: 0x00022F68 File Offset: 0x00021168
		private void ResetdesignationID()
		{
			this.designationIDSpecified = false;
		}

		// Token: 0x06001119 RID: 4377 RVA: 0x00022F74 File Offset: 0x00021174
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000444 RID: 1092
		private uint? _type;

		// Token: 0x04000445 RID: 1093
		private uint? _designationID;

		// Token: 0x04000446 RID: 1094
		private IExtension extensionObject;
	}
}
