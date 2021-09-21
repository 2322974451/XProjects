using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200009C RID: 156
	[ProtoContract(Name = "StartGuildCardRes")]
	[Serializable]
	public class StartGuildCardRes : IExtensible
	{
		// Token: 0x17000381 RID: 897
		// (get) Token: 0x06000AAF RID: 2735 RVA: 0x00016FF4 File Offset: 0x000151F4
		// (set) Token: 0x06000AB0 RID: 2736 RVA: 0x00017020 File Offset: 0x00015220
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

		// Token: 0x17000382 RID: 898
		// (get) Token: 0x06000AB1 RID: 2737 RVA: 0x00017030 File Offset: 0x00015230
		// (set) Token: 0x06000AB2 RID: 2738 RVA: 0x00017050 File Offset: 0x00015250
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

		// Token: 0x06000AB3 RID: 2739 RVA: 0x00017094 File Offset: 0x00015294
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06000AB4 RID: 2740 RVA: 0x000170AC File Offset: 0x000152AC
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x17000383 RID: 899
		// (get) Token: 0x06000AB5 RID: 2741 RVA: 0x000170B8 File Offset: 0x000152B8
		[ProtoMember(2, Name = "card", DataFormat = DataFormat.TwosComplement)]
		public List<uint> card
		{
			get
			{
				return this._card;
			}
		}

		// Token: 0x17000384 RID: 900
		// (get) Token: 0x06000AB6 RID: 2742 RVA: 0x000170D0 File Offset: 0x000152D0
		// (set) Token: 0x06000AB7 RID: 2743 RVA: 0x000170FC File Offset: 0x000152FC
		[ProtoMember(3, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
		public uint result
		{
			get
			{
				return this._result ?? 0U;
			}
			set
			{
				this._result = new uint?(value);
			}
		}

		// Token: 0x17000385 RID: 901
		// (get) Token: 0x06000AB8 RID: 2744 RVA: 0x0001710C File Offset: 0x0001530C
		// (set) Token: 0x06000AB9 RID: 2745 RVA: 0x0001712C File Offset: 0x0001532C
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
					this._result = (value ? new uint?(this.result) : null);
				}
			}
		}

		// Token: 0x06000ABA RID: 2746 RVA: 0x00017170 File Offset: 0x00015370
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06000ABB RID: 2747 RVA: 0x00017188 File Offset: 0x00015388
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x17000386 RID: 902
		// (get) Token: 0x06000ABC RID: 2748 RVA: 0x00017194 File Offset: 0x00015394
		// (set) Token: 0x06000ABD RID: 2749 RVA: 0x000171C0 File Offset: 0x000153C0
		[ProtoMember(4, IsRequired = false, Name = "store", DataFormat = DataFormat.TwosComplement)]
		public uint store
		{
			get
			{
				return this._store ?? 0U;
			}
			set
			{
				this._store = new uint?(value);
			}
		}

		// Token: 0x17000387 RID: 903
		// (get) Token: 0x06000ABE RID: 2750 RVA: 0x000171D0 File Offset: 0x000153D0
		// (set) Token: 0x06000ABF RID: 2751 RVA: 0x000171F0 File Offset: 0x000153F0
		[XmlIgnore]
		[Browsable(false)]
		public bool storeSpecified
		{
			get
			{
				return this._store != null;
			}
			set
			{
				bool flag = value == (this._store == null);
				if (flag)
				{
					this._store = (value ? new uint?(this.store) : null);
				}
			}
		}

		// Token: 0x06000AC0 RID: 2752 RVA: 0x00017234 File Offset: 0x00015434
		private bool ShouldSerializestore()
		{
			return this.storeSpecified;
		}

		// Token: 0x06000AC1 RID: 2753 RVA: 0x0001724C File Offset: 0x0001544C
		private void Resetstore()
		{
			this.storeSpecified = false;
		}

		// Token: 0x06000AC2 RID: 2754 RVA: 0x00017258 File Offset: 0x00015458
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040002B2 RID: 690
		private ErrorCode? _errorcode;

		// Token: 0x040002B3 RID: 691
		private readonly List<uint> _card = new List<uint>();

		// Token: 0x040002B4 RID: 692
		private uint? _result;

		// Token: 0x040002B5 RID: 693
		private uint? _store;

		// Token: 0x040002B6 RID: 694
		private IExtension extensionObject;
	}
}
