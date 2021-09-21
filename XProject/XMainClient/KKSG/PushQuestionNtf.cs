using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200013B RID: 315
	[ProtoContract(Name = "PushQuestionNtf")]
	[Serializable]
	public class PushQuestionNtf : IExtensible
	{
		// Token: 0x1700061E RID: 1566
		// (get) Token: 0x06001337 RID: 4919 RVA: 0x00026DE8 File Offset: 0x00024FE8
		// (set) Token: 0x06001338 RID: 4920 RVA: 0x00026E14 File Offset: 0x00025014
		[ProtoMember(1, IsRequired = false, Name = "qid", DataFormat = DataFormat.TwosComplement)]
		public uint qid
		{
			get
			{
				return this._qid ?? 0U;
			}
			set
			{
				this._qid = new uint?(value);
			}
		}

		// Token: 0x1700061F RID: 1567
		// (get) Token: 0x06001339 RID: 4921 RVA: 0x00026E24 File Offset: 0x00025024
		// (set) Token: 0x0600133A RID: 4922 RVA: 0x00026E44 File Offset: 0x00025044
		[XmlIgnore]
		[Browsable(false)]
		public bool qidSpecified
		{
			get
			{
				return this._qid != null;
			}
			set
			{
				bool flag = value == (this._qid == null);
				if (flag)
				{
					this._qid = (value ? new uint?(this.qid) : null);
				}
			}
		}

		// Token: 0x0600133B RID: 4923 RVA: 0x00026E88 File Offset: 0x00025088
		private bool ShouldSerializeqid()
		{
			return this.qidSpecified;
		}

		// Token: 0x0600133C RID: 4924 RVA: 0x00026EA0 File Offset: 0x000250A0
		private void Resetqid()
		{
			this.qidSpecified = false;
		}

		// Token: 0x17000620 RID: 1568
		// (get) Token: 0x0600133D RID: 4925 RVA: 0x00026EAC File Offset: 0x000250AC
		// (set) Token: 0x0600133E RID: 4926 RVA: 0x00026ED8 File Offset: 0x000250D8
		[ProtoMember(2, IsRequired = false, Name = "serialNum", DataFormat = DataFormat.TwosComplement)]
		public uint serialNum
		{
			get
			{
				return this._serialNum ?? 0U;
			}
			set
			{
				this._serialNum = new uint?(value);
			}
		}

		// Token: 0x17000621 RID: 1569
		// (get) Token: 0x0600133F RID: 4927 RVA: 0x00026EE8 File Offset: 0x000250E8
		// (set) Token: 0x06001340 RID: 4928 RVA: 0x00026F08 File Offset: 0x00025108
		[XmlIgnore]
		[Browsable(false)]
		public bool serialNumSpecified
		{
			get
			{
				return this._serialNum != null;
			}
			set
			{
				bool flag = value == (this._serialNum == null);
				if (flag)
				{
					this._serialNum = (value ? new uint?(this.serialNum) : null);
				}
			}
		}

		// Token: 0x06001341 RID: 4929 RVA: 0x00026F4C File Offset: 0x0002514C
		private bool ShouldSerializeserialNum()
		{
			return this.serialNumSpecified;
		}

		// Token: 0x06001342 RID: 4930 RVA: 0x00026F64 File Offset: 0x00025164
		private void ResetserialNum()
		{
			this.serialNumSpecified = false;
		}

		// Token: 0x06001343 RID: 4931 RVA: 0x00026F70 File Offset: 0x00025170
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040004CB RID: 1227
		private uint? _qid;

		// Token: 0x040004CC RID: 1228
		private uint? _serialNum;

		// Token: 0x040004CD RID: 1229
		private IExtension extensionObject;
	}
}
