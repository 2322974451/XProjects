using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GMCmdArg")]
	[Serializable]
	public class GMCmdArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "cmd", DataFormat = DataFormat.Default)]
		public string cmd
		{
			get
			{
				return this._cmd ?? "";
			}
			set
			{
				this._cmd = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool cmdSpecified
		{
			get
			{
				return this._cmd != null;
			}
			set
			{
				bool flag = value == (this._cmd == null);
				if (flag)
				{
					this._cmd = (value ? this.cmd : null);
				}
			}
		}

		private bool ShouldSerializecmd()
		{
			return this.cmdSpecified;
		}

		private void Resetcmd()
		{
			this.cmdSpecified = false;
		}

		[ProtoMember(2, Name = "args", DataFormat = DataFormat.Default)]
		public List<string> args
		{
			get
			{
				return this._args;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private string _cmd;

		private readonly List<string> _args = new List<string>();

		private IExtension extensionObject;
	}
}
