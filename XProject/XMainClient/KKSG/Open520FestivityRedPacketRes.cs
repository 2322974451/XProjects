using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200055A RID: 1370
	[ProtoContract(Name = "Open520FestivityRedPacketRes")]
	[Serializable]
	public class Open520FestivityRedPacketRes : IExtensible
	{
		// Token: 0x1700155E RID: 5470
		// (get) Token: 0x060045FB RID: 17915 RVA: 0x00084F2C File Offset: 0x0008312C
		// (set) Token: 0x060045FC RID: 17916 RVA: 0x00084F58 File Offset: 0x00083158
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

		// Token: 0x1700155F RID: 5471
		// (get) Token: 0x060045FD RID: 17917 RVA: 0x00084F68 File Offset: 0x00083168
		// (set) Token: 0x060045FE RID: 17918 RVA: 0x00084F88 File Offset: 0x00083188
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

		// Token: 0x060045FF RID: 17919 RVA: 0x00084FCC File Offset: 0x000831CC
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06004600 RID: 17920 RVA: 0x00084FE4 File Offset: 0x000831E4
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x17001560 RID: 5472
		// (get) Token: 0x06004601 RID: 17921 RVA: 0x00084FF0 File Offset: 0x000831F0
		// (set) Token: 0x06004602 RID: 17922 RVA: 0x0008501C File Offset: 0x0008321C
		[ProtoMember(2, IsRequired = false, Name = "stillHavePacket", DataFormat = DataFormat.Default)]
		public bool stillHavePacket
		{
			get
			{
				return this._stillHavePacket ?? false;
			}
			set
			{
				this._stillHavePacket = new bool?(value);
			}
		}

		// Token: 0x17001561 RID: 5473
		// (get) Token: 0x06004603 RID: 17923 RVA: 0x0008502C File Offset: 0x0008322C
		// (set) Token: 0x06004604 RID: 17924 RVA: 0x0008504C File Offset: 0x0008324C
		[XmlIgnore]
		[Browsable(false)]
		public bool stillHavePacketSpecified
		{
			get
			{
				return this._stillHavePacket != null;
			}
			set
			{
				bool flag = value == (this._stillHavePacket == null);
				if (flag)
				{
					this._stillHavePacket = (value ? new bool?(this.stillHavePacket) : null);
				}
			}
		}

		// Token: 0x06004605 RID: 17925 RVA: 0x00085090 File Offset: 0x00083290
		private bool ShouldSerializestillHavePacket()
		{
			return this.stillHavePacketSpecified;
		}

		// Token: 0x06004606 RID: 17926 RVA: 0x000850A8 File Offset: 0x000832A8
		private void ResetstillHavePacket()
		{
			this.stillHavePacketSpecified = false;
		}

		// Token: 0x17001562 RID: 5474
		// (get) Token: 0x06004607 RID: 17927 RVA: 0x000850B4 File Offset: 0x000832B4
		// (set) Token: 0x06004608 RID: 17928 RVA: 0x000850E0 File Offset: 0x000832E0
		[ProtoMember(3, IsRequired = false, Name = "num", DataFormat = DataFormat.TwosComplement)]
		public uint num
		{
			get
			{
				return this._num ?? 0U;
			}
			set
			{
				this._num = new uint?(value);
			}
		}

		// Token: 0x17001563 RID: 5475
		// (get) Token: 0x06004609 RID: 17929 RVA: 0x000850F0 File Offset: 0x000832F0
		// (set) Token: 0x0600460A RID: 17930 RVA: 0x00085110 File Offset: 0x00083310
		[XmlIgnore]
		[Browsable(false)]
		public bool numSpecified
		{
			get
			{
				return this._num != null;
			}
			set
			{
				bool flag = value == (this._num == null);
				if (flag)
				{
					this._num = (value ? new uint?(this.num) : null);
				}
			}
		}

		// Token: 0x0600460B RID: 17931 RVA: 0x00085154 File Offset: 0x00083354
		private bool ShouldSerializenum()
		{
			return this.numSpecified;
		}

		// Token: 0x0600460C RID: 17932 RVA: 0x0008516C File Offset: 0x0008336C
		private void Resetnum()
		{
			this.numSpecified = false;
		}

		// Token: 0x17001564 RID: 5476
		// (get) Token: 0x0600460D RID: 17933 RVA: 0x00085178 File Offset: 0x00083378
		// (set) Token: 0x0600460E RID: 17934 RVA: 0x00085199 File Offset: 0x00083399
		[ProtoMember(4, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
		public string name
		{
			get
			{
				return this._name ?? "";
			}
			set
			{
				this._name = value;
			}
		}

		// Token: 0x17001565 RID: 5477
		// (get) Token: 0x0600460F RID: 17935 RVA: 0x000851A4 File Offset: 0x000833A4
		// (set) Token: 0x06004610 RID: 17936 RVA: 0x000851C0 File Offset: 0x000833C0
		[XmlIgnore]
		[Browsable(false)]
		public bool nameSpecified
		{
			get
			{
				return this._name != null;
			}
			set
			{
				bool flag = value == (this._name == null);
				if (flag)
				{
					this._name = (value ? this.name : null);
				}
			}
		}

		// Token: 0x06004611 RID: 17937 RVA: 0x000851F0 File Offset: 0x000833F0
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x06004612 RID: 17938 RVA: 0x00085208 File Offset: 0x00083408
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x17001566 RID: 5478
		// (get) Token: 0x06004613 RID: 17939 RVA: 0x00085214 File Offset: 0x00083414
		// (set) Token: 0x06004614 RID: 17940 RVA: 0x00085235 File Offset: 0x00083435
		[ProtoMember(5, IsRequired = false, Name = "headpic", DataFormat = DataFormat.Default)]
		public string headpic
		{
			get
			{
				return this._headpic ?? "";
			}
			set
			{
				this._headpic = value;
			}
		}

		// Token: 0x17001567 RID: 5479
		// (get) Token: 0x06004615 RID: 17941 RVA: 0x00085240 File Offset: 0x00083440
		// (set) Token: 0x06004616 RID: 17942 RVA: 0x0008525C File Offset: 0x0008345C
		[XmlIgnore]
		[Browsable(false)]
		public bool headpicSpecified
		{
			get
			{
				return this._headpic != null;
			}
			set
			{
				bool flag = value == (this._headpic == null);
				if (flag)
				{
					this._headpic = (value ? this.headpic : null);
				}
			}
		}

		// Token: 0x06004617 RID: 17943 RVA: 0x0008528C File Offset: 0x0008348C
		private bool ShouldSerializeheadpic()
		{
			return this.headpicSpecified;
		}

		// Token: 0x06004618 RID: 17944 RVA: 0x000852A4 File Offset: 0x000834A4
		private void Resetheadpic()
		{
			this.headpicSpecified = false;
		}

		// Token: 0x06004619 RID: 17945 RVA: 0x000852B0 File Offset: 0x000834B0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001178 RID: 4472
		private ErrorCode? _errorcode;

		// Token: 0x04001179 RID: 4473
		private bool? _stillHavePacket;

		// Token: 0x0400117A RID: 4474
		private uint? _num;

		// Token: 0x0400117B RID: 4475
		private string _name;

		// Token: 0x0400117C RID: 4476
		private string _headpic;

		// Token: 0x0400117D RID: 4477
		private IExtension extensionObject;
	}
}
