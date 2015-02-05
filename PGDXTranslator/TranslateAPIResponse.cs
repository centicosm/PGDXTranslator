using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace PGDXTranslator {

    [DataContract]
    class TranslateAPIResponse {
        [DataMember(Name = "data")]
        public APIData DataSets { get; set; }
    }


    [DataContract]
    public class APIData {
        [DataMember(Name = "languages")]
        public Language[] Languages { get; set; }

        [DataMember(Name = "translations")]
        public TranslationText[] TranslatedText { get; set; }
    }

    [DataContract]
    public class TranslationText {
        [DataMember(Name = "translatedText")]
        public String Text { get; set; }
    }
    
    [DataContract]
    public class Language {
        [DataMember(Name = "language")]
        public String LanguageCode { get; set; }

        [DataMember(Name = "name")]
        public String LanguageName { get; set; }

    }


}
