using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004A4 RID: 1188
	[ProtoContract(Name = "TransformOpRes")]
	[Serializable]
	public class TransformOpRes : IExtensible
	{
		// Token: 0x170012F0 RID: 4848
		// (get) Token: 0x06003DCE RID: 15822 RVA: 0x00075EE8 File Offset: 0x000740E8
		// (set) Token: 0x06003DCF RID: 15823 RVA: 0x00075F14 File Offset: 0x00074114
		[ProtoMember(1, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorcode
		{
			get
			{
				return this._errorcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorcode = new ErrorCode?(value);
			}
		}

		// Token: 0x170012F1 RID: 4849
		// (get) Token: 0x06003DD0 RID: 15824 RVA: 0x00075F24 File Offset: 0x00074124
		// (set) Token: 0x06003DD1 RID: 15825 RVA: 0x00075F44 File Offset: 0x00074144
		[XmlIgnore]
		[Browsable(false)]
		public bool errorcodeSpecified
		{
			get
			{
				return this._errorcode != null;
			}
			set
			{
				bool flag = value == (this._errorcode == null);
				if (flag)
				{
					this._errorcode = (value ? new ErrorCode?(this.errorcode) : null);
				}
			}
		}

		// Token: 0x06003DD2 RID: 15826 RVA: 0x00075F88 File Offset: 0x00074188
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06003DD3 RID: 15827 RVA: 0x00075FA0 File Offset: 0x000741A0
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x170012F2 RID: 4850
		// (get) Token: 0x06003DD4 RID: 15828 RVA: 0x00075FAC File Offset: 0x000741AC
		// (set) Token: 0x06003DD5 RID: 15829 RVA: 0x00075FD8 File Offset: 0x000741D8
		[ProtoMember(2, IsRequired = false, Name = "timeleft", DataFormat = DataFormat.TwosComplement)]
		public uint timeleft
		{
			get
			{
				return this._timeleft ?? 0U;
			}
			set
			{
				this._timeleft = new uint?(value);
			}
		}

		// Token: 0x170012F3 RID: 4851
		// (get) Token: 0x06003DD6 RID: 15830 RVA: 0x00075FE8 File Offset: 0x000741E8
		// (set) Token: 0x06003DD7 RID: 15831 RVA: 0x00076008 File Offset: 0x00074208
		[XmlIgnore]
		[Browsable(false)]
		public bool timeleftSpecified
		{
			get
			{
				return this._timeleft != null;
			}
			set
			{
				bool flag = value == (this._timeleft == null);
				if (flag)
				{
					this._timeleft = (value ? new uint?(this.timeleft) : null);
				}
			}
		}

		// Token: 0x06003DD8 RID: 15832 RVA: 0x0007604C File Offset: 0x0007424C
		private bool ShouldSerializetimeleft()
		{
			return this.timeleftSpecified;
		}

		// Token: 0x06003DD9 RID: 15833 RVA: 0x00076064 File Offset: 0x00074264
		private void Resettimeleft()
		{
			this.timeleftSpecified = false;
		}

		// Token: 0x06003DDA RID: 15834 RVA: 0x00076070 File Offset: 0x00074270
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000F65 RID: 3941
		private ErrorCode? _errorcode;

		// Token: 0x04000F66 RID: 3942
		private uint? _timeleft;

		// Token: 0x04000F67 RID: 3943
		private IExtension extensionObject;
	}
}
