using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Reflection;

namespace KeyboardIndicator
{
    // http://www.devnewsgroups.net/group/microsoft.public.dotnet.framework/topic59307.aspx

    internal sealed class CustomSettings
    {
        private static CustomSettings defaultInstance = new CustomSettings();

        public static CustomSettings Default
        {
            get
            {
                return defaultInstance;
            }
        }

        private Configuration m_Config;

        public CustomSettings()
        {
            Configuration config =
                ConfigurationManager.OpenExeConfiguration(
                ConfigurationUserLevel.None);
            
            System.Diagnostics.Debug.WriteLine("config: "+config.FilePath);

            m_Config = config;
        }

        public void Save()
        {
            //string sectionName = "applicationSettings/" + System.Windows.Forms.Application.ProductName + ".Properties.Settings";
            //string sectionName = "userSettings/" + System.Windows.Forms.Application.ProductName + ".Properties.Settings";
            //ClientSettingsSection section =
            //    (ClientSettingsSection) ConfigurationManager.GetSection(sectionName);
            //ClientSettingsSection section = (ClientSettingsSection)m_Config.GetSection(sectionName);
            ClientSettingsSection section =
                m_Config.GetSectionGroup("userSettings").Sections.Get(0) as ClientSettingsSection;
                //[System.Reflection.Assembly.GetExecutingAssembly().GetName() + ".Properties.Settings"] as ClientSettingsSection;
            
            foreach (SettingElement setting in section.Settings)
            {
                string value = setting.Value.ValueXml.InnerText;
                string name = setting.Name;
                // reflection
                PropertyInfo info = Properties.Settings.Default.GetType().GetProperty(name);
                object v = info.GetValue(Properties.Settings.Default, null);
                // serialize
                string ss = System.ComponentModel.TypeDescriptor.GetConverter(info.PropertyType).ConvertToString(v);
                //System.Diagnostics.Debug.WriteLine(ss);
                setting.Value.ValueXml.InnerText = ss;
            }
            section.SectionInformation.ForceSave = true;
            m_Config.Save(ConfigurationSaveMode.Full);
        }
    }
}
