using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace DreamPoeBot.Auth.SR;

[Serializable]
[DebuggerStepThrough]
[GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
[DataContract(Name = "d0", Namespace = "http://schemas.datacontract.org/2004/07/")]
internal class d0 : r0
{
	[OptionalField]
	private byte[] DataField;

	[OptionalField]
	private string InfoField;

	[DataMember]
	public byte[] Data
	{
		get
		{
			return DataField;
		}
		set
		{
			if (DataField != value)
			{
				DataField = value;
				RaisePropertyChanged("Data");
			}
		}
	}

	[DataMember]
	public string Info
	{
		get
		{
			return InfoField;
		}
		set
		{
			if (InfoField != value)
			{
				InfoField = value;
				RaisePropertyChanged("Info");
			}
		}
	}
}
