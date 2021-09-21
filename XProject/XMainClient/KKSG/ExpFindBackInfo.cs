using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005E3 RID: 1507
	[ProtoContract(Name = "ExpFindBackInfo")]
	[Serializable]
	public class ExpFindBackInfo : IExtensible
	{
		// Token: 0x17001B35 RID: 6965
		// (get) Token: 0x06005793 RID: 22419 RVA: 0x000A6CC0 File Offset: 0x000A4EC0
		// (set) Token: 0x06005794 RID: 22420 RVA: 0x000A6CEC File Offset: 0x000A4EEC
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public ExpBackType type
		{
			get
			{
				return this._type ?? ExpBackType.EXPBACK_ABYSSS;
			}
			set
			{
				this._type = new ExpBackType?(value);
			}
		}

		// Token: 0x17001B36 RID: 6966
		// (get) Token: 0x06005795 RID: 22421 RVA: 0x000A6CFC File Offset: 0x000A4EFC
		// (set) Token: 0x06005796 RID: 22422 RVA: 0x000A6D1C File Offset: 0x000A4F1C
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
					this._type = (value ? new ExpBackType?(this.type) : null);
				}
			}
		}

		// Token: 0x06005797 RID: 22423 RVA: 0x000A6D60 File Offset: 0x000A4F60
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06005798 RID: 22424 RVA: 0x000A6D78 File Offset: 0x000A4F78
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x17001B37 RID: 6967
		// (get) Token: 0x06005799 RID: 22425 RVA: 0x000A6D84 File Offset: 0x000A4F84
		// (set) Token: 0x0600579A RID: 22426 RVA: 0x000A6DB0 File Offset: 0x000A4FB0
		[ProtoMember(2, IsRequired = false, Name = "usedCount", DataFormat = DataFormat.TwosComplement)]
		public int usedCount
		{
			get
			{
				return this._usedCount ?? 0;
			}
			set
			{
				this._usedCount = new int?(value);
			}
		}

		// Token: 0x17001B38 RID: 6968
		// (get) Token: 0x0600579B RID: 22427 RVA: 0x000A6DC0 File Offset: 0x000A4FC0
		// (set) Token: 0x0600579C RID: 22428 RVA: 0x000A6DE0 File Offset: 0x000A4FE0
		[XmlIgnore]
		[Browsable(false)]
		public bool usedCountSpecified
		{
			get
			{
				return this._usedCount != null;
			}
			set
			{
				bool flag = value == (this._usedCount == null);
				if (flag)
				{
					this._usedCount = (value ? new int?(this.usedCount) : null);
				}
			}
		}

		// Token: 0x0600579D RID: 22429 RVA: 0x000A6E24 File Offset: 0x000A5024
		private bool ShouldSerializeusedCount()
		{
			return this.usedCountSpecified;
		}

		// Token: 0x0600579E RID: 22430 RVA: 0x000A6E3C File Offset: 0x000A503C
		private void ResetusedCount()
		{
			this.usedCountSpecified = false;
		}

		// Token: 0x0600579F RID: 22431 RVA: 0x000A6E48 File Offset: 0x000A5048
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400153F RID: 5439
		private ExpBackType? _type;

		// Token: 0x04001540 RID: 5440
		private int? _usedCount;

		// Token: 0x04001541 RID: 5441
		private IExtension extensionObject;
	}
}
