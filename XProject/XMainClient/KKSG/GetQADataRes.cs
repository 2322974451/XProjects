using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000157 RID: 343
	[ProtoContract(Name = "GetQADataRes")]
	[Serializable]
	public class GetQADataRes : IExtensible
	{
		// Token: 0x170006AB RID: 1707
		// (get) Token: 0x060014F9 RID: 5369 RVA: 0x0002A370 File Offset: 0x00028570
		// (set) Token: 0x060014FA RID: 5370 RVA: 0x0002A39C File Offset: 0x0002859C
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

		// Token: 0x170006AC RID: 1708
		// (get) Token: 0x060014FB RID: 5371 RVA: 0x0002A3AC File Offset: 0x000285AC
		// (set) Token: 0x060014FC RID: 5372 RVA: 0x0002A3CC File Offset: 0x000285CC
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

		// Token: 0x060014FD RID: 5373 RVA: 0x0002A410 File Offset: 0x00028610
		private bool ShouldSerializeqid()
		{
			return this.qidSpecified;
		}

		// Token: 0x060014FE RID: 5374 RVA: 0x0002A428 File Offset: 0x00028628
		private void Resetqid()
		{
			this.qidSpecified = false;
		}

		// Token: 0x170006AD RID: 1709
		// (get) Token: 0x060014FF RID: 5375 RVA: 0x0002A434 File Offset: 0x00028634
		// (set) Token: 0x06001500 RID: 5376 RVA: 0x0002A460 File Offset: 0x00028660
		[ProtoMember(2, IsRequired = false, Name = "serialnum", DataFormat = DataFormat.TwosComplement)]
		public uint serialnum
		{
			get
			{
				return this._serialnum ?? 0U;
			}
			set
			{
				this._serialnum = new uint?(value);
			}
		}

		// Token: 0x170006AE RID: 1710
		// (get) Token: 0x06001501 RID: 5377 RVA: 0x0002A470 File Offset: 0x00028670
		// (set) Token: 0x06001502 RID: 5378 RVA: 0x0002A490 File Offset: 0x00028690
		[XmlIgnore]
		[Browsable(false)]
		public bool serialnumSpecified
		{
			get
			{
				return this._serialnum != null;
			}
			set
			{
				bool flag = value == (this._serialnum == null);
				if (flag)
				{
					this._serialnum = (value ? new uint?(this.serialnum) : null);
				}
			}
		}

		// Token: 0x06001503 RID: 5379 RVA: 0x0002A4D4 File Offset: 0x000286D4
		private bool ShouldSerializeserialnum()
		{
			return this.serialnumSpecified;
		}

		// Token: 0x06001504 RID: 5380 RVA: 0x0002A4EC File Offset: 0x000286EC
		private void Resetserialnum()
		{
			this.serialnumSpecified = false;
		}

		// Token: 0x170006AF RID: 1711
		// (get) Token: 0x06001505 RID: 5381 RVA: 0x0002A4F8 File Offset: 0x000286F8
		// (set) Token: 0x06001506 RID: 5382 RVA: 0x0002A524 File Offset: 0x00028724
		[ProtoMember(3, IsRequired = false, Name = "leftTime", DataFormat = DataFormat.TwosComplement)]
		public uint leftTime
		{
			get
			{
				return this._leftTime ?? 0U;
			}
			set
			{
				this._leftTime = new uint?(value);
			}
		}

		// Token: 0x170006B0 RID: 1712
		// (get) Token: 0x06001507 RID: 5383 RVA: 0x0002A534 File Offset: 0x00028734
		// (set) Token: 0x06001508 RID: 5384 RVA: 0x0002A554 File Offset: 0x00028754
		[XmlIgnore]
		[Browsable(false)]
		public bool leftTimeSpecified
		{
			get
			{
				return this._leftTime != null;
			}
			set
			{
				bool flag = value == (this._leftTime == null);
				if (flag)
				{
					this._leftTime = (value ? new uint?(this.leftTime) : null);
				}
			}
		}

		// Token: 0x06001509 RID: 5385 RVA: 0x0002A598 File Offset: 0x00028798
		private bool ShouldSerializeleftTime()
		{
			return this.leftTimeSpecified;
		}

		// Token: 0x0600150A RID: 5386 RVA: 0x0002A5B0 File Offset: 0x000287B0
		private void ResetleftTime()
		{
			this.leftTimeSpecified = false;
		}

		// Token: 0x170006B1 RID: 1713
		// (get) Token: 0x0600150B RID: 5387 RVA: 0x0002A5BC File Offset: 0x000287BC
		// (set) Token: 0x0600150C RID: 5388 RVA: 0x0002A5E8 File Offset: 0x000287E8
		[ProtoMember(4, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170006B2 RID: 1714
		// (get) Token: 0x0600150D RID: 5389 RVA: 0x0002A5F8 File Offset: 0x000287F8
		// (set) Token: 0x0600150E RID: 5390 RVA: 0x0002A618 File Offset: 0x00028818
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

		// Token: 0x0600150F RID: 5391 RVA: 0x0002A65C File Offset: 0x0002885C
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06001510 RID: 5392 RVA: 0x0002A674 File Offset: 0x00028874
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x06001511 RID: 5393 RVA: 0x0002A680 File Offset: 0x00028880
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000535 RID: 1333
		private uint? _qid;

		// Token: 0x04000536 RID: 1334
		private uint? _serialnum;

		// Token: 0x04000537 RID: 1335
		private uint? _leftTime;

		// Token: 0x04000538 RID: 1336
		private ErrorCode? _result;

		// Token: 0x04000539 RID: 1337
		private IExtension extensionObject;
	}
}
