using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200020E RID: 526
	[ProtoContract(Name = "PlayDiceRequestRes")]
	[Serializable]
	public class PlayDiceRequestRes : IExtensible
	{
		// Token: 0x1700094D RID: 2381
		// (get) Token: 0x06001DB3 RID: 7603 RVA: 0x0003A694 File Offset: 0x00038894
		// (set) Token: 0x06001DB4 RID: 7604 RVA: 0x0003A6C0 File Offset: 0x000388C0
		[ProtoMember(1, IsRequired = false, Name = "error", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode error
		{
			get
			{
				return this._error ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._error = new ErrorCode?(value);
			}
		}

		// Token: 0x1700094E RID: 2382
		// (get) Token: 0x06001DB5 RID: 7605 RVA: 0x0003A6D0 File Offset: 0x000388D0
		// (set) Token: 0x06001DB6 RID: 7606 RVA: 0x0003A6F0 File Offset: 0x000388F0
		[XmlIgnore]
		[Browsable(false)]
		public bool errorSpecified
		{
			get
			{
				return this._error != null;
			}
			set
			{
				bool flag = value == (this._error == null);
				if (flag)
				{
					this._error = (value ? new ErrorCode?(this.error) : null);
				}
			}
		}

		// Token: 0x06001DB7 RID: 7607 RVA: 0x0003A734 File Offset: 0x00038934
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x06001DB8 RID: 7608 RVA: 0x0003A74C File Offset: 0x0003894C
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x1700094F RID: 2383
		// (get) Token: 0x06001DB9 RID: 7609 RVA: 0x0003A758 File Offset: 0x00038958
		// (set) Token: 0x06001DBA RID: 7610 RVA: 0x0003A784 File Offset: 0x00038984
		[ProtoMember(2, IsRequired = false, Name = "getValue", DataFormat = DataFormat.TwosComplement)]
		public int getValue
		{
			get
			{
				return this._getValue ?? 0;
			}
			set
			{
				this._getValue = new int?(value);
			}
		}

		// Token: 0x17000950 RID: 2384
		// (get) Token: 0x06001DBB RID: 7611 RVA: 0x0003A794 File Offset: 0x00038994
		// (set) Token: 0x06001DBC RID: 7612 RVA: 0x0003A7B4 File Offset: 0x000389B4
		[XmlIgnore]
		[Browsable(false)]
		public bool getValueSpecified
		{
			get
			{
				return this._getValue != null;
			}
			set
			{
				bool flag = value == (this._getValue == null);
				if (flag)
				{
					this._getValue = (value ? new int?(this.getValue) : null);
				}
			}
		}

		// Token: 0x06001DBD RID: 7613 RVA: 0x0003A7F8 File Offset: 0x000389F8
		private bool ShouldSerializegetValue()
		{
			return this.getValueSpecified;
		}

		// Token: 0x06001DBE RID: 7614 RVA: 0x0003A810 File Offset: 0x00038A10
		private void ResetgetValue()
		{
			this.getValueSpecified = false;
		}

		// Token: 0x17000951 RID: 2385
		// (get) Token: 0x06001DBF RID: 7615 RVA: 0x0003A81C File Offset: 0x00038A1C
		// (set) Token: 0x06001DC0 RID: 7616 RVA: 0x0003A848 File Offset: 0x00038A48
		[ProtoMember(3, IsRequired = false, Name = "leftDiceTime", DataFormat = DataFormat.TwosComplement)]
		public int leftDiceTime
		{
			get
			{
				return this._leftDiceTime ?? 0;
			}
			set
			{
				this._leftDiceTime = new int?(value);
			}
		}

		// Token: 0x17000952 RID: 2386
		// (get) Token: 0x06001DC1 RID: 7617 RVA: 0x0003A858 File Offset: 0x00038A58
		// (set) Token: 0x06001DC2 RID: 7618 RVA: 0x0003A878 File Offset: 0x00038A78
		[XmlIgnore]
		[Browsable(false)]
		public bool leftDiceTimeSpecified
		{
			get
			{
				return this._leftDiceTime != null;
			}
			set
			{
				bool flag = value == (this._leftDiceTime == null);
				if (flag)
				{
					this._leftDiceTime = (value ? new int?(this.leftDiceTime) : null);
				}
			}
		}

		// Token: 0x06001DC3 RID: 7619 RVA: 0x0003A8BC File Offset: 0x00038ABC
		private bool ShouldSerializeleftDiceTime()
		{
			return this.leftDiceTimeSpecified;
		}

		// Token: 0x06001DC4 RID: 7620 RVA: 0x0003A8D4 File Offset: 0x00038AD4
		private void ResetleftDiceTime()
		{
			this.leftDiceTimeSpecified = false;
		}

		// Token: 0x06001DC5 RID: 7621 RVA: 0x0003A8E0 File Offset: 0x00038AE0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400076C RID: 1900
		private ErrorCode? _error;

		// Token: 0x0400076D RID: 1901
		private int? _getValue;

		// Token: 0x0400076E RID: 1902
		private int? _leftDiceTime;

		// Token: 0x0400076F RID: 1903
		private IExtension extensionObject;
	}
}
