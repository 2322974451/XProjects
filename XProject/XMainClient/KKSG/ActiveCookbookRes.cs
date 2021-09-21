using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000280 RID: 640
	[ProtoContract(Name = "ActiveCookbookRes")]
	[Serializable]
	public class ActiveCookbookRes : IExtensible
	{
		// Token: 0x17000B11 RID: 2833
		// (get) Token: 0x06002398 RID: 9112 RVA: 0x000457B8 File Offset: 0x000439B8
		// (set) Token: 0x06002399 RID: 9113 RVA: 0x000457E4 File Offset: 0x000439E4
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

		// Token: 0x17000B12 RID: 2834
		// (get) Token: 0x0600239A RID: 9114 RVA: 0x000457F4 File Offset: 0x000439F4
		// (set) Token: 0x0600239B RID: 9115 RVA: 0x00045814 File Offset: 0x00043A14
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

		// Token: 0x0600239C RID: 9116 RVA: 0x00045858 File Offset: 0x00043A58
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x0600239D RID: 9117 RVA: 0x00045870 File Offset: 0x00043A70
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x17000B13 RID: 2835
		// (get) Token: 0x0600239E RID: 9118 RVA: 0x0004587C File Offset: 0x00043A7C
		// (set) Token: 0x0600239F RID: 9119 RVA: 0x000458A8 File Offset: 0x00043AA8
		[ProtoMember(2, IsRequired = false, Name = "food_id", DataFormat = DataFormat.TwosComplement)]
		public uint food_id
		{
			get
			{
				return this._food_id ?? 0U;
			}
			set
			{
				this._food_id = new uint?(value);
			}
		}

		// Token: 0x17000B14 RID: 2836
		// (get) Token: 0x060023A0 RID: 9120 RVA: 0x000458B8 File Offset: 0x00043AB8
		// (set) Token: 0x060023A1 RID: 9121 RVA: 0x000458D8 File Offset: 0x00043AD8
		[XmlIgnore]
		[Browsable(false)]
		public bool food_idSpecified
		{
			get
			{
				return this._food_id != null;
			}
			set
			{
				bool flag = value == (this._food_id == null);
				if (flag)
				{
					this._food_id = (value ? new uint?(this.food_id) : null);
				}
			}
		}

		// Token: 0x060023A2 RID: 9122 RVA: 0x0004591C File Offset: 0x00043B1C
		private bool ShouldSerializefood_id()
		{
			return this.food_idSpecified;
		}

		// Token: 0x060023A3 RID: 9123 RVA: 0x00045934 File Offset: 0x00043B34
		private void Resetfood_id()
		{
			this.food_idSpecified = false;
		}

		// Token: 0x060023A4 RID: 9124 RVA: 0x00045940 File Offset: 0x00043B40
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040008D4 RID: 2260
		private ErrorCode? _result;

		// Token: 0x040008D5 RID: 2261
		private uint? _food_id;

		// Token: 0x040008D6 RID: 2262
		private IExtension extensionObject;
	}
}
