using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;

namespace XUtliPoolLib
{

	public class XSkillScriptGen : XSingleton<XSkillScriptGen>
	{

		public XSkillScriptGen()
		{
			this._template = this.LoadTemplate();
		}

		public bool ScriptGen(string skill, string scriptname)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			dictionary.Add("class_name", skill);
			dictionary.Add("method_name", scriptname);
			string text = this.TemplateFormat(this._template, dictionary);
			bool flag = text != null && text != "";
			if (flag)
			{
				string path = string.Concat(new string[]
				{
					this.ScriptPath,
					skill,
					"_",
					scriptname,
					".cs"
				});
				using (FileStream fileStream = new FileStream(path, FileMode.Create))
				{
					StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.UTF8);
					streamWriter.Write(text);
					streamWriter.Close();
				}
				this.AddToProject(skill + "_" + scriptname + ".cs");
			}
			return text != null && text.Length > 0;
		}

		public bool ScriptDel(string skill, string scriptname)
		{
			return this.DelFromProject(skill + "_" + scriptname + ".cs");
		}

		private void AddToProject(string addname)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(this.ProjectFile);
			XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(xmlDocument.NameTable);
			xmlNamespaceManager.AddNamespace("ms", this.NameSpace);
			XmlNode documentElement = xmlDocument.DocumentElement;
			XmlNode xmlNode = documentElement.SelectSingleNode("ms:ItemGroup/ms:Compile", xmlNamespaceManager);
			XmlElement xmlElement = xmlDocument.CreateElement("Compile", this.NameSpace);
			xmlElement.SetAttribute("Include", "Script\\XSkillGen\\XScriptCode\\" + addname);
			xmlNode.ParentNode.AppendChild(xmlElement);
			xmlDocument.Save(this.ProjectFile);
		}

		private bool DelFromProject(string name)
		{
			string str = "Script\\XSkillGen\\XScriptCode\\" + name;
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(this.ProjectFile);
			XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(xmlDocument.NameTable);
			xmlNamespaceManager.AddNamespace("ms", this.NameSpace);
			XmlNode documentElement = xmlDocument.DocumentElement;
			XmlNode xmlNode = documentElement.SelectSingleNode("ms:ItemGroup/ms:Compile[@Include='" + str + "']", xmlNamespaceManager);
			bool flag = xmlNode != null;
			if (flag)
			{
				xmlNode.ParentNode.RemoveChild(xmlNode);
			}
			File.Delete(this.ScriptPath + name);
			xmlDocument.Save(this.ProjectFile);
			return xmlNode != null;
		}

		private string LoadTemplate()
		{
			Assembly assembly = Assembly.Load("XMainClient");
			Stream manifestResourceStream = assembly.GetManifestResourceStream("XMainClient.Script.XSkillGen.SkillGenTemplate.txt");
			byte[] array = new byte[5120];
			int count = (int)manifestResourceStream.Length;
			manifestResourceStream.Read(array, 0, count);
			manifestResourceStream.Close();
			UTF8Encoding utf8Encoding = new UTF8Encoding();
			return utf8Encoding.GetString(array, 0, count);
		}

		private string TemplateFormat(string template, Dictionary<string, string> dicts)
		{
			StringBuilder stringBuilder = new StringBuilder();
			int num = 0;
			int num2;
			for (;;)
			{
				num2 = template.IndexOf("%(", num);
				bool flag = num2 != -1;
				if (!flag)
				{
					goto IL_AE;
				}
				stringBuilder.Append(template.Substring(num, num2 - num));
				num = template.IndexOf(")s", num2);
				bool flag2 = num != -1;
				if (!flag2)
				{
					goto IL_9A;
				}
				string key = template.Substring(num2 + 2, num - num2 - 2);
				bool flag3 = dicts.ContainsKey(key);
				if (!flag3)
				{
					break;
				}
				stringBuilder.Append(dicts[key]);
				num += 2;
			}
			return "";
			IL_9A:
			stringBuilder.Append(template.Substring(num2));
			goto IL_C8;
			IL_AE:
			stringBuilder.Append(template.Substring(num));
			IL_C8:
			return stringBuilder.ToString();
		}

		public override bool Init()
		{
			return true;
		}

		public override void Uninit()
		{
		}

		private string _template;

		public readonly string ScriptPath = "..\\..\\src\\client\\XMainClient\\XMainClient\\Script\\XSkillGen\\XScriptCode\\";

		private readonly string ProjectFile = "..\\..\\src\\client\\XMainClient\\XMainClient\\XMainClient.csproj";

		private readonly string NameSpace = "http://schemas.microsoft.com/developer/msbuild/2003";
	}
}
