using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000479 RID: 1145
	[ProtoContract(Name = "WeddingInviteOperatorArg")]
	[Serializable]
	public class WeddingInviteOperatorArg : IExtensible
	{
		// Token: 0x1700125A RID: 4698
		// (get) Token: 0x06003BDC RID: 15324 RVA: 0x0007260C File Offset: 0x0007080C
		// (set) Token: 0x06003BDD RID: 15325 RVA: 0x00072638 File Offset: 0x00070838
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public WeddingInviteOperType type
		{
			get
			{
				return this._type ?? WeddingInviteOperType.Wedding_Invite;
			}
			set
			{
				this._type = new WeddingInviteOperType?(value);
			}
		}

		// Token: 0x1700125B RID: 4699
		// (get) Token: 0x06003BDE RID: 15326 RVA: 0x00072648 File Offset: 0x00070848
		// (set) Token: 0x06003BDF RID: 15327 RVA: 0x00072668 File Offset: 0x00070868
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
					this._type = (value ? new WeddingInviteOperType?(this.type) : null);
				}
			}
		}

		// Token: 0x06003BE0 RID: 15328 RVA: 0x000726AC File Offset: 0x000708AC
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06003BE1 RID: 15329 RVA: 0x000726C4 File Offset: 0x000708C4
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x1700125C RID: 4700
		// (get) Token: 0x06003BE2 RID: 15330 RVA: 0x000726D0 File Offset: 0x000708D0
		// (set) Token: 0x06003BE3 RID: 15331 RVA: 0x000726FD File Offset: 0x000708FD
		[ProtoMember(2, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
		public ulong roleid
		{
			get
			{
				return this._roleid ?? 0UL;
			}
			set
			{
				this._roleid = new ulong?(value);
			}
		}

		// Token: 0x1700125D RID: 4701
		// (get) Token: 0x06003BE4 RID: 15332 RVA: 0x0007270C File Offset: 0x0007090C
		// (set) Token: 0x06003BE5 RID: 15333 RVA: 0x0007272C File Offset: 0x0007092C
		[XmlIgnore]
		[Browsable(false)]
		public bool roleidSpecified
		{
			get
			{
				return this._roleid != null;
			}
			set
			{
				bool flag = value == (this._roleid == null);
				if (flag)
				{
					this._roleid = (value ? new ulong?(this.roleid) : null);
				}
			}
		}

		// Token: 0x06003BE6 RID: 15334 RVA: 0x00072770 File Offset: 0x00070970
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06003BE7 RID: 15335 RVA: 0x00072788 File Offset: 0x00070988
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x1700125E RID: 4702
		// (get) Token: 0x06003BE8 RID: 15336 RVA: 0x00072794 File Offset: 0x00070994
		// (set) Token: 0x06003BE9 RID: 15337 RVA: 0x000727C1 File Offset: 0x000709C1
		[ProtoMember(3, IsRequired = false, Name = "weddingid", DataFormat = DataFormat.TwosComplement)]
		public ulong weddingid
		{
			get
			{
				return this._weddingid ?? 0UL;
			}
			set
			{
				this._weddingid = new ulong?(value);
			}
		}

		// Token: 0x1700125F RID: 4703
		// (get) Token: 0x06003BEA RID: 15338 RVA: 0x000727D0 File Offset: 0x000709D0
		// (set) Token: 0x06003BEB RID: 15339 RVA: 0x000727F0 File Offset: 0x000709F0
		[XmlIgnore]
		[Browsable(false)]
		public bool weddingidSpecified
		{
			get
			{
				return this._weddingid != null;
			}
			set
			{
				bool flag = value == (this._weddingid == null);
				if (flag)
				{
					this._weddingid = (value ? new ulong?(this.weddingid) : null);
				}
			}
		}

		// Token: 0x06003BEC RID: 15340 RVA: 0x00072834 File Offset: 0x00070A34
		private bool ShouldSerializeweddingid()
		{
			return this.weddingidSpecified;
		}

		// Token: 0x06003BED RID: 15341 RVA: 0x0007284C File Offset: 0x00070A4C
		private void Resetweddingid()
		{
			this.weddingidSpecified = false;
		}

		// Token: 0x06003BEE RID: 15342 RVA: 0x00072858 File Offset: 0x00070A58
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000EE3 RID: 3811
		private WeddingInviteOperType? _type;

		// Token: 0x04000EE4 RID: 3812
		private ulong? _roleid;

		// Token: 0x04000EE5 RID: 3813
		private ulong? _weddingid;

		// Token: 0x04000EE6 RID: 3814
		private IExtension extensionObject;
	}
}
