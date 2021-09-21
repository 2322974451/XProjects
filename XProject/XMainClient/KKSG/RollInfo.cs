using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005C3 RID: 1475
	[ProtoContract(Name = "RollInfo")]
	[Serializable]
	public class RollInfo : IExtensible
	{
		// Token: 0x1700199E RID: 6558
		// (get) Token: 0x060052CA RID: 21194 RVA: 0x0009D7AC File Offset: 0x0009B9AC
		// (set) Token: 0x060052CB RID: 21195 RVA: 0x0009D7D9 File Offset: 0x0009B9D9
		[ProtoMember(1, IsRequired = false, Name = "roleID", DataFormat = DataFormat.TwosComplement)]
		public ulong roleID
		{
			get
			{
				return this._roleID ?? 0UL;
			}
			set
			{
				this._roleID = new ulong?(value);
			}
		}

		// Token: 0x1700199F RID: 6559
		// (get) Token: 0x060052CC RID: 21196 RVA: 0x0009D7E8 File Offset: 0x0009B9E8
		// (set) Token: 0x060052CD RID: 21197 RVA: 0x0009D808 File Offset: 0x0009BA08
		[XmlIgnore]
		[Browsable(false)]
		public bool roleIDSpecified
		{
			get
			{
				return this._roleID != null;
			}
			set
			{
				bool flag = value == (this._roleID == null);
				if (flag)
				{
					this._roleID = (value ? new ulong?(this.roleID) : null);
				}
			}
		}

		// Token: 0x060052CE RID: 21198 RVA: 0x0009D84C File Offset: 0x0009BA4C
		private bool ShouldSerializeroleID()
		{
			return this.roleIDSpecified;
		}

		// Token: 0x060052CF RID: 21199 RVA: 0x0009D864 File Offset: 0x0009BA64
		private void ResetroleID()
		{
			this.roleIDSpecified = false;
		}

		// Token: 0x170019A0 RID: 6560
		// (get) Token: 0x060052D0 RID: 21200 RVA: 0x0009D870 File Offset: 0x0009BA70
		// (set) Token: 0x060052D1 RID: 21201 RVA: 0x0009D89C File Offset: 0x0009BA9C
		[ProtoMember(2, IsRequired = false, Name = "rollValue", DataFormat = DataFormat.TwosComplement)]
		public uint rollValue
		{
			get
			{
				return this._rollValue ?? 0U;
			}
			set
			{
				this._rollValue = new uint?(value);
			}
		}

		// Token: 0x170019A1 RID: 6561
		// (get) Token: 0x060052D2 RID: 21202 RVA: 0x0009D8AC File Offset: 0x0009BAAC
		// (set) Token: 0x060052D3 RID: 21203 RVA: 0x0009D8CC File Offset: 0x0009BACC
		[XmlIgnore]
		[Browsable(false)]
		public bool rollValueSpecified
		{
			get
			{
				return this._rollValue != null;
			}
			set
			{
				bool flag = value == (this._rollValue == null);
				if (flag)
				{
					this._rollValue = (value ? new uint?(this.rollValue) : null);
				}
			}
		}

		// Token: 0x060052D4 RID: 21204 RVA: 0x0009D910 File Offset: 0x0009BB10
		private bool ShouldSerializerollValue()
		{
			return this.rollValueSpecified;
		}

		// Token: 0x060052D5 RID: 21205 RVA: 0x0009D928 File Offset: 0x0009BB28
		private void ResetrollValue()
		{
			this.rollValueSpecified = false;
		}

		// Token: 0x060052D6 RID: 21206 RVA: 0x0009D934 File Offset: 0x0009BB34
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400143F RID: 5183
		private ulong? _roleID;

		// Token: 0x04001440 RID: 5184
		private uint? _rollValue;

		// Token: 0x04001441 RID: 5185
		private IExtension extensionObject;
	}
}
