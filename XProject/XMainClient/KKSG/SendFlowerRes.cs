using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000083 RID: 131
	[ProtoContract(Name = "SendFlowerRes")]
	[Serializable]
	public class SendFlowerRes : IExtensible
	{
		// Token: 0x170002D5 RID: 725
		// (get) Token: 0x06000899 RID: 2201 RVA: 0x00012FF8 File Offset: 0x000111F8
		// (set) Token: 0x0600089A RID: 2202 RVA: 0x00013024 File Offset: 0x00011224
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

		// Token: 0x170002D6 RID: 726
		// (get) Token: 0x0600089B RID: 2203 RVA: 0x00013034 File Offset: 0x00011234
		// (set) Token: 0x0600089C RID: 2204 RVA: 0x00013054 File Offset: 0x00011254
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

		// Token: 0x0600089D RID: 2205 RVA: 0x00013098 File Offset: 0x00011298
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x0600089E RID: 2206 RVA: 0x000130B0 File Offset: 0x000112B0
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x170002D7 RID: 727
		// (get) Token: 0x0600089F RID: 2207 RVA: 0x000130BC File Offset: 0x000112BC
		// (set) Token: 0x060008A0 RID: 2208 RVA: 0x000130E8 File Offset: 0x000112E8
		[ProtoMember(2, IsRequired = false, Name = "fatigue", DataFormat = DataFormat.TwosComplement)]
		public uint fatigue
		{
			get
			{
				return this._fatigue ?? 0U;
			}
			set
			{
				this._fatigue = new uint?(value);
			}
		}

		// Token: 0x170002D8 RID: 728
		// (get) Token: 0x060008A1 RID: 2209 RVA: 0x000130F8 File Offset: 0x000112F8
		// (set) Token: 0x060008A2 RID: 2210 RVA: 0x00013118 File Offset: 0x00011318
		[XmlIgnore]
		[Browsable(false)]
		public bool fatigueSpecified
		{
			get
			{
				return this._fatigue != null;
			}
			set
			{
				bool flag = value == (this._fatigue == null);
				if (flag)
				{
					this._fatigue = (value ? new uint?(this.fatigue) : null);
				}
			}
		}

		// Token: 0x060008A3 RID: 2211 RVA: 0x0001315C File Offset: 0x0001135C
		private bool ShouldSerializefatigue()
		{
			return this.fatigueSpecified;
		}

		// Token: 0x060008A4 RID: 2212 RVA: 0x00013174 File Offset: 0x00011374
		private void Resetfatigue()
		{
			this.fatigueSpecified = false;
		}

		// Token: 0x060008A5 RID: 2213 RVA: 0x00013180 File Offset: 0x00011380
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400023B RID: 571
		private ErrorCode? _errorcode;

		// Token: 0x0400023C RID: 572
		private uint? _fatigue;

		// Token: 0x0400023D RID: 573
		private IExtension extensionObject;
	}
}
