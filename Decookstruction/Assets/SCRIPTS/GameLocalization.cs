using System;
using System.Collections.Generic;
using System.Xml;

public static class GameLocalization
{
    // ---- ---- ---- ---- ---- ---- ---- ----
    // Atributos
    // ---- ---- ---- ---- ---- ---- ---- ----
    private static SortedDictionary<string, GameLocString> stringMap;
    private static string currentLanguage = string.Empty;
    
    // ---- ---- ---- ---- ---- ---- ---- ----
    // Propiedades
    // ---- ---- ---- ---- ---- ---- ---- ----
    /// <summary>
    /// Obtiene o establece el idioma que se utilizará para la obtención de
    /// cadenas de texto cuando este no se especifica.
    /// </summary>
    public static string CurrentLanguage
    {
        get { return GameLocalization.currentLanguage; }
        set { GameLocalization.currentLanguage = value; }
    }
    
    // ---- ---- ---- ---- ---- ---- ---- ----
    // Métodos
    // ---- ---- ---- ---- ---- ---- ---- ----
    /// <summary>
    /// Carga un archivo XML que contiene cadenas de texto identificadas en
    /// diferentes idiomas.
    /// </summary>
    /// <param name="filePath">Ruta al archivo XML.</param>
    public static void LoadLocalizationXml(string filePath)
    {
        XmlDocument dataXML = new XmlDocument();
        dataXML.Load(filePath);
        
        GameLocalization.ParseData(dataXML);
    }
    
    /// <summary>
    /// Carga datos XML como una cadena de texto que contiene cadenas de texto
    /// identificadas en diferentes idiomas.
    /// </summary>
    /// <param name="filePath">Cadena de texto con datos XML.</param>
    public static void LoadLocalizationXmlFromText(string text)
    {
        XmlDocument dataXML = new XmlDocument();
        dataXML.LoadXml(text);
        
        GameLocalization.ParseData(dataXML);
    }
    
    private static void ParseData(XmlDocument dataXML)
    {
        GameLocalization.stringMap = new SortedDictionary<string, GameLocString>();
        
        XmlNodeList stringNodeList = dataXML.DocumentElement.GetElementsByTagName("string");
        foreach (XmlElement stringNode in stringNodeList)
        {
            string currentStringId = stringNode.GetAttribute("id");
            if (currentStringId == string.Empty)
                continue;
            
            GameLocString currentGameLocString = new GameLocString();
            
            XmlNodeList itemNodeList = stringNode.GetElementsByTagName("item");
            foreach (XmlElement itemNode in itemNodeList)
            {
                string itemLang = itemNode.GetAttribute("lang");
                string itemText = itemNode.InnerText;
                
                currentGameLocString.AddItem(itemLang, itemText);
            }
            
            GameLocalization.stringMap.Add(currentStringId, currentGameLocString);
        }
    }
    
    /// <summary>
    /// Obtiene la cadena de texto con el identificador especificado. Utiliza
    /// el idioma asignado en la propiedad 'CurrentLanguage'.
    /// </summary>
    /// <param name="id">Identificador de la cadena de texto a obtener.</param>
    /// <returns>
    /// La cadena de texto con el identificador especificado en el idioma
    /// asignado actualmente. Devuelve null en caso de no encontrarse.
    /// </returns>
    public static string GetString(string id)
    {
        try { return GameLocalization.stringMap[id][GameLocalization.currentLanguage]; }
        catch { return null; }
    }
    
    /// <summary>
    /// Obtiene la cadena de texto con el identificador especificado. Utiliza
    /// el idioma que se le especifica explícitamente como parámetro.
    /// </summary>
    /// <param name="id">Identificador de la cadena de texto a obtener.</param>
    /// <param name="lang">Código del idioma.</param>
    /// <returns>
    /// La cadena de texto con el identificador especificado en el idioma
    /// especificado explícitamente. Devuelve null en caso de no encontrarse.
    /// </returns>
    public static string GetString(string id, string lang)
    {
        try { return GameLocalization.stringMap[id][lang]; }
        catch { return null; }
    }
    
    // ---- ---- ---- ---- ---- ---- ---- ----
    // Subclases
    // ---- ---- ---- ---- ---- ---- ---- ----
    private class GameLocString
    {
        // ---- ---- ---- ---- ---- ---- ---- ----
        // Atributos
        // ---- ---- ---- ---- ---- ---- ---- ----
        private SortedDictionary<string, string> items;
        
        // ---- ---- ---- ---- ---- ---- ---- ----
        // Propiedades
        // ---- ---- ---- ---- ---- ---- ---- ----
        // Indizadores
        public string this[string lang]
        {
            get
            {
                try { return this.items[lang]; }
                catch { return null; }
            }
        }
        
        // ---- ---- ---- ---- ---- ---- ---- ----
        // Constructores
        // ---- ---- ---- ---- ---- ---- ---- ----
        internal GameLocString()
        {
            this.items = new SortedDictionary<string, string>();
        }
        
        internal void AddItem(string itemLang, string itemText)
        {
            this.items.Add(itemLang, itemText);
        }
    }
    
}