using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000311 RID: 785
	[ProtoContract(Name = "MentorMyBeAppliedMsgRes")]
	[Serializable]
	public class MentorMyBeAppliedMsgRes : IExtensible
	{
		// Token: 0x17000D52 RID: 3410
		// (get) Token: 0x06002AFE RID: 11006 RVA: 0x000534F8 File Offset: 0x000516F8
		// (set) Token: 0x06002AFF RID: 11007 RVA: 0x00053524 File Offset: 0x00051724
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

		// Token: 0x17000D53 RID: 3411
		// (get) Token: 0x06002B00 RID: 11008 RVA: 0x00053534 File Offset: 0x00051734
		// (set) Token: 0x06002B01 RID: 11009 RVA: 0x00053554 File Offset: 0x00051754
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

		// Token: 0x06002B02 RID: 11010 RVA: 0x00053598 File Offset: 0x00051798
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x06002B03 RID: 11011 RVA: 0x000535B0 File Offset: 0x000517B0
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x17000D54 RID: 3412
		// (get) Token: 0x06002B04 RID: 11012 RVA: 0x000535BC File Offset: 0x000517BC
		[ProtoMember(2, Name = "msgList", DataFormat = DataFormat.Default)]
		public List<OneMentorBeAppliedMsg> msgList
		{
			get
			{
				return this._msgList;
			}
		}

		// Token: 0x06002B05 RID: 11013 RVA: 0x000535D4 File Offset: 0x000517D4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000AAA RID: 2730
		private ErrorCode? _error;

		// Token: 0x04000AAB RID: 2731
		private readonly List<OneMentorBeAppliedMsg> _msgList = new List<OneMentorBeAppliedMsg>();

		// Token: 0x04000AAC RID: 2732
		private IExtension extensionObject;
	}
}
